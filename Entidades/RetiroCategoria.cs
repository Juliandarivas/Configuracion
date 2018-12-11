using System.Collections.Generic;

namespace Entidades
{
    public class RetiroCategoria
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public List<RetiroCausa> RetirosCausas { get; set; }
    }
}
