using System;

namespace LengthConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Unit of Lengths converter
            String[] options = { "Meter", "Centimeter", "Kilometer", "Inch", "Millimetre", "Decimetre", "Yard", "Foot" };

            String givenUnit = "";
            double givenValue = 0;
            String targetUnit = "";
            int index = -1;

            while (index < 0 || index >= 8)
            {
                Console.WriteLine("What is the unit of your current measurement? ");
                Console.WriteLine("Please select from the following...");
                PrintOptions();
                index = Convert.ToInt32(Console.ReadLine());
                try
                {
                    givenUnit = options[index].ToUpper();
                }
                catch (System.IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            index = -1;

            while (index < 0 || index >= 8)
            {
                Console.WriteLine("Which unit would you like to convert to? ");
                Console.WriteLine("Please select from the following...");
                PrintOptions();
                index = Convert.ToInt32(Console.ReadLine());
                try
                {
                    targetUnit = options[index].ToUpper();
                }
                catch (System.IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            while (givenValue < 1 || givenValue == 0)
            {
                try
                {
                    Console.WriteLine("What is the measurement in length?... ");
                    givenValue = Convert.ToInt32(Console.ReadLine());
                }
                catch(FormatException e)
                {
                    Console.WriteLine("Measurement must be a number...");
                }
            }
            double result = ConvertUnits(givenUnit, targetUnit, givenValue);
            Console.WriteLine(givenValue + " " + givenUnit + "S = " + result + " " + targetUnit + "S");

            Console.WriteLine("RESULT: " + result);
            Console.ReadKey();
        }
        static void PrintOptions()
        {
            Console.WriteLine("0. Meter");
            Console.WriteLine("1. Centimeter");
            Console.WriteLine("2. Kilometer");
            Console.WriteLine("3. Inch");
            Console.WriteLine("4. Millimetre");
            Console.WriteLine("5. Decimeter");
            Console.WriteLine("6. Yard");
            Console.WriteLine("7. Foot");
            Console.WriteLine(".....");
        }
        static double ConvertUnits(String givenUnit, String targetUnit, double givenValue)
        {
            double result = 0;
            switch(givenUnit)
            {
                case ("METER"):
                    switch (targetUnit)
                    {
                        case ("METER"):
                            return givenValue;
                        case ("CENTIMETER"):
                            return givenValue * 100;
                        case ("KILOMETER"):
                            return givenValue / 1000;
                        case ("INCH"):
                            return givenValue * 39.3701;
                        case ("MILLIMETER"):
                            return givenValue * 1000;
                        case ("DECIMETER"):
                            return givenValue * 10;
                        case ("YARD"):
                            return givenValue * 1.09361;
                        case ("FOOT"):
                            return givenValue * 3.28084;
                        default:
                            Console.WriteLine("Have a nice day!");
                            break;
                    }
                    break;
                case ("CENTIMETER"):
                    switch (targetUnit)
                    {
                        case ("METER"):
                            return givenValue * 0.01;
                        case ("CENTIMETER"):
                            return givenValue;
                        case ("KILOMETER"):
                            return givenValue * 0.00001;
                        case ("INCH"):
                            return givenValue * 0.393701;
                        case ("MILLIMETER"):
                            return givenValue * 10;
                        case ("DECIMETER"):
                            return givenValue * 0.1;
                        case ("YARD"):
                            return givenValue * 0.0109361;
                        case ("FOOT"):
                            return givenValue * 0.0328084;
                        default:
                            Console.WriteLine("Have a nice day!");
                            break;
                    }
                    break;
                case ("KILOMETER"):
                    switch (targetUnit)
                    {
                        case ("METER"):
                            return givenValue * 1000;
                        case ("CENTIMETER"):
                            return givenValue * 100000;
                        case ("KILOMETER"):
                            return givenValue;
                        case ("INCH"):
                            return givenValue * 39370.1;
                        case ("MILLIMETER"):
                            return givenValue * 1000000;
                        case ("DECIMETER"):
                            return givenValue * 10000;
                        case ("YARD"):
                            return givenValue * 1093.61;
                        case ("FOOT"):
                            return givenValue * 3280.84;
                        default:
                            Console.WriteLine("Have a nice day!");
                            break;
                    }
                    break;
                case ("INCH"):
                    switch (targetUnit)
                    {
                        case ("METER"):
                            return givenValue * 0.0254;
                        case ("CENTIMETER"):
                            return givenValue * 2.54;
                        case ("KILOMETER"):
                            return givenValue * 0.0000254;
                        case ("INCH"):
                            return givenValue;
                        case ("MILLIMETER"):
                            return givenValue * 25.4;
                        case ("DECIMETER"):
                            return givenValue * 0.254;
                        case ("YARD"):
                            return givenValue * 0.0277778;
                        case ("FOOT"):
                            return givenValue * 0.0833333;
                        default:
                            Console.WriteLine("Have a nice day!");
                            break;
                    }
                    break;
                case ("MILLIMETER"):
                    switch (targetUnit)
                    {
                        case ("METER"):
                            return givenValue * 1000;
                        case ("CENTIMETER"):
                            return givenValue * 10;
                        case ("KILOMETER"):
                            return givenValue * 1000000;
                        case ("INCH"):
                            return givenValue * 0.0393701;
                        case ("MILLIMETER"):
                            return givenValue;
                        case ("DECIMETER"):
                            return givenValue * 0.01;
                        case ("YARD"):
                            return givenValue * 0.00109361;
                        case ("FOOT"):
                            return givenValue * 0.00328084;
                        default:
                            Console.WriteLine("Have a nice day!");
                            break;
                    }
                    break;
                case ("DECIMETER"):
                    switch (targetUnit)
                    {
                        case ("METER"):
                            return givenValue * 0.1;
                        case ("CENTIMETER"):
                            return givenValue * 10;
                        case ("KILOMETER"):
                            return givenValue * 0.0001;
                        case ("INCH"):
                            return givenValue * 3.93701;
                        case ("MILLIMETER"):
                            return givenValue * 100;
                        case ("DECIMETER"):
                            return givenValue;
                        case ("YARD"):
                            return givenValue * 0.109361;
                        case ("FOOT"):
                            return givenValue * 0.328084;
                        default:
                            Console.WriteLine("Have a nice day!");
                            break;
                    }
                    break;
                case ("YARD"):
                    switch (targetUnit)
                    {
                        case ("METER"):
                            return givenValue * 0.9144;
                        case ("CENTIMETER"):
                            return givenValue * 91.44;
                        case ("KILOMETER"):
                            return givenValue * 0.0009144;
                        case ("INCH"):
                            return givenValue * 36;
                        case ("MILLIMETER"):
                            return givenValue * 914.4;
                        case ("DECIMETER"):
                            return givenValue * 9.144;
                        case ("YARD"):
                            return givenValue;
                        case ("FOOT"):
                            return givenValue * 3;
                        default:
                            Console.WriteLine("Have a nice day!");
                            break;
                    }
                    break;
                case ("FOOT"):
                    switch (targetUnit)
                    {
                        case ("METER"):
                            return givenValue * 0.3048;
                        case ("CENTIMETER"):
                            return givenValue * 30.48;
                        case ("KILOMETER"):
                            return givenValue * 0.0003048;
                        case ("INCH"):
                            return givenValue * 12;
                        case ("MILLIMETER"):
                            return givenValue * 304.8;
                        case ("DECIMETER"):
                            return givenValue * 3.048;
                        case ("YARD"):
                            return givenValue * 0.333333;
                        case ("FOOT"):
                            return givenValue;
                        default:
                            Console.WriteLine("Have a nice day!");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Have a nice day!");
                    break;
            }
            return result;
        }
    }
}