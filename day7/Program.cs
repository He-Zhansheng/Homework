using System.Text.RegularExpressions;

namespace day7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1.数据加密
            //string text = "清风漫过湖畔，午间薄雾缓缓消散，夜色悄然而至，河水静静流淌，渡船缓缓靠岸，渡口游人往来，相逢知己相交，互换见闻感受，留心世间风情，记录山河晚报。";

            // 1.1通过情报内容获取到下标：
            //string salt = "7-16-30-38-49-52-63-70";
            //string res = "";
            //string[] strIndexes = salt.Split("-");
            //foreach (string item in strIndexes)
            //{
            //    res = res + text[int.Parse(item)];
            //}
            //Console.WriteLine("破译的情报是：" + res);

            // 1.2为了更安全，生成密文的时候可以调整下标：（上一个字符）
            //string strMessage = "午夜渡口交换情报";
            //string salt = "";
            //foreach (char item in strMessage)
            //{
            //    salt = salt + (text.IndexOf(item) - 1) + "-";
            //}
            //salt = salt.Substring(0, salt.Length - 1);
            //Console.WriteLine($"生成的密文是：{salt}");

            // 1.3通过密文获获取情报的时候，需要在原本的下标基础上+1：
            //string salt = "6-15-29-37-48-51-62-69";
            //string strMessage = "";
            //string[] strIndexes = salt.Split("-");
            //foreach (string item in strIndexes)
            //{
            //    strMessage = strMessage + text[int.Parse(item) + 1];
            //}
            //Console.WriteLine($"破译的情报是：{strMessage}");

            // 1.4还可以在生成密文的时候，奇数就-1，偶数就+1：
            //string strMessage = "午夜渡口交换情报";
            //string salt = "";
            //foreach (char item in strMessage)
            //{
            //    int index = text.IndexOf(item);
            //    if (index % 2 == 0)
            //    {
            //        salt = salt + (index + 1) + "-";
            //    }
            //    else
            //    {
            //        salt = salt + (index - 1) + "-";
            //    }
            //}
            //salt = salt.Substring(0, salt.Length - 1);
            //Console.WriteLine($"生成的密文是：{salt}");     

            // 1.5此时找到情报的时候，也要判断下标是奇数还是偶数，奇数就-1，偶数就+1：
            //string salt = "6-17-31-39-48-53-62-71";
            //string strMessage = "";
            //string[] strIndexes = salt.Split("-");
            //foreach (string item in strIndexes)
            //{
            //    int index = int.Parse(item);
            //    index += index % 2 == 0 ? 1 : -1;
            //    strMessage += text[index];
            //}
            //Console.WriteLine($"破译的情报是：{strMessage}");

            // 2数字转汉字 
            int money = 300456;
            // 创建汉字数组
            string[] arr = ["零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖"];
            // 创建单位数组
            string[] units = ["", "拾", "佰", "仟", "萬", "拾", "佰", "仟", "亿"];
            string res = "";

            // 为了方便对每一个位数进行操作，将每一个位数的数字单独存储
            string nums = money.ToString();
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                int indexUnits = nums.Length - 1 - i;
                // "萬"字特殊，不管"萬"字位是不是零都要输出单位
                if (units[indexUnits] == "萬" || nums[i] != 48)
                    res = arr[nums[i] - 48] + units[indexUnits] + res;
                else
                    res = arr[nums[i] - 48] + res;
            }
            // 将结果中"萬"字位前面相连的零去除
            res = Regex.Replace(res, @"零+萬", "萬");
            // 将结果中含有多个"零"的部分替换为一个"零"
            res = Regex.Replace(res, @"零{2,}", "零");
            // 将结果中末尾的"零"去除
            res = Regex.Replace(res, @"零$", "");
            Console.WriteLine($"数字：{money}转换成汉字是：{res}");
        }
    }
}
