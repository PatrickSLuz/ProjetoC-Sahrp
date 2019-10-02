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
    /// Interaction logic for frmGestor.xaml
    /// </summary>
    public partial class frmGestor : Window
    {
        private Agente AgenteLogado;
        public frmGestor(Object agenteLogado)
        {
            InitializeComponent();
            AgenteLogado = (Agente)agenteLogado;
            Atualizar_dtaPedidosValidados_PorSetorEStatus(4);
            Atualizar_dtaPedidoParaValidar_PorSetorEStatus(0);
            if (AgenteLogado.Setor.NomeSetor.Equals("Financeiro"))
            {
                MessageBox.Show("GESTOR DO SETOR FINANCEIRO");
                btnCadOrcamento.Visibility = Visibility.Visible;
            }
            else if (AgenteLogado.Setor.NomeSetor.Equals("Compras"))
            {
                MessageBox.Show("GESTOR DO SETOR COMPRAS");
                btnCadOrcamento.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("GESTOR NÃO DO SETOR FINANCEIRO E COMPRAS");
                btnCadOrcamento.Visibility = Visibility.Hidden;
            }   
        }

        private void Atualizar_dtaPedidosValidados_PorSetorEStatus(int index)
        {
            dtaPedidosValidados.ItemsSource = PedidoDAO.ListarPedidosPorSetorEStatusIgual(AgenteLogado.Setor.IdSetor, Status.GetStatus(index));
        }
        private void Atualizar_dtaPedidoParaValidar_PorSetorEStatus(int index)
        {
            dtaPedidoParaValidar.ItemsSource = PedidoDAO.ListarPedidosPorSetorEStatusIgual(AgenteLogado.Setor.IdSetor, Status.GetStatus(index));
        }

        private void BtnGerenciarAgentes_Click(object sender, RoutedEventArgs e)
        {
            frmGerenciarAgente telaGerenciarAgente = new frmGerenciarAgente(AgenteLogado);
            telaGerenciarAgente.ShowDialog();
        }

        private void BtnValidarPedido_Click(object sender, RoutedEventArgs e)
        {
            dynamic d = dtaPedidoParaValidar.SelectedItem;
            if (d == null)
            {
                MessageBox.Show("Por Favor, Selecione um Pedido para Validar.", "Tela Gestor", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                d.Status = Status.GetStatus(1);
                if (PedidoDAO.AtualizarStatusPedido(d))
                {
                    MessageBox.Show("Pedido Validado com Sucesso.", "Tela Gestor", MessageBoxButton.OK, MessageBoxImage.Information);
                    Atualizar_dtaPedidosValidados_PorSetorEStatus(0);
                }
                else
                    MessageBox.Show("Houve um Erro ao Validar o Pedido!", "Tela Gestor", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
        }

        private void BtnCadOrcamento_Click(object sender, RoutedEventArgs e)
        {
            frmGerenciarOrcamento telaGerenciarOrcamento = new frmGerenciarOrcamento();
            telaGerenciarOrcamento.ShowDialog();
        }
    }
}
