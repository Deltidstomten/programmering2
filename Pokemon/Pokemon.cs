namespace Pokemon;

class Pokemon
{

    public static Pokemon talonFlame = new Pokemon("TalonFlame", Type.Fire, Ability.FlameBody, [Move.braveBird], 78, 81, 74, 71, 69, 126);

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
    public object Clone()
    {
        return new Pokemon(
            this.Name,
            this.Type,
            this.Ability,
            new List<Move>(this.Moves),
            this.Hp,
            this.Atk,
            this.SpAtk,
            this.Def,
            this.SpDef,
            this.Speed
        );        
    }
}