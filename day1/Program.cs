namespace Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入你要看的作业题号：");
            string num = Console.ReadLine();
            switch (num)
            {
                case "1":
                    {
                        Console.Write("请输入你要计算的第一个数字：");
                        decimal numOne = decimal.Parse(Console.ReadLine());
                        Console.Write("请输入你要计算的第二个数字：");
                        decimal numTwo = decimal.Parse(Console.ReadLine());
                        Console.WriteLine($"{numOne}+{numTwo}={numOne + numTwo}");
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("题目描述：");
                        Console.WriteLine("小明要到美国旅游，可是那里的温度是以华氏度为单位记录的。他需要一个程序将华氏温度（80度）转换为摄氏度，并以华氏度和摄氏度为单位分别显示该温度（提示：摄氏度与芈氏度的转换公式为：摄氏度 = 5/9.0*(华氏度-32)保留3位小数）");
                        Console.WriteLine("请输入您要转换的数字：");
                        decimal numOne = decimal.Parse(Console.ReadLine());
                        Console.WriteLine($"华氏温度：{numOne}摄氏温度：{5 / 9.0m * (numOne - 32):F3}");
                        break;
                    }
                case "3":
                    {
                        int numOne = 20;
                        int numTwo = 10;
                        Console.WriteLine($"交换前整数1的值为：{numOne}，整数2的值为：{numTwo}");
                        int numTmp = numOne - numTwo;
                        numOne -= numTmp;
                        numTwo += numTmp;
                        Console.WriteLine($"交换后整数1的值为：{numOne}，整数2的值为：{numTwo}");
                        break;
                    }
                case "4":
                    {
                        Console.WriteLine("题目描述： 为抵抗洪水，战士连续作战89小时，编程计算共多少天零多少小时？");
                        int numDay = 89 / 24;
                        int numHour = 89 % 24;
                        Console.WriteLine($"共计{numDay}天{numHour}小时。");
                        break;
                    }
                default: Console.WriteLine("输入的题号有误！"); break;
            }
        }
    }
}
