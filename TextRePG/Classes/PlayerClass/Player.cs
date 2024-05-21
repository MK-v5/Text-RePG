using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRePG.Classes.PlayerCharacter;

namespace TextRePG.Classes.PlayerClass
{
    public class Player : Character
    {
        public Player(Character character)
        {
            Debug.WriteLine($"Hello {character}");
        }

        public static Character? GetPlayer(Character? player)
        {
            Debug.WriteLine($"Returning: {player}" +
                            $"Player name: {player.Name}");

            return player;
        }
    }
}
