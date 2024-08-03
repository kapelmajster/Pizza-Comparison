namespace PizzaComparison.Models
{
    public class PizzaComparisonViewModel
    {
        public PizzaModel Pizza1 { get; set; }
        public PizzaModel Pizza2 { get; set; }
        public string BetterDeal { get; set; }
        public bool AreSame { get; set; }
    }

}