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
        }

        private void DataGrid_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            MessageBox.Show("Clicou com botao direto");
        }
    }
}
