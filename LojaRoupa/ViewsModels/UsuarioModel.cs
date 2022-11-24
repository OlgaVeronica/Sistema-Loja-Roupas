using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupa.ViewsModels
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Senha { get; set; }
        public string Senha2 { get; set; }
        public string Tipo { get; set; }

        public string Avatar { get; set; }
    }
}
