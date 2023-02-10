
using System.Security.Policy;

namespace FrankPatata
{
    internal class ClassDetails
    {
        public ClassDetails(int app_id,string nombre,string descripcion,double mediaPuntos,List<ClassComment> lista)
        {
            this.app_id = app_id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.mediaPuntos = mediaPuntos;
            this.listaComentarios = lista;
        }
        public int app_id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public double mediaPuntos { get; set; }
        public List<ClassComment> listaComentarios { get; set; }
        
    }
}
