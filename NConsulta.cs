using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace projetofinal
{
    static class NConsulta 
    {
        //private Turma[] turmas = new Turma[10];
        private static List<> consultas = new List<Consulta>();
        public static void Inserir(Consulta c)
        {
            Abrir();
            // Procurar o maior Id
            int id = 0;
            foreach (Consulta obj in consultas)
                if (obj.Id > id) id = obj.Id;
            c.Id = id + 1;
            consultas.Add(c);
            Salvar();
        }
        public static List<Consulta> Listar()
        {
            Abrir();
            return consultas;
        }
        public static void Atualizar(Consulta c)
        {
            Abrir();
            // Percorrer a lista de turma procurando o id informado (t.Id)
            foreach (Consulta obj in consultas)
                if (obj.Id == c.Id) 
                {
                    obj.Descricao = c.Descricao; 
                    obj.Data = c.Data;
                    obj.Local = c.Local;
                    obj.Hora = c.Hora;
                }
            Salvar();
        }
        public static void Excluir(Consulta c)
        {
            Abrir();
            // Percorrer a lista de turma procurando o id informado (t.Id)
            Consulta x = null;
            foreach (Consulta obj in consultas)
                if (obj.Id == m.Id) x = obj;
            if (x != null) consultas.Remove(x);
            Salvar();
        }
        public static void Abrir()
        {
            StreamReader f = null;
            try
            {
                // Objeto que serializa (transforma) uma lista de turmas em um texto em XML
                XmlSerializer xml = new XmlSerializer(typeof(List<Consulta>));
                // Objeto que abre um texto em um arquivo
                f = new StreamReader("./consultas.xml");
                // Chama a operação de desserialização informando a origem do texto XML
                consultas = (List<Consulta>)xml.Deserialize(f);
            }
            catch
            {
                consultas = new List<Consulta>();
            }
            // Fecha o arquivo
            if (f != null) f.Close();
        }
        public static void Salvar()
        {
            // Objeto que serializa (transforma) uma lista de turmas em um texto em XML
            XmlSerializer xml = new XmlSerializer(typeof(List<Consulta>));
            // Objeto que grava um texto em um arquivo
            StreamWriter f = new StreamWriter("./consultas.xml", false);
            // Chama a operação de serialização informando o destino do texto XML
            xml.Serialize(f, consultas);
            // Fecha o arquivo
            f.Close();
        }
        public static void Agendar(Paciente p, Medico m)
        {
            p.Id = m.Id;
            Atualizar(p);
        }
        public static List<Medico> Listar(Medico m)
        {
            Abrir();
            // Percorrer a lista de alunos procurando o id da turma informada
            List<Medico> agenda = new List<Medico>();
            foreach (Paciente obj in pacientes)
                if (obj.IdMedico == m.Id) agenda.Add(obj);
            return agenda;
        }

    }
}
}
