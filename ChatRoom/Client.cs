using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace ChatRoom;

class Client
{
    const int PORT = 4000;

    static List<Packet> packets = [];

    public static void StartClient(string ipAddress = "127.0.0.1")
    {
        Console.WriteLine("Enter Your Name");
        string input = Console.ReadLine() ?? "Harald";

        string username = input;


        TcpClient client = new TcpClient(ipAddress, PORT);
        NetworkStream stream = client.GetStream();
        Console.WriteLine("Uppkoppling lyckad");

        Task messageListner = new Task(() => ListenForMessage(stream));
        messageListner.Start();

        while (true)
        {
            string message = Console.ReadLine() ?? "";

            Packet packet = new Packet(message, username, DateTime.Now);
            string json = JsonSerializer.Serialize(packet);
            byte[] data = Encoding.UTF8.GetBytes(json);

            stream.Write(data, 0, data.Length);
            packets.Add(packet);
            UpdateTerminal();
        }
    }

    private static void ListenForMessage(NetworkStream stream)
    {
        byte[] buffer = new byte[1024];

        while (true)
        {
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string json = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            if (json.TrimStart().StartsWith('['))
            {
                List<Packet> temp = JsonSerializer.Deserialize<List<Packet>>(json) ?? [];
                packets.AddRange(temp);
                
            } else
            {
                Packet? packet = JsonSerializer.Deserialize<Packet>(json);

                if (packet is null)
                {
                    continue;
                }
                packets.Add(packet);
            }
            
            UpdateTerminal();
        }
    }

    private static void UpdateTerminal()
    {
        Console.Clear();
    
        for (int i = 0; i < packets.Count; i++)
        {
            Console.WriteLine(packets[i].ToString());
        }

        Console.Write("Skriv ett meddelande: ");
    }
}