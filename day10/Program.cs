using System.Text.Json;
using System.Text.RegularExpressions;

namespace day10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 作业1
            // 1.使用读写文件配合命令行窗口 模拟实现注册功能,要求输入用户名和密码,完成注册; (注册的用户信息记录在user.txt文件中, 一行一个用户信息 数据之间通过 === 分隔)
            //Func<bool> register = () =>
            //{
            //    Console.Write("输入用户名：");
            //    string userName = Console.ReadLine();
            //    string filePath = "D:\\Microsoft Visual Studio\\2022\\Project\\Homework\\day10\\user.txt";
            //    string fileMessage = File.ReadAllText(filePath);
            //    if (Regex.IsMatch(fileMessage, $"{userName}===*"))
            //    {
            //        Console.WriteLine($"用户名{userName}已存在，请换一个用户名");
            //        return false;
            //    }
            //    Console.Write("输入密码：");
            //    string userPassword = Console.ReadLine();

            //    File.AppendAllText(filePath, $"{userName}==={userPassword}\n");
            //    return true;
            //};

            //register();
            #endregion

            #region 作业2
            /*扩展练习:  使用读写文件配合命令行窗口  模拟实现注册登录功能进入就是菜单栏界面, 1注册,2登录,0退出
            输入1 进入注册, 要求输入用户名,密码, 用户输入用户名和密码 则实现注册功能, 要求校验用户名和密码
            输入2 进入登录, 要求输入用户名, 密码, 输入后完成登录校验功能; 登录成功提示 登录成功
            输入0 退出程序,
            -用户注册成功的用户信息 以文件的形式存储在user.json中(要求以json形式存储)
            - [{ username: "",password: "",datetime: "时间戳"}]
            -用户操作日志user.log: 用户每次操作都要有日志记录, 记录操作,用户名,操作方式,时间,如果有异常的,记录异常*/
            Action<string> Log = (logMessage) => File.AppendAllText("D:\\Microsoft Visual Studio\\2022\\Project\\Homework\\day10\\log.txt", $"{DateTime.Now}：{logMessage}\n");

            Func<string, string, string?> GetFileMessage = (filePath, exMessage) =>
            {
                try
                {
                    return File.ReadAllText(filePath);
                }
                catch (Exception ex)
                {
                    Log($"{exMessage}文件路径为：\n{filePath}。\n具体错误信息：\n{ex.Message}");
                    return null;
                }
            };

            bool GetInput(string exMessage, out string? res)
            {
                res = Console.ReadLine();
                if (!string.IsNullOrEmpty(res)) return true;
                Log($"{exMessage}输入有误。");
                return false;
            }

            Func<bool> Register = () =>
            {
                string filePath = "D:\\Microsoft Visual Studio\\2022\\Project\\Homework\\day10\\user.json";
                string? fileMessage = GetFileMessage(filePath, $"注册界面读取文件失败。");
                if (fileMessage == null)
                {
                    Console.WriteLine("程序系统出错");
                    return false;
                }

                Console.WriteLine("-----分割线-----\n注册界面\n-----分割线-----");
                Console.Write("输入用户名：");
                if (!GetInput("游客用户在注册界面输入用户名时", out string? userName)) return false;
                if (Regex.IsMatch(fileMessage, $"\"username\":\"{userName}\"*"))
                {
                    Console.WriteLine($"用户名{userName}已存在，请换一个用户名");
                    Log($"游客用户在注册界面输入用户名时输入了一个已注册的用户名。");
                    return false;
                }
                Console.Write("输入密码：");
                if (GetInput("游客用户在注册界面输入密码时", out string? userPassword))
                {
                    Dictionary<string, dynamic> user = new()
                    {
                        ["username"] = userName,
                        ["password"] = userPassword,
                        ["datetime"] = DateTime.Now
                    };
                    File.AppendAllText(filePath, JsonSerializer.Serialize(user));
                    Log($"用户{userName}注册成功。");
                    return true;
                }
                return false;
            };

            Action Login = () =>
            {
                string filePath = "D:\\Microsoft Visual Studio\\20221\\Project\\Homework\\day10\\user.json";
                string? fileMessage = GetFileMessage(filePath, $"登录界面读取文件失败。");
                if (fileMessage == null)
                {
                    Console.WriteLine("程序系统出错");
                    return;
                }
                Console.WriteLine("-----分割线-----\n登陆界面\n-----分割线-----");
                Console.Write("输入用户名：");
                if (!GetInput("游客用户在登录界面输入用户名时", out string? userName)) return;
                if (!Regex.IsMatch(fileMessage, $"\"username\":\"{userName}\"*"))
                {
                    Console.WriteLine($"用户名{userName}不存在，请换一个用户名");
                    Log($"游客用户在登录界面输入用户名时输入了一个未注册的用户名。");
                    return;
                }
                Console.Write("输入密码：");
                if (GetInput("游客用户在注册界面输入密码时", out string? userPassword))
                {
                    if (Regex.IsMatch(fileMessage, $"\"username\":\"{userName}\",\"password\":\"{userPassword}\"*"))
                    {
                        Console.WriteLine("登录成功");
                        Log($"用户{userName}登录成功。");
                        return;
                    }
                    Log($"用户{userName}在登录界面输入密码时输入了一个错误的密码。");
                }
                Console.WriteLine("输入的密码有误");
            };

            bool flagProgramme = true;
            while (flagProgramme)
            {
                Console.Write("请选择你要进行的服务（1注册,2登录,0退出）：");
                if (!GetInput("游客用户在菜单界面输入服务号时", out string? mode)) continue;

                switch (mode)
                {
                    case "0": flagProgramme = false; break;
                    case "1":
                        {
                            if (true == Register())
                            {
                                Console.WriteLine("注册成功");
                                Login();
                            }
                            break;
                        }
                    case "2":
                        {
                            Login();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("您输入的服务号有误：0-2");
                            Log("游客用户在菜单界面输入服务号时输入了错误的服务号。");
                            break;
                        }
                }
            }

            #endregion
        }
    }
}
