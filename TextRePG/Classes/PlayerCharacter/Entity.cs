using System.Collections.Concurrent;
using TextRePG.Classes.PlayerCharacter.CharacterClasses;
using TextRePG.Classes.PlayerCharacter.CharacterRaces;

namespace TextRePG.Classes.PlayerCharacter
{
    public class Entity
    {
        public enum CombatChoices
        {
            None,
            Attack,
            Defend,
        }

        public Entity()
        {
            characterName = "";

            //characterRace = Race.None;
            //characterClass = Class.None;
        }

        #region protected properties

        protected string characterName;

        protected int level;
        protected int experience;
        protected int maxExperience;
        protected int damage;

        //Race Attributes
        protected int hitPoints;
        protected int maxHitPoints;

        protected int skillPoints;
        protected int maxSkillPoints;
        protected int magicPoints;
        protected int maxMagicPoints;
        
        //Class Attributes
        protected int strength;
        protected int defense;
        protected int agility;
        protected bool weild;

        //Miscellanious
        protected bool isDead;
        protected bool blocking;

        #endregion end protected properties

        #region public properties

        public string Name
        {
            get => characterName; //returns value of characterName.
            set => characterName = value; //assigns value of characterName (only in child).
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

        //public Race characterRace;
        //public Class characterClass;
        public CombatChoices combatOptions;

        #endregion end public properties

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
    }
}