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
    /// Interaction logic for frmUsuario.xaml
    /// </summary>
    public partial class frmUsuario : Window
    {
        private Agente AgenteLogado;

        public frmUsuario(Object agenteLogado)
        {
            InitializeComponent();

            AgenteLogado = (Agente)agenteLogado;
            dtaHistPedido.ItemsSource = PedidoDAO.BuscarPedidoPorAgente(AgenteLogado);
            dtaHistPedido.Items.Refresh();
        }

        private void BtnNovoPedido_Click(object sender, RoutedEventArgs e)
        {
            frmCadastroPedido telaCadPedido = new frmCadastroPedido(AgenteLogado);
            telaCadPedido.ShowDialog();
        }
    }
}
