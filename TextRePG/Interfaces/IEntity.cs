using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRePG.Interfaces
{
    /// <summary>
    /// IEntity has the base fucntionality a character WILL need throughout the game.
    /// </summary>
    public interface IEntity
    {

        /// <summary>
        /// Attack() is used to attack the enemy Target. 
        /// </summary>
        int Attack();

        /// <summary>
        /// Defend() is used to reduce damage induced by enemy.
        /// </summary>
        int Defend();

        /// <summary>
        /// A skill will inflict more damage than a regular attack.
        /// It can also induce a bleeding or stun status effect on enemies only.
        /// </summary>
        int UseSkill();

        /// <summary>
        /// Magic will Inflict more damage than a regular attack.
        /// It will also induce a multitude of status effects on either enemies or yourself.
        /// </summary>
        int UseMagic();

        /// <summary>
        /// CalculateDamage() is called upon every Attack(), UseSkill() and all Offensive Magic Ablities in UseMagic() sequence,
        /// the function will calculate the damage to each attack, skill and O.M.A. accordingly.
        /// </summary>
        int CalculateDamage();
    }
}
