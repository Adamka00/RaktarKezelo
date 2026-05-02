using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaktarKezelo.Core.Entities;

[Table("Termekek")]
public class Termek
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Nev { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(50)]
    public string Cikkszam { get; set; } = string.Empty;
    
    public int Keszlet { get; set; } = 0;
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Ar { get; set; }
    
    public int MinKeszlet { get; set; } = 0;
    
    [MaxLength(500)]
    public string Megjegyzes { get; set; } = string.Empty;

    [Required]
    public int KategoriaId { get; set; }

    [ForeignKey("KategoriaId")]
    public virtual Kategoria Kategoria { get; set; } = null!; 
}