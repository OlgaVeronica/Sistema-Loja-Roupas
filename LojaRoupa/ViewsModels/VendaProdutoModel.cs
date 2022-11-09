using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LojaRoupa.ViewsModels
{

    public class VendaProdutoModel
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }

        public int VendaId { get; set; }   

        public int ProdutoId { get; set; }

    }
}
