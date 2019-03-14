using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusApp
{
    public class Order
    {
        private List<Product> _products = new List<Product>();

        public BonusProvider Bonus { get; set; }

        public void AddProduct(Product p)
        {
            _products.Add(p);
        }
        public double GetValueOfProducts()
        {
            double total = _products.Sum(s => s.Value);
            return total;
        //  double valueOfProducts = 0.0;   
        //  foreach (Product p in _products)
        //  {
        //      valueOfProducts += p.Value;
        //  }
        //  return valueOfProducts;
        }
        public double GetValueOfProducts(DateTime date)
        {
            return _products.Sum(s =>
            {
                double total = 0;
                if (date >= s.AvailableFrom && date <= s.AvailableTo)
                {
                    total = s.Value;
                }
                return total;
            });
            //return _products.Where(s => s.AvailableFrom <= date && s.AvailableTo >= date).Sum(s => s.Value); 
        }
        public double GetBonus()
        {
            return Bonus(GetValueOfProducts());
        }
        public double GetTotalPrice()
        {
            return GetValueOfProducts()-GetBonus();
        }
        public List<Product> SortProductOrderByAvailableTo()
        {
            return _products.OrderBy(s => s.AvailableTo).ToList();
        }
    }
}
