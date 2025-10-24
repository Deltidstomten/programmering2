using System.Net;
using System.Net.Sockets;
using System.Text;

namespace RockPaperScissors;

class Server
{
    const int PORT = 4000;

    static Dictionary<string, string> winning_moves = new Dictionary<string, string>()
        {
            {"sten", "sax"},
            {"sax", "påse"},
            {"påse", "sten"}
        };
    public static void StartServer()
    {
        TcpListener server = new TcpListener(IPAddress.Any, PORT);
        server.Start();
        Console.WriteLine("Servern Igång, Väntar på uppkoppling...");

        TcpClient client = server.AcceptTcpClient();
        Console.WriteLine("Klient Ansluten!");

        NetworkStream stream = client.GetStream();

        int serverPoint = 0;
        int clientPoint = 0;

        while (true)
        {
            if (serverPoint >= 3 || clientPoint >= 3)
            {
                client.Close();
                server.Stop();
            }

            string client_choice = ReadClient(stream);

            Console.WriteLine("Välj något");
            string server_choice = Console.ReadLine() ?? "";

            string winner = GetWinner(server_choice, client_choice);
            if (winner == "server")
            {
                Console.WriteLine("Servern Vann!");
                MessageClient(stream, "Servern Vann!");
                serverPoint++;
            }
            else if (winner == "client")
            {
                Console.WriteLine("Klienten Vann!");
                MessageClient(stream, "Klienten Vann!");
                clientPoint++;
            }

            //Console.WriteLine($"Klienten Skrev {message} som var {bytesRead} bytes lång");
        }
    }

    private static void MessageClient(NetworkStream stream, string message)
    {
        byte[] data = Encoding.UTF8.GetBytes(message);
        stream.Write(data, 0, data.Length);
    }

    private static string ReadClient(NetworkStream stream)
    {
        byte[] buffer = new byte[1024];

        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        return message;
    }

    private static string GetWinner(string server_choice, string client_choice)
    {
        if (client_choice == server_choice)
        {
            return "";
        }
        else if (winning_moves.ContainsKey(server_choice) && winning_moves[server_choice] == client_choice)
        {
            return "server";
        }
        else if (winning_moves.ContainsKey(client_choice) && winning_moves[client_choice] == server_choice)
        {
            return "client";
        }
        else
        {
            return "";  
        }
    }
}