using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiPrueba.Models
{
    public class Factura
    {
        public int Id { get; set; }
        public string Codigo { get; set; }

        public int EjercicioContable { get; set; }

        public double Importe { get; set; }


    }
}
