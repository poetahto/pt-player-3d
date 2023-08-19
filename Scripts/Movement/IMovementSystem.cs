using UnityEngine;

namespace pt_player_3d.Scripts.Movement
{
    public interface IMovementSystem
    {
        void ApplyMovementInput(Vector3 direction);
    }
}
