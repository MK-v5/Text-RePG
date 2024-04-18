using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRePG.Classes.PlayerCharacter.CharacterClasses
{
    public class Knight : Character
    {
        public Knight()
        {
            strength = 15;
            defense = 30;
            agility = 10;

            level = 1;
            experience = 0;

            maxExperience = (level * 10) / 2;
        }

        public override string ToString()
        {
            return "Knight";
        }
    }
}
