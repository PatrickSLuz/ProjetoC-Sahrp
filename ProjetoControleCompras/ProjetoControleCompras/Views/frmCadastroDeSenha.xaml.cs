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
    /// Interaction logic for frmCadastroDeSenha.xaml
    /// </summary>
    public partial class frmCadastroDeSenha : Window
    {

        private Agente agente;
        public frmCadastroDeSenha()
        {
            InitializeComponent();
        }
        public frmCadastroDeSenha(Object agente)
        {
            InitializeComponent();
            this.agente = (Agente) agente;

        }

        private void BtnSalvarSenha_Click(object sender, RoutedEventArgs e)
        {
            if (textNovaSenha.Password == textConfirmaSenha.Password)
            {
                AgenteDAO.MudarSenha(agente, textNovaSenha.Password);
                MessageBox.Show("Senha alterada com sucesso!");
            }
            else
            {
                MessageBox.Show("Senhas não são iguais \nFavor digitar novamente", "Cadastro de Senha", MessageBoxButton.OK, MessageBoxImage.Error);
                textNovaSenha.Clear();
                textConfirmaSenha.Clear();
            }
        }
    }
}
