namespace RockPaperScissors;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length > 0 && args[0] == "server")
        {
            Server.StartServer();
        }
        else
        {
            if (args.Length < 2)
            {
                Client.StartClient();
            }
            else
            {
                Client.StartClient(args[1]);
            }
        }
    }
}
