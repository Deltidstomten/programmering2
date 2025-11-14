using System.Net.Sockets;
using System.Text;

namespace ChatRoom;

class Client
{
    const int PORT = 4000;

    public static void StartClient(string ipAddress = "127.0.0.1")
    {
        TcpClient client = new TcpClient(ipAddress, PORT);
        NetworkStream stream = client.GetStream();
        Console.WriteLine("Uppkoppling lyckad");

        while (true)
        {
            Console.Write("Skriv ett meddelande: ");
            string message = Console.ReadLine() ?? "";
            byte[] data = Encoding.UTF8.GetBytes(message);

            stream.Write(data, 0, data.Length);
            Console.WriteLine("Skickade Ett meddelande till servern");
        }
    }
}