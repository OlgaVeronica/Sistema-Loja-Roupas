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
        public string  Data { get; set; }
        public string Hora { get; set; }
        public double Valor { get; set; }
        public string Status { get; set; }
        
        public FornecedorModel Fornecedor { get; set; } = new FornecedorModel();
        public FuncionarioModel Funcionario { get; set; } = new FuncionarioModel();

        public List<ProdutoModel> Produtos { get; set; }
    }
}
