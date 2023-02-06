using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace projetofinal
{
    class NMedico
    {
        private static List<Medico> medicos = new List<Medico>();
        public static void Inserir(Medico t)
        {
            Abrir();
            // Procurar o maior Id
            int id = 0;
            foreach (Medico obj in medicos)
                if (obj.Id > id) id = obj.Id;
            t.Id = id + 1;
            medicos.Add(t);
            Salvar();
        }
        public static List<Medico> Listar()
        {
            Abrir();
            return medicos;
        }
        public static void Atualizar(Medico t)
        {
            Abrir();
            // Percorrer a lista de turma procurando o id informado (t.Id)
            foreach (Medico obj in medicos)
                if (obj.Id == t.Id)
                {
                    obj.Nome = t.Nome;
                    obj.Cpf = t.Cpf;
                    obj.Email = t.Email;
                    obj.Idade = t.Idade;
                    obj.Especializacao = t.Especializacao;
                }
            Salvar();
        }
        public static void Excluir(Medico t)
        {
            Abrir();
            // Percorrer a lista de turma procurando o id informado (t.Id)
            Medico x = null;
            foreach (Medico obj in medicos)
                if (obj.Id == t.Id) x = obj;
            if (x != null) medicos.Remove(x);
            Salvar();
        }
        public static void Abrir()
        {
            StreamReader f = null;
            try
            {
                // Objeto que serializa (transforma) uma lista de alunos em um texto em XML
                XmlSerializer xml = new XmlSerializer(typeof(List<Medico>));
                // Objeto que abre um texto em um arquivo
                f = new StreamReader("./medicos.xml");
                // Chama a operação de desserialização informando a origem do texto XML
                medicos = (List<Medico>)xml.Deserialize(f);
            }
            {
                medicos = new List<Medico>();
            }
            // Fecha o arquivo
            if (f != null) f.Close();
        }
        public static void Salvar()
        {
            // Objeto que serializa (transforma) uma lista de alunos em um texto em XML
            XmlSerializer xml = new XmlSerializer(typeof(List<Medico>));
            // Objeto que grava um texto em um arquivo
            StreamWriter f = new StreamWriter("./medicos.xml", false);
            // Chama a operação de serialização informando o destino do texto XML
            xml.Serialize(f, medicos);
            // Fecha o arquivo
            f.Close();
        }

    }
}


