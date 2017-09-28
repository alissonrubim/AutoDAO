using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdCRUD.Models.DAO
{
    class ProdutoDAO: Model<Produto>
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
            this.ExecuteCommand("UPDATE Produto SET Codigo = @Codigo, Descricao = @Descrica, Preco = @Preco WHERE ProdutoId = @Id", new DatabaseParameter[] {
                new DatabaseParameter("Codigo", prod.Codigo),
                new DatabaseParameter("Descricao", prod.Descricao),
                new DatabaseParameter("Preco", prod.Preco),
                new DatabaseParameter("Id", prod.Id)
            });
        }

        public void Delete(Produto prod)
        {
            this.ExecuteCommand("DELETE FROM Produto WHERE ProdutoId = @Id", new DatabaseParameter[] {
                new DatabaseParameter("Id", prod.Id)
            });
        }

        public List<Produto> GetAll()
        {
            List<Produto> list = new List<Produto>();
            this.ExecuteReader("SELECT Id, Codigo, Descricao, Preco FROM PRODUTO");
            return list;
        }

        public Produto Get(int key)
        {
            this.ExecuteReader("SELECT Id, Codigo, Descricao, Preco FROM PRODUTO WHERE Id = @id", new DatabaseParameter[] {
                new DatabaseParameter("id", key)
            });
            return null;
        }
        

        public List<Produto> GetByDescricao(string descricao)
        {
            List<Produto> list = new List<Produto>();
            this.ExecuteReader("SELECT Id, Codigo, Descricao, Preco FROM PRODUTO WHERE Descricao LIKE @desricao", new DatabaseParameter[] {
                new DatabaseParameter("descricao", $"%{descricao}%")
            });
            return list;
        }
    }
}
