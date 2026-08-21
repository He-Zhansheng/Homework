namespace day14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool flagProgram = true;
            BookManager manager = new BookManager("D:\\Microsoft Visual Studio\\2022\\Project\\Homework\\day14\\book.json");

            Action<Dictionary<string, dynamic>> OutBook = (book) =>
            {
                foreach (var item in book) Console.WriteLine($"{item.Key}：{item.Value}");
            };
            while (flagProgram)
            {
                Console.Write("====图书管理系统====\n1、新增数据\n2、编辑数据\n3、删除数据\n4、查询所有数据\n5、根据名称查询对应数据\n0、退出系统\n请输入你的选择：");
                if (!Sundry.GetInput(out string? selection)) continue;

                switch (selection)
                {
                    case "0":
                        {
                            flagProgram = false;
                            break;
                        }
                    case "1":
                        {

                            break;
                        }
                    case "2":
                        {
                            Console.Write("====修改数据====\n请输入书名：");
                            if (Sundry.GetInput(out string? bookName))
                            {
                                Dictionary<string, dynamic>? book = manager.SearchBook(bookName);
                                if (book == null)
                                {
                                    Console.WriteLine($"未找到书籍《{bookName}》");
                                }
                                else
                                {
                                    Console.Write("请输入书名：");
                                    if (Sundry.GetInput(out bookName))
                                    {
                                        Console.Write("请输入作者名：");
                                        if (Sundry.GetInput(out string? author))
                                        {
                                            Console.Write("请输入标签：");
                                            if (Sundry.GetInput(out string? mark))
                                            {
                                                Console.Write("请输入价格：");
                                                if (Sundry.GetInput(out string? price))
                                                {
                                                    book["name"] = bookName;
                                                    book["author"] = author;
                                                    book["mark"] = mark;
                                                    book["price"] = price;
                                                }
                                                if ()
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    case "3":
                        {
                            Console.Write("====删除数据====\n请输入书名：");
                            if (Sundry.GetInput(out string? bookName))
                            {
                                if (manager.RemoveBook(bookName)) Console.WriteLine($"已删除书籍《{bookName}》");
                                else Console.WriteLine($"删除失败！未找到书籍《{bookName}》");
                            }

                            break;
                        }
                    case "4":
                        {
                            Console.Write("====查询所有数据====\n");
                            List<Dictionary<string, dynamic>> books = manager.SearchAllBook();
                            if (books.Count == 0)
                            {
                                Console.WriteLine("当前系统未收录书籍");
                            }
                            else
                            {
                                foreach (var item in books) OutBook(item);
                            }
                            break;
                        }
                    case "5":
                        {
                            Console.Write("====查询指定书名数据====\n请输入书名：");
                            if (Sundry.GetInput(out string? bookName))
                            {
                                Dictionary<string, dynamic>? book = manager.SearchBook(bookName);
                                if (book == null)
                                {
                                    Console.WriteLine($"未找到书籍《{bookName}》");
                                }
                                else
                                {
                                    Console.WriteLine("书籍信息如下：");
                                    OutBook(book);
                                }
                            }
                            break;
                        }
                }

            }
        }
    }
}
