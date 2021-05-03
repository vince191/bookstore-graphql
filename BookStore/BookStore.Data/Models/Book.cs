using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Data.Models
{
  [Table("tblBooks")]
  public class Book
  {
    [Key] public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string CoverImage { get; set; }
    public string ISBN13 { get; set; }
    public string ISBN10 { get; set; }
    public int Price { get; set; }
    public DateTime ReleaseDate { get; set; }
    public DateTime DateCreated { get; set; }
    public bool Active { get; set; }
  }
}