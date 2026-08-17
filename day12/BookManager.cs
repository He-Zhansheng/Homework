using System.Text.Json;

namespace day12
{
    internal class BookManager
    {
        private string MessagePath;
        string? booksMessage;
        List<Dictionary<string, dynamic>> books;
        public BookManager()
        {
            MessagePath = "D:\\Microsoft Visual Studio\\2022\\Project\\Homework\\day12\\book.json";
            booksMessage = GetMessage();
            if (booksMessage == null)
            {
                Console.WriteLine("程序系统出错");
                return;
            }
            books = string.IsNullOrWhiteSpace(booksMessage) ? new() : JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(booksMessage);
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

            book["isBorrow"] = true;
            Random tmp = new Random();
            book["id"] = tmp.NextDouble();

            books.Add(book);
            File.WriteAllText(MessagePath, JsonSerializer.Serialize(books));

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

            File.WriteAllText(MessagePath, JsonSerializer.Serialize(books));
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
            Console.WriteLine("删除完成");
        }

        public void SearchAllBook()
        {
            Console.Write("====查询所有数据====\n");
            Sundry.Log($"用户查询系统收录的所有书籍");

            books.ForEach(item => Console.WriteLine(JsonSerializer.Serialize(item)));
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
            Console.WriteLine(JsonSerializer.Serialize(book));
            Sundry.Log($"用户查询书籍{bookMessage}");
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

        string? GetMessage()
        {
            try
            {
                return File.ReadAllText(MessagePath);
            }
            catch (Exception ex)
            {
                Sundry.Log($"图书信息存储的路径为：\n{MessagePath}。\n具体错误信息：\n{ex.Message}");
                return null;
            }
        }
    }
}
