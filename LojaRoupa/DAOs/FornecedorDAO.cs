using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaRoupa.DAOs;
using LojaRoupa.Database;
using LojaRoupa.Helpers;
using LojaRoupa.ViewsModels;
using MySql.Data.MySqlClient;

namespace LojaRoupa.DAOs
{
    class FornecedorDAO : AbstractDAO<FornecedorModel>
    {
        public override void Delete(FornecedorModel forn)
        {
            try
            {
                var command = conn.Query();
                command.CommandText = "update fornecedor set status_forn = 'inativo' where (id_forn = @id)";

                command.Parameters.AddWithValue("@id", forn.Id);

                var resultado = command.ExecuteNonQuery();

                if(resultado == 0)
                {
                    throw new Exception("Erro ao deletar fornecedor");
                }

            } catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public override void Insert(FornecedorModel forn)
        {
            try
            {

                var command = conn.Query();
                command.CommandText = "insert into fornecedor values(null, @razaoSocial, @cnpj, @nomeFantasia, @endereco, " +
                    "@email, @telefone, @status);";

                command.Parameters.AddWithValue("@razaoSocial", forn.RazaoSocial);
                command.Parameters.AddWithValue("@cnpj", forn.Cnpj);
                command.Parameters.AddWithValue("@nomeFantasia", forn.NomeFantasia);
                command.Parameters.AddWithValue("@endereco", forn.Endereco);
                command.Parameters.AddWithValue("@email", forn.Email);
                command.Parameters.AddWithValue("@telefone", forn.Telefone);
                command.Parameters.AddWithValue("@status", forn.Status);

                var resultado = command.ExecuteNonQuery();



            } catch (MySqlException error)
            {
                throw error;
            }
            finally
            {
                conn.Close();
            }
        }

        public override List<FornecedorModel> List()
        {

            try
            {
                var lista = new List<FornecedorModel>();

                var command = conn.Query();


                
                command.CommandText = "select * from fornecedor where(status_forn like 'Ativo');";

                
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var fornecedor = new FornecedorModel
                    {
                        Id = reader.GetInt32("id_forn"),
                        RazaoSocial = DAOHelper.GetString(reader, "razao_social_forn"),
                        Cnpj = DAOHelper.GetString(reader, "cnpj_forn"),
                        NomeFantasia = DAOHelper.GetString(reader, "nome_fantasia_forn"),
                        Endereco = DAOHelper.GetString(reader, "endereco_forn"),
                        Email = DAOHelper.GetString(reader, "email_forn"),
                        Telefone = DAOHelper.GetString(reader, "telefone_forn"),
                        Status = DAOHelper.GetString(reader, "status_forn")
                    };

                    lista.Add(fornecedor);

                }
                reader.Close();


                return lista;
            } catch (MySqlException ex)
            {
                throw ex;
            }
            
        }

        public override void Update(FornecedorModel forn)
        {

            try
            {
                var command = conn.Query();
                command.CommandText = "update fornecedor set razao_social_forn = @razaoSocial, cnpj_forn = @cnpj, nome_fantasia_forn = @nomeFantasia, " +
                        "endereco_forn = @endereco, email_forn = @email, telefone_forn = @telefone where (id_forn = @id);";

                command.Parameters.AddWithValue("@id", forn.Id);
                command.Parameters.AddWithValue("@razaoSocial", forn.RazaoSocial);
                command.Parameters.AddWithValue("@cnpj", forn.Cnpj);
                command.Parameters.AddWithValue("@nomeFantasia", forn.NomeFantasia);
                command.Parameters.AddWithValue("@endereco", forn.Endereco);
                command.Parameters.AddWithValue("@email", forn.Email);
                command.Parameters.AddWithValue("@telefone", forn.Telefone);
                command.Parameters.AddWithValue("@status", forn.Status);                

                var resultado = command.ExecuteNonQuery();


            } catch(MySqlException ex)
            {
                throw ex;
            }
            

        }
    }
}
