using System;
using System.Linq;
using System.Collections.Generic;

namespace DeckOfCards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            int commandsNum = int.Parse(Console.ReadLine());

            for (int i = 1; i <= commandsNum; i++)
            {
                string input = Console.ReadLine();
                string[] command = input.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (command[0] == "Add")
                {
                    string cardNaame = command[1];

                    if (CheckCards(cards, cardNaame))
                    {
                        Console.WriteLine("Card is already in the deck");
                    }
                    else
                    {
                        cards.Add(cardNaame);
                        Console.WriteLine("Card successfully added");
                    }
                }
                else if (command[0] == "Remove")
                {
                    string cardName = command[1];
                    
                    if (CheckCards(cards, cardName))
                    {
                        cards.Remove(cardName);
                        Console.WriteLine("Card successfully removed");
                    }
                    else
                    {
                        Console.WriteLine("Card not found");
                    }
                }
                else if (command[0] == "Remove At")
                {
                    int index = int.Parse(command[1]);

                    if (index >= 0 && index < cards.Count)
                    {
                        cards.RemoveAt(index);
                        Console.WriteLine("Card successfully removed");
                    }
                    else
                    {
                        Console.WriteLine("Index out of range");
                    }
                }
                else if (command[0] == "Insert")
                {
                    int index = int.Parse(command[1]);
                    string cardName = command[2];

                    if (index >= 0 && index < cards.Count)
                    {
                        if (CheckCards(cards, cardName))
                        {
                            Console.WriteLine("Card is already added");
                        }
                        else
                        {
                            cards.Insert(index, cardName);
                            Console.WriteLine("Card successfully added");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Index out of range");
                    }
                }
            }

            Console.WriteLine(String.Join(", ", cards));
        }

        static bool CheckCards(List<string> cards, string cardName)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i] == cardName)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
