namespace RaktarKezelo.Konzol;

public interface IFajlKezelo
{
    void Mentes(List<Termek> termekek, string fajlNev);
    List<Termek> Betoltes(string fajlNev);
}