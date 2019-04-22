using System.Collections.Generic;

namespace GuyGame
{
    public abstract class EnemyObject
    {
        // Variables
        private readonly string name;    // Name of the enemy

        private readonly int speed;    // Speed of the enemy

        private readonly double damage;    // Damage of the enemy

        private readonly int minQuestions;    // Minimum questions that user can choose 

        private readonly int maxQuestions;    // Maximum questions that user can choose

        private readonly int selectedNumberOfQuestions; // Stores user number of questions, should be between minQuestions and maxQuestions

        
        // constructor 
        protected EnemyObject(string name, int speed, double damage, int minQuestions, int maxQuestions, int selectedNumberOfQuestions)
        {
            this.name = name;
            this.speed = speed;
            this.damage = damage;
            this.minQuestions = minQuestions;
            this.maxQuestions = maxQuestions;
            this.selectedNumberOfQuestions = selectedNumberOfQuestions;
        }

        // Functions 
        
        //get
        private string GetName() => name;
        private int GetSpeed() => speed;
        private double GetDamage => damage;
        private int GetMinQuestions => minQuestions;
        

        public void Attack() => SpeakClass.newEnemyEn(GetName());
    }
}