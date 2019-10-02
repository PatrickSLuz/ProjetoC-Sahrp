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
    /// Interaction logic for frmGerenciarAgente.xaml
    /// </summary>
    public partial class frmGerenciarAgente : Window
    {
        private Agente AgenteLogado;
        private bool EhGestor = false;

        public frmGerenciarAgente()
        {
            InitializeComponent();
            AtualizarDataGridAdmin();
            EhGestor = false;
            dtaAgentes.Items.Refresh(); // Atualizar o DataGrid
        }
        public frmGerenciarAgente(Object agenteLogado)
        {
            InitializeComponent();
            AgenteLogado = (Agente)agenteLogado;
            AtualizarDataGridGestor(AgenteLogado);
            EhGestor = true;
            dtaAgentes.Items.Refresh(); // Atualizar o DataGrid
        }
        
        private void AtualizarDataGridAdmin()
        {
            dtaAgentes.ItemsSource = AgenteDAO.ListarAgentes();// Inserindo os Agentes no DataGrid
        }

        private void AtualizarDataGridGestor(Agente agente)
        {
            dtaAgentes.ItemsSource = AgenteDAO.ListarAgentesPorSetor(agente);// Inserindo os Agentes no DataGrid
        }

        private void BtnNovoAgente_Click(object sender, RoutedEventArgs e)
        {
            frmCadastroAgente telaCadAgente; 
            if (EhGestor)
            {
                telaCadAgente = new frmCadastroAgente(AgenteLogado, 0); /* Novo Agente - Gestor */
                telaCadAgente.ShowDialog();
                AtualizarDataGridGestor(AgenteLogado);
            }
            else
            {
                telaCadAgente = new frmCadastroAgente();
                telaCadAgente.ShowDialog();
                AtualizarDataGridAdmin();
            }
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            AbrirTelaDeAlteracaoAgente();
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            dynamic ag = dtaAgentes.SelectedItem;
            if (ag == null)
            {
                
                MessageBox.Show("Por Favor, Selecione um Usuário para Excluir.", "Gerenciar Agentes", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {                
                if ((MessageBox.Show("Deseja realmente excluir " + ag.NomeAgente + "?", "Gerenciar Agente", MessageBoxButton.YesNo, MessageBoxImage.Question)) == MessageBoxResult.Yes)
                {                
                    AgenteDAO.excluir(ag);
                    if (EhGestor)
                        AtualizarDataGridGestor(AgenteLogado);
                    else
                        AtualizarDataGridAdmin();
                }
            }
        }

        private void BtnResetarSenha_Click(object sender, RoutedEventArgs e)
        {
            dynamic ag = dtaAgentes.SelectedItem;
            if (ag == null)
            {
                MessageBox.Show("Por Favor, Selecione um Usuário para Resetar a Senha.", "Gerenciar Agentes", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if ((MessageBox.Show("Deseja realmente Resetar a Senha do(a) " + ag.NomeAgente + "?", "Gerenciar Agente", MessageBoxButton.YesNo, MessageBoxImage.Question)) == MessageBoxResult.Yes)
                {
                    string senhaPadrao = SetarSenhaPadrao.CriarSenhaPadrao(ag);
                    AgenteDAO.MudarSenha(ag, senhaPadrao);
                    if (EhGestor)
                        AtualizarDataGridGestor(AgenteLogado);
                    else
                        AtualizarDataGridAdmin();
                    MessageBox.Show("Senha Resetada com Sucesso.\n\nSua nova senha será:\nPrimeira Letra do Nome Maiuscula + @ + Cargo \nExemplo: N@Cargoexemplo", "Gerenciar Agentes", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void DtaAgentes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AbrirTelaDeAlteracaoAgente();
        }

        private void AbrirTelaDeAlteracaoAgente()
        {
            // Alterar Agente
            dynamic ag = dtaAgentes.SelectedItem;
            if (ag == null)
            {
                MessageBox.Show("Por Favor, Selecione um Usuário para Editar.", "Gerenciar Agentes", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                frmCadastroAgente telaAlterarAgente;
                
                if (EhGestor)
                {
                    telaAlterarAgente = new frmCadastroAgente(ag, 1);
                    telaAlterarAgente.Title = "Editar Agente";
                    telaAlterarAgente.ShowDialog();
                    AtualizarDataGridGestor(AgenteLogado);
                }
                else
                {
                    telaAlterarAgente = new frmCadastroAgente(ag);
                    telaAlterarAgente.Title = "Editar Agente";
                    telaAlterarAgente.ShowDialog();
                    AtualizarDataGridAdmin();
                }
            }


        }
    }
}
