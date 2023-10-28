namespace JRLW04CRRUD.Models.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public int? Edition { get; set; }   
    public int PublicationYear { get; set; }
}
