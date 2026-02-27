namespace ChatRoom;

class Packet
{
    public Packet(string message, string username, DateTime time)
    {
        Message = message;
        Username = username;
        Time = time;
    }

    public string Message
    { get; set; }

    public string Username
    { get; set; }
    public DateTime Time
    { get; set; }

    override public string ToString()
    {
        return $"{Username} {Time.ToString("HH:mm")} : {Message}";
    }
}