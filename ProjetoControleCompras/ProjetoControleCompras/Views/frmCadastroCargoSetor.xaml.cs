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
    /// Interaction logic for frmCadastroCargoSetor.xaml
    /// </summary>
    public partial class frmCadastroCargoSetor : Window
    {
        public frmCadastroCargoSetor()
        {
            InitializeComponent();
        }

        private void BtnCadSetor_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Clicou no Botão Cad Setor");
        }

        private void BtnCadCargo_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Clicou no Botão Cad Cargo");
        }
    }
}
