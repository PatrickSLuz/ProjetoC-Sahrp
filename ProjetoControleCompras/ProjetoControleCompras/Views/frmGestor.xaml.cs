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
            AtualizarDataGrid();
        }

        private void AtualizarDataGrid()
        {
            dtaPedidoParaValidar.ItemsSource = PedidoDAO.ListarPedidosPorSetorEStatusIgual(AgenteLogado.Setor.IdSetor, "Aguardando Validação do Gestor");
            dtaPedidosValidados.ItemsSource = PedidoDAO.ListarPedidosPorSetorEStatusDiff(AgenteLogado.Setor.IdSetor, "Aguardando Validação do Gestor");
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
                d.Status = "Aguardando Cadastro de Orçamentos";
                if (PedidoDAO.AtualizarStatusPedido(d))
                {
                    MessageBox.Show("Pedido Validado com Sucesso.", "Tela Gestor", MessageBoxButton.OK, MessageBoxImage.Information);
                    AtualizarDataGrid();
                }
                else
                    MessageBox.Show("Houve um Erro ao Validar o Pedido!", "Tela Gestor", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
        }
    }
}
