using System;

namespace Compiler {
    class Program {
        public static void Main(string[] args) {
            // Console.Write("Input your file name:  ");
            // string file_name = Console.ReadLine();
            string file_name = "input_file.txt";
            string context = IOFile.InputFile(file_name);
            
            Analysis.LexicalAnalysis(context);
            
            IOFile.OutputFile(Analysis.Lexical);
        }
    }
}