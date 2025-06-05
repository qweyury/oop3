using System.IO;

namespace Lab3.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }          // Название фильма
        public int? DirectorId { get; set; }        // ID режиссёра
        public Director? Director { get; set; }     // Режиссёр фильма
    }
}