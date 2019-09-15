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
    /// Interaction logic for frmCadastroCargoSetor.xaml
    /// </summary>
    public partial class frmCadastroCargoSetor : Window
    {
        public frmCadastroCargoSetor()
        {
            InitializeComponent();
        }

        private void BtnCadSetor_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Clicou no Botão Cad Setor");

            Setor setor = new Setor();

            if (!string.IsNullOrEmpty(txtNome.Text))
            {
                setor.NomeSetor = txtNome.Text;
                if (CargoSetorDAO.CadastrarSetor(setor))
                {
                    MessageBox.Show("Setor Cadastrado com Sucesso!", "Cadastro de Setor", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Este Setor já esta Cadastrado!", "Cadastro de Setor", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                txtNome.Clear();
            }
            else
            {
                MessageBox.Show("Por Favor, Insira o Nome do Setor!", "Cadastro de Setor", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtNome.Clear();
            }
        }

        private void BtnCadCargo_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Clicou no Botão Cad Cargo");

            Cargo cargo = new Cargo();

            if (!string.IsNullOrEmpty(txtNome.Text))
            {
                cargo.NomeCargo = txtNome.Text;
                if (CargoSetorDAO.CadastrarCargo(cargo))
                {
                    MessageBox.Show("Cargo Cadastrado com Sucesso!", "Cadastro de Cargo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Este Cargo já esta Cadastrado!", "Cadastro de Cargo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                txtNome.Clear();
            }
            else
            {
                MessageBox.Show("Por Favor, Insira o Nome do Cargo!", "Cadastro de Cargo", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtNome.Clear();
            }
        }
    }
}
