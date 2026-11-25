using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;



namespace HTTP
{
    internal class Program
    {
        enum Menu
        {
            Listar = 1,
            Unica = 2,
            Sair = 3
        }

        static void Main(string[] args)
        {
            bool EscolheuSair = false;
            while (EscolheuSair == false)
            {

                Console.WriteLine("Requisição HTTP");
                Console.WriteLine("Você quer requerer a lista inteira ou apenas uma específica?");
                Console.WriteLine("1 - Listar");
                Console.WriteLine("2 - Única");
                Console.WriteLine("3 - Sair");

                string opcaoStr = Console.ReadLine();
                Menu opcao = (Menu)int.Parse(opcaoStr);
                if (opcao >= Menu.Listar && opcao <= Menu.Sair)
                {
                    switch (opcao)
                    {
                        case Menu.Listar:
                            ReqList();
                            break;
                        case Menu.Unica:
                            ReqUnica();
                            break;
                        case Menu.Sair:
                            EscolheuSair = true;
                            break;
                        default:
                            Console.WriteLine("Opção inválida");
                            Console.WriteLine("Digite enter para continuar");
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Opção inválida");
                }

            }
                



                void ReqList()
                {
                    var requisicao2 = WebRequest.Create("https://jsonplaceholder.typicode.com/todos/");
                    requisicao2.Method = "GET";
                    using (var resposta = requisicao2.GetResponse())
                    {
                        var stream = resposta.GetResponseStream();
                        StreamReader leitor = new StreamReader(stream);
                        object dados = leitor.ReadToEnd();
                        List<Tarefa> tarefas = JsonConvert.DeserializeObject<List<Tarefa>>(dados.ToString());
                        foreach (Tarefa tarefa in tarefas)
                        {
                            tarefa.Exibir();
                        }
                        stream.Close();
                        leitor.Close();

                    }
                    Console.WriteLine("Clique enter para continuar");
                    Console.ReadLine();
                    Console.Clear();

                }


                void ReqUnica()
                {
                    Console.WriteLine("Digite o id do Json:");
                    int id = int.Parse(Console.ReadLine());
                    if (id <= 200)
                    {

                        var requisicao2 = WebRequest.Create("https://jsonplaceholder.typicode.com/todos/" + id);
                        requisicao2.Method = "GET";
                        using (var resposta = requisicao2.GetResponse())
                        {
                            var stream = resposta.GetResponseStream();
                            StreamReader leitor = new StreamReader(stream);
                            object dados = leitor.ReadToEnd();
                            Tarefa tarefa = JsonConvert.DeserializeObject<Tarefa>(dados.ToString());
                            tarefa.Exibir();
                            stream.Close();
                            leitor.Close();
                        }
                    }

                    else
                    {
                        Console.WriteLine("Id inválido! Tente novamente.");

                    }
                    Console.WriteLine("Clique enter para continuar");
                    Console.ReadLine();
                    Console.Clear();


                }

        }
    }
}
