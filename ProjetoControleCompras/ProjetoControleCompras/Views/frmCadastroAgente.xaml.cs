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
    /// Interaction logic for frmCadastroAgente.xaml
    /// </summary>
    public partial class frmCadastroAgente : Window
    {

        List<Setor> listaDeSetores = CargoSetorDAO.ListarSetores();
        List<Cargo> listaDeCargos = CargoSetorDAO.ListarCargos();

        public frmCadastroAgente()
        {
            InitializeComponent();

            // Atribuir dados cadastrados do BD em um ComboBox    
            this.comboBoxCargo.ItemsSource = listaDeCargos;

            // Atribuir dados cadastrados do BD em um ComboBox
            this.comboBoxSetor.ItemsSource = listaDeSetores;
        }

        private void BtnCadAgente_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNomeAgente.Text) && !string.IsNullOrEmpty(comboBoxCargo.Text) 
                && !string.IsNullOrEmpty(comboBoxSetor.Text) && !string.IsNullOrEmpty(txtLogin.Text))
            {
                Agente agente = new Agente();
                Cargo cargo = new Cargo();
                Setor setor = new Setor();

                agente.NomeAgente = txtNomeAgente.Text;

                foreach (Cargo cargosCadastrados in listaDeCargos)
                {
                    if (comboBoxCargo.Text.Equals(cargosCadastrados.NomeCargo))
                        cargo = cargosCadastrados;
                }
                agente.Cargo = cargo;

                foreach (Setor setoresCadastrados in listaDeSetores)
                {
                    if (comboBoxSetor.Text.Equals(setoresCadastrados.NomeSetor))
                        setor = setoresCadastrados;
                }
                agente.Setor = setor;

                agente.Login = txtLogin.Text;

                string nome_sem_espaco = txtNomeAgente.Text.Replace(" ", "");
                nome_sem_espaco = char.ToUpper(nome_sem_espaco[0]) + nome_sem_espaco.Substring(1).ToLower();

                agente.Senha = nome_sem_espaco + "@" + agente.Cargo;

                if (AgenteDAO.CadastrarAgente(agente))
                {
                    MessageBox.Show("Agente Cadastrado com Sucesso! \nSua primeira senha será: Nome+@+Cargo \nPrimeira letra do nome e cargo maiuscula \nExemplo: Nomeexemplo@Cargoexemplo", "Cadastro de Agente", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Ja existe um Agente cadastrado com este Login!", "Cadastro de Agente", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Por Favor, Preencha Todos os Campos!", "Cadastro de Agente", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
