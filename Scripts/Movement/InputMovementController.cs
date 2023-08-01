using UnityEngine;

namespace pt_player_3d.Scripts.Movement
{
    public class InputMovementController : MonoBehaviour
    {
        [SerializeField]
        private MovementController movementController;

        private void OnDisable()
        {
            movementController.ApplyInput(Vector3.zero);
        }

        private void Update()
        {
            Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            direction.Normalize();
            movementController.ApplyInput(direction);
        }
    }
}
