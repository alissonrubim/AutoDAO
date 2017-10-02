using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdCRUD.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
    }
}
