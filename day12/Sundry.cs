namespace day12
{
    internal class Sundry
    {
        private Sundry() { }

        // 日志输出
        public static void Log(string logMessage) => File.AppendAllText("D:\\Microsoft Visual Studio\\2022\\Project\\Homework\\day12\\log.txt", $"{DateTime.Now}：{logMessage}\n");

        // 终端信息输入
        public static bool GetInput(string LocationMessage, out string? res)
        {
            res = Console.ReadLine();
            if (!string.IsNullOrEmpty(res)) return true;
            Log($"{LocationMessage}输入有误。");
            return false;
        }
    }
}
