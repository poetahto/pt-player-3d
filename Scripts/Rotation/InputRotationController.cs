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
            float pitchDelta = -Input.GetAxisRaw("Mouse Y") * sensitivity;
            float yawDelta = Input.GetAxisRaw("Mouse X") * sensitivity;
            _system.ApplyRotationInput(pitchDelta, yawDelta);
        }
    }
}
