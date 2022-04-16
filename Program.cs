using Senai_UC_12_ER.Classes;


Console.WriteLine(@$"
====================================================
|                                                  |
|        Bem vindo ao sistema de cadastro de       |
|           Pessoa Físicas e Jurídicas             |
|                                                  | 
====================================================
");

BarraCarregamento("Carregando", 300);

List<PessoaFisica> listaPf = new List<PessoaFisica>();
//List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

string? opcao;
do
{
    Console.Clear();
    Console.WriteLine(@$"
==============================================
|       Escolha uma das opções abaixo        |
----------------------------------------------
|           1 - Pessoa Física                |
|           2 - Pessoa Juridíca              |
|                                            |
|           0 - Sair                         |
==============================================
    ");

    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":

            PessoaFisica metodoPf = new PessoaFisica();

            string? opcaoPf;
            do
            {   Console.Clear();
                Console.WriteLine(@$"
    ===========================================
    |      Escolha uma das opções abaixo:     |
    |-----------------------------------------|
    |        1 - Cadastrar Pessoa Física      |
    |        2 - Listar Pessoas Físicas       |
    |                                         |
    |        0 - Voltar ao menu anterior      |
    ===========================================

    ");
                opcaoPf = Console.ReadLine();

                switch (opcaoPf)
                {
                    case "1":
                        PessoaFisica novaPf = new PessoaFisica();
                        Endereco novoEnd = new Endereco();

                        Console.Clear();
                        Console.WriteLine($"Digite o nome da pessoa física que deseja cadastrar ");
                        novaPf.nome = Console.ReadLine();
                        
                        bool dataValida;
                        do
                        {   Console.Clear();
                            Console.WriteLine($"Digite a data de nascimento Ex: dd/mm/aaaa ");
                            string? dataNasc = Console.ReadLine();

                            dataValida = metodoPf.ValidarDataNascimento(dataNasc);
                            if (dataValida){
                                novaPf.dataNascimento = dataNasc;
                            } else{
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Clear();
                                Console.WriteLine($"Data digitada inválida, digite uma data válida por favor");
                                Console.ResetColor();  
                            };
                            
                        } while (dataValida == false);

                        Console.Clear();
                        Console.WriteLine($"Digite o número do CPF");
                        novaPf.cpf= Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine($"Digite o rendimento mensal (Somente números)  ");
                        novaPf.rendimento = float.Parse(Console.ReadLine());

                        Console.Clear();
                        Console.WriteLine($"Digite o logradouro");
                        novoEnd.logradouro= Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine($"Digite o número do endereço");
                        novoEnd.numero = int.Parse(Console.ReadLine());

                        Console.Clear();
                        Console.WriteLine($"Digite o complemento do endereço(Aperte enter para vazio) ");
                        novoEnd.complemento = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine($"Este endereço é comercial: S/N");
                        string EndCom = Console.ReadLine().ToUpper();

                        if (EndCom == "S")
                        {
                            novoEnd.endComercial = true;
                        } else 
                        {
                            novoEnd.endComercial = false;
                        }                       

                        novaPf.endereco = novoEnd;
                      
                        //listaPf.Add(novaPf);

                        //StreamWriter sw = new StreamWriter($"{novaPf.nome}.text");
                        //sw.Write(novaPf.nome);
                        //sw.Close();
                        

                        using (StreamWriter sw = new StreamWriter($"{novaPf.nome}.txt"))
                        {
                            sw.WriteLine(@$"
                            Nome:{novaPf.nome}
                            CPF: {novaPf.cpf}
                            Data de Nascimento: {novaPf.dataNascimento}
                            Rendimento: {novaPf.rendimento}
                            Endereço: {novaPf.endereco.logradouro},{" " + novaPf.endereco.numero}
                            
                            ");
                        }

                        Console.Clear();
                        Console.WriteLine($"Cadastro realizado com sucesso!");
                        Thread.Sleep(3000);


                        //PessoaFisica novaPF = new PessoaFisica();
                        //Endereco novoEnd =  new Endereco();

                        //novaPF.nome = "Aparecida";
                        //novaPF.dataNascimento = ("13/08;/1987");
                        //novaPF.cpf = "12345678901";
                        //novaPF.rendimento = 1854.5f;

                        //novoEnd.logradouro = "Rua das Flores";
                        //novoEnd.numero = 12345;
                        //novoEnd.complemento = "Comercial Violeta";
                        //novoEnd.endComercial = true;

                        //novaPF.endereco = novoEnd;


                        //Console.WriteLine($"Nome:{novaPF.nome}");
                        //Console.WriteLine($"Data de Nascimento:{novaPF.dataNascimento}");
                        //Console.WriteLine($"CPF:{novaPF.cpf}");
                        //Console.WriteLine($"Rendimento:{novaPF.rendimento}");
                        //Console.WriteLine($"Endereço: {novaPF.endereco.logradouro},{novaPF.endereco.numero}");

                        //Console.WriteLine(@$"
                        //Nome:{novaPF.nome}
                        //Maior de idade:{ metodoPF.validarDataNascimento(novaPF.dataNascimento)}
                        //CPF:{novaPF.cpf}
                        //Rendimento:{novaPF.rendimento}
                        //Endereço: {novaPF.endereco.logradouro},{novaPF.endereco.numero}
                        //");


                        
                        break;
                    case "2":
                        Console.Clear();

                        if (listaPf.Count > 0)
                        {
                            foreach (PessoaFisica cadaPessoa in listaPf)
                            {
                                
                                Console.Clear();
                                
                                Console.WriteLine(@$"
                        ==============================================
                        Nome: {cadaPessoa.nome}
                        Data de Nascimento: {cadaPessoa.dataNascimento}
                        CPF: {cadaPessoa.cpf}
                        Endereço: {cadaPessoa.endereco.logradouro},{" " + cadaPessoa.endereco.numero}
                        Rendimento: {cadaPessoa.rendimento}
                        Taxa de imposto a ser paga é: {metodoPf.PagarImposto(cadaPessoa.rendimento).ToString("C")}
                        ==============================================
                        ");
                                
                        Console.WriteLine($"Aperte 'enter' para continuar");
                        Console.ReadLine();
                            }                            
                        }
                        
                        //  else {
                        //     Console.WriteLine($"Lista vazia!");
                        //     Thread.Sleep(2500);
                            
                        // }

                        using (StreamReader sr =  new StreamReader("Maria.txt"))
                        {
                            string linha;
                            while ((linha = sr.ReadLine()) != null)
                            {
                              Console.WriteLine($"{linha}");
                            }
                        }
                        
                        Console.WriteLine($"Aperte 'enter' para continuar");
                        Console.ReadLine();

                        break;
                    case "0":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção inválida, por favor digite outra opção");
                        Thread.Sleep(3000);
                        
                        break;
                }
                               
            } while (opcaoPf != "0");
            break;
        case "2":
            PessoaJuridica metodoPj = new PessoaJuridica();

                        string? opcaoPj;
                        do
                        {
                            Console.Clear();

                Console.WriteLine(@$"
        ==============================================
        |       Escolha uma das opções abaixo        |
        ----------------------------------------------
        |         1 - Cadastrar Pessoa Jurídica      |
        |         2 - Listar Pessoa Jurídica         |
        |                                            |
        |         0 - Voltar ao menu anterior        |
        ==============================================
                ");
                            opcaoPj = Console.ReadLine();

                            switch (opcaoPj)
                            {
                                case "1":
                                    PessoaJuridica novaPj = new PessoaJuridica();
                                    Endereco novoEnd = new Endereco();

                                    Console.Clear();
                                    Console.WriteLine($"Digite o nome da pessoa jurídica que deseja cadastrar ");
                                    novaPj.nome = Console.ReadLine();
                                    
                                    bool cnpjValido;
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Digite o CNPJ ");
                                        string? cnpj = Console.ReadLine();

                                        cnpjValido = metodoPj.ValidarCnpj(cnpj);
                                        if (cnpjValido){
                                            novaPj.cnpj = cnpj;
                                        } else{
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine($"CNPJ digitado é inválido, por favor digite um CNPJ válido");
                                            Console.ResetColor();    
                                        };
                                        
                                    } while (cnpjValido == false);

                                    Console.Clear();
                                    Console.WriteLine($"Digite a razão social");
                                    novaPj.razaoSocial = Console.ReadLine();

                                    Console.Clear();
                                    Console.WriteLine($"Digite o rendimento mensal (Somente números) ");
                                    novaPj.rendimento = float.Parse(Console.ReadLine());

                                    Console.Clear();
                                    Console.WriteLine($"Digite o logradouro");
                                    novoEnd.logradouro= Console.ReadLine();

                                    Console.Clear();
                                    Console.WriteLine($"Digite o número do endereço");
                                    novoEnd.numero = int.Parse(Console.ReadLine());

                                    Console.Clear();
                                    Console.WriteLine($"Digite o complemento do endereço(Aperte ENTER para vazio)");
                                    novoEnd.complemento = Console.ReadLine();

                                    
                                    Console.Clear();
                                    Console.WriteLine($"Este endereço é comercial? S/N");
                                    string EndCom = Console.ReadLine().ToUpper();

                                    if (EndCom == "S"){
                                        novoEnd.endComercial = true;
                                    } else {
                                        novoEnd.endComercial = false;
                                    }                       

                                    novaPj.endereco = novoEnd;

                                    metodoPj.Inserir(novaPj);

                                    //listaPj.Add(novaPj);
                                    // using (StreamWriter sw = new StreamWriter($"{novaPj.nome}.txt"))
                                    // {
                                    //     sw.WriteLine(@$"
                                    //     Nome: {novaPj.nome}
                                    //     Razão Social: {novaPj.razaoSocial}
                                    //     CNPJ: {novaPj.cnpj}
                                    //     Endereço: {cadaPessoa.endereco.logradouro},{" " + cadaPessoa.endereco.numero}
                                    //     Complemento: {novaPj.endereco.complemento}
                                    
                                    //     ");
                                    // }
                                    
                                    Console.WriteLine($"Cadastro realizado com sucesso!");
                                    Thread.Sleep(3000);


                                    //         if (listaPj.Count > 0)
                                    //         {
                                    //             foreach (PessoaJuridica cadaPessoa in listaPj)
                                    //             {
                                    //             Console.Clear();
                                    //             Console.WriteLine($"==============================================");
                                    //             Console.WriteLine(@$"
                                    // Nome: {cadaPessoa.nome}
                                    // Razão Social: {cadaPessoa.razaoSocial}
                                    // CNPJ: {cadaPessoa.cnpj}
                                    // Rendimento: {cadaPessoa.rendimento}
                                    // Taxa de imposto a ser paga é: {metodoPj.PagarImposto(cadaPessoa.rendimento).ToString("C")}
                                    // Endereço: {cadaPessoa.endereco.logradouro},{" " + cadaPessoa.endereco.numero}
                                    // ");
                                    //             Console.WriteLine($"==============================================");

                                    //             Console.WriteLine($"Aperte 'Enter' para continuar");
                                    //             Console.ReadLine();
                                    //             }
                                     //         }
                                    //         else
                                    //         {
                                    //             Console.WriteLine("Lista vazia!!!");
                                    //             Thread.Sleep(3000);
                                    //         }
                                   
                                    break;
                                case "2":
                                    Console.Clear();

                                    List<PessoaJuridica> listaPj = metodoPj.Ler();

                                    foreach (PessoaJuridica cadaItem in listaPj)
                                    {
                                         Console.Clear();
                                
                                Console.WriteLine(@$"
                                ==============================================
                                Nome da empresa:{cadaItem.nome}
                                Razão Social: {cadaItem.razaoSocial}
                                CNPJ: {cadaItem.cnpj}
                                ==============================================
                                        ");
                                
                                    }
                                    Console.Clear();
                                    Console.WriteLine($"Cadastro realizado com sucesso!");
                                    Thread.Sleep(3000);


                                    // if (listaPj.Count > 0)
                                    // {
                                    //     foreach (PessoaJuridica cadaPessoa in listaPj)
                                    //     {                                            
                                    //         Console.WriteLine(@$"
                                    //         Nome: {cadaPessoa.nome}
                                    //         Razão Social: {cadaPessoa.razaoSocial}
                                    //         CNPJ: {cadaPessoa.cnpj}
                                    //         Endereço: {cadaPessoa.endereco.logradouro},{" " + cadaPessoa.endereco.numero}
                                    //         Taxa de imposto a ser paga é: {cadaPessoa.PagarImposto(cadaPessoa.rendimento).ToString("C")}
                                    //         ");
                                    //     }

                                    //     Console.WriteLine($"Aperte 'ENTER' para continuar");
                                    //     Console.ReadLine();                           
                                    // } else {
                                    //     Console.WriteLine($"Lista vazia!");
                                    //     Thread.Sleep(2500);
                                    // }                      
                                    break;
                                case "0":
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine($"Opção inválida, por favor digite outra opção");
                                    Thread.Sleep(5500);
                                    
                                    break;
                            }
                                        
                        } while (opcaoPj != "0");
                        
            break;

        case "0":
            Console.Clear();
            Console.WriteLine("Obrigada por utilizar nosso sistema!");
            Thread.Sleep(2000);
            BarraCarregamento("Finalizando", 200);
            break;

        default:
            Console.Clear();
            Console.WriteLine($"Opção inválida, por favor digite outra opção");
            Thread.Sleep(3000);
            break;
    }   
} while (opcao != "0");

static void BarraCarregamento (string texto, int tempo){    
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write($"{texto} ");

            for (var cont = 0; cont < 10; cont++)
            {
                Console.Write(".");
                Thread.Sleep(tempo);  
            }
            Console.ResetColor();

}