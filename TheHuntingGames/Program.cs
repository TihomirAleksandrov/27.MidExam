using System;

namespace TheHuntingGames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            decimal energy = decimal.Parse(Console.ReadLine());
            decimal waterPerPerson = decimal.Parse(Console.ReadLine());
            decimal foodPerPerson = decimal.Parse(Console.ReadLine());

            decimal waterNeeded = waterPerPerson * days * players;
            decimal foodNeeded = foodPerPerson * days * players;
            bool flag = true;

            for (int i = 1; i <= days; i++)
            {
                decimal energyLost = decimal.Parse(Console.ReadLine());

                energy -= energyLost;

                if (energy <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {foodNeeded:f2} food and {waterNeeded:f2} water.");
                    flag = false;
                    break;
                }

                if (i % 2 == 0)
                {
                    energy += (energy * (decimal)0.05);
                    waterNeeded -= (waterNeeded * (decimal)0.3);
                }

                if (i % 3 == 0)
                {
                    energy += (energy * (decimal)0.1);
                    foodNeeded -= (foodNeeded / players);
                }
            }

            if (flag)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {energy:f2} energy!");
            }
        }
    }
}
