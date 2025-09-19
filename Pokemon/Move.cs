namespace Pokemon;

class Move
{
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

    public Move(int newPp, Type newType, int newAtkPower, int newSelfAttack, int newAcc)
    {
        Pp = newPp;
        Type = newType;
        AtkPower = newAtkPower;
        SelfAttack = newSelfAttack;
        Acc = newAcc;
    }
}