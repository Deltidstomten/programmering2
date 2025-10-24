using System.Net;
using System.Net.Sockets;
using System.Text;

namespace RockPaperScissors;

class Server
{
    const int PORT = 4000;
    public static void StartServer()
    {
        TcpListener server = new TcpListener(IPAddress.Any, PORT);
        server.Start();
        Console.WriteLine("Servern Igång, Väntar på uppkoppling...");

        TcpClient client = server.AcceptTcpClient();
        Console.WriteLine("Klient Ansluten!");

        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];

        while(true)
        {
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            Console.WriteLine($"Klienten Skrev {message} som var {bytesRead} bytes lång");
        }
        
        client.Close();
        server.Stop();
    }
}