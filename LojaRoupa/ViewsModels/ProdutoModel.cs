using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupa.ViewsModels
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Tecido { get; set; }
        public string Tipo { get; set; }
        public string Colecao { get; set; }
        public string Tamanho { get; set; }
        public string Estampa { get; set; }
        public string Status { get; set; }

        public int Quantidade { get; set; }

        public float Preco { get; set; }

        public MarcaModel Marca { get; set; }
        
    }
}
