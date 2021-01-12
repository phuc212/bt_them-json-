using System;
using System.Collections.Generic;
using System.Text;

namespace bt3
{
    class Menu
    {
        public string  DrinkName { get; set; }
        public string FoodName { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public double Total => Price * Count;
        public string DisplayDrinkAndFood()
        {
            return $"ten nuoc uong: {DrinkName}\t\t gia: {Price}\t\t soluong: {Count}" +
                $"ten do an:{FoodName}\t\t gia:{Price}\t\t so luong: {Count}";
                
        }
    }
}
