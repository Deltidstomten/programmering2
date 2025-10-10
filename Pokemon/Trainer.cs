namespace Pokemon;

class Trainer
{
    public static Trainer Harald = new Trainer("Harald Ironfist", 53, false, "Eld nationen attackerar!", "Ledare över MagmaArmoracau", [(Pokemon)Pokemon.talonFlame.Clone()]);

    private const int MAX_TEAM_SIZE = 6;
    public Trainer(string name, int age, bool gender, string catchphrase, string occupation, List<Pokemon> team)
    {
        Name = name;
        Age = age;
        Gender = gender;
        Catchphrase = catchphrase;
        Occupation = occupation;
        Team = team;
    }

    public void AddPokemon(Pokemon newPokemon)
    {
        if (Team.Count < MAX_TEAM_SIZE)
        {
            Team.Add(newPokemon);
        }
    }

    public string Name { get; set; }

    public int Age { get; set; }

    public bool Gender { get; set; }

    public string Catchphrase { get; set; }

    public string Occupation { get; set; }

    public List<Pokemon> Team { get; set; }


}