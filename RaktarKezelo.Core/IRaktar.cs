using RaktarKezelo.Core.Entities;
namespace RaktarKezelo.Core;

public interface IRaktar
{
    void Hozzaad(Termek ujTermek);
    List<Termek> GetOsszesTermek();
    
    List<Termek> KeresesNevAlapjan(string kulcsszo);
    
    List<Termek> RendezesArAlapjan(bool novekvo);
}