using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRePG.Classes.GameStates
{
    public class Combat
    {
        //temporary Player values
        int health = 10;

        //temporary Enemy values
        int eHealth = 11;

        //temporary common values
        int damage = 7;

        //private readonly string[] combatOptions = { "Attack", "Defend", "Flee" };
        /*
        public Combat(Stacker stateStack, Context context) : base(stateStack, context)
        { }
        */
        public void CombatLoop()
        {
            PlayerTurn();
        }

        void PlayerTurn()
        {
            string attack = "Attack";

            Console.WriteLine("Please select an option:");
            Console.WriteLine("");
            Console.WriteLine("Attack");

            string input = Console.ReadLine();

            if (input == attack)
            {
                Console.Clear();
                Console.WriteLine("You attacked:");
                Console.WriteLine($"you did{damage}");
                Console.WriteLine($"it's health is {eHealth - damage}");
                Console.ReadKey();
                EnemyTurn();
            }

            if (eHealth >= 0)
            {
                Console.WriteLine("you win!");
                Console.ReadKey();
            }
        }
        
        void EnemyTurn()
        {
            Console.Clear();
            Console.WriteLine("it attacked:");
            Console.WriteLine($"it did{damage}");
            Console.WriteLine($"your health is {health - damage}");
            Console.ReadKey();
            PlayerTurn();

            if(health >= 0)
            {
                Console.WriteLine("it wins.");
                Console.ReadKey();
            }
        }
    }
}
