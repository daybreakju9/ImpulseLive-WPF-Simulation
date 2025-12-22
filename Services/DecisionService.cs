using ImpulseLive.WPF.Models;

namespace ImpulseLive.WPF.Services
{
    /// <summary>
    /// 消费决策处理服务，基于行为经济学理论模拟消费决策对玩家状态的影响
    /// </summary>
    public class DecisionService
    {
        /// <summary>
        /// 处理购买决策，体现行为经济学中的非理性消费机制
        /// </summary>
        /// <param name="player">玩家对象</param>
        /// <param name="product">当前商品</param>
        /// <param name="stats">行为统计对象</param>
        /// <param name="timeLeft">剩余时间</param>
        public void Buy(Player player, Product product, BehaviorStats stats, int timeLeft)
        {
            // 扣除资金
            player.Money -= product.Price;
            
            // 理性值降低：体现非理性决策，话术等级越高影响越大
            player.Rationality -= 10 + product.RhetoricLevel * 2;
            
            // 欲望值增加：购买行为强化消费欲望
            player.Desire += 5;
            player.BuyCount++;

            // 稀缺效应：时间压力下的购买行为
            if (timeLeft <= 5) 
                stats.BuyUnderTimePressure++; // 记录限时购买次数
            
            // 从众心理：高销量影响购买决策
            if (product.SoldCount > 5000) 
                stats.BuyHighSold++; // 记录从众购买次数
            
            // 支付痛感弱化：分期支付降低支付阻力
            if (product.HasInstallment) 
                stats.InstallmentUsed++; // 记录分期使用次数
        }

        /// <summary>
        /// 处理犹豫决策，体现内心消费冲突
        /// </summary>
        /// <param name="player">玩家对象</param>
        public void Hesitate(Player player)
        {
            // 犹豫导致理性值小幅下降
            player.Rationality -= 5;
            
            // 犹豫强化消费欲望，体现即时满足的心理需求
            player.Desire += 10;
            player.HesitateCount++;
        }

        /// <summary>
        /// 处理拒绝决策，体现理性控制能力
        /// </summary>
        /// <param name="player">玩家对象</param>
        /// <param name="product">当前商品</param>
        public void Refuse(Player player, Product product)
        {
            // 拒绝购买提升理性值，体现自我控制能力
            player.Rationality += 5;
            
            // 拒绝购买降低消费欲望
            player.Desire -= 10;
            player.RefuseCount++;

            // 心理反弹：面对高强度营销话术的拒绝会产生心理压力
            if (product.RhetoricLevel >= 4) 
                player.Rationality -= 3; // 心理反弹效果
        }
    }
}