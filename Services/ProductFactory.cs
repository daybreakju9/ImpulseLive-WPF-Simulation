using ImpulseLive.WPF.Models;

namespace ImpulseLive.WPF.Services
{
    public class ProductFactory
    {
        private List<Product> _productList = new List<Product>
{
    new Product { Name = "考研英语词汇书", Price = 59, SoldCount = 32000, TimeLimit = 8, RhetoricLevel = 2, HasInstallment = false },
    new Product { Name = "四六级真题合集", Price = 89, SoldCount = 28000, TimeLimit = 7, RhetoricLevel = 2, HasInstallment = false },
    new Product { Name = "学习用平板电脑", Price = 2499, SoldCount = 11000, TimeLimit = 12, RhetoricLevel = 4, HasInstallment = true },
    new Product { Name = "平板防蓝光类纸膜", Price = 99, SoldCount = 41000, TimeLimit = 6, RhetoricLevel = 3, HasInstallment = false },
    new Product { Name = "机械键盘（青轴）", Price = 499, SoldCount = 9800, TimeLimit = 9, RhetoricLevel = 3, HasInstallment = false },
    new Product { Name = "无线蓝牙耳机", Price = 399, SoldCount = 5600, TimeLimit = 8, RhetoricLevel = 3, HasInstallment = false },
    new Product { Name = "降噪头戴式耳机", Price = 1299, SoldCount = 7200, TimeLimit = 11, RhetoricLevel = 4, HasInstallment = true },
    new Product { Name = "宿舍护眼台灯", Price = 129, SoldCount = 35000, TimeLimit = 6, RhetoricLevel = 2, HasInstallment = false },
    new Product { Name = "颈椎按摩仪", Price = 299, SoldCount = 21000, TimeLimit = 8, RhetoricLevel = 4, HasInstallment = false },
    new Product { Name = "智能手表", Price = 1299, SoldCount = 8900, TimeLimit = 12, RhetoricLevel = 5, HasInstallment = true },

    new Product { Name = "运动跑鞋", Price = 799, SoldCount = 15000, TimeLimit = 10, RhetoricLevel = 3, HasInstallment = true },
    new Product { Name = "潮流卫衣", Price = 359, SoldCount = 13000, TimeLimit = 9, RhetoricLevel = 4, HasInstallment = false },
    new Product { Name = "宿舍折叠桌", Price = 199, SoldCount = 27000, TimeLimit = 7, RhetoricLevel = 2, HasInstallment = false },
    new Product { Name = "人体工学椅", Price = 1899, SoldCount = 6400, TimeLimit = 13, RhetoricLevel = 4, HasInstallment = true },
    new Product { Name = "USB小风扇", Price = 49, SoldCount = 58000, TimeLimit = 5, RhetoricLevel = 1, HasInstallment = false },
    new Product { Name = "桌面收纳盒", Price = 39, SoldCount = 62000, TimeLimit = 5, RhetoricLevel = 1, HasInstallment = false },
    new Product { Name = "零食大礼包", Price = 129, SoldCount = 47000, TimeLimit = 6, RhetoricLevel = 3, HasInstallment = false },
    new Product { Name = "网红速食拌面", Price = 59, SoldCount = 52000, TimeLimit = 6, RhetoricLevel = 3, HasInstallment = false },
    new Product { Name = "盲盒手办", Price = 79, SoldCount = 18000, TimeLimit = 7, RhetoricLevel = 5, HasInstallment = false },
    new Product { Name = "限定款潮玩盲盒", Price = 199, SoldCount = 9200, TimeLimit = 8, RhetoricLevel = 5, HasInstallment = false },

    new Product { Name = "摄影入门课程", Price = 699, SoldCount = 8600, TimeLimit = 10, RhetoricLevel = 4, HasInstallment = true },
    new Product { Name = "剪辑软件会员年卡", Price = 299, SoldCount = 14000, TimeLimit = 9, RhetoricLevel = 4, HasInstallment = false },
    new Product { Name = "AI绘画会员", Price = 399, SoldCount = 12000, TimeLimit = 8, RhetoricLevel = 4, HasInstallment = false },
    new Product { Name = "考研全程班", Price = 4999, SoldCount = 5300, TimeLimit = 15, RhetoricLevel = 5, HasInstallment = true },
    new Product { Name = "英语口语陪练课", Price = 1999, SoldCount = 6100, TimeLimit = 12, RhetoricLevel = 5, HasInstallment = true },

    new Product { Name = "智能门禁卡套", Price = 29, SoldCount = 69000, TimeLimit = 5, RhetoricLevel = 1, HasInstallment = false },
    new Product { Name = "校园定制保温杯", Price = 99, SoldCount = 33000, TimeLimit = 7, RhetoricLevel = 2, HasInstallment = false },
    new Product { Name = "情侣手链", Price = 159, SoldCount = 17000, TimeLimit = 8, RhetoricLevel = 5, HasInstallment = false },
    new Product { Name = "生日礼物定制相册", Price = 199, SoldCount = 12000, TimeLimit = 9, RhetoricLevel = 5, HasInstallment = false },
    new Product { Name = "宿舍香薰机", Price = 149, SoldCount = 24000, TimeLimit = 7, RhetoricLevel = 3, HasInstallment = false },
        new Product { Name = "宿舍小冰箱", Price = 899, SoldCount = 8600, TimeLimit = 11, RhetoricLevel = 4, HasInstallment = true },
    new Product { Name = "电热水壶", Price = 129, SoldCount = 42000, TimeLimit = 6, RhetoricLevel = 2, HasInstallment = false },
    new Product { Name = "宿舍电煮锅", Price = 199, SoldCount = 31000, TimeLimit = 7, RhetoricLevel = 3, HasInstallment = false },
    new Product { Name = "便携挂烫机", Price = 259, SoldCount = 18000, TimeLimit = 8, RhetoricLevel = 3, HasInstallment = false },
    new Product { Name = "床上书桌", Price = 169, SoldCount = 26000, TimeLimit = 7, RhetoricLevel = 2, HasInstallment = false },

    new Product { Name = "无线鼠标", Price = 79, SoldCount = 54000, TimeLimit = 6, RhetoricLevel = 2, HasInstallment = false },
    new Product { Name = "显示器支架", Price = 199, SoldCount = 21000, TimeLimit = 7, RhetoricLevel = 2, HasInstallment = false },
    new Product { Name = "电脑散热支架", Price = 99, SoldCount = 38000, TimeLimit = 6, RhetoricLevel = 2, HasInstallment = false },
    new Product { Name = "Type-C拓展坞", Price = 149, SoldCount = 26000, TimeLimit = 7, RhetoricLevel = 3, HasInstallment = false },
    new Product { Name = "外接移动硬盘", Price = 599, SoldCount = 14000, TimeLimit = 9, RhetoricLevel = 3, HasInstallment = true },

    new Product { Name = "运动手环", Price = 299, SoldCount = 19000, TimeLimit = 8, RhetoricLevel = 3, HasInstallment = false },
    new Product { Name = "智能体脂秤", Price = 179, SoldCount = 23000, TimeLimit = 7, RhetoricLevel = 3, HasInstallment = false },
    new Product { Name = "瑜伽垫", Price = 99, SoldCount = 36000, TimeLimit = 6, RhetoricLevel = 2, HasInstallment = false },
    new Product { Name = "可调节哑铃", Price = 299, SoldCount = 16000, TimeLimit = 8, RhetoricLevel = 3, HasInstallment = false },
    new Product { Name = "健身私教体验课", Price = 499, SoldCount = 7200, TimeLimit = 9, RhetoricLevel = 5, HasInstallment = false },

    new Product { Name = "联名T恤", Price = 259, SoldCount = 15000, TimeLimit = 8, RhetoricLevel = 4, HasInstallment = false },
    new Product { Name = "限量球鞋抽签资格", Price = 199, SoldCount = 9800, TimeLimit = 7, RhetoricLevel = 5, HasInstallment = false },
    new Product { Name = "明星同款背包", Price = 699, SoldCount = 8600, TimeLimit = 9, RhetoricLevel = 4, HasInstallment = true },
    new Product { Name = "潮牌帽子", Price = 199, SoldCount = 17000, TimeLimit = 7, RhetoricLevel = 3, HasInstallment = false },
    new Product { Name = "联名手机壳", Price = 129, SoldCount = 28000, TimeLimit = 6, RhetoricLevel = 3, HasInstallment = false },

    new Product { Name = "视频平台年会员", Price = 258, SoldCount = 34000, TimeLimit = 8, RhetoricLevel = 4, HasInstallment = false },
    new Product { Name = "音乐平台会员", Price = 168, SoldCount = 46000, TimeLimit = 7, RhetoricLevel = 3, HasInstallment = false },
    new Product { Name = "小说App年度会员", Price = 128, SoldCount = 39000, TimeLimit = 7, RhetoricLevel = 3, HasInstallment = false },
    new Product { Name = "游戏季票", Price = 299, SoldCount = 22000, TimeLimit = 8, RhetoricLevel = 5, HasInstallment = false },
    new Product { Name = "限定游戏皮肤礼包", Price = 199, SoldCount = 31000, TimeLimit = 6, RhetoricLevel = 5, HasInstallment = false },

    new Product { Name = "恋爱聊天课程", Price = 399, SoldCount = 8800, TimeLimit = 9, RhetoricLevel = 5, HasInstallment = false },
    new Product { Name = "情感咨询体验", Price = 699, SoldCount = 5200, TimeLimit = 10, RhetoricLevel = 5, HasInstallment = true },
    new Product { Name = "心理测试合集", Price = 99, SoldCount = 27000, TimeLimit = 6, RhetoricLevel = 4, HasInstallment = false },
    new Product { Name = "性格分析报告", Price = 199, SoldCount = 15000, TimeLimit = 7, RhetoricLevel = 4, HasInstallment = false },
    new Product { Name = "情绪疗愈音频课", Price = 299, SoldCount = 13000, TimeLimit = 8, RhetoricLevel = 4, HasInstallment = false },

    new Product { Name = "旅行双肩包", Price = 499, SoldCount = 12000, TimeLimit = 9, RhetoricLevel = 3, HasInstallment = false },
    new Product { Name = "周末短途旅行团", Price = 1299, SoldCount = 6400, TimeLimit = 11, RhetoricLevel = 5, HasInstallment = true },
    new Product { Name = "一次性胶片相机", Price = 159, SoldCount = 18000, TimeLimit = 7, RhetoricLevel = 4, HasInstallment = false },
    new Product { Name = "拍立得相纸", Price = 199, SoldCount = 22000, TimeLimit = 7, RhetoricLevel = 4, HasInstallment = false },
    new Product { Name = "拍立得相机", Price = 699, SoldCount = 9000, TimeLimit = 10, RhetoricLevel = 4, HasInstallment = true },


    
};


        public Product Generate(int round)
        {
            // 根据回合数从列表中选择商品，循环使用
            int index = (round - 1) % _productList.Count;
            return _productList[index];
        }
    }
}