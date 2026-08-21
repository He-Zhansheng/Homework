namespace day15
{

    internal class Car
    {
        public int Id { get; }                         // 车辆Id
        public string Card { get; }                    // 车牌号
        public string Type { get; }                          // 车辆类型
        public bool Status { get; set; }             // 车辆租借状态，空闲为真
        public decimal Price { get; }                  // 车辆租借小时费

        public Car(int id, string card, string Type, bool Status, decimal Price)
        {
            this.Id = id;
            this.Card = card;
            this.Type = Type;
            this.Status = Status;
            this.Price = Price;
        }
        public void ShowData()
        {
            Console.WriteLine(
                $"车牌号为{Card}的{Type}当前处于{(Status ? "空闲" : "已租借")}，车辆ID为：{Id}，车辆租借小时费为：{Price}"
                );
        }
    }
}
