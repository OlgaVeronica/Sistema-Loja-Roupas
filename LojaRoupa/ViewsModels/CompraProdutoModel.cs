using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupa.ViewsModels
{
    public class CompraProdutoModel
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }

        public int CompraId { get; set; }

        public int ProdutoId { get; set; }

    }
}
