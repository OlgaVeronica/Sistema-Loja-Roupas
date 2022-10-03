using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LojaRoupa.DAOs;
using LojaRoupa.Database;
using LojaRoupa.ViewsModels;
using MySql.Data.MySqlClient;

namespace LojaRoupa.DAOs
{
    class MarcaDAO : AbstractDAO<MarcaModel>   
    {
        public override void Delete(MarcaModel marca)
        {
            throw new NotImplementedException();
        }

        public override void Insert(MarcaModel marca)
        {
            try
            {

                var command = conn.Query();
                command.CommandText = "insert into Marca values(null, @nome, @logo, 'ativo');";

                command.Parameters.AddWithValue("@nome", marca.Nome);
                command.Parameters.AddWithValue("@logo", marca.Logo);
               

                var resultado = command.ExecuteNonQuery();



            }
            catch (MySqlException error)
            {
                throw error;
            }
            finally
            {
                conn.Close();
            }
        }

        public override List<MarcaModel> List()
        {
            throw new NotImplementedException();
        }

        public override void Update(MarcaModel marca)
        {
            throw new NotImplementedException();
        }
    }

}
