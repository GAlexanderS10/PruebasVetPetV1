﻿using System;
using System.Collections.Generic;

namespace PruebasVetPetV1.Models
{
    public partial class Servicio
    {
        public int ServicioId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal? Precio { get; set; }
    }
}
