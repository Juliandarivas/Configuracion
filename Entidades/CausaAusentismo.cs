namespace Entidades
{
    public class CausaAusentismo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Remunerado { get; set; }
        public int DescuentaDomingo { get; set; }
        public string IdItem { get; set; }
        public bool Activo { get; set; }
    }
}
