namespace ImpulseLive.WPF.Models
{
    public class Player
    {
        public int Money { get; set; } = 3000;
        public int Rationality { get; set; } = 100;
        public int Desire { get; set; } = 0;

        public int BuyCount { get; set; }
        public int HesitateCount { get; set; }
        public int RefuseCount { get; set; }
    }
}