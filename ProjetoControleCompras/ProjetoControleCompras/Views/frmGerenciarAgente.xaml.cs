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
    /// Interaction logic for frmGerenciarAgente.xaml
    /// </summary>
    public partial class frmGerenciarAgente : Window
    {
        public frmGerenciarAgente()
        {
            InitializeComponent();
            AtualizarDataGridAdmin();
            dtaAgentes.Items.Refresh(); // Atualizar o DataGrid
        }
        public frmGerenciarAgente(Object agenteLogado)
        {
            InitializeComponent();
            AtualizarDataGridGestor((Agente)agenteLogado);
            dtaAgentes.Items.Refresh(); // Atualizar o DataGrid
        }

        private void atualizarGridAgente()
        {
            dtaAgentes.ItemsSource = AgenteDAO.ListarAgentes();// Inserindo os Agentes no DataGrid
            atualizarGridAgente();
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
            frmCadastroAgente telaCadAgente = new frmCadastroAgente();
            telaCadAgente.ShowDialog();
            atualizarGridAgente();            
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            AbrirTelaDeAlteracaoAgente();
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnResetarSenha_Click(object sender, RoutedEventArgs e)
        {

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
                frmCadastroAgente telaAlterarAgente = new frmCadastroAgente(ag);
                telaAlterarAgente.ShowDialog();
                dtaAgentes.Items.Refresh();
            }
        }
    }
}
