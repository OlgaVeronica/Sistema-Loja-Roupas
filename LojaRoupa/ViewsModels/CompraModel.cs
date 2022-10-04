using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupa.ViewsModels
{
    public class CompraModel
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string Hora { get; set; }
        public string Valor { get; set; }
        public string Status { get; set; }
    }
}
