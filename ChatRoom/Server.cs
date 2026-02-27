using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace ChatRoom;

class Server
{
    const int PORT = 4000;

    static List<NetworkStream> streams = [];
    static object _lock = new object();

    static List<Packet> messages = [];

    public static void StartServer()
    {
        TcpListener server = new TcpListener(IPAddress.Any, PORT);
        server.Start();
        Console.WriteLine("Servern Igång, Väntar på uppkoppling...");

        ReadFileToConversation();

        Task connectionListener = new Task(() => ListenForConnections(server));
        connectionListener.Start();

        Task messageListner = new Task(() => ListenForMessages());
        messageListner.Start();

        while (true)
        {
            string input = Console.ReadLine() ?? "";

            if (input == "q" || input == "quit")
            {
                Console.WriteLine("Exiting...");
                WriteConversationToFile();
                Environment.Exit(0);
            }
        }
    }

    private static void BroadcastMessage(Packet packet, NetworkStream sender)
    {
        lock (_lock)
        {
            foreach (NetworkStream stream in streams)
            {
                if (stream == sender) { continue; }

                string json = JsonSerializer.Serialize(packet);
                byte[] data = Encoding.UTF8.GetBytes(json);
                stream.Write(data, 0, data.Length);
            }
        }
    }

    private static void ListenForMessages()
    {
        byte[] buffer = new byte[1024];

        while (true)
        {
            lock (_lock)
            {
                foreach (NetworkStream stream in streams)
                {
                    // om det inte finns ett inkomande meddelande, skippa streamen
                    if (!stream.DataAvailable) continue;

                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string json = Encoding.UTF8.GetString(buffer, 0, bytesRead);


                    Packet? packet = JsonSerializer.Deserialize<Packet>(json);

                    if (packet is null) { continue; }

                    Console.WriteLine($"Tog emot meddelandet: {packet.Message}");
                    messages.Add(packet);
                    BroadcastMessage(packet, stream);
                }
            }
        }
    }

    private static void WriteConversationToFile()
    {
        string json = JsonSerializer.Serialize(messages, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText("history.json", json);
    }

    private static void ReadFileToConversation()
    {
        string json = File.ReadAllText("history.json");
        messages = JsonSerializer.Deserialize<List<Packet>>(json) ?? [];
    }

    private static void ListenForConnections(TcpListener server)
    {
        while (true)
        {
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Klient Ansluten!");

            NetworkStream stream = client.GetStream();
            lock (_lock)
            {
                streams.Add(stream);
            }

            Thread.Sleep(500);

            SendHistory(stream);
        }
    }

    private static void SendHistory(NetworkStream stream)
    {
        string json = JsonSerializer.Serialize(messages);
        byte[] data = Encoding.UTF8.GetBytes(json);
        stream.Write(data, 0, data.Length);
    }
}