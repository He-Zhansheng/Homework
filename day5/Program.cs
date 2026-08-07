namespace day5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////1、通过歌曲查找歌手
            //List<Dictionary<string, dynamic>> singerList = new List<Dictionary<string, dynamic>>
            //{
            //    new Dictionary<string, dynamic>
            //    {
            //        {"singerId", 1001},
            //        {"singerName", "周杰伦"},
            //        {"genre", "流行"}
            //    },
            //    new Dictionary<string, dynamic>
            //    {
            //        {"singerId", 1002},
            //        {"singerName", "林俊杰"},
            //        {"genre", "华语流行"}
            //    },
            //    new Dictionary<string, dynamic>
            //    {
            //        {"singerId", 1003},
            //        {"singerName", "邓紫棋"},
            //        {"genre", "流行、摇滚"}
            //    },
            //    new Dictionary<string, dynamic>
            //    {
            //        {"singerId", 1004},
            //        {"singerName", "薛之谦"},
            //        {"genre", "抒情流行"}
            //    },
            //    new Dictionary<string, dynamic>
            //    {
            //        {"singerId", 1005},
            //        {"singerName", "毛不易"},
            //        {"genre", "民谣流行"}
            //    }
            //};

            //List<Dictionary<string, dynamic>> songList = new List<Dictionary<string, dynamic>>
            //{
            //    new Dictionary<string, dynamic>
            //    {
            //        {"songId", 10001},
            //        {"singerId", 1001},
            //        {"songName", "青花瓷"},
            //        {"duration", 239}
            //    },
            //    new Dictionary<string, dynamic>
            //    {
            //        {"songId", 10002},
            //        {"singerId", 1001},
            //        {"songName", "发如雪"},
            //        {"duration", 253}
            //    },
            //    new Dictionary<string, dynamic>
            //    {
            //        {"songId", 10003},
            //        {"singerId", 1001},
            //        {"songName", "东风破"},
            //        {"duration", 215}
            //    },
            //    new Dictionary<string, dynamic>
            //    {
            //        {"songId", 1004},
            //        {"singerId", 1002},
            //        {"songName", "不为谁而作的歌"},
            //        {"duration", 296}
            //    },
            //    new Dictionary<string, dynamic>
            //    {
            //        {"songId", 1005},
            //        {"singerId", 1002},
            //        {"songName", "背对背拥抱"},
            //        {"duration", 262}
            //    }
            //};

            //Console.WriteLine("输入歌曲名称：");
            //string songName = Console.ReadLine();
            //bool isAlive = false;
            //int singerId = 0;
            //foreach (var messageSong in songList)
            //{
            //    if (messageSong["songName"] == songName)
            //    {
            //        isAlive = true;
            //        singerId = messageSong["singerId"];
            //        break;
            //    }
            //}

            //if (isAlive)
            //{
            //    foreach (var messageSinger in singerList)
            //    {
            //        if (messageSinger["singerId"] == singerId)
            //        {
            //            Console.WriteLine($"《{songName}》的歌手是：{messageSinger["singerName"]}");
            //            break;
            //        }
            //    }
            //}
            //else Console.WriteLine("未找到该歌曲！");

            // 2.排序
            //List<Dictionary<string, dynamic>> goodsList = new List<Dictionary<string, dynamic>>
            //{
            //    new Dictionary<string, dynamic>
            //    {
            //        {"name", "机械键盘"},
            //        {"price", 299.99},
            //        {"code", "G001"},
            //        {"stock", 120}
            //    },
            //    new Dictionary<string, dynamic>
            //    {
            //        {"name", "无线鼠标"},
            //        {"price", 89.50},
            //        {"code", "G002"},
            //        {"stock", 356}
            //    },
            //    new Dictionary<string, dynamic>
            //    {
            //        {"name", "27寸显示器"},
            //        {"price", 1299.00},
            //        {"code", "G003"},
            //        {"stock", 48}
            //    },
            //    new Dictionary<string, dynamic>
            //    {
            //        {"name", "电竞耳机"},
            //        {"price", 199.00},
            //        {"code", "G004"},
            //        {"stock", 85}
            //    },
            //    new Dictionary<string, dynamic>
            //    {
            //        {"name", "电脑支架"},
            //        {"price", 69.90},
            //        {"code", "G005"},
            //        {"stock", 210}
            //    }
            //};

            //// 提示输入的 是price还是stock  排序类型
            //Console.WriteLine("请输入排序的根据（price/stock）：");
            //string strType = Console.ReadLine();
            //// 提示输入的是 ASC 还是DSC     排序顺序(ASC升序,DSC降序)
            //Console.WriteLine("请输入排序的方法(ASC升序,DSC降序)：");
            //string strMethod = Console.ReadLine();
            //// 根据输入完成数据排序
            //Dictionary<string, dynamic> dicTmp;
            //for (int i = goodsList.Count - 1; i > 0; i--)
            //{
            //    for (int j = 0; j < i; j++)
            //    {
            //        if (strMethod == "ASC")
            //        {
            //            if (goodsList[j][strType] > goodsList[j + 1][strType])
            //            {
            //                dicTmp = goodsList[j];
            //                goodsList[j] = goodsList[j + 1];
            //                goodsList[j + 1] = dicTmp;
            //            }
            //        }
            //        else
            //        {
            //            if (goodsList[j][strType] < goodsList[j + 1][strType])
            //            {
            //                dicTmp = goodsList[j];
            //                goodsList[j] = goodsList[j + 1];
            //                goodsList[j + 1] = dicTmp;
            //            }
            //        }
            //    }
            //}
            ////输出
            //foreach (var goods in goodsList)
            //{
            //    foreach (var messageGoods in goods)
            //    {
            //        Console.WriteLine(messageGoods);
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
