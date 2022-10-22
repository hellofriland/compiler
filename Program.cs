namespace Compiler {
    class Program {
        public static void Main(string[] args) {
            // Console.Write("Input your file name:  ");
            // string file_name = Console.ReadLine();
            string fileName = "input_file.txt";
            string context = IOFile.InputFile(fileName);
            
            Analysis.LexicalAnalysis(context);
            IOFile.OutputFile(Analysis.Lexical);
        }
    }
}