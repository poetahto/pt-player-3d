using UnityEngine;

namespace pt_player_3d.Scripts.Rotation
{
    public class InputRotationController : MonoBehaviour
    {
        [SerializeField]
        private GameObject rotationSystem;

        [SerializeField]
        private float sensitivity = 1;

        private IRotationSystem _system;

        private void Awake()
        {
            _system = rotationSystem.GetComponent<IRotationSystem>();
        }

        private void Update()
        {
            Vector2 delta = new Vector2(Input.GetAxisRaw("Mouse X"), -Input.GetAxisRaw("Mouse Y"));
            _system.ApplyRotationInput(delta * sensitivity);
        }
    }
}
