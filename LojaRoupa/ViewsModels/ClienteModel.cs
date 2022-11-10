using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupa.ViewsModels
{
    public class ClienteModel
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Status { get; set; }


    }
}
