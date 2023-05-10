using System;

public class Program
{
    public static void Main()
    {
        int player1 = int.Parse(Console.ReadLine());
        int player2 = int.Parse(Console.ReadLine());

        bool endBattle = true;

        string input = Console.ReadLine();
        while (input != "End of battle")
        {
            if (input == "one")
            {
                player2--;
            }
            else if (input == "two")
            {
                player1--;
            }
            if (player1 == 0)
            {
                Console.WriteLine("Player one is out of eggs. Player two has {0} eggs left.", player2);
                endBattle = false;
                break;
            }
            if (player2 == 0)
            {
                Console.WriteLine("Player two is out of eggs. Player one has {0} eggs left.", player1);
                endBattle = false;
                break;
            }
            input = Console.ReadLine();
        }

        if (endBattle)
        {
            Console.WriteLine("Player one has {0} eggs left.", player1);
            Console.WriteLine("Player two has {0} eggs left.", player2);
        }
    }
}