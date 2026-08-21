using System.Text.Json;
using System.Text.RegularExpressions;

namespace day15
{
    internal class Manager
    {
        // 实例化一个客户信息列表
        List<Customer> DataCustomers;

        // 实例化一个车辆信息列表
        List<Car> DataCars;

        // 实例化一个车辆租还记录信息列表
        List<Record> DataRecords;

        // 保存信息文件路径
        string pathCar = "./Data_car.json";
        string pathCustomer = "./Data_customer.json";
        string pathRecord = "./Data_record.json";

        // 优化信息文件存储格式
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,// JSON序列化时候美化
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // Json序列化时中文不变
            AllowTrailingCommas = true, // JSON反序列化时候允许 最后出现逗号
        };

        public Manager()
        /*根据路径打开信息文件，并初始化信息列表*/
        {
            string dataJson = "";
            if (!File.Exists(pathCar)) DataCars = new List<Car>();
            else
            {
                dataJson = File.ReadAllText(pathCar);
                DataCars = JsonSerializer.Deserialize<List<Car>>(dataJson);
            }
            if (!File.Exists(pathCustomer)) DataCustomers = new List<Customer>();
            else
            {
                dataJson = File.ReadAllText(pathCustomer);
                DataCustomers = JsonSerializer.Deserialize<List<Customer>>(dataJson);
            }
            if (!File.Exists(pathRecord)) DataRecords = new List<Record>();
            else
            {
                dataJson = File.ReadAllText(pathRecord);
                DataRecords = JsonSerializer.Deserialize<List<Record>>(dataJson);
            }
        }

        void Updata(params (string, string)[] pathsAndfliles)
        // 将文件信息保存
        {
            foreach (var item in pathsAndfliles) File.WriteAllText(item.Item1, item.Item2);
        }

        public void AddCar()
        /*添加一个车辆信息*/
        {
            /*接收用户输入的信息*/
            // 接收车牌号并以车牌号作为主键，判断唯一性
            Console.Write("请输入车辆车牌号：");
            string cardCar = Console.ReadLine();
            if (DataCars.Exists(item => item.Card == cardCar)) Console.WriteLine($"车牌号：{cardCar}已存在！");
            else
            {
                Console.Write("请输入车辆的种类：");
                string typeCar = Console.ReadLine();
                Console.Write("请输入车辆的租借费（小时）：");
                if (!decimal.TryParse(Console.ReadLine(), out decimal priceCar)) Console.WriteLine("请输入正确的价格格式！");
                else
                {
                    // 新建车辆信息，并添加到车辆信息列表
                    DataCars.Add(new Car(DataCars.Count + 1, cardCar, typeCar, true, priceCar));

                    // 将信息更新到文件中
                    Updata((pathCar, JsonSerializer.Serialize(DataCars, options)));
                    Console.WriteLine("====添加成功====");
                }
            }
        }

        public void ShowCar()
        /*展示所有车辆信息*/
        {
            if (DataCars.Count == 0) Console.WriteLine("系统内没有车辆信息，请先添加！");
            else foreach (var item in DataCars) item.ShowData();
        }

        public void ShowCar(int idCar)
        /*方法重载，展示单个指定车辆信息*/
        {
            if (DataCars.Count == 0) Console.WriteLine("系统内没有车辆信息，请先添加！");
            else
            {
                Car? objCar = DataCars.Find(item => item.Id == idCar);
                if (objCar == null) Console.WriteLine($"没有ID为{idCar}的车辆信息！");
                else objCar.ShowData();
            }
        }

        public void ShowIdleCar()
        /*展示闲置的车辆信息*/
        {
            List<Car> carsIdle = DataCars.FindAll(item => item.Status);
            if (carsIdle.Count == 0) Console.WriteLine("当前没有闲置的车辆！");
            else foreach (Car item in carsIdle) item.ShowData();
        }

        public void AddCustomer()
        /*添加一个用户信息*/
        {
            /*接受用户输入的信息*/
            // 接收身份证号并以身份证号作为主键，判断唯一性
            Console.Write("请输入客户身份证号：");
            string cardCustomer = Console.ReadLine();
            if (DataCustomers.Exists(item => item.IdCard == cardCustomer)) Console.WriteLine($"身份证号：{cardCustomer}已存在！");
            else
            {
                Console.Write("请输入客户姓名：");
                string name = Console.ReadLine();
                Console.Write("请输入客户性别（男/女）：");
                string gender = Console.ReadLine();
                if (!(gender == "男" || gender == "女")) Console.WriteLine("请输入正确的性别！");
                else
                {
                    Console.Write("请输入客户手机号：");
                    string phoneNo = Console.ReadLine();
                    if (!Regex.IsMatch(phoneNo, @"^1\d{10}$")) Console.WriteLine("输入的手机号格式错误！");
                    else
                    {
                        Console.Write("请输入客户座右铭：");
                        string? motto = Console.ReadLine();

                        // 新建用户信息，并添加到信息列表
                        DataCustomers.Add(new Customer(DataCustomers.Count + 1, name, cardCustomer, DateTime.Now.ToString(), gender, phoneNo, motto));

                        // 更新到信息文件
                        Updata((pathCustomer, JsonSerializer.Serialize(DataCustomers, options)));
                        Console.WriteLine("====添加成功====");
                    }
                }
            }
        }

        public void ShowCustomer()
        /*展示所有用户信息*/
        {
            if (DataCustomers.Count == 0) Console.WriteLine("系统内没有客户信息，请先添加！");
            else foreach (var item in DataCustomers) item.ShowData();
        }

        public void ShowCustomer(int idCustomer)
        /*方法重载，展示单个指定用户信息*/
        {
            if (DataCustomers.Count == 0) Console.WriteLine("系统内没有用户信息，请先添加！");
            else
            {
                Customer? objCustomer = DataCustomers.Find(item => item.Id == idCustomer);
                if (objCustomer == null) Console.WriteLine($"没有ID为{idCustomer}的用户信息！");
                else objCustomer.ShowData();
            }
        }

        public void AddRecord(int idCar, int idCustomer)
        /*添加租用记录*/
        {
            // 校验客户id和车辆id
            Car? car = DataCars.Find(item => item.Id == idCar);
            if (car == null) Console.WriteLine($"没有ID为{idCar}的车辆信息");
            else
            {
                int indexCustomer = DataCustomers.FindIndex(item => item.Id == idCustomer);
                if (indexCustomer == -1) Console.WriteLine($"没有ID为{idCustomer}的客户信息");
                else
                {
                    // 新建租用订单信息，并添加到订单信息列表
                    DataRecords.Add(new Record(DataRecords.Count + 1, idCar, indexCustomer));

                    // 更新车辆信息状态
                    car.Status = false;

                    // 更新到信息文件
                    Updata((pathCar, JsonSerializer.Serialize(DataRecords, options)), (pathRecord, JsonSerializer.Serialize(DataRecords, options)));
                    Console.WriteLine($"====租用成功，你的租用订单编号为：{DataRecords.Count}====");
                }
            }

        }

        public void ReturnCar(int idRecord)
        {
            // 校验订单id
            Record? record = DataRecords.Find(item => item.IdRecord == idRecord);
            if (record == null) Console.WriteLine($"没有订单ID为{idRecord}的订单信息");
            else
            {
                // 获取订单状态
                Car car = DataCars.Find(item => item.Id == record.IdCar);
                if (car.Status) Console.WriteLine("车辆已还！");
                else
                {
                    // 获取租借金额
                    decimal pricePay = record.GetPrice(car.Price);

                    // 提示用户支付
                    Console.WriteLine($"你的租用金额为：{pricePay}，是否支付（Y/y支付，任意键取消）：");
                    string ch = Console.ReadLine();
                    if (ch == "Y" || ch == "y")
                    {
                        Console.WriteLine("====支付成功====");
                        // 更新车辆信息状态
                        car.Status = true;

                        // 更新到信息文件
                        Updata((pathCar, JsonSerializer.Serialize(DataRecords, options)), (pathRecord, JsonSerializer.Serialize(DataRecords, options)));
                        Console.WriteLine("====还车成功====");
                    }
                    Console.WriteLine("====取消支付====");
                }
            }
        }
    }
}
