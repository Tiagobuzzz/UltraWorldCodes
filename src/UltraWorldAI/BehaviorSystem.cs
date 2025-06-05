using System;
using System.Collections.Generic;

namespace UltraWorldAI
{
    /// <summary>
    /// Very simple planner that chooses an action for the character based on
    /// the dominant emotion and some core beliefs. It can be replaced with a
    /// more sophisticated Behavior Tree or planner later.
    /// </summary>
    public class BehaviorSystem
    {
        private readonly Person _person;
        private readonly Random _random = new Random();

        public BehaviorSystem(Person person)
        {
            _person = person;
        }

        /// <summary>
        /// Returns a short description of what the character intends to do next.
        /// </summary>
        public string DecideNextAction()
        {
            string mood = _person.Mind.Emotions.GetDominantEmotion();
            if (mood == "anger")
            {
                return "buscar conflito";
            }
            if (mood == "fear")
            {
                return "evitar perigos";
            }

            // Pick a belief at random to act upon
            var beliefs = _person.Mind.Beliefs.Beliefs;
            if (beliefs.Count > 0)
            {
                int index = _random.Next(beliefs.Count);
                var belief = new List<string>(beliefs.Keys)[index];
                return $"agir de acordo com a crença '{belief}'";
            }

            return "permanecer ocioso";
        }
    }
}
