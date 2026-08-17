using System.Text.RegularExpressions;

namespace day6
{
    internal class Program
    {
        static void Func1()
        {
            Console.WriteLine("题目描述：提取一句话中所有的中文姓名（string str = \"hello, I am 刘德华,your name is 黎明?\"）");
            string megMod = @"[\u4e00-\u9fa5]+";
            string strTag = "hello, I am 刘德华,your name is 黎明?";
            MatchCollection res = Regex.Matches(strTag, megMod);
            Console.WriteLine("找到如下中文名：");
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }
        static void Func2()
        {
            Console.WriteLine("题目描述：替换所有多余空格（string str = \"abc  dd  ee  ff  gg  HH  h j k\"）");
            string tag = "abc  dd  ee  ff  gg  HH  h j k";
            string regMod = @"\s+";
            string res = Regex.Replace(tag, regMod, "");

            Console.WriteLine(res);
        }
        static void Func3()
        {
            Console.WriteLine("题目描述：身份证号码（string str = \"我的身份证号是: 360731200111052112,你的身份证是: 42108320041119211X\";\r\n// 书写正则, 找到字符串中的身份证号及 出生年,月,日）");
            string regMod = @"[1-9]\d{5}(\d{4})(\d{2})(\d{2})\d{3}\w[0-9Xx]";
            string tag = "我的身份证号是: 360731200111052112,你的身份证是: 42108320041119211X";
            MatchCollection res = Regex.Matches(tag, regMod);
            foreach (Match item in res)
            {
                Console.WriteLine($"身份证号：{item.Groups[0]}，出生日期：{item.Groups[1]}年{item.Groups[2]}月{item.Groups[3]}日");
            }
        }
        static void Func4()
        {
            Console.WriteLine("题目描述：密码强度检测：强中弱（字母、数字、特殊符号）\r\n\r\n```C#\r\n// 请输入密码（字母、数字、特殊符号）\r\n\r\n//密码中可以有数字,字母,特殊符号;长度要求8~15 \r\n//如果只有一种则 强度为弱\r\n//如果只有两种则 强度为中\r\n//如果三种都有则 强度为强\r\n\r\n//验证密码长度是否符合,并输出密码强度\r\n```\r\n\r\n");

            Console.WriteLine("请输入密码（字母、数字、特殊符号）");
            string strOld = Console.ReadLine();
            if (strOld.Length >= 8 && strOld.Length <= 15)
            {
                bool isInt = Regex.IsMatch(strOld, @"\d");
                bool isWord = Regex.IsMatch(strOld, @"[a-zA-Z]");
                bool isSymbol = Regex.IsMatch(strOld, @"[^0-9a-zA-Z]");
                if (isInt && isSymbol && isWord)
                {
                    Console.WriteLine($"你的密码{strOld}密码强度是“强”");
                }
                else if ((isInt && isWord) || (isInt && isSymbol) || (isSymbol && isWord))
                {
                    Console.WriteLine($"你的密码{strOld}密码强度是“中”");
                }
                else if (isInt | isSymbol | isWord)
                {
                    Console.WriteLine($"你的密码{strOld}密码强度是“弱”");
                }
            }
            else Console.WriteLine("输入的密码长度有误");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入你要查看的题号（1-4）");
            string num = Console.ReadLine();
            switch (num)
            {
                case "1": Func1(); break;
                case "2": Func2(); break;
                case "3": Func3(); break;
                case "4": Func4(); break;
                default: Console.WriteLine("输入的题号有误！"); break;
            }
        }
    }
}
