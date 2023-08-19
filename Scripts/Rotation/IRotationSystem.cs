using UnityEngine;

namespace pt_player_3d.Scripts.Rotation
{
    public interface IRotationSystem
    {
        public void ApplyRotationInput(Vector2 delta);
        public Vector3 Rotation { get; set; }
    }
}
