namespace Compiler{
    class IOFile {
        public static string InputFile(string name) {
            string path = "/home/friland/Projects/compiler/io/" + name;
            Console.WriteLine(path);
            string str = File.ReadAllText(path);
            return str;
        }

        public static void OutputFile(List<string> context) {
            string path = "/home/friland/Projects/compiler/io/output.txt";
            FileInfo fl = new FileInfo(path);
            FileStream fs = fl.Create();
            fs.Close();
            fl.Delete();

            using (StreamWriter sw = new StreamWriter(path)) {
                for (int n = 0; n < context.Count; n++) {
                    sw.WriteLine(context[n]);
                }
            }
        }
    }
}