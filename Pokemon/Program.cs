namespace Pokemon;

class Program
{
    static void Main(string[] args)
    {
        Pokemon pokemon = new Pokemon("TalonFlame", Type.Fire, Ability.FlameBody, [Move.spitt], 78, 81, 74, 71, 69, 126);

        Console.WriteLine(pokemon.Name);

    }
}
