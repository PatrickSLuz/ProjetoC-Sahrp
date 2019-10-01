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
    /// Interaction logic for frmCadastrarProduto.xaml
    /// </summary>
    public partial class frmCadastrarProduto : Window
    {
        Produto produto;
        public frmCadastrarProduto()
        {
            InitializeComponent();

            atulizarDataGrid();
        }

        private void atulizarDataGrid() {
            dtaProdutos.ItemsSource = ProdutoDAO.ListarProdutos();// Inserindo os Produtos no DataGrid
            dtaProdutos.Items.Refresh(); // Atualizar o DataGrid
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNomeProduto.Text))
            {
                if (produto == null)
                {
                    produto = new Produto();
                }
                produto.NomeProduto = txtNomeProduto.Text;
                if (ProdutoDAO.CadastrarProduto(produto))
                {
                    MessageBox.Show("Produto Cadastrado com Sucesso!", "Cadastro de Produto", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtNomeProduto.Clear();
                    atulizarDataGrid();
                }
                else
                {
                    MessageBox.Show("Este Produto já Existe! Verifique.", "Cadastro de Produto", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Por Favor, Preencha o Nome do Produto!", "Cadastro de Produto", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DtaProdutos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
