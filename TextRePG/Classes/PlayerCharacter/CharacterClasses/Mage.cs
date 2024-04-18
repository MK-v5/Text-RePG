using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRePG.Classes.PlayerCharacter.CharacterClasses
{
    public class Mage : Character
    {
        public Mage()
        {
            strength = 10;
            defense = 10;
            agility = 15;

            level = 1;
            experience = 0;

            maxExperience = (level * 10) / 2;
        }

        public override string ToString()
        {
            return "Mage";
        }
    }
}
