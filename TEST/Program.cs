namespace TEST;

class Program
{
    public static List<Book> bookList = [];
    public static List<Movie> movieList = [];
    static void Main(string[] args)
    {
        /*
        Book bok1 = new Book("50 shades of grey");
        Console.WriteLine(bok1.Name);

        Movie film1 = new Movie("End game", ["Robert Downie Jr", "Chriss Part", "Tom Holland", "Chris Evens", "Chris Hemsworth"]);
        foreach (var actor in film1.Actors)
        {
            Console.WriteLine(actor);
        }
        */

        while (true)
        {
            Console.WriteLine("Biblioteket 3000");
            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("1. Lägga till ny media");
            Console.WriteLine("2. Visa Böcker");
            Console.WriteLine("3. Visa Filmer");
            Console.WriteLine("4. Visa Låtar");

            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                Console.WriteLine("1. Bok");
                Console.WriteLine("2. Film");
                Console.WriteLine("3. Låt");

                userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    addBook();
                }
                else if (userInput == "2")
                {
                    addMovie();
                }
                else if (userInput == "3")
                {
                    addMusic();
                }

            }
            else if (userInput == "2")
            {
                listBooks();
            }
        }
    }




    public static void addBook()
    {
        Console.WriteLine("Vad heter boken?");
        string bookName = Console.ReadLine();

        Console.WriteLine("När släpptes den?");
        string bookYearString = Console.ReadLine();
        int bookYear = Convert.ToInt32(bookYearString);

        Console.WriteLine("Vem skrev den?");
        string bookAuthor = Console.ReadLine();

        Console.WriteLine("Vilken genre?");
        string bookGenre = Console.ReadLine();

        Console.WriteLine("är den fiktion?");
        Console.WriteLine("1. Ja");
        Console.WriteLine("2. Nej");
        string bookFictionString = Console.ReadLine();
        bool bookFiction = false;
        if (bookFictionString == "1")
        {
            bookFiction = true;
        }
        else
        {
            bookFiction = false;
        }

        bookList.Add(new Book(bookName, bookYear, bookAuthor, bookGenre, bookFiction));
    }

    public static void addMovie()
    {
        Console.WriteLine("Vad heter filmen?");
        string movieName = Console.ReadLine();

        Console.WriteLine("När släpptes filmen?");
        string movieYearString = Console.ReadLine();
        int movieYear = Convert.ToInt32(movieYearString);


        Console.WriteLine("Vem gjorde filmen?");
        string movieAuthor = Console.ReadLine();

        Console.WriteLine("Vilken genre har filmen?");
        string movieGenre = Console.ReadLine();

        Console.WriteLine("Vilka är med i filmen (separera alla namn med ett kommatecken)?");
        string movieActorsString = Console.ReadLine();
        List<string> movieActors = movieActorsString.Split(",").ToList();

        movieList.Add(new Movie(movieName, movieYear, movieAuthor, movieGenre, movieActors));
    }

    public static void addMusic()
    {

    }

    public static void listBooks()
    {
        Console.WriteLine("{0,-10} {1,-10} {2,-10} {3, -10} {4, -10}", "Namn", "Skriven av", "Släppt", "Genre", "Fiktion");
        foreach (Book book in bookList)
        {
            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3, -10} {4, -10}", book.Name, book.Author, book.Year, book.Genre, book.IsFiction);
        }
        
    }
}
