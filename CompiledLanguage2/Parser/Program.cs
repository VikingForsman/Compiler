using System;
using System.IO;
using System.Text;

namespace Parser {
    class Program {
        static void Main(string[] args) {
            var prg = "let x = 1 in 1 + x"; 
            var data = Encoding.ASCII.GetBytes(prg);
            var stream = new MemoryStream(data, 0, data.Length);

            var l = new Scanner(stream);
            var p = new Parser(l);

            Console.WriteLine(p.Parse());
            Console.WriteLine(p.result);
            Console.ReadKey();
        }
    }
}
