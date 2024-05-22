using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRePG.Classes.PlayerCharacter.CharacterRaces
{
    public class Dragon : Character
    {
        public Dragon()
        {
            characterRace = Race.Dragon;
            maxHitPoints = 30;
            maxSkillPoints = 15;
            maxMagicPoints = 10;

            hitPoints = maxHitPoints;
            magicPoints = maxMagicPoints;
            skillPoints = maxSkillPoints;
        }

        public override void LevelUp()
        {
            base.LevelUp();
            maxHitPoints = 30;
            hitPoints = maxHitPoints;
        }

        public override string ToString()
        {
            return "Dragon";
        }
    }
}
