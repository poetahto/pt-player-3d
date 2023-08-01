using UnityEngine;

namespace pt_player_3d.Scripts.Movement
{
    public abstract class MovementController : MonoBehaviour
    {
        public abstract void ApplyInput(Vector3 direction);
    }
}