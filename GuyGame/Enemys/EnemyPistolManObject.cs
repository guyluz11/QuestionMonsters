using System.Speech.Synthesis;

namespace GuyGame
{
    public class EnemyPistolManObjectTest : EnemyObject
    {
        const string name = "Pistol Man"; // Name of the enemy
        const int speed = 4; // Speed of the enemy
        const double damage = 20; // Damage of the enemy
        const int minQuestions = 3; // Constant minimum questions (specific to the inherited enemy type) 
        const int maxQuestions = 4; // Maximum questions that user can choose


        public EnemyPistolManObjectTest() : base(name, speed, damage,minQuestions, maxQuestions, 1)
        {
            
        }
    }
}