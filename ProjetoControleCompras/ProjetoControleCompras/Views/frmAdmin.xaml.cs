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

        private void MenuItem_Agente_Click(object sender, RoutedEventArgs e)
        {
            frmGerenciarAgente telaGerenciarAgente = new frmGerenciarAgente();
            telaGerenciarAgente.ShowDialog();
        }

        private void MenuItem_Setor_Click(object sender, RoutedEventArgs e)
        {
            frmCadastroCargoSetor telaCadCargoSetor = new frmCadastroCargoSetor();
            telaCadCargoSetor.btnCadCargo.Visibility = Visibility.Hidden;
            telaCadCargoSetor.btnCadSetor.Visibility = Visibility.Visible;
            telaCadCargoSetor.ShowDialog();
        }

        private void MenuItem_Cargo_Click(object sender, RoutedEventArgs e)
        {
            frmCadastroCargoSetor telaCadCargoSetor = new frmCadastroCargoSetor();
            telaCadCargoSetor.btnCadCargo.Visibility = Visibility.Visible;
            telaCadCargoSetor.btnCadSetor.Visibility = Visibility.Hidden;
            telaCadCargoSetor.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Envento de Fechamneto de uma Tela
            if ((MessageBox.Show("Deseja realmente Fechar?", "Tela Principal", MessageBoxButton.YesNo, MessageBoxImage.Question)) == MessageBoxResult.No)
            {
                e.Cancel = true; // Cancelar o Evento
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
