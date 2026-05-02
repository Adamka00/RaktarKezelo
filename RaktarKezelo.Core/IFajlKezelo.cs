using RaktarKezelo.Core.Entities;
namespace RaktarKezelo.Core;

public interface IFajlKezelo
{
    void Mentes(List<Termek> termekek, string fajlNev);
    List<Termek> Betoltes(string fajlNev);
}