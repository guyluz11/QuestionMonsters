namespace GuyGame
{
    public class EnemyJumperObject : EnemyObject
    {
        const string name = "Jumper man"; // Name of the enemy
        const int speed = 2; // Speed of the enemy
        const double damage = 13; // Damage of the enemy
        const int minQuestions = 2; // Constant minimum questions (specific to the inherited enemy type) 
        const int maxQuestions = 3; // Maximum questions that user can choose


        public EnemyJumperObject() : base(name, speed, damage,minQuestions, maxQuestions, 1)
        {
            
        }
    }
}