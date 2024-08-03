namespace PizzaComparison.Models
{
    public class PizzaModel
    {
        public double Size { get; set; }
        public int Quantity { get; set; }
        public double? PricePerPizza { get; set; }
        public double Area => Math.PI * Math.Pow(Size / 2, 2);
        public double TotalArea => Area * Quantity;
        public double? TotalPrice => PricePerPizza.HasValue ? PricePerPizza.Value * Quantity : (double?)null;
        public double? PricePerCm2 => TotalPrice.HasValue ? TotalPrice.Value / TotalArea : (double?)null;
    }
}
