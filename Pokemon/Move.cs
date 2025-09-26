namespace Pokemon;

class Move
{
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

    public Move(string newName, int newPp, Type newType, int newAtkPower, int newSelfAttack, int newAcc)
    {
        Name = newName;
        Pp = newPp;
        Type = newType;
        AtkPower = newAtkPower;
        SelfAttack = newSelfAttack;
        Acc = newAcc;
    }

    public static Move spitt = new Move("Spitt", 1, Type.Bug, 1, 0, 1);
    public static Move braveBird = new Move("Brave Bird", 15, Type.Flying, 120, 40, 100);

}