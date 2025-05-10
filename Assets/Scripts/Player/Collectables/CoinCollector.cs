using Props;
using UnityEngine;

namespace Player.Collectables
{
    public class CoinCollector : ICollector
    {
        private readonly Player _player;

        public CoinCollector(Player player)
        {
            _player = player;
        }

        public bool TryCollect(ICollectable collectable)
        {
            if (collectable is not Coin coin)
                return false;

            Debug.Log($"{_player.name} has collected a coin with amount of {coin.Amount}");

            return true;
        }
    }
}