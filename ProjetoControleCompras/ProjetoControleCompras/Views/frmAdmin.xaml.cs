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

namespace ProjetoControleCompras.Views
{
    /// <summary>
    /// Interaction logic for frmAdmin.xaml
    /// </summary>
    public partial class frmAdmin : Window
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            frmCadastroCargoSetor telaCadCargoSetor = new frmCadastroCargoSetor();
            frmCadastroAgente telaCadAgente = new frmCadastroAgente();

            MenuItem itemMenu= (MenuItem) sender;

            if (itemMenu.Header.Equals("Usuário"))
            {
                Console.WriteLine("Clicou no MenuItem Aba Usuario");
                telaCadAgente.ShowDialog();
            }

            if (itemMenu.Header.Equals("Setor"))
            {
                Console.WriteLine("Clicou no MenuItem Aba Setor");
                telaCadCargoSetor.Title = "Cadastro de Setor";
                telaCadCargoSetor.btnCadCargo.Visibility = Visibility.Hidden;
                telaCadCargoSetor.btnCadSetor.Visibility = Visibility.Visible;
                telaCadCargoSetor.ShowDialog();
            }

            if (itemMenu.Header.Equals("Cargo"))
            {
                Console.WriteLine("Clicou no MenuItem Aba Cargo");
                telaCadCargoSetor.Title = "Cadastro de Cargo";
                telaCadCargoSetor.btnCadCargo.Visibility = Visibility.Visible;
                telaCadCargoSetor.btnCadSetor.Visibility = Visibility.Hidden;
                telaCadCargoSetor.ShowDialog();
            }
        }
        
    }
}
