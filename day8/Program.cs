namespace day8
{
    internal class Program
    {
        static void Main(string[] args)
        {

            void Func1()
            {
                double Func1_1(double r)
                {
                    return Math.PI * Math.Pow(r, 2) * 200;
                }

                Console.WriteLine("题目描述：装修房间：参数1，圆的半径，计算圆的面积，每平方米收费200元，返回装修总价。计算这个半径的圆装修一半需要多少钱？");
                double r = double.Parse(Console.ReadLine());
                Console.WriteLine($"半径{r}的圆装修一半需要{Func1_1(r) / 2}元");
            }

            void Func2()
            {
                int Func2_1(string strTarget, char chTarget)
                {
                    int numCount = 0;
                    foreach (char item in strTarget)
                    {
                        if (item == chTarget) numCount++;
                    }
                    return numCount;
                }

                Console.WriteLine("题目描述：计算字符在字符串中出现的次数：参数1字符串，参数2某个字符，函数统计次数，并返回。");
                Console.Write("请输入目标字符串：");
                string strTarget = Console.ReadLine();
                Console.Write("请输入需要查找的字符：");
                char chTarget = char.Parse(Console.ReadLine());
                Console.WriteLine($"字符{chTarget}在字符串{strTarget}出现的次数是：{Func2_1(strTarget, chTarget)}");

            }

            void Func3()
            {
                int Func3_1(int[] nums)
                {
                    List<int> numsList = nums.ToList();
                    int numMin = numsList.Min();
                    return numsList.IndexOf(numMin);
                }

                Console.WriteLine("题目描述：计算一个整型数组中，最小值第一次出现的下标。");
                int[] nums = [10, 20, 5, 30, 50, 1, 6, 7];
                Console.Write("数组：[ ");
                foreach (int item in nums)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine($"]最小值第一次出现的下标是：{Func3_1(nums)}");
            }

            void Func4()
            {
                bool Func4_1(string strTarget)
                {
                    int j = strTarget.Length - 1;
                    int i = 0;
                    while (i < j)
                    {
                        if (strTarget[i] == strTarget[j])
                        {
                            i++;
                            j--;
                        }
                        else break;
                    }
                    if (i < j) return false;
                    return true;
                }

                Console.WriteLine("题目描述：判断一个字符串是否为回文，返回布尔值类型。");
                Console.Write("请输入你要判断的字符串：");
                string strTarget = Console.ReadLine();
                if (Func4_1(strTarget)) Console.WriteLine($"字符串{strTarget}是回文字符串");
                else Console.WriteLine($"字符串{strTarget}不是回文字符串");
            }

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
