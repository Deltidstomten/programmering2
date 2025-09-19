namespace Pokemon;

class Pokemon
{

    public string Name
    { get; set; }
    public Type Type
    { get; set; }

    public Ability Ability
    { get; set; }

    public List<Move> Moves
    { get; set; }

    public int Hp
    { get; set; }

    public int Atk
    { get; set; }

    public int SpAtk
    { get; set; }

    public int Def
    { get; set; }

    public int SpDef
    { get; set; }

    public int Speed
    { get; set; }

    public Pokemon(string newName, Type newType, Ability newAbility, List<Move> newMoves,
                    int newHp, int newAtk, int newSpAtk, int newDef, int newSpDef, int newSpeed)
    {
        Name = newName;
        Type = newType;
        Ability = newAbility;
        Moves = newMoves;
        Hp = newHp;
        Atk = newAtk;
        SpAtk = newSpAtk;
        Def = newDef;
        SpDef = newSpDef;
        Speed = newSpeed;
    }
}