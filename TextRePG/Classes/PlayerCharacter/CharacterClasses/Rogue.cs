using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRePG.Classes.PlayerCharacter.CharacterClasses
{
    public class Rogue : Character
    {
        public Rogue(Entity EntityStack, CharacterContext context) : base(EntityStack, context)
        {
            characterClass = Class.Rogue;
            strength = 15;
            defense = 10;
            agility = 40;

            level = 1;
            experience = 0;

            maxExperience = (level * 10) / 2;
        }

        public override string ToString()
        {
            return "Rogue";
        }
    }
}
