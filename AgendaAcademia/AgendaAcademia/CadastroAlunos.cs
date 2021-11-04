using System.Collections.Generic;
using System.IO;

namespace AgendaAcademia
{
    public class CadastroAlunos
    {

        private static string CaminhoArquivo = "C:\\AgendamentoCrossfit\\Alunos\\alunos.txt";

        public void CadastrarAluno(Aluno aluno)
        {
            if (!File.Exists(CaminhoArquivo))
            {
                File.Create(CaminhoArquivo);
            }

            using (StreamWriter streamWriter = new StreamWriter(File.OpenWrite(CaminhoArquivo)))
            {
                string registroAluno = aluno.Cpf + "/" + aluno.Nome + "/" + aluno.Idade;
                streamWriter.WriteLine(registroAluno);
            }
        }

        public IList<Aluno> ListarAlunos()
        {
            IList<Aluno> alunos = null;

            if (File.Exists(CaminhoArquivo))
            {
                alunos = new List<Aluno>();
                string[] registrosAlunos = File.ReadAllLines(CaminhoArquivo);

                foreach (string linhaAluno in registrosAlunos)
                {
                    string[] dadosAluno = linhaAluno.Split("/");
                    string cpf = dadosAluno[0];
                    string nome = dadosAluno[1];
                    string idade = dadosAluno[2];

                    var aluno = new Aluno
                    {
                        Cpf = cpf,
                        Nome = nome,
                        Idade = int.Parse(idade)
                    };

                    alunos.Add(aluno);
                }
            }

            return alunos;
        }

        public Aluno ObterPorCpf(string cpfBuscado)
        {
            if (File.Exists(CaminhoArquivo))
            {
                string[] registrosAlunos = File.ReadAllLines(CaminhoArquivo);

                foreach (string linhaAluno in registrosAlunos)
                {
                    string[] dadosAluno = linhaAluno.Split("/");
                    string cpf = dadosAluno[0];

                    if (cpf == cpfBuscado)
                    {
                        string nome = dadosAluno[1];
                        string idade = dadosAluno[2];

                        var aluno = new Aluno
                        {
                            Cpf = cpf,
                            Nome = nome,
                            Idade = int.Parse(idade)
                        };

                        return aluno;
                    }
                }
            }

            return null;
        }
    }
}
