namespace Compiler {
    class Analysis {
        // 存储词汇分析的结果
        public static List<string> Lexical = new List<string>();
        // 关键字
        private static string[] MyKeyword = { "if", "else", "void", "int", "double", "float", "char", "string" };
        // 分隔符
        private static string[] MySeparater = { ",", ";", "{", "}", "[", "]", "(", ")" };
        // 运算符
        private static string[] MyOperator = {"!", "+", "-", "*", "/", "%", ">", "<", "="};

        /// <summary>
        /// 是否为过滤符
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        static bool IsFilter(char ch) {
            if (ch == ' ' || ch == '\n' || ch == '\t') {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 是否为关键字
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        static bool IsKeyword(string word) {
            for (int i = 0; i < MyKeyword.Length; i++) {
                if (MyKeyword[i] == word) {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 是否为分隔符
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        static bool IsSeparater(string word) {
            for (int i = 0; i < MySeparater.Length; i++) {
                if (MySeparater[i] == word) {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 是否为运算符
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private static bool IsOperator(string word) {
            for (int i = 0; i < MyOperator.Length; i++) {
                if (MyOperator[i] == word) {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 是否为小写字符
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        private static bool IsLowerCaseLetter(char ch) {
            if (ch >= 'a' && ch <= 'z') {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 是否为大写字符
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        private static bool IsUpperCaseLetter(char ch) {
            if (ch >= 'A' && ch <= 'Z') {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 是否为小写字符
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        private static bool IsDigit(char ch) {
            if (ch >= '0' && ch <= '9') {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 进行词法分析
        /// </summary>
        /// <param name="context"></param>
        public static void LexicalAnalysis(string context) {
            char[] ch_context = context.ToCharArray();
            string arr;

            for (int i = 0; i < ch_context.Length; i++) {
                arr= "";

                if (IsFilter(ch_context[i])) {
                    if (ch_context[i] == ' ') {
                        Lexical.Add("< ,Filter>");
                    }
                    if (ch_context[i] == '\n') {
                        Lexical.Add("<\\n,tFilter>");
                    }
                }
                else if (IsLowerCaseLetter(ch_context[i])) {
                    while (IsLowerCaseLetter(ch_context[i])) { 
                        arr = arr + ch_context[i];
                        i++;
                    }

                    if (IsKeyword(arr)) {
                        Lexical.Add($"<{arr},Keyword>");
                    }
                    else {
                        Lexical.Add($"<{arr},Identifier>");
                    }
                }
                else if (IsDigit(ch_context[i])) {
                    while (IsDigit(ch_context[i]) || (ch_context[i] == '.' && IsDigit(ch_context[i+1]) )) {
                            arr += ch_context[i];
                            i++;
                    }
                    Lexical.Add($"<{arr},Digit>");
                }
                else if (IsUpperCaseLetter(ch_context[i])) {
                    while (IsUpperCaseLetter(ch_context[i]) || IsLowerCaseLetter(ch_context[i]) || IsDigit(ch_context[i])) {
                        arr += ch_context[i];
                        i++;
                    }
                    Lexical.Add($"<{arr},Identifier>");
                }
                else if (IsOperator(ch_context[i].ToString())) {
                    while (IsOperator(context[i].ToString())) {
                        arr += ch_context[i];
                        i++;
                    }
                    Lexical.Add($"<{arr},Operator>");
                }
                else if (IsSeparater(ch_context[i].ToString())) {
                    arr += ch_context[i];
                    Lexical.Add($"<{arr},Sepatater>");
                }
            }
        }
    }
}