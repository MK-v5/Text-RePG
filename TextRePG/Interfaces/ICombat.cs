using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRePG.Classes.PlayerCharacter;

namespace TextRePG.Interfaces
{
    public interface ICombat
    {
        void Commit
            (Character character,
            Character enemy,
            bool playerSucceeded,
            bool enemySucceeded);
    }
}
