namespace day15
{
    internal class Customer
    {
        public int Id { get; }                  // 用户Id
        public string Name { get; }                    // 用户姓名
        public string IdCard { get; }                  // 用户身份证号
        public string TimeRegister { get; }            // 用户注册时间
        public string Gender { get; }              // 用户性别
        public string PhoneNo { get; }                 // 用户手机号
        public string? Motto { get; }                   // 用户座右铭

        public Customer(int Id, string Name, string IdCard, string TimeRegister, string Gender, string PhoneNo, string? Motto)
        {
            this.Id = Id;
            this.Name = Name;
            this.IdCard = IdCard;
            this.TimeRegister = TimeRegister;
            this.Gender = Gender;
            this.PhoneNo = PhoneNo;
            this.Motto = Motto;
        }

        public void ShowData()
        {
            Console.WriteLine(
                $"姓名：{Name}，ID：{Id}，身份证号：{IdCard}，注册时间：{TimeRegister}，性别：{Gender}，手机号：{PhoneNo}，座右铭：{(string.IsNullOrWhiteSpace(Motto) ? "无" : Motto)}"
                );
        }
    }
}
