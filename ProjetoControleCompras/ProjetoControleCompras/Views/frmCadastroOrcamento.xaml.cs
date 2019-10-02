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
    /// Interaction logic for frmCadastroOrcamento.xaml
    /// </summary>
    public partial class frmCadastroOrcamento : Window
    {
        Pedido Pedido = new Pedido();
        public frmCadastroOrcamento(Object pedido)
        {
            InitializeComponent();
            Pedido = (Pedido)pedido;
            atualizarDataGridOrcamento();
        }

        private void atualizarDataGridOrcamento()
        {
            dtaOrcamento.ItemsSource = OrcamentoDAO.ListarOrcamento();            
            dtaOrcamento.Items.Refresh(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtCNPJ.Text != "" && txtEmpresa.Text != "" && txtValor.Text != "")
            {
                MessageBox.Show("Orçamento cadastrado com Sucesso!", "Cadastro de Orçamento", MessageBoxButton.OK, MessageBoxImage.Information);
                txtCNPJ.Clear();
                txtEmpresa.Clear();
                txtValor.Clear();
                btnCadastrar.Content = "Cadastrar";
                atualizarDataGridOrcamento();
            }
            else
            {
                MessageBox.Show("FAVOR PREENCHER TODOS OS CAMPOS!!!");
            }
        }
    }
}
