using System.Net;
using System.Net.Sockets;
using System.Text;

namespace RockPaperScissors;

class Client
{
    const int PORT = 4000;

    public static void StartClient(string ipAddress = "127.0.0.1")
    {
        TcpClient client = new TcpClient(ipAddress, PORT);

        NetworkStream stream = client.GetStream();

        Console.WriteLine("Uppkoppling lyckad");
        Console.WriteLine("Välkommen till Sten/Sax/Påse");
        while (true)
        {
            Console.WriteLine("Vad Väljer du?");
            string message = Console.ReadLine() ?? "Error";
            byte[] data = Encoding.UTF8.GetBytes(message);

            stream.Write(data, 0, data.Length);
            Console.WriteLine("Skickade Ett meddelande till servern");

            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string status = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine(status);

        }

        stream.Close();
        client.Close();

    }
}