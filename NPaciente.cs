using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace projetofinal
{
    class NPaciente
    {
        private static List<Paciente> pacientes = new List<Paciente>();
        public static void Inserir(Paciente t)
        {
            Abrir();
            // Procurar o maior Id
            int id = 0;
            foreach (Paciente obj in pacientes)
                if (obj.Id > id) id = obj.Id;
            t.Id = id + 1;
            pacientes.Add(t);
            Salvar();
        }
        public static List<Paciente> Listar()
        {
            Abrir();
            return pacientes;
        }
        public static void Atualizar(Paciente t)
        {
            Abrir();
            // Percorrer a lista de turma procurando o id informado (t.Id)
            foreach (Paciente obj in pacientes)
                if (obj.Id == t.Id)
                {
                    obj.Nome = t.Nome;
                    obj.Cpf = t.Cpf;
                    obj.Email = t.Email;
                    obj.Idade = t.Idade;
                    obj.Estado = t.Estado;
                    obj.Cidade = t.Cidade;
                    obj.IdMedico = t.IdMedico;
                }
            Salvar();
        }
        public static void Excluir(Paciente t)
        {
            Abrir();
            // Percorrer a lista de turma procurando o id informado (t.Id)
            Paciente x = null;
            foreach (Paciente obj in pacientes)
                if (obj.Id == t.Id) x = obj;
            if (x != null) pacientes.Remove(x);
            Salvar();
        }
        public static void Abrir()
        {
            StreamReader f = null;
            try
            {
                // Objeto que serializa (transforma) uma lista de alunos em um texto em XML
                XmlSerializer xml = new XmlSerializer(typeof(List<Paciente>));
                // Objeto que abre um texto em um arquivo
                f = new StreamReader("./pacientes.xml");
                // Chama a operação de desserialização informando a origem do texto XML
                pacientes = (List<Paciente>)xml.Deserialize(f);
            }
            catch
            {
                pacientes = new List<Paciente>();
            }
            // Fecha o arquivo
            if (f != null) f.Close();
        }
        public static void Salvar()
        {
            // Objeto que serializa (transforma) uma lista de alunos em um texto em XML
            XmlSerializer xml = new XmlSerializer(typeof(List<Paciente>));
            // Objeto que grava um texto em um arquivo
            StreamWriter f = new StreamWriter("./pacientes.xml", false);
            // Chama a operação de serialização informando o destino do texto XML
            xml.Serialize(f, pacientes);
            // Fecha o arquivo
            f.Close();
        }
       