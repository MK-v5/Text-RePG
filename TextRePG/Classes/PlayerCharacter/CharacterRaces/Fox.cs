using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRePG.Classes.PlayerCharacter.CharacterRaces
{
    public class Fox : Character
    {
        public Fox()
        {
            maxHitPoints = 15;
            maxSkillPoints = 30;
            maxMagicPoints = 40;

            hitPoints = maxHitPoints;
            magicPoints = maxMagicPoints;
            skillPoints = maxSkillPoints;
        }

        public override void LevelUp()
        {
            base.LevelUp();
            maxHitPoints = 15;
            hitPoints = maxHitPoints;
        }

        public override string ToString()
        {
            return "Fox";
        }
    }
}
