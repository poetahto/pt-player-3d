using UnityEngine;

namespace pt_player_3d.Scripts.Rotation
{
    public interface IRotationSystem
    {
        public void ApplyRotationInput(float pitchDelta, float yawDelta);
    }
}
