using System.Net.Sockets;
using System.Text;

namespace ChatRoom;

class Client
{
    const int PORT = 4000;

    static List<string> messages = [];

    public static void StartClient(string ipAddress = "127.0.0.1")
    {
        TcpClient client = new TcpClient(ipAddress, PORT);
        NetworkStream stream = client.GetStream();
        Console.WriteLine("Uppkoppling lyckad");

        Task messageListner = new Task(() => ListenForMessage(stream));
        messageListner.Start();

        while (true)
        {
            string message = Console.ReadLine() ?? "";
            byte[] data = Encoding.UTF8.GetBytes(message);

            stream.Write(data, 0, data.Length);
            messages.Add(message);

        }
    }

    private static void ListenForMessage(NetworkStream stream)
    {
        byte[] buffer = new byte[1024];

        while (true)
        {
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            messages.Add(message);
            UpdateTerminal();
        }
    }

    private static void UpdateTerminal()
    {
        Console.Clear();
    
        for (int i = 0; i < messages.Count; i++)
        {
            Console.WriteLine(messages[i]);
        }

        Console.Write("Skriv ett meddelande: ");
    }
}