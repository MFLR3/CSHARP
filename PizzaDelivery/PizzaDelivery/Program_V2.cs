namespace PizzaDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            // COST
            // Sizes: Small: £4 - Medium: £5 - large: £6 - XL: £6.50 - XXL: £8
            // Cheese Stuffed Crust: Additional £2.50
            // Every topping is £1 extra

            String[] toppings = {"Anchovies", "Bacon", "Black Olives", "Cheddar", "Chorizo", "Dill Pickles", "Eggplant", 
                                "Fresh Basil", "Garlic", "Habaneros", "Italian Sausage", "Jellied Eels", "Kimchi",
                                "Lasagna", "Mozzarella", "Nachos", "Onions", "Peppers", "Quail Eggs", "Raisins", 
                                "Salami", "Tomato", "Umenoshi", "Venison", "Walnuts", "Xavier Steak", "Yorkshire Pudding",
                                "Zucchini"};

            String[] pizzaBases = {"Thin Crust", "Thick Crust", "Cheese Stuffed Crust" };
            String[] sauces = {"Tomato", "Alfredo", "Plain"};
            String[] sizes = {"Small", "Medium", "large", "XL", "XXL"};
            List<object> order = new List<object>();
            bool finishedOrdering = false;            

            while (finishedOrdering == false) {
                String yesOrNo = "";
                while (yesOrNo != "Y" && yesOrNo != "N")
                {
                    Console.WriteLine("Would you like to order a pizza? ");
                    Console.WriteLine("(Y/N)...");
                    yesOrNo = Console.ReadLine();
                    yesOrNo = yesOrNo.ToUpper();
                }

                if(yesOrNo == "N") 
                { 
                    finishedOrdering = true;
                }   
                
                if(yesOrNo == "Y") 
                {
                    // Pizza Size
                    String sizeChoice = "";
                    Console.WriteLine("Please select your size: ");
                    for (int i = 0; i < sizes.Length; i++)
                    {
                        Console.WriteLine(sizes[i] + " - " + (i + 1));
                     
                    }
                    sizeChoice = Console.ReadLine();

                    // Pizza Base
                    for (int i = 0; i < pizzaBases.Length; i++)
                    {
                        Console.WriteLine(pizzaBases[i] + " - " + (i + 1));
                    }

                    String baseChoice = Console.ReadLine();
                    Console.WriteLine("Base choice: " + baseChoice);

                    while( (pizzaBases[Convert.ToInt32(baseChoice) - 1] == "Cheese Stuffed Crust" && sizes[Convert.ToInt32(sizeChoice) - 1] == "Small") ||
                        (pizzaBases[Convert.ToInt32(baseChoice) - 1] == "Cheese Stuffed Crust" && sizes[Convert.ToInt32(sizeChoice) - 1] == "Medium"))
                    {
                        if (sizes[Convert.ToInt32(sizeChoice) - 1] == "Small" || sizes[Convert.ToInt32(sizeChoice) - 1] == "Medium")
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Stuffed Crust not available for Small or medium.");
                            Console.WriteLine("Please select your pizza base: ");

                            for (int i = 0; i < pizzaBases.Length; i++)
                            {
                                Console.WriteLine(pizzaBases[i] + " - " + (i + 1));
                            }

                            Console.WriteLine("...");
                            baseChoice = Console.ReadLine();
                        }
                    }

                    // Pizza Sauce
                    Console.WriteLine("Please select your pizza sauce: ");

                    for (int i = 0; i < sauces.Length; i++)
                    {
                        Console.WriteLine(sauces[i] + " - " + (i + 1));
                    }

                    String sauceChoice = Console.ReadLine();

                    // Pizza Toppings
                    List<String> toppingChoices = new List<String>();
                    String toppingChoice = "";

                    while(toppingChoice != "0")
                    {
                        Console.WriteLine("Please select your pizza toppings: ");

                        for (int i = 0; i < toppings.Length; i++)
                        {
                            Console.WriteLine(toppings[i] + " - " + (i + 1));
                        }
                        Console.WriteLine("Enter 0 when finished selecting toppings. ");

                        Console.Write("...");
                        toppingChoice = Console.ReadLine();
                        
                        if(toppingChoice == "0")
                        {
                            continue;
                        }

                        toppingChoices.Add(toppings[Convert.ToInt32(toppingChoice) - 1]);
                        Console.WriteLine("Topping: " + toppings[Convert.ToInt32(toppingChoice) - 1]);
                        Console.WriteLine("Amount of toppings" + toppingChoices.Count); 
                        Console.WriteLine(" ");
                    }

                    Pizza pizza = new Pizza(sizes[Convert.ToInt32(sizeChoice) - 1], pizzaBases[Convert.ToInt32(baseChoice) - 1], sauces[Convert.ToInt32(sauceChoice) - 1], toppingChoices);
                    order.Add(pizza);
                    Console.WriteLine(" ");
                    Console.WriteLine("Cost of this Pizza: £" + pizza.CalculateCostOfPizza());     
                    sizeChoice = "";
                    baseChoice = "";
                    sauceChoice = "";
                    
                    foreach(Pizza p in order)
                    {
                        p.PrintPizza();
                        p.CalculateCostOfPizza();
                        Console.WriteLine(" ");
                    }
                }
            }

            // Order Details
            Console.WriteLine(" ");
            Console.WriteLine("Here is your Order");
            double finalCost = 0;

            foreach (Pizza p in order)
            {
                p.PrintPizza();
                Console.WriteLine("Cost: £" + p.CalculateCostOfPizza());
                finalCost += p.CalculateCostOfPizza();
                Console.WriteLine(" ");
            }

            Console.WriteLine("Total cost: £" + finalCost);
            Console.WriteLine("Thank you");
            Console.ReadKey();
        }
    }
    class Pizza
    {
        String size;
        String pizzaBase;
        String sauce;
        List<String> toppings;
        public Pizza(String size, String pizzaBase, String sauce, List<String> toppings)
        {
            this.size = size;
            this.pizzaBase = pizzaBase;
            this.sauce = sauce;
            this.toppings = toppings;
        }         
        public void PrintPizza()
        {
            Console.WriteLine("Size: " + size);
            Console.WriteLine("Base: " + pizzaBase);
            Console.WriteLine("Sauce: " + sauce);
            Console.WriteLine("Toppings: ");

            foreach (String topping in  toppings) 
            {
                Console.WriteLine($"{topping}");
            }
        }
        public double CalculateCostOfPizza()
        {
            double cost = 0;

            if(pizzaBase == "Cheese Stuffed Crust")
            {
                cost += 2.5;
            }

            cost = cost + toppings.Count;

            switch (size)
            {
                case "Small":
                    cost += 4;
                    break;
                case "Medium":
                    cost += 5;
                    break;
                case "Large":
                    cost += 6;
                    break;
                case "XL":
                    cost += 6.5;
                    break;
                case "XXL":
                    cost += 8;
                    break;
                default:
                    cost += 0;
                    break;
            }
            return cost;
        }
    }
}
