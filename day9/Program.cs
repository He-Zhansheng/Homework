using System.Text.Json;

namespace day9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Dictionary<string, dynamic>> list = new() {
                new Dictionary<string, dynamic>(){
                    ["name"] = "zs",
                    ["age"] = 29,
                    ["isMan"] = true,
                    ["isSingle"] = true,
                    ["salary"] = 4200
                },
                new Dictionary<string, dynamic>(){
                    ["name"] = "ls",
                    ["age"] = 20,
                    ["isMan"] = false,
                    ["isSingle"] = true,
                    ["salary"] = 3400
                },
                new Dictionary<string, dynamic>(){
                    ["name"] = "ww",
                    ["age"] = 19,
                    ["isMan"] = true,
                    ["isSingle"] = false,
                    ["salary"] = 6000
                },
                new Dictionary<string, dynamic>(){
                    ["name"] = "zl",
                    ["age"] = 14,
                    ["isMan"] = false,
                    ["isSingle"] = true,
                    ["salary"] = 2000
                },
                new Dictionary<string, dynamic>(){
                    ["name"] = "sq",
                    ["age"] = 35,
                    ["isMan"] = true,
                    ["isSingle"] = false,
                    ["salary"] = 7000
                },
                new Dictionary<string, dynamic>(){
                    ["name"] = "zb",
                    ["age"] = 27,
                    ["isMan"] = false,
                    ["isSingle"] = true,
                    ["salary"] = 2900
                },
            };
            // 作业1
            // Find: 要求查找年龄小于20的
            //Dictionary<string, dynamic> persion = list.Find((item) =>
            //{
            //    return item["age"] < 20;
            //});
            //Console.WriteLine(JsonSerializer.Serialize(persion));
            // FindLast: 要求查找年龄大于25的
            //Dictionary<string, dynamic> persion1 = list.FindLast((item) =>
            //{
            //    return item["age"] > 25;
            //}
            //    );
            //Console.WriteLine(JsonSerializer.Serialize(persion1));
            // FindAll: 找出性别男的
            //List<Dictionary<string, dynamic>> persions = list.FindAll((item) =>
            //{
            //    return item["isMan"] == true;
            //}
            //);
            //foreach (var item in persions) Console.WriteLine(JsonSerializer.Serialize(item));

            // FindIndex: 找出薪水大于5000
            //int index = list.FindIndex((item) => item["salary"] > 5000
            //    );
            //Console.WriteLine(JsonSerializer.Serialize(list[index]));

            // FindLastIndex: 找出薪水小于3000
            //int index1 = list.FindLastIndex(item => item["salary"] < 3000
            //    );
            //Console.WriteLine(JsonSerializer.Serialize(list[index1]));

            // Exists: 判断是否有薪水大于5000
            //Console.WriteLine(list.Exists(item => item["salary"] > 5000));

            // ForEach: 输出每个的 名字-年龄-薪水
            //list.ForEach(item =>
            //{
            //    Console.WriteLine($"{item["name"]}-{item["age"]}-{item["salary"]}");
            //}
            //    );

            // ConvertAll: 映射得到一个所以薪水的list
            //List<dynamic> salaries = list.ConvertAll(item => item["salary"]);
            //Console.WriteLine(JsonSerializer.Serialize(salaries));

            //TrueForAll: 判断是否都成年
            //Console.WriteLine(list.TrueForAll(item => item["age"] >= 18));

            //  作业2:  封装一个函数 接收一个字符串; 返回一个字典,键是字符串的每个字符,键值是这个字符在字符串中出现的次数
            Func<string, Dictionary<char, int>> homework2 = str =>
            {
                Dictionary<char, int> res = new();
                for (int i = 0; i < str.Length - 1; i++)
                {
                    if (res.ContainsKey(str[i])) continue;     // 避免重复计算
                    int numCount = 1;
                    for (int j = i + 1; j < str.Length; j++)
                    {
                        if (str[i] == str[j]) numCount++;
                    }
                    res.Add(str[i], numCount);
                }
                return res;
            };

            Console.Write("请输入一个字符串：");
            string str = Console.ReadLine();
            Dictionary<char, int> res = homework2(str);
            Console.WriteLine(JsonSerializer.Serialize(res));
        }
    }
}
