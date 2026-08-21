namespace day15
{
    internal class Record
    {
        public int IdRecord { get; }            // 订单编号
        public int IdCar { get; }               // 租用车辆编号
        public int IdCustomer { get; }          // 客户编号
        public string TimeRental { get; }              // 租用起始时间
        public string TImeReturn { get; set; }              // 归还时间
        public decimal Price { get; set; }                   // 支付金额

        public Record(int idRecord, int idCar, int idCustomer)
        /*用于创建租用订单*/
        {
            IdRecord = idRecord;
            IdCar = idCar;
            IdCustomer = idCustomer;
            TimeRental = DateTime.Now.ToString();
        }

        public decimal GetPrice(decimal price)
        /*用于获取租借金额*/
        {
            // 归还时间
            DateTime timeNow = DateTime.Now;
            TImeReturn = timeNow.ToString();

            // 起始时间
            DateTime timeRental = DateTime.Parse(TimeRental);

            // 租用时间
            TimeSpan timeTotal = timeNow - timeRental;
            Price = (decimal)(timeTotal.TotalHours) * price;

            return Price;
        }
    }
}
