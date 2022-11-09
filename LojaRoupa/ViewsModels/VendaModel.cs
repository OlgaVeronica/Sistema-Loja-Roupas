using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupa.ViewsModels
{
    public class VendaModel
    {
        public int Id { get; set; }
        public FuncionarioModel Funcionario { get; set; }
        public ClienteModel Cliente { get; set; }

        public DateTime? Data { get; set; }
        public float Valor { get; set; }

        public ProdutoModel[] Produto { get; set; }
        
    }
}
