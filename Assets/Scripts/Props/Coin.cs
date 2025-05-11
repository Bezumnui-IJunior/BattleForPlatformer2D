using UnityEngine;

namespace Props
{
    [RequireComponent(typeof(Collider2D))]
    public class Coin : MonoBehaviour, ICollectable
    {
        public int Amount => 1;

        public void Accept(ICollector collector)
        {
            collector.Collect(this);
            Destroy();
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }
    }
}