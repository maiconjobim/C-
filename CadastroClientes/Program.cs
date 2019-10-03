using System;
using diretorio;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using System.IO;


namespace Testes
{
    class Program
    {
        static void Main(string[] args)

        {
            //Arquivo. Ler(1);





            var clienteAtual = new Cliente();//gerendo um cliente

            clienteAtual.Nome = "yyyy";// nome do cliente 
            clienteAtual.Telefone = "554456969648"; // telefone
            clienteAtual.CPF = "18594154";//cpf
            clienteAtual.Gravar(); // grava o clineteAtual no txt ou csv 


            var total = Cliente.LerClientes();// lista de Clientes "que são objetos"


            foreach (Cliente i in total) // escreve na tela  a lista de clientes  
            {

                Console.WriteLine($"{i.Nome}  {i.Telefone}  {i.CPF} ");// escreve nome telefone e cpf do cliente

            }









            Console.Read();
        }
    }
}
