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
    /// Interaction logic for frmUsuario.xaml
    /// </summary>
    public partial class frmUsuario : Window
    {
        private Agente AgenteLogado;

        public frmUsuario(Object agenteLogado)
        {
            InitializeComponent();

            AgenteLogado = (Agente)agenteLogado;

            Atualizar_dta_Historico();
            Atualizar_dta_PedidoAtual();
        }

        private void Atualizar_dta_PedidoAtual()
        {
            List<Pedido> pedidoAtual = new List<Pedido>();
            foreach (Pedido pe in PedidoDAO.ListarPedidoPorAgente(AgenteLogado))
            {
                if (!pe.Status.Equals(Status.GetStatus(3))/*Pedido Cancelado*/
                 && !pe.Status.Equals(Status.GetStatus(4))/*Pedido Finalizado*/)
                {
                    pedidoAtual.Add(pe);
                }
            }
            if (pedidoAtual.Count > 0)
            {
                btnNovoPedido.IsEnabled = false;
                btnCancelarPedido.IsEnabled = true;
            }
            else
            {
                btnNovoPedido.IsEnabled = true;
                btnCancelarPedido.IsEnabled = false;
            }
            dtaPedidoAtual.ItemsSource = pedidoAtual;
            dtaPedidoAtual.Items.Refresh();
        }

        private void Atualizar_dta_Historico()
        {
            List<Pedido> listP = new List<Pedido>();
            foreach (Pedido p in PedidoDAO.ListarPedidoPorAgente(AgenteLogado))
            {
                if (p.Status.Equals(Status.GetStatus(3))/*Pedido Cancelado*/
                 || p.Status.Equals(Status.GetStatus(4))/*Pedido Finalizado*/)
                {
                    listP.Add(p);
                }
            }
            dtaHistPedido.ItemsSource = listP;
            dtaHistPedido.Items.Refresh();
        }

        private void BtnNovoPedido_Click(object sender, RoutedEventArgs e)
        {
            frmCadastroPedido telaCadPedido = new frmCadastroPedido(AgenteLogado);
            telaCadPedido.ShowDialog();
            Atualizar_dta_Historico();
            Atualizar_dta_PedidoAtual();
        }

        private void BtnCancelarPedido_Click(object sender, RoutedEventArgs e)
        {
            dynamic d = dtaPedidoAtual.SelectedItem;
            if (d == null)
            {
                MessageBox.Show("Por Favor, Selecione o Pedido que Deseja Cancelar.", "Tela Usuario", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                d.Status = Status.GetStatus(3);
                if (PedidoDAO.AtualizarStatusPedido(d))
                {
                    MessageBox.Show("Pedido Cancelado com Sucesso.", "Tela Usuario", MessageBoxButton.OK, MessageBoxImage.Information);
                    Atualizar_dta_Historico();
                    Atualizar_dta_PedidoAtual();
                }
                else
                    MessageBox.Show("Houve um Erro ao Cancelar o Pedido!", "Tela Usuario", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Ver Itens
            AbrirTelaVisualizacao.AbrirTelaVerItens(dtaHistPedido.SelectedItem);

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            // Ver Orçamentos
            AbrirTelaVisualizacao.AbrirTelaVerOrcamentos(dtaPedidoAtual.SelectedItem);
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            // Ver Itens
            AbrirTelaVisualizacao.AbrirTelaVerItens(dtaHistPedido.SelectedItem);
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            // Ver Orçamentos
            AbrirTelaVisualizacao.AbrirTelaVerOrcamentos(dtaPedidoAtual.SelectedItem);
        }
    }
}
