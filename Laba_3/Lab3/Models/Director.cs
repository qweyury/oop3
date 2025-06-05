namespace Lab3.Models
{
    public class Director
    {
        public int Id { get; set; }
        public string? Name { get; set; }          // Имя режиссёра
        public List<Movie>? Movies { get; set; } = new List<Movie>();  // Фильмы режиссёра
    }
}
