using UnityEngine;

namespace pt_player_3d.Scripts
{
    [CreateAssetMenu(menuName = Player3dNaming.AssetMenuName + "/Jumping Settings")]
    public class JumpingSettings : ScriptableObject
    {
        public float jumpSpeed = 5;
    }
}