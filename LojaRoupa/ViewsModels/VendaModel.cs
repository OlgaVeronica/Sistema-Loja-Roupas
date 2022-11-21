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
        public FuncionarioModel Funcionario { get; set; } = new FuncionarioModel();
        public ClienteModel Cliente { get; set; } = new ClienteModel();

        public DateTime? Data { get; set; }
        public string Hora { get; set; }
        public float Valor { get; set; }

        public List<ProdutoModel> Produto { get; set; }
        
    }
}
