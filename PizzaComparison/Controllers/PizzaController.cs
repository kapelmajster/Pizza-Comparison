using Microsoft.AspNetCore.Mvc;
using PizzaComparison.Models;

namespace PizzaComparison.Controllers
{
    public class PizzaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new PizzaComparisonViewModel
            {
                Pizza1 = new PizzaModel(),
                Pizza2 = new PizzaModel()
            });
        }

        [HttpPost]
        public IActionResult Index(double size1, int quantity1, double? pricePerPizza1, double size2, int quantity2, double? pricePerPizza2)
        {
            var pizza1 = new PizzaModel
            {
                Size = size1,
                Quantity = quantity1,
                PricePerPizza = pricePerPizza1
            };

            var pizza2 = new PizzaModel
            {
                Size = size2,
                Quantity = quantity2,
                PricePerPizza = pricePerPizza2
            };

            string betterDeal;
            bool areSame = false;

            // Treat both as if they don't have a price if one is missing
            if ((pizza1.PricePerPizza.HasValue && !pizza2.PricePerPizza.HasValue) || (!pizza1.PricePerPizza.HasValue && pizza2.PricePerPizza.HasValue))
            {
                pizza1.PricePerPizza = null;
                pizza2.PricePerPizza = null;
            }

            if (pizza1.PricePerCm2.HasValue && pizza2.PricePerCm2.HasValue)
            {
                if (pizza1.PricePerCm2.Value == pizza2.PricePerCm2.Value)
                {
                    betterDeal = "Both pizzas have the same price per cm²";
                    areSame = true;
                }
                else
                {
                    betterDeal = pizza1.PricePerCm2.Value < pizza2.PricePerCm2.Value ? "Pizza 1" : "Pizza 2";
                }
            }
            else
            {
                if (pizza1.TotalArea == pizza2.TotalArea)
                {
                    betterDeal = "Both pizzas have the same total area";
                    areSame = true;
                }
                else
                {
                    betterDeal = pizza1.TotalArea > pizza2.TotalArea ? "Pizza 1" : "Pizza 2";
                }
            }

            var viewModel = new PizzaComparisonViewModel
            {
                Pizza1 = pizza1,
                Pizza2 = pizza2,
                BetterDeal = betterDeal,
                AreSame = areSame
            };

            ViewBag.ShowResults = true;
            return View(viewModel);
        }
    }
}
