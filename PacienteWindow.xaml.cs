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

namespace projetofinal
{
    /// <summary>
    /// Lógica interna para AlunoWindow.xaml
    /// </summary>
    public partial class Paciente : Window
    {
        public Paciente()
        {
            InitializeComponent();
        }

        private void InserirClick(object sender, RoutedEventArgs e)
        {
            // Novo objeto com os dados da turma que será inserida
            Paciente t = new Paciente();
            t.Id = int.Parse(txtId.Text);
            t.Nome = txtNome.Text;
            t.Cpf = txtCpf.Text;
            t.Email = txtEmail.Text;
            t.Estado = txtEstado.Text;
            t.Cidade = txtCidade.Text;
            t.Idade = txtIdade.Text;
            // Inserir a turma na lista de turmas
            NPaciente.Inserir(t);
            // Lista a turma inserida
            ListarClick(sender, e);
        }

        private void ListarClick(object sender, RoutedEventArgs e)
        {
            listPacientes.ItemsSource = null;
            listPacientes.ItemsSource = NPaciente.Listar();
        }

        private void AtualizarClick(object sender, RoutedEventArgs e)
        {
            // Novo objeto com os dados da turma que será inserida
            Paciente t = new Paciente();
            t.Id = int.Parse(txtId.Text);
            t.Nome = txtNome.Text;
            t.Cpf = txtCpf.Text;
            t.Email = txtEmail.Text;
            t.Estado = txtEstado.Text;
            t.Cidade = txtCidade.Text;
            t.Idade = txtIdade.Text;
            // Inserir a turma na lista de turmas
            NPaciente.Atualizar(t);
            // Lista as turmas cadastradas
            ListarClick(sender, e);
        }

        private void ExcluirClick(object sender, RoutedEventArgs e)
        {
            // Novo objeto com os dados da turma que será inserida
            Paciente t = new Paciente();
            t.Id = int.Parse(txtId.Text);
            // Inserir a turma na lista de turmas
            NPaciente.Excluir(t);
            // Lista as turmas cadastradas
            ListarClick(sender, e);
        }

        private void listPacientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listPacientes.SelectedItem != null)
            {
                Paciente obj = (Paciente)listPacientes.SelectedItem;
                txtId.Text = obj.Id.ToString();
                txtNome.Text = obj.Nome;
                txtEmail.Text = obj.Email;
                txtCpf = obj.Cpf;
                txtEstado = obj.Estado;
                txtCidade = obj.Cidade;
                txt.Idade = obj.Idade;
            }
        }

        private void txtIdade_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
