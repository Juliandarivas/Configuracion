﻿namespace Entidades
{
    public class LicenciaRemuneradaCausa
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string IdItem { get; set; }
        public bool Activo { get; set; }
        public Item Item { get; set; }
    }
}