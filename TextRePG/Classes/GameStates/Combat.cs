using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRePG.Classes.EnemyCharacter;
using TextRePG.Classes.PlayerCharacter;

namespace TextRePG.Classes.GameStates
{
    public class Combat : State
    {
        private Enemy enemy;

        private Character? player;

        public Combat(Stacker stateStack, Context context, Character? character) : base(stateStack, context) 
        {

            player = character;
            

        }
    }
}
