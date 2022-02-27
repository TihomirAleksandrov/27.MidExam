using System;
using System.Linq;

namespace FriendListMaintenance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            int blacklistCounter = 0;
            int lostCounter = 0;

            string input = Console.ReadLine();

            while (input!= "Report")
            {
                string[] command = input.Split().ToArray();

                if (command[0] == "Blacklist")
                {
                    string name = command[1];

                    if (CheckName(names, name))
                    {
                        blacklistCounter++;
                    }

                    BlacklistName(names, name);
                }
                else if (command[0] == "Error")
                {
                    int index = int.Parse(command[1]);
                    
                    if (index >= 0 && index < names.Length)
                    {
                        if (names[index] != "Blacklisted" && names[index] != "Lost")
                        {
                            lostCounter++;
                            Console.WriteLine($"{names[index]} was lost due to an error.");
                            names[index] = "Lost";
                        }
                    }
                }
                else if (command[0] == "Change")
                {
                    int index = int.Parse(command[1]);
                    string newName = command[2];
                    
                    if (index >= 0 && index < names.Length)
                    {
                        if (names[index] != "Blacklisted" && names[index] != "Lost")
                        {
                            Console.WriteLine($"{names[index]} changed his username to {newName}.");
                            names[index] = newName;
                        }
                    }
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine($"Blacklisted names: {blacklistCounter}");
            Console.WriteLine($"Lost names: {lostCounter}");
            Console.WriteLine(String.Join(" ", names));
        }

        static void BlacklistName(string[] names, string name)
        {
            bool flag = false;
            
            for (int i = 0; i < names.Length; i++)
            {
                if (name == names[i])
                {
                    flag = true;
                    Console.WriteLine($"{names[i]} was blacklisted.");
                    names[i] = "Blacklisted";
                    break;
                }
            }

            if (!flag)
            {
                Console.WriteLine($"{name} was not found.");
            }
        }

        static bool CheckName(string[] names, string name)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] == name)
                {
                    return true;
                }
            }

            return false;
        }

        
    }
}
