using ImpulseLive.WPF.Models;

namespace ImpulseLive.WPF.Services
{
    public class ResultAnalyzer
    {
        public List<string> Analyze(Player player, BehaviorStats stats)
        {
            var results = new List<string>();
            // 计算总决策次数
            int totalDecisions = player.BuyCount + player.RefuseCount + player.HesitateCount;

            // 稀缺效应分析：时间压力对决策的影响
            if (stats.BuyUnderTimePressure > 2)
                results.Add("【稀缺效应】你多次在倒计时压力下购买，时间紧迫感激发了你的非理性消费欲望");

            // 从众心理分析：他人购买行为的影响
            if (stats.BuyHighSold > 2)
                results.Add("【从众心理】你明显受到他人购买行为影响，高销量信息增强了你的购买意愿");

            // 支付痛感弱化分析：分期支付的影响
            if (stats.InstallmentUsed > 0)
                results.Add("【支付痛感弱化】分期支付降低了你的支付痛感，弱化了消费决策的理性思考");

            // 购买频率分析：消费倾向评估
            if (player.BuyCount > 7)
                results.Add("【消费倾向】你在游戏中购买频率较高，表现出较强的冲动消费倾向");
            else if (player.BuyCount < 3)
                results.Add("【理性控制】你在游戏中购买频率较低，表现出较强的理性控制能力");

            // 犹豫行为分析：内心冲突程度
            if (player.HesitateCount > 3)
                results.Add("【内心冲突】你多次犹豫不决，反映出内心理性与欲望的激烈冲突");

            // 理性值变化分析：长期决策趋势
            if (player.Rationality < 50)
                results.Add("【理性衰退】游戏结束时理性值较低，表明你在持续消费中逐渐失去理性判断能力");
            else if (player.Rationality > 80)
                results.Add("【理性保持】游戏结束时理性值较高，表明你在消费决策中始终保持了良好的理性判断");

            // 欲望值变化分析：营销话术效果
            if (player.Desire > 10)
                results.Add("【欲望激发】游戏过程中你的欲望值持续高涨，说明主播话术有效激发了你的消费欲望");
            else if (player.Desire < 0)
                results.Add("【欲望控制】游戏过程中你的欲望值较低，对主播的营销话术保持了较强的抵抗力");

            // 决策模式分析：整体决策倾向
            if (player.BuyCount > player.RefuseCount + player.HesitateCount)
                results.Add("【购买偏向】你的决策模式偏向于购买，容易被商品信息和营销手段吸引");
            else if (player.RefuseCount > player.BuyCount + player.HesitateCount)
                results.Add("【拒绝偏向】你的决策模式偏向于拒绝，对商品保持了较高的警惕性和理性判断");

            // 主要影响因素分析：识别关键影响因素
            if (stats.BuyUnderTimePressure > stats.BuyHighSold + stats.InstallmentUsed)
                results.Add("【时间主导】倒计时压力是影响你决策的主要因素，稀缺效应对你作用明显");

            // 消费克制能力分析：自我控制水平
            if (player.RefuseCount > player.BuyCount)
                results.Add("【克制能力强】你表现出较强的消费克制能力，能够有效抵制大部分购买诱惑");
            else if (player.BuyCount > player.RefuseCount * 2)
                results.Add("【克制能力弱】你在面对商品诱惑时克制能力较弱，容易产生冲动消费行为");

            // 理性与欲望平衡分析：决策主导因素
            if (player.Rationality > player.Desire + 50)
                results.Add("【理性主导】你在消费决策中理性占据绝对主导，能够有效控制欲望冲动");
            else if (player.Desire > player.Rationality)
                results.Add("【欲望主导】你在消费决策中欲望占据主导，理性控制相对薄弱");

            // 消费习惯稳定性分析：决策一致性
            if (totalDecisions > 0 && player.HesitateCount < totalDecisions * 0.2)
                results.Add("【决策稳定】你有相对稳定的消费习惯，决策过程较为果断，不易受外界干扰");
            else if (totalDecisions > 0 && player.HesitateCount > totalDecisions * 0.5)
                results.Add("【决策摇摆】你的消费习惯不够稳定，决策过程较为摇摆，容易受环境影响");

            // 影响权重分析：不同因素的相对影响力
            if (stats.BuyHighSold > stats.BuyUnderTimePressure && stats.BuyHighSold > stats.InstallmentUsed)
                results.Add("【从众主导】他人的购买行为对你的消费决策影响最大，体现了典型的社会认同心理");
            else if (stats.InstallmentUsed > stats.BuyUnderTimePressure && stats.InstallmentUsed > stats.BuyHighSold)
                results.Add("【支付主导】支付方式对你的消费决策影响最大，支付痛感弱化显著影响了你的判断");

            // 消费压力感知分析：经济条件的影响
            if (player.Money < 3000)
                results.Add("【经济压力】剩余资金较少，你可能感受到了一定的消费压力，影响了决策过程");
            else if (player.Money > 8000)
                results.Add("【经济宽松】剩余资金充足，你在消费时感受到的压力较小，决策更加自由");

            // 行为经济学总结：提供理论反思
            if (player.BuyCount > player.RefuseCount && player.Rationality < 70)
                results.Add("【理论反思】你的消费行为体现了行为经济学中的非理性决策特征，建议在现实消费中更加注重理性思考");
            else if (player.RefuseCount > player.BuyCount && player.Rationality > 70)
                results.Add("【理论反思】你的消费行为相对理性，成功抵制了多种营销手段的诱惑，符合传统经济学的理性人假设");

            // 限制分析结果数量为3条左右，确保用户能看到返回按钮
            return results.Take(3).ToList();
        }
    }
}