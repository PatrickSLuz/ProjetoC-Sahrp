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
    /// Interaction logic for frmCadastroPedido.xaml
    /// </summary>
    public partial class frmCadastroPedido : Window
    {
        private List<ItemPedido> itensPedido = new List<ItemPedido>(); // Lista para alimentar o DataGrid
        public frmCadastroPedido()
        {
            InitializeComponent();

            cboProdutos.ItemsSource = ProdutoDAO.ListarProdutos();
            cboProdutos.DisplayMemberPath = "NomeProduto"; // Propriedade do Objeto para ser exibido dentro do ComboBox
            cboProdutos.SelectedValuePath = "IdProduto"; // Capturar o item que foi selecionado
        }

        private void BtnAddProduto_Click(object sender, RoutedEventArgs e)
        {
            if (!txtQuantidade.Text.Equals(""))
            {
                Produto p = ProdutoDAO.BuscarProdutoPorID(Convert.ToInt32(cboProdutos.SelectedValue));
                if (p != null)
                {
                    ItemPedido it = new ItemPedido();
                    it.Produtos = p;
                    it.Quantidade = Convert.ToInt32(txtQuantidade.Text);
                    
                    itensPedido.Add(it);
                    dtaProdutos.ItemsSource = itensPedido; // Inserindo os Produtos no DataGrid
                    dtaProdutos.Items.Refresh(); // Atualizar o DataGrid
                }
                else
                {
                    MessageBox.Show("Produto não Encontrado!", "Adicionar Produto", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Por Favor, Insira a Quantidade para este Produto!", "Adicionar Produto", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
