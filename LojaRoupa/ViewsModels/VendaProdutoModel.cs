using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LojaRoupa.ViewsModels
{

    class VendaProdutoModel
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }

        public VendaModel Venda { get; set; }   

        public ProdutoModel Produto { get; set; }

    }
}
