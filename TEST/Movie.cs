namespace TEST;

class Movie : Media
{
    public List<string> Actors
    { get; set; }

    public Movie(string newName, int newYear, string newAuthor, string newGenre, List<string> newActors)
    {
        Name = newName;
        Year = newYear;
        Author = newAuthor;
        Genre = newGenre;
        Actors = newActors;
    }
}