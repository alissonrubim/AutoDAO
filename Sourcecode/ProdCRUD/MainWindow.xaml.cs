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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProdCRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Models.Produto> gridResumeList = new List<Models.Produto>();
        private ProdutoDAO dao;

        public MainWindow()
        {
            InitializeComponent();
            gridResume.ItemsSource = gridResumeList;
            dao = new ProdutoDAO();
            reloadGrid();
        }

        private void reloadGrid()
        {
            string filter = filterDescricao.Text;
            if (filter == "")
            {
                gridResumeList = dao.GetAll();
            }
            else
            {
                gridResumeList = dao.GetByDescricao(filter);
            }
        }

        private void filter_Click(object sender, RoutedEventArgs e)
        {
            reloadGrid();
        }
    }
}
