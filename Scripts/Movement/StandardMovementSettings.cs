using UnityEngine;

namespace pt_player_3d.Scripts.Movement
{
    [CreateAssetMenu(menuName = Player3dNaming.AssetMenuName + "/Standard Movement Settings")]
    public class StandardMovementSettings : ScriptableObject
    {
        public float speed = 3;
    }
}
