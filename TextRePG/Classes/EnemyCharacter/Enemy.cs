using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRePG.Classes.PlayerCharacter;
using TextRePG.Interfaces;

namespace TextRePG.Classes.EnemyCharacter
{
    public class Enemy : Character
    {
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

        private float statModifier = 0.4f;

        public EnemyType enemyType;
        public EnemyRace enemyRace;

        private Character? player;

        public Enemy(Character? player)
        {
            this.player = player;

            CreateEnemy();

            while(level != player.Level)
            {
                level++;
            }

            ApplyStats();
        }

        private void CreateEnemy()
        {
            var rnd = new Random();

            var enemyTypes = Enum.GetValues(typeof(EnemyType));
            var enemyRaces = Enum.GetValues(typeof(EnemyRace));
            enemyType = (EnemyType)enemyTypes.GetValue(rnd.Next(enemyTypes.Length));
            enemyRace = (EnemyRace)enemyRaces.GetValue(rnd.Next(enemyRaces.Length));
            Debug.WriteLine($"Enemy type: {enemyType}");
            Debug.WriteLine($"Enemy race: {enemyRace}");
        }

        private float LevelModifier()
        {
            float playerLevel = player.Level;
            return statModifier += playerLevel;
        }

        private void ApplyStats()
        {
            float hp = 30;
            float sp = 15;
            float mp = 15;
            
            float s = 15;
            float d = 10;
            float a = 15;

            switch (enemyType)
            {
                case EnemyType.Mercenary:
                    strength = (int)(s *= LevelModifier());
                    defense = (int)(d *= LevelModifier());
                    agility = (int)(a *= LevelModifier());


                    break;

                case EnemyType.Bandit:
                    s = 10;
                    d = 15;
                    a = 30;

                    strength = (int)(s *= LevelModifier());
                    defense = (int)(d *= LevelModifier());
                    agility = (int)(a *= LevelModifier());
                    break;

                case EnemyType.PlagueDoctor:
                    s = 15;
                    d = 15;
                    a = 10;

                    strength = (int)(s *= LevelModifier());
                    defense = (int)(d *= LevelModifier());
                    agility = (int)(a *= LevelModifier());
                    break;

                case EnemyType.Demon:
                    s = 30;
                    d = 10;
                    a = 30;

                    strength = (int)(s *= LevelModifier());
                    defense = (int)(d *= LevelModifier());
                    agility = (int)(a *= LevelModifier());
                    break;
            }

            switch (enemyRace)
            {
                case EnemyRace.Horse:
                    hitPoints = (int)(hp *= LevelModifier());
                    skillPoints = (int)(sp *= LevelModifier());
                    magicPoints = (int)(mp *= LevelModifier());
                    break;

                case EnemyRace.Rat:
                    hp = 15;
                    sp = 10;
                    mp = 15;

                    hitPoints = (int)(hp *= LevelModifier());
                    skillPoints = (int)(sp *= LevelModifier());
                    magicPoints = (int)(mp *= LevelModifier());
                    break;

                case EnemyRace.Snake:
                    hp = 10;
                    sp = 30;
                    mp = 30;

                    hitPoints = (int)(hp *= LevelModifier());
                    skillPoints = (int)(sp *= LevelModifier());
                    magicPoints = (int)(mp *= LevelModifier());
                    break;

                case EnemyRace.Monkey:
                    hp = 15;
                    sp = 15;
                    mp = 30;

                    hitPoints = (int)(hp *= LevelModifier());
                    skillPoints = (int)(sp *= LevelModifier());
                    magicPoints = (int)(mp *= LevelModifier());
                    break;
            }
        }
    }
}
