using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRePG.Classes.PlayerCharacter.CharacterClasses
{
    public class Berserker : Character
    {
        public Berserker()
        {
            strength = 30;
            defense = 15;
            agility = 10;

            level = 1;
            experience = 0;

            maxExperience = (level * 10) / 2;
        }

        public override string ToString()
        {
            return "Berserker";
        }
    }
}
