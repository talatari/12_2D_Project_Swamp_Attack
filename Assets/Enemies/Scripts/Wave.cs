using System;

namespace Enemies
{
    [Serializable]
    public class Wave
    {
        public Enemy[] EnemyPrefabs;
        public float Delay;
        public int Count;
    }
}