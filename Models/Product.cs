namespace ImpulseLive.WPF.Models
{
    public class Product
    {
        public string Name { get; set; } = string.Empty;

        public int Price { get; set; }
        public int SoldCount { get; set; }
        public int TimeLimit { get; set; }       // 秒
        public int RhetoricLevel { get; set; }   // 1–5

        public bool HasInstallment { get; set; }
        
        // 根据话术等级转换为具体文字描述
        public string RhetoricDescription
        {
            get
            {
                return RhetoricLevel switch
                {
                    1 => "主播简单介绍商品基本信息，语气平淡，无明显诱导",
                    2 => "主播强调商品性价比，开始使用基础推销话术",
                    3 => "主播结合自身使用体验，有效说服你这个商品值得购买",
                    4 => "主播使用紧急呼吁和稀缺性话术，强力诱导你立即下单",
                    5 => "主播使用专业心理学话术，精准击中你的消费痛点，让你难以拒绝",
                    _ => "未知的话术等级"
                };
            }
        }
    }
}