using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Data.Models
{
  [Table("tblAuthors")]
  public class Author
  {
    [Key] public Guid Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ProfileImage { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime DateCreated { get; set; }
    public bool Active { get; set; }
  }
}