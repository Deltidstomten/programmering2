namespace Pokemon;

class Move
{
    public static Move spitt = new Move("Spitt", 1, Type.Bug, 1, 0, 1, true);
    public static Move braveBird = new Move("Brave Bird", 15, Type.Flying, 120, 40, 100, false);

    public Move(string name, int pp, Type type, int atkPower, int selfAttack, int acc, bool isSpecial)
    {
        Name = name;
        Pp = pp;
        Type = type;
        AtkPower = atkPower;
        SelfAttack = selfAttack;
        Acc = acc;
        IsSpecial = isSpecial;
    }

    public string Name
    { get; set; }
    public int Pp
    { get; set; }
    public Type Type
    { get; set; }
    public int AtkPower
    { get; set; }

    public int SelfAttack
    { get; set; }

    public int Acc
    { get; set; }

    public bool IsSpecial
    { get; set; }
}