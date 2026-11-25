using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP
{
    internal class Tarefa
    {
        public int userId;
        public int id;
        public string title;
        public bool completed;

        public void Exibir()
        {
            Console.WriteLine("Objeto tarefa:");
            Console.WriteLine($"User ID: {userId}");
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Finalizou: {completed}");
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------");

        }
    }
}
