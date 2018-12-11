using System.ComponentModel;

namespace Entidades
{
    public class RetiroCausa
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int IdRetiroCategoria { get; set; }
        public RetiroCategoria RetiroCategoria { get; set; }
    }
}
