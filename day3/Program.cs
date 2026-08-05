namespace day3
{
    internal class Program
    {
        static void Func1()
        {
            Console.WriteLine("题目描述：账号密码验证（练习分支嵌套）：账号规定是\"admin\"，密码规定是\"123456\"。让用户输入账号和密码，判断账号和密码是否正确，账号和密码都正确就输出登入成功；账号不对，就输出账号不存在；密码不对，就输出密码错误。");
            Console.Write("请输入你的账号：");
            string userName = Console.ReadLine();
            Console.Write("请输入你的密码：");
            string userPass = Console.ReadLine();
            if (userName == "admin")
            {
                if (userPass == "123456") Console.WriteLine("登入成功");
                else Console.WriteLine("密码不对");
            }
            else Console.WriteLine("账号不存在");
        }

        static void Func2()
        {
            Console.WriteLine("题目描述：选择菜单（add / edit / del）执行操作（练习多分支和switch）：提示用户选择菜单（add / edit / del），判断输入的是add，就输出新增成功；输入的是edit，就输出编辑成功；输入的是del，就输出删除成功。");
            Console.WriteLine("选择菜单：add/edit/del");
            string strMenu = Console.ReadLine();
            switch (strMenu)
            {
                case "add": Console.WriteLine("新增成功"); break;
                case "edit": Console.WriteLine("编辑成功"); break;
                case "del": Console.WriteLine("删除成功"); break;
                default: Console.WriteLine("输入有误！"); break;
            }

            if (strMenu == "add") Console.WriteLine("新增成功");
            else if (strMenu == "edit") Console.WriteLine("编辑成功");
            else if (strMenu == "del") Console.WriteLine("删除成功");
            else Console.WriteLine("输入有误！");
        }

        static void Func3()
        {
            Console.WriteLine("题目描述：会员打折满1000打9折，普通用户满2000打9.5折（练习多分支和分支嵌套）：让用户输入自己的类型（VIP / USER）和消费金额，如果是VIP，判断消费金额是否达到1000，如果达到了，就输出他应该支付的金额，如果没有达到，也输出他应该支付的金额；如果是USER，判断消费金额是否达到2000，如果达到了和没有达到，都输出他应该支付的金额。");
            Console.WriteLine("请输入你的类型（vip/user）");
            string strUser = Console.ReadLine();
            Console.WriteLine("请输入你的消费金额");
            decimal numMoney = decimal.Parse(Console.ReadLine());
            switch (strUser)
            {
                case "vip":
                    {
                        if (numMoney >= 1000) Console.WriteLine($"你是{strUser},你应付的金额是{numMoney * 0.9m}");
                        else Console.WriteLine($"你是{strUser},你应付的金额是{numMoney}");
                        break;
                    }
                case "user":
                    {
                        if (numMoney >= 2000) Console.WriteLine($"你是{strUser},你应付的金额是{numMoney * 0.95m}");
                        else Console.WriteLine($"你是{strUser},你应付的金额是{numMoney}");
                        break;
                    }
                default: Console.WriteLine("输入的类型有误！"); break;
            }

            //if (strUser == "vip" && numMoney >= 1000) Console.WriteLine($"你是{strUser},你应付的金额是{numMoney * 0.9m}");
            //else if (strUser == "user" && numMoney >= 2000) Console.WriteLine($"你是{strUser},你应付的金额是{numMoney * 0.95m}");
            //else Console.WriteLine($"你是{strUser},你应付的金额是{numMoney}");
        }

        static void Func4()
        {
            Console.WriteLine("题目描述：通过月份判断季节（练习switch的穿透写法）：用户输入月份，判断月份如果是3、4、5月份，就输出这是春季；如果是6、7、8月份，就输出这是夏季；如果是9、10、11月份，就输出这是秋季，如果是12、1、2月份，就输出这是冬季。");
            Console.WriteLine("前请输入一个月份：");
            string strMon = Console.ReadLine();
            switch (strMon)
            {
                case "3":
                case "4":
                case "5": Console.WriteLine("这是春季"); break;
                case "6":
                case "7":
                case "8": Console.WriteLine("这是夏季"); break;
                case "9":
                case "10":
                case "11": Console.WriteLine("这是秋季"); break;
                case "12":
                case "1":
                case "2": Console.WriteLine("这是冬季"); break;
                default: Console.WriteLine("输入的月份有误！"); break;
            }
        }

        static void Func5()
        {
            Console.WriteLine("题目描述：快递运费（练习多分支）：输入快递重量，单位是Kg，如果重量小于1Kg，输出快递费10元；如果重量在1Kg~5Kg之间，就输出快递费20元；如果重量超过5Kg，就输出快递费50元。");
            Console.Write("请输入快递重量（kg）：");
            double numWeg = double.Parse(Console.ReadLine());
            if (numWeg < 1 && numWeg > 0) Console.WriteLine("快递费：10元");
            else if (numWeg < 5) Console.WriteLine("快递费：20元");
            else if (numWeg >= 5) Console.WriteLine("快递费：50元");
            else Console.WriteLine("请输入正确的重量");
        }

        static void Func6()
        {
            Console.WriteLine("题目描述：会员等级优惠（练习多分支和switch）：输入会员等级，等级是3~5的整数，判断等级如果是5，输出终身免运费；等级是4，输出每月可领优惠券；等级是3，输出购物打9折，否则没有福利。");
            Console.WriteLine("请输入你的会员等级（3-5）：");
            int numGrade = int.Parse(Console.ReadLine());
            switch (numGrade)
            {
                case 3: Console.WriteLine("购物打九折"); break;
                case 4: Console.WriteLine("每月可领优惠卷"); break;
                case 5: Console.WriteLine("终身免运费"); break;
                default: Console.WriteLine("请输入正确的会员等级"); break;
            }

            //if (numGrade == 3) Console.WriteLine("购物打九折");
            //else if(numGrade == 4) Console.WriteLine("每月可领优惠卷");
            //else if(numGrade == 5) Console.WriteLine("终身免运费");
            //else Console.WriteLine("请输入正确的会员等级");
        }

        static void Func7()
        {
            Console.WriteLine("题目描述：自动售货机选商品（练习多分支和switch）：输入商品编号整数，1就输出已购买可乐；2输出已购买雪碧；3输出已购买矿泉水；否则输出无此商品。");
            int numGoods = int.Parse(Console.ReadLine());
            switch (numGoods)
            {
                case 1: Console.WriteLine("已购买可乐"); break;
                case 2: Console.WriteLine("已购买雪碧"); break;
                case 3: Console.WriteLine("已购买矿泉水"); break;
                default: Console.WriteLine("无此商品"); break;
            }

            //if(numGoods== 1) Console.WriteLine("已购买可乐");
            //else if(numGoods== 2) Console.WriteLine("已购买雪碧");
            //else if(numGoods == 3) Console.WriteLine("已购买矿泉水");
            //else Console.WriteLine("无此商品");
        }

        static void Func8()
        {
            Console.WriteLine("题目描述：速度分级（练习多分支）：输入当前速度，如果在0~30，输出低速通过；30~60输出中速通过；60~100输出高速通过；100~120输出超速通过。");
            Console.WriteLine("请输入当前速度：");
            int numSpeed = int.Parse(Console.ReadLine());
            if (numSpeed > 0 && numSpeed <= 30) Console.WriteLine("低速通过");
            else if (numSpeed > 30 && numSpeed <= 60) Console.WriteLine("中速通过");
            else if (numSpeed > 60 && numSpeed <= 100) Console.WriteLine("高速通过");
            else if (numSpeed > 100 && numSpeed <= 120) Console.WriteLine("超速通过");
            else Console.WriteLine("输入的速度有误");

        }

        static void Main(string[] args)
        {
            Console.WriteLine("请输入你要查看的题号（1-8）");
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
                default: Console.WriteLine("输入的题号有误！"); break;
            }
        }
    }
}
