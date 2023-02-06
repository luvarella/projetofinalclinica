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
    public partial class AlunoWindow : Window
    {
        public AlunoWindow()
        {
            InitializeComponent();
        }

        private void InserirClick(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string nome = txtNome.Text;
            string mat = txtMatricula.Text;
            string email = txtEmail.Text;
            Aluno t = new Aluno
            {
                Id = id,
                Nome = nome,
                Matricula = mat,
                Email = email
            };
            NAluno.Inserir(t);
            ListarClick(sender, e);
        }

        private void ListarClick(object sender, RoutedEventArgs e)
        {
            listAlunos.ItemsSource = null;
            listAlunos.ItemsSource = NAluno.Listar();
        }

        private void AtualizarClick(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string nome = txtNome.Text;
            string mat = txtMatricula.Text;
            string email = txtEmail.Text;
            Aluno t = new Aluno
            {
                Id = id,
                Nome = nome,
                Matricula = mat,
                Email = email
            };
            NAluno.Atualizar(t);
            ListarClick(sender, e);
        }

        private void ExcluirClick(object sender, RoutedEventArgs e)
        {
            if (listAlunos.SelectedItem != null)
            {
                NAluno.Excluir((Aluno)listAlunos.SelectedItem);
                ListarClick(sender, e);
            }
            else
                MessageBox.Show("Selecione o aluno a ser excluído");
        }

        private void listAlunos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listAlunos.SelectedItem != null)
            {
                Aluno obj = (Aluno)listAlunos.SelectedItem;
                txtId.Text = obj.Id.ToString();
                txtNome.Text = obj.Nome;
                txtMatricula.Text = obj.Matricula;
                txtEmail.Text = obj.Email;
            }
        }
    }
}