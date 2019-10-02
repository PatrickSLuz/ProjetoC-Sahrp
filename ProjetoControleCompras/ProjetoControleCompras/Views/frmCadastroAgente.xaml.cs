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
    /// Interaction logic for frmCadastroAgente.xaml
    /// </summary>
    public partial class frmCadastroAgente : Window
    {
        List<Setor> listaDeSetores;
        List<Cargo> listaDeCargos = CargoSetorDAO.ListarCargos();

        Agente agente;

        // Novo Agente - Admin
        public frmCadastroAgente()
        {
            InitializeComponent();
            listaDeSetores = new List<Setor>();
            listaDeSetores = CargoSetorDAO.ListarSetores();

            AtualizarComboBox();
        }
        // Editar Agente - Admin
        public frmCadastroAgente(Object agente)
        {
            InitializeComponent();

            this.agente = (Agente) agente;

            listaDeSetores = new List<Setor>();
            listaDeSetores = CargoSetorDAO.ListarSetores();

            PreencherDadosEditar();

            AtualizarComboBox();
        }

        // Gestor
        public frmCadastroAgente(Object agente, int i)/* 0: NOVO | 1: EDITAR*/
        {
            InitializeComponent();
            this.agente = (Agente)agente;
            listaDeSetores = new List<Setor>();
            listaDeSetores.Add(CargoSetorDAO.BuscarSetorDoAgente(this.agente));
            if (i == 1)
            {
                PreencherDadosEditar();
            }
            AtualizarComboBox();
        }

        private void BtnCadAgente_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNomeAgente.Text) && !string.IsNullOrEmpty(comboBoxCargo.Text) 
                && !string.IsNullOrEmpty(comboBoxSetor.Text) && !string.IsNullOrEmpty(txtLogin.Text))
            {
                Cargo cargo = new Cargo();
                Setor setor = new Setor();

                if (agente == null)
                    agente = new Agente();

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

                agente.Senha = SetarSenhaPadrao.CriarSenhaPadrao(agente);

                if (AgenteDAO.CadastrarAgente(agente))
                {
                    MessageBox.Show("Agente Cadastrado com Sucesso! \n\nSua primeira senha será:\nPrimeira Letra do Nome Maiuscula + @ + Cargo \nExemplo: N@Cargoexemplo", "Cadastro de Agente", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
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

        private void PreencherDadosEditar()
        {
            txtNomeAgente.Text = this.agente.NomeAgente;
            comboBoxCargo.SelectedValue = this.agente.Cargo.NomeCargo.ToString();
            comboBoxSetor.SelectedValue = this.agente.Setor.NomeSetor.ToString();
            txtLogin.Text = this.agente.Login;
            btnCadAgente.Content = "Salvar";
        }

        private void AtualizarComboBox()
        {
            // Atribuir dados cadastrados do BD em um ComboBox    
            this.comboBoxCargo.ItemsSource = listaDeCargos;
            // Atribuir dados cadastrados do BD em um ComboBox
            this.comboBoxSetor.ItemsSource = listaDeSetores;
        }
    }
}
