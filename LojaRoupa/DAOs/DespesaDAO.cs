using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaRoupa.ViewsModels;
using MySql.Data.MySqlClient;

namespace LojaRoupa.DAOs
{
    class DespesaDAO : AbstractDAO<DespesaModel>
    {
        public override void Delete(DespesaModel despesa)
        {
            /*try
            {
                var command = conn.Query();
                command.CommandText = 
            }
            catch
            {

            }*/
        }

        public override void Insert(DespesaModel t)
        {
            throw new NotImplementedException();
        }

        public override List<DespesaModel> List()
        {
            throw new NotImplementedException();
        }

        public override void Update(DespesaModel t)
        {
            throw new NotImplementedException();
        }
    }
}
