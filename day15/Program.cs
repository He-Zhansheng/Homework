namespace day15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 实例化一个管理类对象
            Manager manager = new Manager();

            // 菜单界面控制
            bool programStop = false;
            while (!programStop)
            {
                // 显示菜单界面，并接受用户选择
                Console.WriteLine("==欢迎来到神车系统==");
                Console.WriteLine("0：退出系统");
                Console.WriteLine("1：新增车辆");
                Console.WriteLine("2：查看所有车辆信息");
                Console.WriteLine("3：查看某辆车");
                Console.WriteLine("4：查看所有空闲车辆");
                Console.WriteLine("5：新增客户");
                Console.WriteLine("6：查看所有客户");
                Console.WriteLine("7：查看某个客户");
                Console.WriteLine("8：租车");
                Console.WriteLine("9：换车");
                Console.Write("请在以上选项中选择合适的数字：");
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "0":
                        {
                            programStop = true;
                            break;
                        }
                    case "1":
                        {
                            manager.AddCar();
                            break;
                        }
                    case "2":
                        {
                            manager.ShowCar();
                            break;
                        }
                    case "3":
                        {
                            Console.Write("请输入要查询车辆的ID：");
                            if (int.TryParse(Console.ReadLine(), out int idCar)) manager.ShowCar(idCar);
                            else Console.WriteLine("请输入正确的id");
                            break;
                        }
                    case "4":
                        {
                            manager.ShowIdleCar();
                            break;
                        }
                    case "5":
                        {
                            manager.AddCustomer();
                            break;
                        }
                    case "6":
                        {
                            manager.ShowCustomer();
                            break;
                        }
                    case "7":
                        {
                            Console.Write("请输入要查询用户的ID：");
                            if (int.TryParse(Console.ReadLine(), out int idCar)) manager.ShowCustomer(idCar);
                            else Console.WriteLine("请输入正确的id");
                            break;
                        }
                    case "8":
                        {
                            Console.Write("请输入要租借车辆的ID：");
                            if (!int.TryParse(Console.ReadLine(), out int idCar)) Console.WriteLine("请输入正确的id");
                            else
                            {
                                Console.Write("请输入客户的ID：");
                                if (!int.TryParse(Console.ReadLine(), out int idCustomer)) Console.WriteLine("请输入正确的id");
                                else manager.AddRecord(idCar, idCustomer);
                            }
                            break;
                        }
                    case "9":
                        {
                            Console.Write("请输入要归还的租界订单的ID：");
                            if (!int.TryParse(Console.ReadLine(), out int idRecord)) Console.WriteLine("请输入正确的id");
                            manager.ReturnCar(idRecord);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("请按序号输入正确的数字！");
                            break;
                        }
                }
            }
        }
    }
}
