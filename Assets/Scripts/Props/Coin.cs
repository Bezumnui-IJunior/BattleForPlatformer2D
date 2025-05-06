using UnityEngine;

namespace Props
{
    [RequireComponent(typeof(Collider2D))]
    public class Coin : MonoBehaviour, ICollectable
    {
        public int Amount { get; } = 1;

        public void Yield()
        {
            Destroy();
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }
    }
}