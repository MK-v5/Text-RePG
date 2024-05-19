using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRePG.Classes.PlayerCharacter;

namespace TextRePG.Classes.EnemyCharacter.EnemyRaces
{
    class Rat : Character
    {
        public Rat()
        {
            maxHitPoints = 10;
            maxSkillPoints = 30;
            maxMagicPoints = 15;

            hitPoints = maxHitPoints;
            magicPoints = maxMagicPoints;
            skillPoints = maxSkillPoints;
        }

        public override void LevelUp()
        {
            base.LevelUp();
            maxHitPoints = 10;
            hitPoints = maxHitPoints;
        }

        public override string ToString()
        {
            return "Rat";
        }
    }
}
