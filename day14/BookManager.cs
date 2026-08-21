using System.Text.Json;

namespace day14
{
    internal class BookManager
    {
        string DataPath { get; }
        List<Dictionary<string, dynamic>> DataBooks { get; set; }

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,// JSON序列化时候美化
            AllowTrailingCommas = true, // JSON反序列化时候允许 最后出现逗号
        };

        public BookManager(string path)
        {
            DataPath = path;
            // 判断文件是否存在，如果不存在则创建
            if (!File.Exists(DataPath)) File.WriteAllText(DataPath, "");
            string DataJson = File.ReadAllText(DataPath);

            DataBooks = string.IsNullOrWhiteSpace(DataJson) ? new() : JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(DataJson);
        }

        void UpdateData()
        {
            File.WriteAllText(DataPath, JsonSerializer.Serialize(DataBooks, options));
        }

        public void UpdateBook(Dictionary<string, dynamic> book)
        {

        }

        public bool RemoveBook(string bookName)
        /*删除指定书籍*/
        {
            Dictionary<string, dynamic>? book = SearchBook(bookName);
            if (book != null)
            {
                DataBooks.Remove(book);

                UpdateData();           // 完成后更新数据
                return true;
            }
            return false;
        }

        public List<Dictionary<string, dynamic>> SearchAllBook()
        /*查找所有书籍*/
        {
            return DataBooks;
        }

        public Dictionary<string, dynamic>? SearchBook(string bookName)
        /*根据书名查找书籍*/
        {
            // 找到了就返回对应书籍的信息，没找到就返回null
            foreach (var item in DataBooks)
            {
                if (item["name"].GetString() == bookName) return item;
            }

            return null;
        }
    }
}
