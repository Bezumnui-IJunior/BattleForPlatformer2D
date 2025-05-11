using Props;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Player))]
    [RequireComponent(typeof(Collider2D))]
    public class Collector : MonoBehaviour, ICollector
    {
        private Player _player;

        private void Awake()
        {
            _player = GetComponent<Player>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out ICollectable collectable))
                return;

            collectable.Accept(this);
        }

        public void Collect(Coin coin)
        {
            Debug.Log(
                $"{_player.name} has collected a coin with amount of {coin.Amount}. I don't have a wallet impl so do not blame me");
        }

        public void Collect(Medkit medkit)
        {
            _player.EntityHealth.Heal(medkit.Amount);
        }
    }
}