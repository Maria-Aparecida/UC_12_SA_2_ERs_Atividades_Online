
using System.Text.RegularExpressions;
using Senai_UC_12_ER.Interfaces;

namespace Senai_UC_12_ER.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {   public string ?cnpj { get; set; }
        public string ?razaoSocial { get; set; }

        public string caminho {get; private set;} = "Database/PessoaJuridica.csv";

        public override float PagarImposto(float rendimento)
        {
            if (rendimento <= 3000)
            {
                return rendimento * 0.03f;
            }
            else if (rendimento > 3000 && rendimento <= 6000)
            {
                return rendimento * 0.05f;
            }
            else if (rendimento > 6000 && rendimento <= 10000)
            {
                return rendimento * 0.07f;
            }else
            {
                return rendimento * 0.09f;
            }
        }

        public bool ValidarCnpj(string cnpj)
        {
            if (Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)"))
            {
                if(cnpj.Length == 18){
                    if(cnpj.Substring(11,4) == "0001"){
                        return true;
                    }
                }
                else if(cnpj.Length == 14){
                    if (cnpj.Substring(8,4) == "0001"){
                        return true;
                    }
                }

            }
             return false;
        }

        public void Inserir (PessoaJuridica pj)
        {   
            VerificarPastaArquivo(caminho);

            string [] pjString = {$"{pj.nome},{pj.cnpj},{pj.razaoSocial}"};           

            File.AppendAllLines(caminho, pjString);
        }

        public List<PessoaJuridica> Ler()
        {
            List<PessoaJuridica> listaPj = new List<PessoaJuridica>();
            string [] linhas = File.ReadAllLines(caminho);

            foreach (string  cadaLinha in linhas)
            {
                string [] atributo = cadaLinha.Split(",");
                PessoaJuridica cadaPj = new PessoaJuridica();
                cadaPj.nome = atributo[0];
                cadaPj.cnpj = atributo[1];
                cadaPj.razaoSocial = atributo[2];

                listaPj.Add(cadaPj);
            }

            return listaPj;
        }

    }
}