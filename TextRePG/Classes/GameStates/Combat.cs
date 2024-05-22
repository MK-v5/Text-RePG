using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRePG.Classes.EnemyCharacter;
using TextRePG.Classes.PlayerCharacter;
using TextRePG.Classes.PlayerClass;
using TextRePG.Lib;

namespace TextRePG.Classes.GameStates
{
    public class Combat : State
    {
        #region constructor values

        public readonly string[] CombatOptions = { "Attack", "Defend", "Skill" }; 

        private Enemy enemy;

        private Character? player;

        private Context Conntext;

        private Random rnd = new Random();

        public Combat(Stacker stateStack, Context context)
            : base(stateStack, context)
        {
            Conntext = context;
        }

        #endregion end constructor values

        void CombatLoop()
        {
            while(player.HP > 0)
            {
                Draw();
            }
        }

        public override void Draw()
        {
            Console.Clear();
            GUI.DrawState(this);
            GUI.DrawOptions(CombatOptions);

            Console.WriteLine("\nWhat will you do?: \n");
            CombatChoices(InputManager.GetIntInput("-> "));
        }

        void CombatChoices(int input)
        {
            player.characterClass = Entity.Class.Rogue;
            player.characterRace = Entity.Race.Cat;

            switch (input) 
            {
                case 1:
                    player.Attack();
                    Console.ReadKey();
                    EnemyTurn();
                    break;

                case 2:
                    player.Defend();
                    Console.ReadKey();
                    EnemyTurn();
                    break;

                case 3:
                    Console.WriteLine("You Ambitions lead you nowhere (W.I.P.)");
                    break;
            }
        }

        void EnemyTurn()
        {
            Console.WriteLine("The Enemy Lunges at you");
            enemy.Attack();
        }



        void Lose()
        {
            if(player.HP <= 0)
            {
                Console.WriteLine("You Were Slain.");
            }
        }

        void Win()
        {
            if(enemy.HP <= 0)
            {
                Console.WriteLine("You succesfully defeated the enemy, you get to live for another battle.");
            }
        }

        public override string ToString()
        {
            return "Combat";
        }
    }
}
