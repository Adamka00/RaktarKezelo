namespace RaktarKezelo.Konzol;

public class Termek
{
    public int Id { get; set; }
    public string Nev { get; set; }
    public int Ar { get; set; }
    public int Mennyiseg { get; set; }
    
    public Termek(int id, string nev, int ar, int mennyiseg)
    {
        Id = id;
        Nev = nev;
        Ar = ar;
        Mennyiseg = mennyiseg;
    }
    
    public override string ToString()
    {
        return $"ID: {Id}, Név: {Nev}, Ár: {Ar} Ft, Mennyiség: {Mennyiseg}";
    }
}