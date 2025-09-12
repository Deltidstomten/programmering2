namespace TEST;

class Book : Media
{
    public bool IsFiction
    { get; set; }
    public Book(string newName, int newYear, string newAuthor, string newGenre, bool newIsFiction)
    {
        Name = newName;
        Year = newYear;
        Author = newAuthor;
        Genre = newGenre;
        IsFiction = newIsFiction;
    }
}