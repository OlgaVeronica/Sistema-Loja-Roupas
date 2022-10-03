using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaRoupa.Database;

namespace LojaRoupa.DAOs
{
    public abstract class AbstractDAO
    {
        protected Conexao conn = new Conexao();
        private string table;
        public abstract void Insert();
        public abstract void Update();
        public abstract void Delete();


    }
}
