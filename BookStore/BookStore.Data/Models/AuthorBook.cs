using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Data.Models
{
  [Table("tblAuthorBooks")]
  public class AuthorBook
  {
    [Key] public Guid Id { get; set; }
    [ForeignKey("fkAuthor")] public Guid AuthorId { get; set; }
    [ForeignKey("fkBook")] public Guid BookId { get; set; }
    public DateTime DateCreated { get; set; }
    
    public virtual Author Author { get; set; }
    public virtual Book Book { get; set; }
  }
}