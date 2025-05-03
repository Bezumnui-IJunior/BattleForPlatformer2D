using UnityEngine;

namespace Entity.StaticDatas
{
    [CreateAssetMenu(fileName = "TrackerData", menuName = "ScriptableObject/TrackerData")]
    public class TrackerData : ScriptableObject
    {
        [field: SerializeField] public float FallThreshold { get; private set; } = 0.2f;
        [field: SerializeField] public float JumpCooldown { get; private set; } = 0.2f;
    }
}