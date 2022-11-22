using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaRoupa.ViewsModels;

namespace LojaRoupa.DAOs
{
    class VendaProdutoDAO : AbstractDAO<VendaProdutoModel>
    {
        public override void Delete(VendaProdutoModel t)
        {
            throw new NotImplementedException();
        }

        public override void Insert(VendaProdutoModel vendaProduto)
        {
            try
            {

                var command = conn.Query();

                command.CommandText = "insert into venda_roupa values (null, @quant, @vend, @roup)";

                command.Parameters.AddWithValue("@quant", vendaProduto.Quantidade);
                command.Parameters.AddWithValue("@vend", vendaProduto.VendaId);
                command.Parameters.AddWithValue("@roup", vendaProduto.ProdutoId);

                var resultado = command.ExecuteNonQuery();

                if(resultado == 0)
                {
                    throw new Exception("Erro ao inserir Venda - produto");
                }
                else{
                    var dao = new ProdutoDAO();
                    dao.AtualizarQuantidade(vendaProduto.ProdutoId, vendaProduto.Quantidade, "Subtrair");
                }
            } catch (Exception ex)
            {
                throw ex;           
            }
            finally
            {
                conn.Close();
            }
        }

        public override List<VendaProdutoModel> List()
        {
            throw new NotImplementedException();
        }

        public override void Update(VendaProdutoModel t)
        {
            throw new NotImplementedException();
        }
    }
}
