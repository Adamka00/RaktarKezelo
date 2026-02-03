namespace RaktarKezelo.Konzol;

public interface IRaktar
{
    void Hozzaad(Termek ujTermek);
    List<Termek> GetOsszesTermek();
}