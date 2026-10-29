namespace OOP.Klassid;

// Harjutus 2: privaatne jääk, ainult loetav omadus ja väljamakse piirangud.
public class PangaKonto
{
    private double _balance;
    public const double MaxWithdraw = 1000;

    public double Balance
    {
        get { return _balance; }
    }

    public bool Deposit(double summa)
    {
        if (summa <= 0 || double.IsNaN(summa) || double.IsInfinity(summa))
        {
            return false;
        }

        _balance += summa;
        return true;
    }

    public bool Withdraw(double summa)
    {
        if (summa <= 0 || double.IsNaN(summa) || double.IsInfinity(summa)
            || summa > MaxWithdraw || summa > _balance)
        {
            return false;
        }

        _balance -= summa;
        return true;
    }
}
