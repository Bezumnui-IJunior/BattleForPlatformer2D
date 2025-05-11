using UnityEngine;

namespace Props
{
    public class Medkit : MonoBehaviour, ICollectable
    {
        public float Amount => 25;
        
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