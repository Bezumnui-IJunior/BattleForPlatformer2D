using System.Collections.Generic;
using System.Linq;
using Player.Collectables;
using Props;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Player))]
    [RequireComponent(typeof(Collider2D))]
    public class Collector : MonoBehaviour
    {
        private Player _player;
        private readonly List<ICollector> _collectors = new();

        private void Awake()
        {
            _player = GetComponent<Player>();
            _collectors.Add(new CoinCollector(_player));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out ICollectable collectable))
                return;

            if (_collectors.Any(collector => collector.TryCollect(collectable)))
            {
                collectable.Yield();
            }
        }
    }
}