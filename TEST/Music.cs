namespace TEST;

class Music : Media
{
    public string Album
    { get; set; }
    public Music(string newName, int newYear, string newAuthor, string newGenre, string newAlbum)
    {
        Name = newName;
        Year = newYear;
        Author = newAuthor;
        Genre = newGenre;
        Album = newAlbum;
    }
}