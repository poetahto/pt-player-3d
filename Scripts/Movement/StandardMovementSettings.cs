using UnityEngine;

namespace pt_player_3d.Scripts.Movement
{
    [CreateAssetMenu(menuName = Player3dNaming.AssetMenuName + "/Standard Movement Settings")]
    public class StandardMovementSettings : ScriptableObject
    {
        public float speed = 3;
        public float acceleration = 3;
        public float decceleration = 3;
    }
}
