using ProjetoControleCompras.DAL;
using ProjetoControleCompras.Models;
using ProjetoControleCompras.Utils;
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
            txtIdPedido.Text = Pedido.IdPedido.ToString();
            txtSolicitante.Text = Pedido.Solicitante.NomeAgente;
            atualizarDataGridOrcamento();
        }

        private void atualizarDataGridOrcamento()
        {
            dtaOrcamento.ItemsSource = OrcamentoDAO.ListarOrcamento();            
            dtaOrcamento.Items.Refresh(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtCNPJ.Text != "" && txtEmpresa.Text != "" && txtValor.Text != "" && txtDescricao.Text != "")
            {
                if (Validacao.ValidarCPF_CNPJ(txtCNPJ.Text))
                {
                    Orcamento orcamento = new Orcamento();
                    orcamento.NomeEmpresa = txtEmpresa.Text;
                    orcamento.CpfCnpjFornecedor = txtCNPJ.Text;
                    orcamento.Valor = Convert.ToDouble(txtValor.Text);
                    orcamento.Pedido = Pedido;
                    orcamento.Descricao = txtDescricao.Text;

                    if (OrcamentoDAO.CadastrarOrcamento(orcamento))
                    {
                        MessageBox.Show("Orçamento cadastrado com Sucesso!", "Cadastro de Orçamento", MessageBoxButton.OK, MessageBoxImage.Information);
                        txtCNPJ.Clear();
                        txtEmpresa.Clear();
                        txtValor.Clear();
                        txtDescricao.Clear();
                        atualizarDataGridOrcamento();
                    }
                    else
                    {
                        MessageBox.Show("Erro no Cadastro do Orçamento! Verifique.", "Cadastro de Orçamento", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("CNPJ Inválido! Verifique.", "Cadastro de Orçamento", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por Favor, Preencha Todos os Campos!", "Cadastro de Orçamento", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
