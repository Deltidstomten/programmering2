namespace Pokemon;

class Program
{
    static void Main(string[] args)
    {
        List<Move> moves = [new Move(1, Type.Bug, 1, 1, 1)];
        Pokemon pokemon = new Pokemon("TalonFlame", Type.Fire, Ability.FlameBody, moves, 78, 81, 74, 71, 69, 126);

        Console.WriteLine(pokemon.Name);
    }
}
