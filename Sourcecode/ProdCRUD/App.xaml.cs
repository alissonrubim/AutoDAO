using ProdCRUD.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProdCRUD
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void Application_Start(object sender, StartupEventArgs args)
        {
            Database.ConnectionString = "SERVER=localhost; DATABASE=teste; UID=root; PASSWORD=!@#$1234;";
        }
    }
}
