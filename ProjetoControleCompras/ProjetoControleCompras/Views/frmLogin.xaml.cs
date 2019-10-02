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
    /// Interaction logic for frmLogin.xaml
    /// </summary>
    public partial class frmLogin : Window
    {
        public frmLogin()
        {
            InitializeComponent();
            txtLogin.Focus(); // Setando o Foco para o Field do Login qnd a tela for aberta
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLogin.Text) && !string.IsNullOrEmpty(txtSenha.Password))
            {
                Agente ag = new Agente();
                ag.Login = txtLogin.Text;
                ag = AgenteDAO.BuscarAgentePorLogin(ag);

                if (ag != null)
                {
                    if (ag.Login.Equals(txtLogin.Text) && ag.Senha.Equals(txtSenha.Password))
                    {
                        VerificarCargoESetor(ag);
                    }
                    else
                    {
                        MessageBox.Show("Usuário e/ou Senha incorretos. Tente novamente!", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Usuário não Encontrado. Verifique!", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtLogin.Clear();
                    txtSenha.Clear();
                }
            }
            else
            {
                MessageBox.Show("Por Favor, Preencha todos os campos e tente novamente!", "Login", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            txtLogin.Clear();
            txtSenha.Clear();
        }

        private void VerificarCargoESetor(Agente ag)
        {
            if (ag.Cargo.NomeCargo.Equals("Administrador"))
            {
                // Logar como Admin
                frmAdmin telaAdmin = new frmAdmin(ag);
                Close();
                telaAdmin.Show();
            }
            if (ag.Cargo.NomeCargo.Equals("Usuario"))
            {
                // Logar como Usuario
                VerificarPrimeiraSenha(ag);
                frmUsuario telaUsuario = new frmUsuario(ag);
                Close();
                telaUsuario.ShowDialog();
            }
            if (ag.Cargo.NomeCargo.Equals("Gestor"))
            {
                // Logar como Gestor
                VerificarPrimeiraSenha(ag);
                frmGestor telaGestor = new frmGestor(ag);
                Close();
                telaGestor.ShowDialog();

                if (ag.Setor.NomeSetor.Equals("Financeiro"))
                {
                    
                }
                else if (ag.Setor.NomeSetor.Equals("Compras"))
                {

                }
            }
        }

        private void VerificarPrimeiraSenha(Agente ag)
        {
            string SenhaPadrao = SetarSenhaPadrao.CriarSenhaPadrao(ag);

            if (ag.Senha.Equals(SenhaPadrao) )
            {
                frmCadastroDeSenha TelaCadastroDeSenha = new frmCadastroDeSenha(ag);
                TelaCadastroDeSenha.ShowDialog();
            }
        }

        private void TxtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                // Quando apertar o Enter no TextBox da Senha
            }
        }
    }
}
