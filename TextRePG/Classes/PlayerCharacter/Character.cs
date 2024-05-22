using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRePG.Classes.PlayerCharacter.CharacterClasses;
using TextRePG.Classes.PlayerCharacter.CharacterRaces;
using TextRePG.Interfaces;

namespace TextRePG.Classes.PlayerCharacter
{
    public class Character
    {

        protected Character(Entity EntityStack, CharacterContext context)
        {
            entityStack = EntityStack;
            Context = context;
        }

        protected Entity entityStack;
        protected CharacterContext Context;

        Random rnd = new Random();

        int defenseFactor = 5;

        #region protected properties

        //Name
        protected string characterName;

        //Level and exp.
        protected int level;
        protected int experience;
        protected int maxExperience;
        protected int damage;

        //Race Attributes.
        protected int hitPoints;
        protected int maxHitPoints;

        protected int skillPoints;
        protected int maxSkillPoints;
        protected int magicPoints;
        protected int maxMagicPoints;

        //Class Attributes.
        protected int strength;
        protected int defense;
        protected int agility;

        //Miscellanious.
        protected bool isDead;
        protected bool blocking;

        #endregion end protected properties

        #region public properties

        public string Name
        {
            get => characterName; //returns value of characterName.
            set => characterName = value; //assigns value of characterName (only in child).
        }

        public int Level
        {
            get => level;
            set => level = value;
        }

        public int HP
        {
            get => hitPoints;
            protected set => hitPoints = value;
        }

        public int maxHP
        {
            get => maxHitPoints;
            protected set => maxHitPoints = value;
        }

        public int SP
        {
            get => skillPoints;
            protected set => skillPoints = value;
        }

        public int maxSP
        {
            get => maxSkillPoints;
            protected set => maxSkillPoints = value;
        }

        public int MP
        {
            get => magicPoints;
            protected set => magicPoints = value;
        }

        public int maxMP
        {
            get => maxMagicPoints;
            protected set => maxMagicPoints = value;
        }

        public int STR
        {
            get => strength;
            protected set => strength = value;
        }

        public int DEF
        {
            get => defense;
            protected set => defense = value;
        }

        public int AGI
        {
            get => agility;
            protected set => agility = value;
        }

        public int DMG
        {
            get => damage;
            protected set => damage = value;
        }

        public bool Blocking
        {
            get => blocking;
            protected set => blocking = value;
        }

        public bool IsAlive() => HP >= 0;

        public bool IsBlocking() => Blocking;

        #endregion end public properties

        #region enum region

        public enum EnemyType
        {
            Bandit,
            Demon,
            Mercenary,
            PlagueDoctor
        }

        public enum EnemyRace
        {
            Rat,
            Monkey,
            Horse,
            Snake
        }

        public enum Race
        {
            None,
            Wolf,
            Cat,
            Fox,
            Dragon
        }

        public enum Class
        {
            None,
            Knight,
            Rogue,
            Mage,
            Berserker
        }

        public Race characterRace;

        public Class characterClass;

        #endregion end enum region

        public struct CharacterContext
        {
            public readonly Race characterRace;
            public readonly Class characterClass;
            public readonly EnemyType enemyType;
            public readonly EnemyRace enemyRace;

            public CharacterContext(Race race, Class classs, EnemyType et, EnemyRace er)
            {

            }
        }

        #region methods

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
            //make magic Logic
            /*
            * make it 
            *
            */
            throw new NotImplementedException();
        }

        public int UseSkill()
        {
            //make  skill logic
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

        #endregion end methods

        #region LevelUp Method

        public virtual void LevelUp()
        {
            level++;
            experience -= maxExperience;
            maxExperience += level * 10;

            switch (this)
            {
                //increase stats by race
                case Wolf:
                    maxHitPoints += 20;
                    maxSkillPoints += 30;
                    maxMagicPoints += 25;
                    break;

                case Cat:
                    maxHitPoints += 20;
                    maxSkillPoints += 30;
                    maxMagicPoints += 25;
                    break;

                case Fox:
                    maxHitPoints += 20;
                    maxSkillPoints += 30;
                    maxMagicPoints += 25;
                    break;

                case Dragon:
                    maxHitPoints += 20;
                    maxSkillPoints += 30;
                    maxMagicPoints += 25;
                    break;

                //increase stats by Class
                case Knight:
                    strength += 35;
                    defense += 15;
                    agility += 5;
                    break;

                case Rogue:
                    strength += 35;
                    defense += 15;
                    agility += 5;
                    break;

                case Mage:
                    strength += 35;
                    defense += 15;
                    agility += 5;
                    break;

                case Berserker:
                    strength += 35;
                    defense += 15;
                    agility += 5;
                    break;
            }
        }

        #endregion end LevelUp Method

    }
}
