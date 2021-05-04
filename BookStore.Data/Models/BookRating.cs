using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Data.Models
{
  [Table("tblBookRatings")]
  public class BookRating
  {
    [Key] public Guid Id { get; set; }
    [ForeignKey("fkBook")] public Guid BookId { get; set; }
    [ForeignKey("fkUser")] public Guid UserId { get; set; }
    public int Rating { get; set; }
    public DateTime DateCreated { get; set; } 
    
    public virtual User User { get; set; }
    public virtual Book Book { get; set; }
  }
}