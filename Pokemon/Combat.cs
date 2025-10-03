namespace Pokemon;

class Combat
{
    //Random random = new Random();

    public static void Battle(Trainer player, Trainer opponent, bool isEncounter = false)
    {
        Console.WriteLine($"{player.Name} Says {player.Catchphrase}");
        Console.WriteLine($"{opponent.Name} Says {opponent.Catchphrase}");

        Pokemon playerPokemon = player.Team[0];
        Pokemon opponentPokemon = opponent.Team[0];

        Move playerPokemonMove;
        Move opponentPokemonMove;

        while (true)
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Fight");
            Console.WriteLine("2. Change Pokemon");
            if (isEncounter)
            {
                Console.WriteLine("3. Run");
            }

            string playerChoice = Console.ReadLine();
            string opponentChoice = "1";

            if (playerChoice == "1")
            {
                Console.WriteLine("What Move Do You Want To Use?");
                for (int i = 0; i < playerPokemon.Moves.Count; i++)
                {
                    Console.WriteLine($"{i}. {playerPokemon.Moves[i].Name}");
                }

                string input = Console.ReadLine();

                playerPokemonMove = playerPokemon.Moves[Int32.Parse(input)];
            }

            if (opponentChoice == "1")
            {
                
            }

            if (playerChoice == "1" && opponentChoice == "1")
            {

            }


        }
    }

    public static readonly double[,] effectivenessChart = new double[18, 18]
    {
        // Normal
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0.5, 0, 1, 1, 0.5, 1},
        // Fire
        {1, 0.5, 0.5, 2, 1, 2, 1, 1, 1, 1, 1, 2, 0.5, 1, 0.5, 1, 2, 1},
        // Water
        {1, 2, 0.5, 0.5, 1, 1, 1, 1, 2, 1, 1, 1, 2, 1, 0.5, 1, 1, 1},
        // Grass
        {1, 0.5, 2, 0.5, 1, 1, 1, 0.5, 2, 0.5, 1, 0.5, 2, 1, 0.5, 1, 0.5, 1},
        // Electric
        {1, 1, 2, 0.5, 0.5, 1, 1, 1, 0, 2, 1, 1, 1, 1, 0.5, 1, 1, 1},
        // Ice
        {1, 0.5, 0.5, 2, 1, 0.5, 1, 1, 2, 2, 1, 1, 1, 1, 2, 1, 0.5, 1},
        // Fighting
        {2, 1, 1, 1, 1, 2, 1, 0.5, 1, 0.5, 0.5, 0.5, 2, 0, 1, 2, 2, 0.5},
        // Poison
        {1, 1, 1, 2, 1, 1, 1, 0.5, 0.5, 1, 1, 1, 0.5, 0.5, 1, 1, 0, 2},
        // Ground
        {1, 2, 1, 0.5, 2, 1, 1, 2, 1, 0, 1, 0.5, 2, 1, 1, 1, 2, 1},
        // Flying
        {1, 1, 1, 2, 0.5, 1, 2, 1, 1, 1, 1, 2, 0.5, 1, 1, 1, 0.5, 1},
        // Psychic
        {1, 1, 1, 1, 1, 1, 2, 2, 1, 1, 0.5, 1, 1, 1, 1, 0, 0.5, 1},
        // Bug
        {1, 0.5, 1, 2, 1, 1, 0.5, 0.5, 1, 0.5, 2, 1, 1, 0.5, 1, 2, 0.5, 0.5},
        // Rock
        {1, 2, 1, 1, 1, 2, 0.5, 1, 0.5, 2, 1, 2, 1, 1, 1, 1, 0.5, 1},
        // Ghost
        {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 0.5, 1, 1},
        // Dragon
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 0.5, 0},
        // Dark
        {1, 1, 1, 1, 1, 1, 0.5, 1, 1, 1, 2, 1, 1, 2, 1, 0.5, 1, 0.5},
        // Steel
        {1, 0.5, 0.5, 1, 0.5, 2, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 0.5, 2},
        // Fairy
        {1, 0.5, 1, 1, 1, 1, 2, 0.5, 1, 1, 1, 1, 1, 1, 2, 2, 0.5, 1}
    };
}