using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdCRUD.Models.DAO
{
    class ProdutoDAO : Model<Produto>
    {
        public void Insert(Produto prod)
        {
            this.ExecuteCommand("INSERT INTO Produto(Codigo, Descricao, Preco) VALUES(@Codigo, @Descricao, @Preco)", new DatabaseParameter[] {
                new DatabaseParameter("Codigo", prod.Codigo),
                new DatabaseParameter("Descricao", prod.Descricao),
                new DatabaseParameter("Preco", prod.Preco)
            });
        }

        public void Update(Produto prod)
        {
            this.ExecuteCommand("UPDATE Produto SET Codigo = @Codigo, Descricao = @Descrica, Preco = @Preco WHERE ProdutoId = @ProdutoId", new DatabaseParameter[] {
                new DatabaseParameter("Codigo", prod.Codigo),
                new DatabaseParameter("Descricao", prod.Descricao),
                new DatabaseParameter("Preco", prod.Preco),
                new DatabaseParameter("ProdutoId", prod.ProdutoId)
            });
        }

        public void Delete(Produto prod)
        {
            this.ExecuteCommand("DELETE FROM Produto WHERE ProdutoId = @ProdutoId", new DatabaseParameter[] {
                new DatabaseParameter("ProdutoId", prod.ProdutoId)
            });
        }

        public List<Produto> GetAll()
        {
            List<Produto> list = new List<Produto>();
            MySqlDataReader reader = this.ExecuteReader("SELECT ProdutoId, Codigo, Descricao, Preco FROM PRODUTO");
            while (reader.Read())
            {
                list.Add(createProduct(reader));

            }
            return list;
        }

        public Produto Get(int key)
        {
            this.ExecuteReader("SELECT ProdutoId, Codigo, Descricao, Preco FROM PRODUTO WHERE ProdutoId = @ProdutoId", new DatabaseParameter[] {
                new DatabaseParameter("ProdutoId", key)
            });
            return null;
        }


        public Produto createProduct(MySqlDataReader reader)
        {
            return new Produto()
            {
                Codigo = Convert.ToInt32(reader["Codigo"]),
                Descricao = reader["Descricao"].ToString(),
                Preco = Convert.ToDouble(reader["Preco"]),
                ProdutoId = Convert.ToInt32(reader["ProdutoId"])
            };
        }

        public List<Produto> GetByDescricao(string descricao)
        {
            List<Produto> list = new List<Produto>();
            this.ExecuteReader("SELECT ProdutoId, Codigo, Descricao, Preco FROM PRODUTO WHERE Descricao LIKE @desricao", new DatabaseParameter[] {
                new DatabaseParameter("descricao", $"%{descricao}%")
            });
            return list;
        }
    }
}
