using UnityEngine;

namespace pt_player_3d.Scripts.Rotation
{
    public class RotationSystem : MonoBehaviour
    {
        [SerializeField] private Transform pitch;
        [SerializeField] private Transform yaw;
        [SerializeField] private RotationSettings settings;

        private float _pitch;
        private float _yaw;

        private void Start()
        {
            _pitch = pitch.eulerAngles.x;
            _yaw = yaw.eulerAngles.y;
        }

        public void ApplyRotation(Vector2 delta)
        {
            _yaw += delta.x * settings.sensitivity;
            _pitch -= delta.y * settings.sensitivity;
            _pitch = Mathf.Clamp(_pitch, settings.minPitch, settings.maxPitch);

            pitch.localRotation = Quaternion.Euler(_pitch, 0, 0);
            yaw.localRotation = Quaternion.Euler(0, _yaw, 0);
        }
    }
}
