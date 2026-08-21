namespace day14
{
    internal static class Sundry
    {
        public static bool GetInput(out string? input)
        {
            input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("输入有误");
                return false;
            }
            return true;
        }
    }
}
