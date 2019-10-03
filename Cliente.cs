
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testes;
using System.Configuration;
using System.IO;
using System;
using diretorio;

namespace Classes
{
    public class Cliente //clsse para gerar clientes
    {
        public string Nome; // variavel para o nome dos clientes 
        public string Telefone; // variavel para o Telefone dos clientes
        public string CPF; // variavel para o CPF dos clientes



        public void Gravar() // metodo para gravar a lista de clientes no Banco de dados local .TXT ou .CSV 
        {
            List<Cliente> clientes = Cliente.LerClientes(); //chama o metodo LerCliente que terna uma lista 
            clientes.Add(this); //add o novo cliente estanciado para a lista de clientes 
            if (File.Exists(CaminhoBaseClientes()))//verivita co caminho do Db
            {
                StreamWriter r = new StreamWriter(CaminhoBaseClientes());// abre o modo de escrina no arquivo 


                r.WriteLine("Nome;Telefone;CPF;"); //escreve no arquivo o cabeçalho
                foreach(Cliente p in clientes) // escreve no arquivo cada linha com dados de clientes
                {

                    string linha = p.Nome + ";" + p.Telefone + ";" + p.CPF +";"; // string de cada linha do arquivo 
                    r.WriteLine(linha); //escreve as linhas

                }

                r.Close();//close no arquivo 

            }
        }


            

            public static List<Cliente> LerClientes() // metodo para ler arquivo e retornar lista de objetos "Clientes" 
            {
                var clientes = new List<Cliente>();//criando a lista 


                if (File.Exists(CaminhoBaseClientes())) // checa se o aqruivo existe
                {
                    // using é usado para abrir o arquivo e feichalo onde acaba o bloco
                    using (StreamReader arquivo = File.OpenText(CaminhoBaseClientes())) 
                    {
                        string linha; 
                        int i = 0;  
                        while ((linha = arquivo.ReadLine()) != null) // le a linha do raquivo e joga em linha 
                        {
                            i++;
                            if (i == 1) continue; // pula a primeria  leitura para não ler o cabeçalho

                            var clienteArquivo = linha.Split(';'); // cria um vetor de strings divididas por ;
                            var cliente = new Cliente(); // novo obj cliente
                            cliente.Nome = clienteArquivo[0]; //preence seu nome com a primeria posição do vetor 
                            cliente.Telefone = clienteArquivo[1];//preence seu Telefoen com a segunda posição do vetor 
                            cliente.CPF = clienteArquivo[2];//preence seu CPF com a terceira posição do vetor 


                            clientes.Add(cliente); // add o cliente Lido,a cada linha, a lista de Clientes

                        }

                    }
                }
                else
                {
                    Console.WriteLine("Não existe O Arquivo"); // se não encontrar o arquivo do Bd manda essa menssagem
                }

                return clientes;// retorna a lista de objetos
            }






            private static string CaminhoBaseClientes() // metodo que retorna o caminho do banco de dados conforme definido no App.comfig 
            {
            return ConfigurationManager.AppSettings["BaseDeClientes"];
            }


    }

}
