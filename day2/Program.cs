namespace day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //字典
            var scores = new Dictionary<string, int>
            {
                { "张三", 85 },
                { "李四", 92 },
                { "王五", 78 }
            };
            //scores.Add("赵六", 90); // 添加新的键值对
            //scores.TryAdd("赵六", 90); // 尝试添加新的键值对，如果键已存在则不会添加
            //scores.Remove("王五"); // 删除指定键的键值对
            //scores.TryGetValue("李四", out int score); // 尝试获取指定键的值，如果键不存在则返回false
            //scores.ContainsKey("张三"); // 判断字典中是否包含指定键
            //scores.ContainsValue(85); // 判断字典中是否包含指定值
            //scores.Clear(); // 清空字典
            //scores.Take(scores.Count / 2); // 获取字典中前一半的键值对,返回一个新的字典
            //scores.Skip(scores.Count / 2); // 获取字典中后一半的键值对,返回一个新的字典,底层是跳过前一半的键值对。
            //scores.OrderBy(x => x.Value); // 按照值升序排序字典,返回一个新的字典
            //scores.OrderByDescending(x => x.Value); // 按照值降序排序字典,返回一个新的字典

            //list集合
            List<int> listTest = new List<int>() { 1, 2, 3, 4, 5 };

            //listTest.Add(1);                                        // 追加数据，语法：list数据.Add(数据)
            //listTest.AddRange(new List<int>() { 6, 7, 8 });         // 追加集合，语法：list数据.AddRange(集合数据)
            //listTest.Remove(1);                                     // 删除指定数据，语法：list数据.Remove(数据)
            //listTest.RemoveAt(listTest.Count - 1);                  // 删除指定索引的数据，语法：list数据.RemoveAt(索引)
            //listTest.RemoveAll(x => x == 2);                        // 删除所有符合条件的数据，语法：list数据.RemoveAll(条件)
            //listTest.Clear();                                       // 清空集合，语法：list数据.Clear()
            //listTest.RemoveRange(0, 2);                             // 删除指定范围的数据，语法：list数据.RemoveRange(起始索引, 删除数量)
            //listTest.Insert(0, 1);                                    // 在指定索引插入数据，语法：list数据.Insert(索引, 数据)
            //listTest.InsertRange(0, new List<int>() { 1, 2, 3 });     // 在指定索引插入集合，语法：list数据.InsertRange(索引, 集合数据)
            //listTest.Contains(1);                                    // 判断集合中是否包含指定数据，语法：list数据.Contains(数据)
            //listTest.IndexOf(1);                                     // 获取指定数据第一次出现在集合中的索引，语法：list数据.IndexOf(数据)
            //listTest.LastIndexOf(1);                                 // 获取指定数据最后一次出现在集合中的索引，语法：list数据.LastIndexOf(数据)
            //listTest.Sort();                                         // 对集合进行升序排序，语法：list数据.Sort()
            //listTest.Reverse();                                      // 对集合进行反转，语法：list数据.Reverse()
        }
    }
}
