using UnityEngine;

namespace pt_player_3d.Scripts
{
    public abstract class GroundCheck3d : MonoBehaviour
    {
        public abstract bool TryGetGround(out GroundData3d groundData3d);
    }

    public struct GroundData3d
    {
        public Vector3 Normal;
        public Vector3 Point;
        public Collider Surface;
    }
}
