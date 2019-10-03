using ProjetoControleCompras.DAL;
using ProjetoControleCompras.Models;
using ProjetoControleCompras.Utils;
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
    /// Interaction logic for frmGerenciarCompras.xaml
    /// </summary>
    public partial class frmGerenciarCompras : Window
    {
        public frmGerenciarCompras()
        {
            InitializeComponent();

            AtualizarDataGrid();
        }

        private void AtualizarDataGrid()
        {
            dtaComprasAFazer.ItemsSource = PedidoDAO.ListarPedidosPorStatus(Status.GetStatus(2));
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Ver Itens
            AbrirTelaVisualizacao.AbrirTelaVerItens(dtaComprasAFazer.SelectedItem);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            // Ver Orçamentos
            AbrirTelaVisualizacao.AbrirTelaVerOrcamentos(dtaComprasAFazer.SelectedItem);
        }

        private void BtnEncerrarPedido_Click(object sender, RoutedEventArgs e)
        {
            dynamic d = dtaComprasAFazer.SelectedItem;
            if (d != null)
            {
                if (MessageBox.Show("Você tem Certeza que ja realizou as Copmras do Pedido ID: " + d.IdPedido, 
                    "Gerenciar Compras", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    d.Status = Status.GetStatus(4);
                    if (PedidoDAO.AtualizarStatusPedido(d))
                    {
                        MessageBox.Show("Pedido Encerrado com Sucesso!", "Gerenciar Compras", MessageBoxButton.OK, MessageBoxImage.Information);
                        AtualizarDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("Houve um Erro ao Encerrar o Pedido! Tente Novamente.", "Gerenciar Compras", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por Favor, Selecione um Pedido para Encerrar.", "Gerenciar Compras", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
