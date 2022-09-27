using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupa.ViewsModels
{
    class ProdutoModel
    {

        public ProdutoModel(object _dataContext)
        {
           
            _dataContext = new CaixaModel();
        }
    }
}
