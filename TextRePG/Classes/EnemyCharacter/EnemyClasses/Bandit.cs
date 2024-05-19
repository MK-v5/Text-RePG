using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TextRePG.Classes.PlayerCharacter;

namespace TextRePG.Classes.EnemyCharacter.EnemyClasses
{
    public class Bandit : Character
    {
        public Bandit()
        {
            strength = 15;
            defense = 10;
            agility = 30;

            level = 1;
        }

        public override string ToString()
        {
            return "Bandit";
        }
    }
}
