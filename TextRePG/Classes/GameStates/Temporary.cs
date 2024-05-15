using TextRePG.Classes.PlayerCharacter;

namespace TextRePG.Classes.GameStates
{
    public class Temporary : State
    {
        public Temporary(Stack<State> state, List<Character> characters, List<Character> CharacterNoMore) 
            : base(state, characters, CharacterNoMore)
        { }

        public override void Update()
        {
            Console.WriteLine("Hi there");
        }
    }
}