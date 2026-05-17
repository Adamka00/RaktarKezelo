using RaktarKezelo.Core.Entities;
namespace RaktarKezelo.Core.Interfaces;

public interface IFajlKezelo
{
    void Mentes(List<Termek> termekek, string fajlNev);
    List<Termek> Betoltes(string fajlNev);
}