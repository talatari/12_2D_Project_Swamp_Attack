using UnityEngine;

namespace Players
{
    public class Wallet : MonoBehaviour
    {
        private int _coins = 0;

        public int Coins => _coins;
        
        public void AddCoins(int coins)
        {
            if (coins > 0)
                _coins += coins;
        }

        public void SpendCoins(int coins)
        {
            if (coins <= 0) 
                return;
            
            if (_coins - coins >= 0)
                _coins -= coins;
        }
    }
}