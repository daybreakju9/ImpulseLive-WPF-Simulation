using ImpulseLive.WPF.Models;

namespace ImpulseLive.WPF.Services
{
    public class ProductFactory
    {
        private List<Product> _productList = new List<Product>
{
    new Product { Name = "USB小风扇", Price = 49, SoldCount = 56000, TimeLimit = 5, RhetoricLevel = 1, HasInstallment = false },
    new Product { Name = "无线蓝牙耳机", Price = 399, SoldCount = 14500, TimeLimit = 8, RhetoricLevel = 3, HasInstallment = false },
    new Product { Name = "考研英语词汇书", Price = 59, SoldCount = 42000, TimeLimit = 6, RhetoricLevel = 2, HasInstallment = false },
    new Product { Name = "恋爱聊天课程", Price = 399, SoldCount = 6200, TimeLimit = 8, RhetoricLevel = 5, HasInstallment = false },
    new Product { Name = "宿舍护眼台灯", Price = 129, SoldCount = 38000, TimeLimit = 6, RhetoricLevel = 2, HasInstallment = false },

    new Product { Name = "学习用平板电脑", Price = 2499, SoldCount = 6800, TimeLimit = 9, RhetoricLevel = 4, HasInstallment = true },
    new Product { Name = "桌面收纳盒", Price = 39, SoldCount = 48000, TimeLimit = 5, RhetoricLevel = 1, HasInstallment = false },
    new Product { Name = "摄影入门课程", Price = 699, SoldCount = 7800, TimeLimit = 9, RhetoricLevel = 4, HasInstallment = true },
    new Product { Name = "无线鼠标", Price = 79, SoldCount = 52000, TimeLimit = 6, RhetoricLevel = 2, HasInstallment = false },
    new Product { Name = "智能手表", Price = 1299, SoldCount = 8100, TimeLimit = 10, RhetoricLevel = 5, HasInstallment = true },

    new Product { Name = "零食大礼包", Price = 129, SoldCount = 43000, TimeLimit = 6, RhetoricLevel = 3, HasInstallment = false },
    new Product { Name = "降噪头戴式耳机", Price = 1299, SoldCount = 6200, TimeLimit = 9, RhetoricLevel = 4, HasInstallment = true },
    new Product { Name = "四六级真题合集", Price = 89, SoldCount = 36000, TimeLimit = 7, RhetoricLevel = 2, HasInstallment = false },
    new Product { Name = "盲盒手办", Price = 79, SoldCount = 16500, TimeLimit = 7, RhetoricLevel = 5, HasInstallment = false },
    new Product { Name = "电热水壶", Price = 129, SoldCount = 41000, TimeLimit = 6, RhetoricLevel = 2, HasInstallment = false },

    new Product { Name = "考研全程班", Price = 4999, SoldCount = 3200, TimeLimit = 8, RhetoricLevel = 5, HasInstallment = true },
    new Product { Name = "Type-C拓展坞", Price = 49, SoldCount = 26000, TimeLimit = 7, RhetoricLevel = 3, HasInstallment = false },
    new Product { Name = "一箱网红速食拌面", Price = 59, SoldCount = 50000, TimeLimit = 6, RhetoricLevel = 3, HasInstallment = false },
    new Product { Name = "情感咨询体验", Price = 699, SoldCount = 4100, TimeLimit = 9, RhetoricLevel = 5, HasInstallment = true },
    new Product { Name = "宿舍折叠桌", Price = 199, SoldCount = 27000, TimeLimit = 7, RhetoricLevel = 2, HasInstallment = false },

    new Product { Name = "视频平台年会员", Price = 258, SoldCount = 33000, TimeLimit = 8, RhetoricLevel = 4, HasInstallment = false },
    new Product { Name = "人体工学椅", Price = 1899, SoldCount = 5400, TimeLimit = 10, RhetoricLevel = 4, HasInstallment = true },
    new Product { Name = "小说App年度会员", Price = 128, SoldCount = 37000, TimeLimit = 7, RhetoricLevel = 3, HasInstallment = false },
    new Product { Name = "宿舍小冰箱", Price = 899, SoldCount = 7600, TimeLimit = 10, RhetoricLevel = 4, HasInstallment = true },
    new Product { Name = "智能门禁卡套", Price = 29, SoldCount = 52000, TimeLimit = 5, RhetoricLevel = 1, HasInstallment = false },

    new Product { Name = "AI绘画会员", Price = 399, SoldCount = 13200, TimeLimit = 8, RhetoricLevel = 4, HasInstallment = false },
    new Product { Name = "联名T恤", Price = 259, SoldCount = 14800, TimeLimit = 8, RhetoricLevel = 4, HasInstallment = false },
    new Product { Name = "宿舍电煮锅", Price = 199, SoldCount = 29500, TimeLimit = 7, RhetoricLevel = 3, HasInstallment = false },
    new Product { Name = "音乐平台会员", Price = 168, SoldCount = 45000, TimeLimit = 7, RhetoricLevel = 3, HasInstallment = false },
    new Product { Name = "情绪疗愈音频课", Price = 299, SoldCount = 12800, TimeLimit = 8, RhetoricLevel = 4, HasInstallment = false },

    new Product { Name = "限定款潮玩盲盒", Price = 199, SoldCount = 8800, TimeLimit = 7, RhetoricLevel = 5, HasInstallment = false },
    new Product { Name = "剪辑软件会员年卡", Price = 299, SoldCount = 18500, TimeLimit = 8, RhetoricLevel = 4, HasInstallment = false },
    new Product { Name = "床上书桌", Price = 169, SoldCount = 25000, TimeLimit = 7, RhetoricLevel = 2, HasInstallment = false },
    new Product { Name = "游戏季票", Price = 299, SoldCount = 21000, TimeLimit = 8, RhetoricLevel = 5, HasInstallment = false },
    new Product { Name = "限定游戏皮肤礼包", Price = 199, SoldCount = 29000, TimeLimit = 6, RhetoricLevel = 5, HasInstallment = false }
};


        public Product Generate(int round)
        {
            // 根据回合数从列表中选择商品，循环使用
            int index = (round - 1) % _productList.Count;
            return _productList[index];
        }
    }
}