using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvetCsvToObject
{
    class Program
    {
        static void Main(string[] args)
        {
            var t =Cliente.LerClientes();
            Console.WriteLine(t[1].Id);

        }

    }

    public class Cliente //clsse para gerar clientes
    {



        public string Date;
        public string DateTime;
        public string Id;
        public string EndDateTim;
        public string Project;
        public string Who;
        public string Description;
        public string ProjectCategory;
        public string Company;
        public string TaskList;
        public string Task;
        public string ParentTask;
        public string IsSubtask;
        public string IsitBillable;
        public string InvoiceNumber;
        public string Hours;
        public string Minutes;
        public string DecimalHours;
        public string Estimated;
        public string EstimatedHours;
        public string EstimatedMinutes;
        public string Tags;











        public static List<Cliente> LerClientes() // metodo para ler arquivo e retornar lista de objetos "Clientes" 
        {
            var clientes = new List<Cliente>();//criando a lista 


            if (File.Exists(CaminhoBaseClientes())) // checa se o aqruivo existe
            {
                // using é usado para abrir o arquivo e feichalo onde acaba o bloco
                using (StreamReader arquivo = File.OpenText(CaminhoBaseClientes()))
                {
                    string linha;
                    linha = arquivo.ReadToEnd();// le a linha do raquivo e joga em linha 

                    string[] separatingStrings = { "\"," };


                    //System.Console.WriteLine($"Original text: '{text}'");
                    linha = linha.Replace("\n", "");


                    string[] words = linha.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);





                    //; var clienteArquivo = linha.Split(','); // cria um vetor de strings divididas por ;
                    
                    for (int i = 0; i < 22*5000;  i=i+22)
                    {

                    var cliente = new Cliente(); // novo obj cliente

                        cliente.Id = words[i + 1];
                        cliente.Date = words[i + 2];
                        cliente.DateTime = words[i + 3];
                        cliente.EndDateTim = words[i + 4];
                        cliente.Project = words[i + 5];
                        cliente.Who = words[i + 6];
                        cliente.Description = words[i + 7];
                        cliente.ProjectCategory = words[i + 8];
                        cliente.Company = words[i + 9];
                        cliente.TaskList = words[i + 10];
                        cliente.Task = words[i + 11];
                        cliente.ParentTask = words[i + 12];
                        cliente.IsSubtask = words[i + 13];
                        cliente.IsitBillable = words[i + 14];
                        cliente.InvoiceNumber = words[i + 15];
                        cliente.Hours = words[i + 16];
                        cliente.Minutes = words[i + 17];
                        cliente.DecimalHours = words[i + 18];
                        cliente.Estimated = words[i + 19];
                        cliente.EstimatedHours = words[i + 20];
                        cliente.EstimatedMinutes = words[i + 21];
                        cliente.Tags = words[i + 22];







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

        public static string CaminhoBaseClientes()
        {
            var endereco = @"C:\projetos\exportTimeLog.csv ";

            return endereco;
        }
    }
}
