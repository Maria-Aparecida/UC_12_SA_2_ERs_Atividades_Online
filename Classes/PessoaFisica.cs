using Senai_UC_12_ER.Interfaces;

namespace Senai_UC_12_ER.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        public string ?cpf { get; set; }
        
        public string ?dataNascimento { get; set; }


        public bool ValidarDataNascimento(DateTime dataNascimento){

            DateTime dataAtual = DateTime.Today;

            double anos = (dataAtual - dataNascimento).TotalDays/365;

            if(anos >=18){
                //Console.WriteLine($"{dataNascimento}");
                return true;
                
            }
            return false;
        }
        public bool ValidarDataNascimento(string dataNascimento){
            DateTime dataConvertida;
            if(DateTime.TryParse(dataNascimento, out dataConvertida)){
               // Console.WriteLine($"{dataConvertida}");

                DateTime dataAtual = DateTime.Today;
                double anos = (dataAtual - dataConvertida).TotalDays/365;
                if(anos >= 18 && anos < 100){
                    return true;
                }
                return false;   
            }
            return false;
        }
            public override float PagarImposto(float rendimento)
                {
                if (rendimento <= 1500)
                {
                   return 0; 

                }else if (rendimento > 1500 && rendimento <= 3500)
                {
                  return (rendimento / 1000) * 2; 

                }else if (rendimento > 3500 && rendimento < 6000)
                {
                  return (rendimento / 1000) * 3.5f; 
                    
                }else
                {
                  return (rendimento/1000) * 5; 
                    
                }
            }
        
        
        
    }
}