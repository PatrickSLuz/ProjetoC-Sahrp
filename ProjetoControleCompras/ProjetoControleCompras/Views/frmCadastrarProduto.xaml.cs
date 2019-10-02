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

            atualizarDataGrid();
        }

        private void atualizarDataGrid() {
            dtaProdutos.ItemsSource = ProdutoDAO.ListarProdutos();// Inserindo os Produtos no DataGrid
            dtaProdutos.Items.Refresh(); // Atualizar o DataGrid
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNomeProduto.Text))
            {
                if (produto == null)
                    produto = new Produto();

                string action;
                if (btnCadastrar.Content == "Salvar")
                    action = "Editado";
                else
                    action = "Cadastrado";

                produto.NomeProduto = txtNomeProduto.Text;
                
                if (ProdutoDAO.CadastrarProduto(produto))
                {
                    produto = new Produto();
                    MessageBox.Show("Produto "+ action +" com Sucesso!", "Cadastro de Produto", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtNomeProduto.Clear();
                    btnCadastrar.Content = "Cadastrar";
                    atualizarDataGrid();
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
        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            dynamic d = dtaProdutos.SelectedItem;
            if (d == null)
            {

                MessageBox.Show("Por Favor, Selecione um Produto para Editar.", "Gerenciar Produtos", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                produto = d;
                btnCadastrar.Content = "Salvar";
                txtNomeProduto.Text = d.NomeProduto;
            }
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            dynamic d = dtaProdutos.SelectedItem;
            if (d == null)
            {
                MessageBox.Show("Por Favor, Selecione um Produto para Excluir.", "Gerenciar Produtos", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if ((MessageBox.Show("Deseja realmente excluir " + d.NomeProduto + "?", "Gerenciar Agente", MessageBoxButton.YesNo, MessageBoxImage.Question)) == MessageBoxResult.Yes)
                {
                    if (ProdutoDAO.ExcluirProduto(d))
                        MessageBox.Show("Produto Excluido com Sucesso!", "Gerenciar Produtos", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Erro ao Excluir Produto! Tente Novamente.", "Gerenciar Produtos", MessageBoxButton.OK, MessageBoxImage.Error);

                    atualizarDataGrid();
                }
            }
        }
    }
}
