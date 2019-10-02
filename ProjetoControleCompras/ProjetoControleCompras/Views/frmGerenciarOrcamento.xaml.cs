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
    /// Interaction logic for frmGerenciarOrcamento.xaml
    /// </summary>
    public partial class frmGerenciarOrcamento : Window
    {
        public frmGerenciarOrcamento()
        {
            InitializeComponent();
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
    }
}
