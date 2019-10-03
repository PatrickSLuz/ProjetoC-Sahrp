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
    /// Interaction logic for frmVerOrcamentosPedido.xaml
    /// </summary>
    public partial class frmVerOrcamentosPedido : Window
    {
        public frmVerOrcamentosPedido(Object pedido)
        {
            InitializeComponent();
            Pedido p = (Pedido)pedido;
            lblOrcamentos.Content = "Orçamentos do Pedido ID: " + p.IdPedido;
            dtaOrcamentos.ItemsSource = OrcamentoDAO.ListarOrcamentoPorPedido(p.IdPedido);
            p = null;
        }
    }
}
