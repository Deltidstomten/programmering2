using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ChatRoom;

class Server
{
    const int PORT = 4000;

    static List<NetworkStream> streams = [];
    static object _lock = new object();

    public static void StartServer()
    {
        TcpListener server = new TcpListener(IPAddress.Any, PORT);
        server.Start();
        Console.WriteLine("Servern Igång, Väntar på uppkoppling...");

        Task connectionListener = new Task(() => ListenForConnections(server));
        connectionListener.Start();

        while (true)
        {
            ListenForMessages();
        }
    }

    private static void BroadcastMessage(string message, NetworkStream sender)
    {
        lock (_lock)
        {
            foreach (NetworkStream stream in streams)
            {
                if (stream == sender) { continue; }

                byte[] data = Encoding.UTF8.GetBytes(message);
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
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    Console.WriteLine($"Tog emot meddelandet: {message}");
                    BroadcastMessage(message, stream);
                }
            }
        }
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
        }
    }
}