using System.Collections.Generic;

namespace Entidades
{
    public class Item
    {
        public string ItmId { get; set; }
        public string Descripcion { get; set; }
        public byte? Nomina { get; set; }
        public double Factor { get; set; }
        public string DescripcionCompleta { get { return $"{ItmId} - {Descripcion}"; } }
        public List<LicenciaRemuneradaCausa> LicenciaRemuneradaCausaIdItemNavigation { get; set; }
    }
}
