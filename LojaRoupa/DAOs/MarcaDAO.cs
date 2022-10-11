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
using LojaRoupa.Helpers;

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
            try
            {
                var lista = new List<MarcaModel>();

                var command = conn.Query();
                command.CommandText = "select * from marca";



                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var marca = new MarcaModel();
                    marca.Id = reader.GetInt32("id_mar");
                    marca.Nome = DAOHelper.GetString(reader, "nome_mar");
                    marca.Logo = DAOHelper.GetString(reader, "logo_mar");
                    marca.Status = DAOHelper.GetString(reader, "status_mar");
                    

                    lista.Add(marca);

                }
                reader.Close();


                return lista;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public override void Update(MarcaModel marca)
        {
            throw new NotImplementedException();
        }
    }

}
