namespace FrankPatata
{
    public class ClassElement
    {
        public int id { get; set; }
        public object tipo { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public string version { get; set; }
        public string publisher { get; set; }
        public string genero { get; set; }
        public ElementDetails detalles { get; set; }
        public List<ElementComment> comentarios { get; set; }
        
    }
}
