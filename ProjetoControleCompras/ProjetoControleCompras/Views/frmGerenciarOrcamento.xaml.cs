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
    /// Interaction logic for frmGerenciarOrcamento.xaml
    /// </summary>
    public partial class frmGerenciarOrcamento : Window
    {
        public frmGerenciarOrcamento()
        {
            InitializeComponent();
            AtualizarDataGrid();
        }

        private void AtualizarDataGrid()
        {
            dtaPedidosParaCadOrcamento.ItemsSource = PedidoDAO.ListarPedidosPorStatus(Status.GetStatus(1));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dynamic d = dtaPedidosParaCadOrcamento.SelectedItem;
            if (d != null)
            {
                frmCadastroOrcamento telaCadOrcamento = new frmCadastroOrcamento(d);
                telaCadOrcamento.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por Favor, Selecione um Pedido para Cadastrar os Orçamentos.", "Gerenciar Orçamentos", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        private void BtnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            Pedido p = (Pedido)dtaPedidosParaCadOrcamento.SelectedItem;
            if (p != null)
            {
                p = PedidoDAO.BuscarPedidoPorID(p.IdPedido);
                if (p.Orcamentos != null)
                {
                    if (p.Orcamentos.Count >= 2)
                    {
                        // Atualizar Status - Passar para o Setor de Compras
                        p.Status = Status.GetStatus(2); /* Aguardando Compra do Pedido */
                        if (PedidoDAO.AtualizarStatusPedido(p))
                        {
                            MessageBox.Show("Cadastros de Orçamentos Finalizados com Sucesso.", "Gerenciar Orçamentos", MessageBoxButton.OK, MessageBoxImage.Information);
                            AtualizarDataGrid();
                        }
                        else
                            MessageBox.Show("Houve um Erro ao Validar o Pedido!", "Gerenciar Orçamentos", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show("É necessário Cadastrar no Mínimo 2 Orçamentos para um Pedido.", "Gerenciar Orçamentos", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("É necessário Cadastrar no Mínimo 2 Orçamentos para um Pedido.", "Gerenciar Orçamentos", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por Favor, Selecione um Pedido para Finalizar.", "Gerenciar Orçamentos", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Ver Itens
            AbrirTelaVisualizacao.AbrirTelaVerItens(dtaPedidosParaCadOrcamento.SelectedItem);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            // Ver Orçamentos
            AbrirTelaVisualizacao.AbrirTelaVerOrcamentos(dtaPedidosParaCadOrcamento.SelectedItem);
        }
    }
}
