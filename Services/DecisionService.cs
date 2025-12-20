using ImpulseLive.WPF.Models;

namespace ImpulseLive.WPF.Services
{
    public class DecisionService
    {
        public void Buy(Player player, Product product, BehaviorStats stats, int timeLeft)
        {
            player.Money -= product.Price;
            player.Rationality -= 10 + product.RhetoricLevel * 2;
            player.Desire += 5;
            player.BuyCount++;

            if (timeLeft <= 5) stats.BuyUnderTimePressure++;
            if (product.SoldCount > 5000) stats.BuyHighSold++;
            if (product.HasInstallment) stats.InstallmentUsed++;
        }

        public void Hesitate(Player player)
        {
            player.Rationality -= 5;
            player.Desire += 10;
            player.HesitateCount++;
        }

        public void Refuse(Player player, Product product)
        {
            player.Rationality += 5;
            player.Desire -= 10;
            player.RefuseCount++;

            if (product.RhetoricLevel >= 4)
                player.Rationality -= 3; // 心理反弹
        }
    }
}