using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaRoupa.Database;

namespace LojaRoupa.DAOs
{
    /// <summary>
    ///     Abstract Class para classes DAO
    /// </summary>
    /// <typeparam name="T"></typeparam>

    public abstract class AbstractDAO<T>
    {
        protected Conexao conn = new Conexao();
        private string table;
        public abstract void Insert(T t);
        public abstract void Update(T t);
        public abstract void Delete(T t);

        public abstract List<T> List();


    }
}
