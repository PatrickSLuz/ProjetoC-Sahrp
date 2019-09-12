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
                if (txtLogin.Text.Equals("admin") && txtSenha.Password.Equals("admin"))
                {
                    Console.WriteLine("ADMIN Logado");
                    frmAdmin telaAdmin = new frmAdmin();
                    // Para fechar a Janela atual.
                    this.Close();
                    telaAdmin.Show();
                }
                else
                {
                    Console.WriteLine("Falha Login ADMIN");
                    MessageBox.Show("Usuário e/ou Senha incorretos. Tente novamente!", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
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
    }
}
