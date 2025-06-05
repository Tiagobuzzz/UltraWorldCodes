using System.Collections.Generic;

namespace UltraWorldAI
{
    public class GoalSystem
    {
        public List<Goal> ActiveGoals { get; } = new();

        public void AddGoal(string description, float urgency)
        {
            ActiveGoals.Add(new Goal { Description = description, Urgency = urgency });
        }

        public void RemoveGoal(Goal goal)
        {
            ActiveGoals.Remove(goal);
        }
    }

    public class Goal
    {
        public string Description { get; set; } = string.Empty;
        public float Urgency { get; set; }
    }
}
