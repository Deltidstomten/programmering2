namespace Pokemon;

class Program
{
    static void Main(string[] args)
    {
        Pokemon poke1 = Pokemon.talonFlame;
        Pokemon poke2 = (Pokemon)Pokemon.talonFlame.Clone();
        poke2.Name = "Hassan";
        poke2.Moves.Add(Move.spitt);
        Console.WriteLine(poke1.Name);
        Console.WriteLine(poke2.Name);

        Console.WriteLine(poke1.Moves.Count);
        Console.WriteLine(poke2.Moves.Count);

    }
}
