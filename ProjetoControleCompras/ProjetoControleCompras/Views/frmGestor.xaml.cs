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
        }

        private void BtnGerenciarAgentes_Click(object sender, RoutedEventArgs e)
        {
            frmGerenciarAgente telaGerenciarAgente = new frmGerenciarAgente(AgenteLogado);
            telaGerenciarAgente.ShowDialog();
        }
    }
}
