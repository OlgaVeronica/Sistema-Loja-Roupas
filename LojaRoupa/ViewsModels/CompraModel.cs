using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupa.ViewsModels
{
    internal class CompraModel
    {
        public int Id { get; set; }
        public int Data { get; set; }
        public int Hora { get; set; }
        public int Valor { get; set; }
        public string Status { get; set; }
    }
}
