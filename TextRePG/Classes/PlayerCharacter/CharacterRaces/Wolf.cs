using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRePG.Classes.PlayerCharacter.CharacterRaces
{
    public class Wolf : Character 
    {
        public Wolf()
        {
            maxHitPoints = 40;
            maxSkillPoints = 10;
            maxMagicPoints = 15;

            hitPoints = maxHitPoints;
            magicPoints = maxMagicPoints;
            skillPoints = maxSkillPoints;
        }

        public override void LevelUp()
        {
            base.LevelUp();
            maxHitPoints = 40;
            hitPoints = maxHitPoints;
        }

        public override string ToString()
        {
            return "Wolf";
        }
    }
}
