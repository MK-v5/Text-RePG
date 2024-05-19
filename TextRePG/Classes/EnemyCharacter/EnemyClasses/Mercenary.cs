using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRePG.Classes.PlayerCharacter;

namespace TextRePG.Classes.EnemyCharacter.EnemyClasses
{
    public class Mercenary : Character
    {
        public Mercenary()
        {
            strength = 15;
            defense = 10;
            agility = 15;

            level = 1;
        }

        public override string ToString()
        {
            return "Mercenary";
        }
    }
}
