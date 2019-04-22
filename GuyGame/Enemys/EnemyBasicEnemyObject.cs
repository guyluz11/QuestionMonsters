namespace GuyGame
{
    public class EnemyBasicEnemyObject : EnemyObject
    {
        
        // Name = 
        // Speed = 
        // Damage = 
        // MinQuestions
        // MaxQuestions 
        // Basic enemy settings
        
        
        const string name = "Enemy"; // Name of the enemy
        const int speed = 1; // Speed of the enemy
        const double damage = 10; // Damage of the enemy
        const int minQuestions = 1; // Constant minimum questions (specific to the inherited enemy type) 
        const int maxQuestions = 3; // Maximum questions that user can choose

        
        public EnemyBasicEnemyObject() : base(name, speed, damage,minQuestions, maxQuestions, 1)
        {

            // Initialing the variables in the parent class
        }
    }
}