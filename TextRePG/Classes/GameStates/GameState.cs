namespace TextRePG.Classes.GameStates
{
    public class GameState : State
    {
        public GameState(Stack<State> state) : base(state)
        { }

        public override void Update()
        {
            Console.WriteLine("Hi there");
        }
    }
}