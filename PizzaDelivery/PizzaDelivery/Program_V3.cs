using System;
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
                                "Fresh Basil", "Garlic", "Habaneros", "Italian Sausage", "Kimchi", "Mozzarella", "Nachos", 
                                "Onions", "Peppers", "Salami", "Tomato", "Umenoshi", "Venison", "Walnuts", "Xavier Steak", 
                                "Yorkshire Pudding", "Zucchini"};
            String[] pizzaBases = { "Thin Crust", "Thick Crust", "Cheese Stuffed Crust" };
            String[] sauces = { "Tomato", "Alfredo", "Plain" };
            String[] sizes = { "Small", "Medium", "large", "XL", "XXL" };
            List<object> order = new List<object>();
            bool finishedOrdering = false;

            while (finishedOrdering == false)
            {
                String yesOrNo = "";
                while (yesOrNo != "Y" && yesOrNo != "N")
                {
                    Console.WriteLine("Would you like to order a pizza? ");
                    Console.WriteLine("(Y/N)");
                    Console.Write("> ");
                    yesOrNo = Console.ReadLine();
                    yesOrNo = yesOrNo.ToUpper();
                    Console.WriteLine(" ");
                }

                if (yesOrNo == "N")
                {
                    finishedOrdering = true;
                }

                if (yesOrNo == "Y")
                {
                    // Pizza Size
                    String userInput = "";
                    int sizeChoice = 0;

                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Please select your size: ");
                            for (int i = 0; i < sizes.Length; i++)
                            {
                                Console.WriteLine(sizes[i] + " - " + (i + 1));
                            }
                            Console.Write("> ");
                            userInput = Console.ReadLine();
                            sizeChoice = Convert.ToInt32(userInput);
                            Console.WriteLine(" ");

                            if (sizeChoice < 1 || sizeChoice > 5)
                            {
                                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                                continue;
                            }
                            break; 
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                        }
                    }

                    // Pizza Base
                    int baseChoice = 0;

                    while (true)
                    {
                        try
                        {
                            while (baseChoice < 1 || baseChoice > 3)
                            {                              
                                Console.WriteLine("Please select your pizza base: ");
                                for (int i = 0; i < pizzaBases.Length; i++)
                                {
                                    Console.WriteLine(pizzaBases[i] + " - " + (i + 1));
                                }

                                Console.Write("> ");
                                userInput = Console.ReadLine();
                                baseChoice = Convert.ToInt32(userInput);
                                Console.WriteLine(" ");
                            }

                            while ((pizzaBases[Convert.ToInt32(baseChoice) - 1] == "Cheese Stuffed Crust" && sizes[Convert.ToInt32(sizeChoice) - 1] == "Small") ||
                                (pizzaBases[Convert.ToInt32(baseChoice) - 1] == "Cheese Stuffed Crust" && sizes[Convert.ToInt32(sizeChoice) - 1] == "Medium"))
                            {
                                if (sizes[Convert.ToInt32(sizeChoice) - 1] == "Small" || sizes[Convert.ToInt32(sizeChoice) - 1] == "Medium")
                                {                                 
                                    Console.WriteLine("Stuffed Crust not available for Small or medium.");
                                    Console.WriteLine("Please select your pizza base: ");
                                    for (int i = 0; i < pizzaBases.Length; i++)
                                    {
                                        Console.WriteLine(pizzaBases[i] + " - " + (i + 1));
                                    }

                                    Console.Write("> ");
                                    userInput = Console.ReadLine();
                                    baseChoice = Convert.ToInt32(userInput);

                                    while (baseChoice < 1 || baseChoice > 3)
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                                        Console.WriteLine("Please select your pizza base: ");
                                        for (int i = 0; i < pizzaBases.Length; i++)
                                        {
                                            Console.WriteLine(pizzaBases[i] + " - " + (i + 1));
                                        }

                                        Console.Write("> ");
                                        userInput = Console.ReadLine();
                                        baseChoice = Convert.ToInt32(userInput);
                                        Console.WriteLine("");
                                    }

                                    Console.WriteLine(" ");                                                                   
                                }
                            }                            
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                            Console.WriteLine("");
                        }
                    }

                    // Pizza Sauce
                    int sauceChoice = 0;

                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Please select your pizza sauce: ");

                            for (int i = 0; i < sauces.Length; i++)
                            {
                                Console.WriteLine(sauces[i] + " - " + (i + 1));
                            }

                            Console.Write("> ");
                            userInput = Console.ReadLine();
                            sauceChoice = Convert.ToInt32(userInput);

                            if (sauceChoice < 1 || sauceChoice > 3)
                            {
                                Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                                continue;
                            }
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                        }
                    }

                    // Pizza Toppings                    
                    List<String> toppingChoices = new List<String>();
                    int toppingChoice = 0;
                    bool exit = false;

                    while (exit == false)
                    {
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Please select your pizza toppings: ");

                                for (int i = 0; i < toppings.Length; i++)
                                {
                                    Console.WriteLine(toppings[i] + " - " + (i + 1));
                                }
                                Console.WriteLine("Enter 0 when finished selecting toppings. ");
                                Console.Write("> ");

                                userInput = Console.ReadLine();
                                toppingChoice = Convert.ToInt32(userInput);

                                if (toppingChoice == 0)
                                {
                                    exit = true;
                                    break;
                                }

                                if (toppingChoice < 0 || toppingChoice > 24)
                                {
                                    Console.WriteLine("Invalid input. Please enter a number between 1 and 24.");
                                    break;
                                }

                                toppingChoices.Add(toppings[Convert.ToInt32(toppingChoice) - 1]);
                                Console.WriteLine(" ");
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a number between 1 and 24.");
                            }
                        }                        
                    }

                    Pizza pizza = new Pizza(sizes[Convert.ToInt32(sizeChoice) - 1], pizzaBases[Convert.ToInt32(baseChoice) - 1], sauces[Convert.ToInt32(sauceChoice) - 1], toppingChoices);
                    order.Add(pizza);
                    Console.WriteLine(" ");
                    
                    sizeChoice = 0;
                    baseChoice = 0;
                    sauceChoice = 0;

                    foreach (Pizza p in order)
                    {
                        p.PrintPizza();
                        p.CalculateCostOfPizza();
                        Console.WriteLine("Cost of this Pizza: £" + p.CalculateCostOfPizza());
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

            foreach (String topping in toppings)
            {
                Console.WriteLine($"{topping}");
            }
        }
        public double CalculateCostOfPizza()
        {
            double cost = 0;

            if (pizzaBase == "Cheese Stuffed Crust")
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
