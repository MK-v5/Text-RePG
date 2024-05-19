using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TextRePG.Classes.PlayerCharacter;

namespace TextRePG.Classes.EnemyCharacter.EnemyClasses
{
    public class PlagueDoctor : Character
    {
        public PlagueDoctor()
        {
            strength = 10;
            defense = 30;
            agility = 10;

            level = 1;
        }

        public override string ToString()
        {
            return "Mercenary";
        }
    }
}
