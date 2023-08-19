using UnityEngine;

namespace pt_player_3d.Scripts.Rotation
{
    [CreateAssetMenu(menuName = Player3dNaming.AssetMenuName + "/Rotation Settings")]
    public class RotationSettings : ScriptableObject
    {
        public float maxPitch = 90;
        public float minPitch = -90;
    }
}
