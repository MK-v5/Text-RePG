using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRePG.Classes.EnemyCharacter;
using TextRePG.Classes.PlayerCharacter;
using TextRePG.Classes.PlayerClass;

namespace TextRePG.Classes.GameStates
{
    public class Combat : State
    {
        #region constructor values

        private Enemy enemy;

        private Character? player;

        private Random rnd = new Random();

        public Combat
            (Stacker stateStack, Context context,
            Character? character, bool isCombat, List<Character> characters,
            List<Character> deadCharacters)
            : base(stateStack, context) 
        {
            EndCombat = isCombat;
            player = character;
            if (player != null) enemy = new (player);
            Player.GetPlayer(character);
            Debug.WriteLine($"Enemy Type{enemy.enemyType}" +
                            $"Enemy Race{enemy.enemyRace}");
        }

        #endregion end constructor values

        public override void Update()
        {
            Console.Clear();
            if (!EndCombat)
            {
                InstatiateCombat();
            }
            else
            {
                StateStack.PopState();
            }
        }

        private void InstatiateCombat()
        {
/*
            while ()
            {

            }
*/
        }
    }
}
