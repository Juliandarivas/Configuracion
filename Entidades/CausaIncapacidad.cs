using Enumerables;

namespace Entidades
{
    public class CausaIncapacidad
    {
        public int Id { get; set; }
        public string Descricpcion { get; set; }
        public int MesesPromedio { get; set; }
        public double PorcentajeEmpleador { get; set; }
        public double PorcentajeEntidad { get; set; }
        public int DiasEmpleador { get; set; }
        public int DiasMaximos { get; set; }
        public TipoConteoDias TipoConteoDias { get; set; }
        public bool Activo { get; set; }
        public string Entidad { get; set; }
    }
}
