using ProjetoControleCompras.DAL;
using ProjetoControleCompras.Models;
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
        private bool fazerLogoff = false;
        private Agente AgenteLogado;

        public frmAdmin(Object agenteLogado)
        {
            InitializeComponent();
            AgenteLogado = (Agente)agenteLogado;
            atualiarTabelaPedidos();
        }

        private void atualiarTabelaPedidos()
        {
            dtaTodosPedidos.ItemsSource = PedidoDAO.ListarPedidos();
            dtaTodosPedidos.Items.Refresh();
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

        private void MenuItem_Produto_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarProduto telaCadProduto = new frmCadastrarProduto();
            telaCadProduto.ShowDialog();
        }

        private void MenuItem_Pedido_Click(object sender, RoutedEventArgs e)
        {
            frmCadastroPedido telaCadPedido = new frmCadastroPedido(AgenteLogado);
            telaCadPedido.ShowDialog();
            atualiarTabelaPedidos();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Envento de Fechamneto de uma Tela
            string action = fazerLogoff ? "Sair" : "Fechar";
            if ((MessageBox.Show("Deseja realmente " + action + "?", "Tela Principal", MessageBoxButton.YesNo, MessageBoxImage.Question)) == MessageBoxResult.No)
            {
                e.Cancel = true; // Cancelar o Evento
            }else if (fazerLogoff)
            {
                frmLogin telaLogin = new frmLogin();
                telaLogin.Show();
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            fazerLogoff = true;
            Close();
            fazerLogoff = false;
        }
    }
}
