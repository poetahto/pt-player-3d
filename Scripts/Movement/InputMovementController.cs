using UnityEngine;

namespace pt_player_3d.Scripts.Movement
{
    public class InputMovementController : MonoBehaviour
    {
        [SerializeField]
        private MovementController movementController;

        private void Update()
        {
            Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            movementController.ApplyInput(direction);
        }
    }
}
