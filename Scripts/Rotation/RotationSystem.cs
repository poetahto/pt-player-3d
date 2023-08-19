using UnityEngine;

namespace pt_player_3d.Scripts.Rotation
{
    public class RotationSystem : MonoBehaviour, IRotationSystem
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

        public void ApplyRotationInput(Vector2 delta)
        {
            _yaw += delta.x;
            _pitch += delta.y;
            _pitch = Mathf.Clamp(_pitch, settings.minPitch, settings.maxPitch);

            pitch.localRotation = Quaternion.Euler(_pitch, 0, 0);
            yaw.localRotation = Quaternion.Euler(0, _yaw, 0);
        }

        public Vector3 Rotation
        {
            get => new Vector3(_yaw, _pitch, 0);
            set
            {
                _pitch = value.y;
                _yaw = value.x;
                _pitch = Mathf.Clamp(_pitch, settings.minPitch, settings.maxPitch);

                pitch.localRotation = Quaternion.Euler(_pitch, 0, 0);
                yaw.localRotation = Quaternion.Euler(0, _yaw, 0);
            }
        }
    }
}
