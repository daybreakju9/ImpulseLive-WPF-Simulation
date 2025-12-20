using ImpulseLive.WPF.Models;

namespace ImpulseLive.WPF.Services
{
    public class ResultAnalyzer
    {
        public List<string> Analyze(Player player, BehaviorStats stats)
        {
            var results = new List<string>();

            // 基础分析
            if (stats.BuyUnderTimePressure > 2)
                results.Add("你多次在倒计时压力下购买（稀缺效应）");

            if (stats.BuyHighSold > 2)
                results.Add("你明显受到他人购买行为影响（从众心理）");

            if (stats.InstallmentUsed > 0)
                results.Add("分期/免密支付降低了你的支付痛感");

            // 新增分析：购买频率
            if (player.BuyCount > 7)
                results.Add("你在游戏中购买频率较高，表现出较强的消费倾向");
            else if (player.BuyCount < 3)
                results.Add("你在游戏中购买频率较低，表现出较强的理性控制能力");

            // 新增分析：犹豫行为
            if (player.HesitateCount > 3)
                results.Add("你多次犹豫不决，反映出内心的消费冲突");

            // 新增分析：理性值变化
            if (player.Rationality < 50)
                results.Add("游戏结束时理性值较低，表明你在消费中逐渐失去理性判断");
            else if (player.Rationality > 80)
                results.Add("游戏结束时理性值较高，表明你保持了良好的理性决策能力");

            // 新增分析：欲望值变化
            if (player.Desire > 10)
                results.Add("游戏过程中你的欲望值持续高涨，容易被营销话术打动");
            else if (player.Desire < 0)
                results.Add("游戏过程中你的欲望值较低，对商品保持了较强的抵抗力");

            // 新增分析：决策模式
            if (player.BuyCount > player.RefuseCount + player.HesitateCount)
                results.Add("你的决策模式偏向于购买，容易被商品吸引");
            else if (player.RefuseCount > player.BuyCount + player.HesitateCount)
                results.Add("你的决策模式偏向于拒绝，对商品保持了较高的警惕性");

            // 新增分析：限时决策
            if (stats.BuyUnderTimePressure > stats.BuyHighSold + stats.InstallmentUsed)
                results.Add("倒计时压力是影响你决策的主要因素");

            // 新增分析：消费克制能力
            if (player.RefuseCount > player.BuyCount)
                results.Add("你表现出较强的消费克制能力，能够抵制大部分购买诱惑");
            else if (player.BuyCount > player.RefuseCount * 2)
                results.Add("你在面对商品诱惑时克制能力较弱，容易产生冲动消费");

            // 新增分析：理性与欲望平衡
            if (player.Rationality > player.Desire + 50)
                results.Add("你在消费决策中理性占据主导，能够有效控制欲望");
            else if (player.Desire > player.Rationality)
                results.Add("你在消费决策中欲望占据主导，理性控制相对薄弱");

            // 新增分析：消费习惯稳定性
            int totalDecisions = player.BuyCount + player.RefuseCount + player.HesitateCount;
            if (totalDecisions > 0 && player.HesitateCount < totalDecisions * 0.2)
                results.Add("你有相对稳定的消费习惯，决策过程较为果断");
            else if (totalDecisions > 0 && player.HesitateCount > totalDecisions * 0.5)
                results.Add("你的消费习惯不够稳定，决策过程较为摇摆");

            // 新增分析：不同因素影响权重
            if (stats.BuyHighSold > stats.BuyUnderTimePressure && stats.BuyHighSold > stats.InstallmentUsed)
                results.Add("他人的购买行为对你的消费决策影响最大");
            else if (stats.InstallmentUsed > stats.BuyUnderTimePressure && stats.InstallmentUsed > stats.BuyHighSold)
                results.Add("支付方式对你的消费决策影响最大");

            // 新增分析：消费压力感知
            if (player.Money < 3000)
                results.Add("剩余资金较少，你可能感受到了一定的消费压力");
            else if (player.Money > 8000)
                results.Add("剩余资金充足，你在消费时感受到的压力较小");

            return results;
        }
    }
}