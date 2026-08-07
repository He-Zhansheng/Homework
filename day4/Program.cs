namespace day4
{
    internal class Program
    {
        static void Func1()
        {
            Console.WriteLine("题目描述：计算100以内偶数的和");
            int numSum = 0;
            //for (int i = 2; i < 100; i++)
            //    if (i % 2 == 0) numSum += i;
            //Console.WriteLine($"100以内偶数的和:{numSum}");

            for (int i = 2; i <= 100; i += 2)
                numSum += i;
            Console.WriteLine($"100以内偶数的和:{numSum}");
        }
        static void Func2()
        {
            Console.WriteLine("题目描述：显示出1000-2000年中所有的闰年，并以每行四个数的形式输出");
            for (int i = 1000; i <= 2000; i++)
            {
                // 找到第一个闰年
                if ((i % 4 == 0 && i % 100 != 0) || i % 400 == 0)
                {
                    int numCount = 0;
                    // 控制一行输出的个数
                    //for (; i <= 2000; i += 4)
                    //{
                    //    if ((i % 4 == 0 && i % 100 != 0) || i % 400 == 0)
                    //    {
                    //        Console.Write($"{i} ");
                    //        numCount++;
                    //    }
                    //    if (numCount == 4)
                    //    {
                    //        numCount = 0;
                    //        Console.WriteLine();
                    //    }
                    //}

                    while (i <= 2000 && numCount < 4)
                    {
                        Console.Write($"{i} ");
                        numCount++;
                        i += 4;

                        while (!((i % 4 == 0 && i % 100 != 0) || i % 400 == 0)) i += 4;
                    }
                    Console.WriteLine();
                    i--;
                }
            }
        }
        static void Func3()
        {
            Console.WriteLine("题目描述：输出一个倒三角形,总共9行");
            for (int i = 9; i > 0; i--)
            {
                for (int j = i; j > 0; j--)
                    Console.Write("*");
                Console.WriteLine();
            }
        }
        static void Func4()
        {
            Console.WriteLine("题目描述：用循环计算下面的结果\r\n\r\n1 - 1/2 + 1/3 - 1/4 + ... - 1/100");
            int numMor = 0;
            double numSum = 0;
            while (++numMor <= 100)
            {
                numSum += numMor % 2 != 0 ? 1d / numMor : 1 - 1d / numMor;
            }
            Console.WriteLine($"结果是：{numSum}");
        }
        static void Func5()
        {
            Console.WriteLine("题目描述：求10以内所有数字的阶乘的和");
            int numSum = 0;
            for (int i = 1; i <= 10; i++)
            {
                int numTmp = 1;
                for (int j = 1; j <= i; j++)
                {
                    numTmp *= j;
                }
                numSum += numTmp;
            }
            Console.WriteLine($"10以内所有数字的阶乘的和：{numSum}");
        }
        static void Func6()
        {
            Console.WriteLine("题目描述：篮球从5米高的地方掉下来，每次弹起的高度是原来的30%，经过几次弹起，篮球的高度小于0.1米。");
            double numHeg = 5;
            int numCount = 0;
            while (numHeg > 0.1)
            {
                numHeg *= 0.3;
                numCount++;
            }
            Console.WriteLine($"经过{numCount}次弹起，篮球的高度小于0.1米。");
        }
        static void Func7()
        {
            Console.WriteLine("题目描述：有一个棋盘，有64个方格，在第一个方格里面放1粒芝麻重量是0.00001kg，第二个里面放2粒，第三个里面放4，棋盘上放的所有芝麻的重量");
            double numResult = 0.00001;
            double num = 1;
            //for (int i = 1; i < 64; i++)
            //{
            //    num *= 2;
            //    numResult += (num * 0.00001);
            //}

            for (int i = 1; i <= 64; i++)
            {
                num = Math.Pow(2, i - 1);
                numResult += (num * 0.00001);
            }
            Console.WriteLine($"棋盘上放的所有芝麻的重量是{numResult}kg");
        }
        static void Func8()
        {
            Console.WriteLine("题目描述：某人在银行有50000元存款。银行每月都要收取服务费，存款大于5000元时每个月收取总额的5%，总额不大于5000元的时候不收服务费；假设这个人存了以后从来都不用，用循环计算银行要扣这个人的手续费能扣多少次？每次扣取后剩余多少钱？");
            double numMoney = 50000;
            int numCount = 1;
            while (numMoney > 5000)
            {
                numMoney *= 0.95;
                Console.WriteLine($"第{numCount++}次扣除手续费后剩余{numMoney}");
            }
        }
        static void Func9()
        {
            Console.WriteLine("题目描述：猴子摘桃，猴子摘了x个桃，每天吃一半，再多吃一个，第7天吃的时候剩下一个了，猴子摘了多少桃子（假定吃一半是向下取整，且第7天还没开始吃发现只有一个了）？");
            // 假定吃一半是向下取整，且第7天还没开始吃发现只有一个了
            int numLast = 1;
            int numDay = 4;
            while (--numDay > 0)
            {
                numLast += 1;
                numLast *= 2;
            }
            Console.WriteLine($"猴子一共摘了{numLast}个桃子");
        }
        static void Func10()
        {
            Console.WriteLine("题目描述：有个皮球，每次落地弹起都是高度的一半，如果从10米高的地方丢下，第十次弹起时，皮球总过经历了多少距离。");
            int numCount = 0;
            double numHet = 10;
            double numDistance = 10;
            while (++numCount < 10)
            {
                numHet *= 0.5;
                numDistance += (2 * numHet);
            }
            Console.WriteLine($"第十次弹起时，皮球总过经历了{numDistance}距离");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("请输入你要查看的题号（1-10）");
            string num = Console.ReadLine();
            switch (num)
            {
                case "1": Func1(); break;
                case "2": Func2(); break;
                case "3": Func3(); break;
                case "4": Func4(); break;
                case "5": Func5(); break;
                case "6": Func6(); break;
                case "7": Func7(); break;
                case "8": Func8(); break;
                case "9": Func9(); break;
                case "10": Func10(); break;
                default: Console.WriteLine("输入的题号有误！"); break;
            }
        }
    }
}
