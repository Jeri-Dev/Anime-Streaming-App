namespace Database.Entities
{
    public class Serie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string VideoPath { get; set; }

        public int ProductoraId { get; set; }
        public Productora? Productora { get; set; }

        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
    }
}
