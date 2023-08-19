using UnityEngine;

namespace pt_player_3d.Scripts.Movement
{
    public class InputMovementController : MonoBehaviour
    {
        [SerializeField]
        private GameObject movementSystem;

        private IMovementSystem _system;

        private void Awake()
        {
            _system = movementSystem.GetComponent<IMovementSystem>();
        }

        private void OnDisable()
        {
            _system.ApplyMovementInput(Vector3.zero);
        }

        private void Update()
        {
            Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            direction.Normalize();
            _system.ApplyMovementInput(direction);
        }
    }
}
