using ProdCRUD.Models;
using ProdCRUD.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProdCRUD
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        public Produto currentData = null;

        public DetailWindow(Produto prod)
        {
            InitializeComponent();
            currentData = prod;
            if (prod == null)
                DataContext = new Produto();
            else
                DataContext = currentData;
        }

        public void btnConfirm_Click(object sender, EventArgs args)
        {
            Produto current = (Produto)DataContext;
            ProdutoDAO dao = new ProdutoDAO();
            if (currentData == null)
                dao.Insert(current);
            else
                dao.Update(current);
            this.Close();
        }

        public void btnCancel_Click(object sender, EventArgs args)
        {
            this.Close();
        }
    }
}
