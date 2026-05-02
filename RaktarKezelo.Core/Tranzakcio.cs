using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaktarKezelo.Core.Entities;

public class Tranzakcio
{
    [Key]
    public int Id { get; set; }
    
    public int TermekId { get; set; }
    
    [ForeignKey("TermekId")]
    public virtual Termek Termek { get; set; }
    
    public int Mennyiseg { get; set; } //pozitív -> bejövő, negatív -> kimenő

    public DateTime Datum { get; set; } = DateTime.Now;
    
    public string Tipus { get; set; } // "Bejövő" vagy "Kimenő"
}