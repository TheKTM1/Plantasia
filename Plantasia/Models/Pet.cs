using System.ComponentModel.DataAnnotations;

namespace Plantasia.Models;

public class Pet
{
   [Key]
   public int Id { get; set; } 
   public int Level { get; set; }
   public int Exp { get; set; }
   public int RequiredExp { get; set; }
   public string PictureHref { get; set; }
   public string Produce { get; set; }
}