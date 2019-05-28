using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_dz
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza = new Pizza(new LazioIngredientsFactory());
            Console.Write(pizza.ToString());
            Console.WriteLine($"Цена:\t{pizza.CalculatePrice()}");
            Console.WriteLine("\n");
            pizza = new Pizza(new AbruzzoIngredientsFactory());
            Console.Write(pizza.ToString());
            Console.WriteLine($"Цена:\t{pizza.CalculatePrice()}");
            Console.WriteLine("\n");
            pizza = new Pizza(new LombardiaIngredientsFactory());
            Console.Write(pizza.ToString());
            Console.WriteLine($"Цена:\t{pizza.CalculatePrice()}");
            Console.WriteLine("\n");
        }
    }
    class Pizza
    {
        private Base _base;
        private Sauce sauce;
        private Cheese cheese;
        private List<Addon> addons;
        public Pizza(IngredientsFactory factory)
        {
            _base = factory.CreateBase();
            sauce = factory.CreateSauce();
            cheese = factory.CreateCheese();
            addons = factory.CreateAddons();
        }
        public double CalculatePrice()
        {
            double summ = _base.Price + sauce.Price + cheese.Price;
            foreach (Addon item in addons)
            {
                summ += item.Price;
            }
            return summ;
        }
        public override string ToString()
        {
            string tmp = $"Основа:\t{_base.Name}\nСоус:\t{sauce.Name}\nСыр:\t{cheese.Name}\nИнгредиенты:\n";
            foreach (Addon item in addons)
            {
                tmp += $"\t\t{item.Name}\n";
            }
            return tmp;
        }
    }
    abstract class IngredientsFactory
    {
        public abstract Base CreateBase();
        public abstract Sauce CreateSauce();
        public abstract Cheese CreateCheese();
        public abstract List<Addon> CreateAddons();
    }
    class LazioIngredientsFactory : IngredientsFactory
    {
        public override Base CreateBase()
        {
            return new Standart();
        }
        public override Sauce CreateSauce()
        {
            return new Tomato();
        }
        public override Cheese CreateCheese()
        {
            return new Mozarella();
        }
        public override List<Addon> CreateAddons()
        {
            return new List<Addon>() { new Mushroom(), new Seafood()};
        }
    }
    class AbruzzoIngredientsFactory : IngredientsFactory
    {
        public override Base CreateBase()
        {
            return new XXL();
        }
        public override Sauce CreateSauce()
        {
            return new Barbecue();
        }
        public override Cheese CreateCheese()
        {
            return new Parmesan();
        }
        public override List<Addon> CreateAddons()
        {
            return new List<Addon>() { new Salami(), new Pepperoni()};
        }
    }
    class LombardiaIngredientsFactory : IngredientsFactory
    {
        public override Base CreateBase()
        {
            return new XXL();
        }
        public override Sauce CreateSauce()
        {
            return new Tomato();
        }
        public override Cheese CreateCheese()
        {
            return new Ricotta();
        }
        public override List<Addon> CreateAddons()
        {
            return new List<Addon>() { new Salami(), new Mushroom()};
        }
    }
    abstract class Base
    {
        public string Name { set; get; }
        public double Price { set; get; }
    }
    class Standart : Base
    {
        public Standart()
        {
            Name = "Стандарт";
            Price = 100;
        }
    }
    class XXL : Base
    {
        public XXL()
        {
            Name = "XXL";
            Price = 200;
        }
    }
    abstract class Sauce
    {
        public string Name { set; get; }
        public double Price { set; get; }
    }
    class Tomato : Sauce
    {
        public Tomato()
        {
            Name = "Томатный";
            Price = 25;
        }
    }
    class Barbecue : Sauce
    {
        public Barbecue()
        {
            Name = "Барбекю";
            Price = 50;
        }
    }
    abstract class Cheese
    {
        public string Name { set; get; }
        public double Price { set; get; }
    }
    class Mozarella : Cheese
    {
        public Mozarella()
        {
            Name = "Моцарелла";
            Price = 50;
        }
    }
    class Parmesan : Cheese
    {
        public Parmesan()
        {
            Name = "Пармезан";
            Price = 100;
        }
    }
    class Ricotta : Cheese
    {
        public Ricotta()
        {
            Name = "Рикотта";
            Price = 75;
        }
    }
    abstract class Addon
    {
        public string Name { set; get; }
        public double Price { set; get; }
    }
    class Mushroom : Addon
    {
        public Mushroom()
        {
            Name = "Грибы";
            Price = 50;
        }
    }
    class Seafood : Addon
    {
        public Seafood()
        {
            Name = "Морепродукты";
            Price = 150;
        }
    }
    class Salami : Addon
    {
        public Salami()
        {
            Name = "Салями";
            Price = 75;
        }
    }
    class Pepperoni : Addon
    {
        public Pepperoni()
        {
            Name = "Пепперони";
            Price = 100;
        }
    }
}