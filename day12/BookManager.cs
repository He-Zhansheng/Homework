using System.Text.Json;

namespace day12
{
    internal class BookManager
    {
        private string MessagePath { get; set; }
        string? booksMessage;
        List<Dictionary<string, dynamic>> books;

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,// JSON序列化时候美化
            AllowTrailingCommas = true, // JSON反序列化时候允许 最后出现逗号
        };

        public BookManager()
        {
            MessagePath = "D:\\Microsoft Visual Studio\\2022\\Project\\Homework\\day12\\book.json";
            // 判断文件是否存在，如果不存在则创建
            if (!File.Exists(MessagePath)) File.WriteAllText(MessagePath, "");
            booksMessage = File.ReadAllText(MessagePath);

            books = string.IsNullOrWhiteSpace(booksMessage) ? new() : JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(booksMessage);
        }

        void UpdateData()
        {
            File.WriteAllText(MessagePath, JsonSerializer.Serialize(books, options));
        }

        public void AddBook()
        {
            Console.Write("====新增数据====\n请输入书名：");
            if (!Sundry.GetInput("用户在新增数据界面输入书名时", out string? bookMessage)) return;
            Dictionary<string, dynamic>? book = books.Find(item => item["name"].GetString() == bookMessage);
            if (book != null)
            {
                Console.WriteLine("该书已被收录");
                Sundry.Log($"用户添加了一个已被收录的图书");
                return;
            }

            book = new Dictionary<string, dynamic>()
            {
                ["name"] = bookMessage
            };
            if (!ModifyMessage(book, $"书籍{book["name"]}", "新增数据")) return;

            book["isBorrow"] = false;
            book["id"] = new Random().NextDouble();

            books.Add(book);
            UpdateData();

            Console.WriteLine("新增成功");
            Sundry.Log($"新增书本{book["name"]}成功");
        }

        public void UpdateBook()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("当前没有书籍可以修改");
                Sundry.Log("用户尝试在空系统内修改数据");
                return;
            }

            Console.Write("====修改数据====\n请输入书名：");
            if (!Sundry.GetInput("用户在修改数据界面输入书名时", out string? bookMessage)) return;
            Dictionary<string, dynamic>? book = books.Find(item => item["name"].GetString() == bookMessage);
            if (book == null)
            {
                Console.WriteLine($"未找到书籍{bookMessage}");
                Sundry.Log($"用户尝试修改未收录书籍{bookMessage}");
                return;
            }

            Console.Write("请输入修改后的书名:");
            if (!Sundry.GetInput("用户在修改数据界面输入新书名时", out bookMessage)) return;
            book["name"] = bookMessage;
            if (!ModifyMessage(book, "修改后", "修改数据")) return;

            UpdateData();
            Console.WriteLine("修改成功");
            Sundry.Log($"修改书本{book["name"]}成功");
        }

        public void RemoveBook()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("当前没有书籍可以删除");
                Sundry.Log("用户尝试在空系统内删除数据");
                return;
            }

            Console.Write("====删除数据====\n请输入书名：");
            if (!Sundry.GetInput("用户在删除数据界面输入书名时", out string? bookMessage)) return;

            if (books.RemoveAll(item => item["name"].GetString() == bookMessage) != 0) Sundry.Log($"用户删除书籍{bookMessage}");
            UpdateData();
            Console.WriteLine("删除完成");
        }

        public void SearchAllBook()
        {
            Console.Write("====查询所有数据====\n");
            Sundry.Log($"用户查询系统收录的所有书籍");

            books.ForEach(item => { foreach (var item1 in item) Console.WriteLine($"{item1.Key}:{item1.Value}"); });
        }

        public void SearchBook()
        {
            Console.Write("====查询指定书名数据====\n请输入书名：");
            if (!Sundry.GetInput("用户在删除数据界面输入书名时", out string? bookMessage)) return;

            Dictionary<string, dynamic>? book = books.Find(item => item["name"].GetString() == bookMessage);
            if (book == null)
            {
                Console.WriteLine($"未找到书籍{bookMessage}");
                Sundry.Log($"用户查看未收录书籍{bookMessage}");
                return;
            }
            foreach (var item1 in book) Console.WriteLine($"{item1.Key}:{item1.Value}");

            Sundry.Log($"用户查询书籍{bookMessage}");
        }

        public bool GetBook()
        {
            Console.WriteLine("====借阅书籍====\n目前系统内可借阅的书籍如下：");
            Sundry.Log($"用户查询系统可借阅的所有书籍");
            books.ForEach(item =>
            {
                if (!item["isBorrow"].GetBoolean()) Console.WriteLine(item["name"]);
            }
            );
            Console.WriteLine("请输入你要借阅的书籍名（按0取消）：");
            if (Sundry.GetInput($"用户在借阅书籍界面输入借阅书籍名时", out string? bookName))
            {
                if (bookName != "0")
                {
                    foreach (var item in books)
                    {
                        if (item["name"].GetString() == bookName)
                        {
                            Console.WriteLine("借阅成功");
                            item["isBorrow"] = true;
                            Sundry.Log($"用户借阅书籍{bookName}");
                            UpdateData();
                            return true;
                        }
                    }
                    Console.WriteLine("书籍名有误");
                }
            }
            return false;
        }

        bool ModifyMessage(Dictionary<string, dynamic> book, string messageModify, string messageLocation)
        {
            string? bookMessage;
            Console.Write($"请输入{messageModify}的作者名：");
            if (!Sundry.GetInput($"用户在{messageLocation}界面输入{messageModify}作者名时", out bookMessage)) return false;
            book["author"] = bookMessage;

            Console.Write($"请输入{messageModify}的标签：");
            if (!Sundry.GetInput($"用户在{messageLocation}界面输入{messageModify}标签时", out bookMessage)) return false;
            book["mark"] = bookMessage;

            Console.Write($"请输入{messageModify}的价格：");
            if (!Sundry.GetInput($"用户在{messageLocation}界面输入{messageModify}价格时", out bookMessage)) return false;
            book["price"] = bookMessage;
            return true;
        }
    }
}
