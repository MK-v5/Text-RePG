using System.Collections.Concurrent;
using TextRePG.Classes.GameStates;
using TextRePG.Classes.PlayerCharacter.CharacterClasses;
using TextRePG.Classes.PlayerCharacter.CharacterRaces;

namespace TextRePG.Classes.PlayerCharacter
{
    public class Entity
    {
        
        public enum Action
        {
            PushToRace,
            PushToClass,
            PopFromRace,
            PopFromClass,
            ClearFromRace,
            ClearFromClass
        }

        #region Entity Dictionaries

        private readonly Dictionary<Character.Race, Func<Character?>> raceFactories = new();
        private readonly Dictionary<Character.Class, Func<Character?>> ClassFactories = new();

        private readonly List<PlayerTypeQueue> ptList = new List<PlayerTypeQueue>();

        private readonly Character.CharacterContext Context;

        public readonly Stack<Character?> characterStack = new();

        public Entity(Character.CharacterContext context)
        {
            Context = context;
        }

        #endregion End Entity Dictionaries

        public void RegisterCharacterRace<Type>(Character.Race race)where Type : Character
        {
            raceFactories[race] = () => Activator.CreateInstance(typeof(Type), this, Context)as Type;
        }

        public void AddToRace(Character.Race race)
        {
            ptList.Add(new PlayerTypeQueue(Action.PushToRace, race));
        }

        public void AddToClass(Character.Class classs)
        {
            ptList.Add(new PlayerTypeQueue(Action.PushToClass, classs));
        }

        public void PopFrom()
        {
            ptList.Add(new PlayerTypeQueue(Action.PopFromRace, Character.Race.None));
        }

        #region Entity Struct Logic

        private struct PlayerTypeQueue
        {
            public readonly Action Action;
            public readonly Character.Race Race;
            public readonly Character.Class Class;

            public PlayerTypeQueue(Action action, Character.Race race)
            {
                Action = action;
                Race = race;
            }

            public PlayerTypeQueue(Action action, Character.Class classs)
            {
                Action = action;
                Class = classs;
            }
        }

        #endregion End Entity Struct Logic

        private Character? CreateCharacterRace(Character.Race race)
        {
            if (raceFactories.TryGetValue(race, out var raceFactory))
            {
                return raceFactory.Invoke();
            }

            throw new ArgumentException($"Race not Recognised: {race}");
        }
    }
}