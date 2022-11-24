using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupa.ViewsModels
{
    public class DespesaModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Vencimento { get; set; }
        public float Valor { get; set; }
        public string Status { get; set; }
    }
}
