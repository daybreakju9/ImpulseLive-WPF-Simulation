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
                    1 => "这款产品适合日常使用，性能稳定。",
                    2 => "这个价位真的很少见，性价比很高。",
                    3 => "很多用户已经下单了，反馈都很好。",
                    4 => "错过今天真的要后悔，这个价格不会再有！",
                    5 => "最后几秒！卖完就下架，现在不抢就没了！",
                    _ => "未知的话术等级"
                };
            }
        }
    }
}