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
            Vector3 direction = new Vector3(
                Input.GetAxisRaw("Horizontal"),
                GetAxis(KeyCode.Space, KeyCode.LeftShift),
                Input.GetAxisRaw("Vertical")
            );

            direction.Normalize();
            _system.ApplyMovementInput(direction);
        }

        private static float GetAxis(KeyCode positive, KeyCode negative)
        {
            float result = 0;
            if (Input.GetKey(positive)) result++;
            if (Input.GetKey(negative)) result--;
            return result;
        }
    }
}
