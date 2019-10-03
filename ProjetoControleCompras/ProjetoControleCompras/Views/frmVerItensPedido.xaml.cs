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
    /// Interaction logic for frmVerItensPedido.xaml
    /// </summary>
    public partial class frmVerItensPedido : Window
    {
        private Pedido Pedido;

        public frmVerItensPedido(Object pedido)
        {
            InitializeComponent();

            Pedido = (Pedido)pedido;

            lblIdPedido.Content = "Itens do Pedido: " + Pedido.IdPedido;

            dtaItensPedido.ItemsSource = Pedido.ItensPedido;
        }
    }
}
