namespace day12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool flagProgram = true;
            while (flagProgram)
            {
                Console.Write("====图书管理系统====\n1、新增数据\n2、编辑数据\n3、删除数据\n4、查询所有数据\n5、根据名称查询对应数据\n6、借阅书籍\n0、退出系统\n请输入你的选择：");
                if (!Sundry.GetInput("用户在图书管理系统界面输入选择时", out string? selection)) continue;

                BookManager bookManager = new BookManager();
                switch (selection)
                {
                    case "0":
                        {
                            Sundry.Log("用户退出系统");
                            flagProgram = false;
                            break;
                        }
                    case "1":
                        {
                            bookManager.AddBook();
                            break;
                        }
                    case "2": bookManager.UpdateBook(); break;
                    case "3": bookManager.RemoveBook(); break;
                    case "4": bookManager.SearchAllBook(); break;
                    case "5": bookManager.SearchBook(); break;
                    case "6": bookManager.GetBook(); break;
                    default:
                        {
                            Console.WriteLine("您输入的服务号有误：0-6");
                            Sundry.Log("用户在菜单界面输入选择时输入了错误的序号。");
                            break;
                        }
                }
            }
        }
    }

}
