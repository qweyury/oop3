namespace Lab3.Models
{
    public class MovieGenre
    {
        public int Id { get; set; }
        public int? MovieId { get; set; }           // ID фильма
        public Movie? Movie { get; set; }           // Фильм
        public int? GenreId { get; set; }           // ID жанра
        public Genre? Genre { get; set; }           // Жанр фильма
    }
}