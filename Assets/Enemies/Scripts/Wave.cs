using System;

namespace Enemies
{
    [Serializable]
    public class Wave
    {
        public Enemy EnemyPrefab;
        public float Delay;
        public int Count;
    }
}