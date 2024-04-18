using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRePG.Interfaces;

namespace TextRePG.Classes.PlayerCharacter
{
    public class Character : Entity, IEntity
    {
        Random rnd = new Random();

        int defenseFactor = 5;

        public int Attack()
        {
            //Calculate damage upon calling this function.
            int damage = CalculateDamage();
            return damage;
        }

        public int Defend()
        {
            //Calculate damage upon calling this function.
            int incomingDMG = CalculateDamage();

            //apply defense to reduce the damage taken from enemy or status effect.
            int reducedDMG = incomingDMG - (DEF * defenseFactor);
            reducedDMG = Math.Max(reducedDMG, 0);

            return reducedDMG;
        }

        public int UseMagic()
        {
            //make skill Logic
            /*
            * make it 
            *
            */
            throw new NotImplementedException();
        }

        public int UseSkill()
        {
            //make magic logic
            throw new NotImplementedException();
        }

        public int CalculateDamage()
        {

            var baseDMG = DMG;
            var modDMG = (int)(baseDMG * (1 + STR / 10.0));

            //induce Randomness 
            var Randomness = rnd.NextDouble() * 0.2 + 1.5; //between 0.2 and 1.5
            var TotalDMG = (int)(modDMG * Randomness);

            return TotalDMG;
        }
    }
}
