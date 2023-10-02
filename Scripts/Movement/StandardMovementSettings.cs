using UnityEngine;
using UnityEngine.Serialization;

namespace pt_player_3d.Scripts.Movement
{
    [CreateAssetMenu(menuName = Player3dNaming.AssetMenuName + "/Standard Movement Settings")]
    public class StandardMovementSettings : ScriptableObject
    {
        public float speed = 3;
        public float acceleration = 3;

        [FormerlySerializedAs("decceleration")]
        public float deceleration = 3;

        public bool controlY;
    }
}
