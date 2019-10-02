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
        private Agente AgenteLogado;

        public frmCadastroPedido(Object agenteLogado)
        {
            InitializeComponent();

            AgenteLogado = (Agente) agenteLogado;

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

        private void BtnRegPedido_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDescricao.Text))
            {
                if (itensPedido.Count > 0)
                {
                    Pedido pedido = new Pedido();
                    pedido.Solicitante = AgenteLogado;
                    pedido.ItensPedido = itensPedido;
                    pedido.DescMot = txtDescricao.Text;
                    if (AgenteLogado.Setor.NomeSetor == "Diretoria")
                    {
                        pedido.Status = Status.GetStatus(1);
                    }
                    else
                    {
                        pedido.Status = Status.GetStatus(0);
                    }
                    if (PedidoDAO.CadastrarPedido(pedido))
                    {
                        MessageBox.Show("Seu Pedido foi Cadastrado com Sucesso!", "Cadastrar Pedido", MessageBoxButton.OK, MessageBoxImage.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao Cadastrar o Pedido! Tente Novamente", "Cadastrar Pedido", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por Favor, Informe o(s) Produto(s) para o Pedido!", "Cadastrar Pedido", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por Favor, Preencha a Descrição/Motivo deste Pedido!", "Cadastrar Pedido", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

 
    }
}
