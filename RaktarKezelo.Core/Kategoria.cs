using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using RaktarKezelo.Core.Entities;

namespace RaktarKezelo.Core.Entities;

public class Kategoria
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Nev { get; set; }
    
    public virtual ICollection<Termek> Termekek { get; set; }
}