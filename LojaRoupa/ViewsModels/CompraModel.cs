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
        public DateTime?  Data { get; set; }
        public string Hora { get; set; }
        public float Valor { get; set; }
        public string Status { get; set; }
        
        public FornecedorModel Fornecedor { get; set; }
        public FuncionarioModel Funcionario { get; set; }

        public List<ProdutoModel> Produtos { get; set; }
    }
}
