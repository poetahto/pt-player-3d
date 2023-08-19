using UnityEngine;

namespace pt_player_3d.Scripts.Rotation
{
    public class RotationSystem : MonoBehaviour, IRotationSystem
    {
        [SerializeField]
        private Transform pitch;

        [SerializeField]
        private Transform yaw;

        [SerializeField]
        private RotationSettings settings;

        private float _pitch;
        private float _yaw;

        public float Pitch
        {
            get => _pitch;
            set
            {
                _pitch = value;
                _pitch = Mathf.Clamp(Pitch, settings.minPitch, settings.maxPitch);
                UpdateTransforms();
            }
        }

        public float Yaw
        {
            get => _yaw;
            set
            {
                _yaw = value;
                UpdateTransforms();
            }
        }

        public Vector3 Rotation
        {
            get => new Vector3(_yaw, _pitch, 0);
            set
            {
                _yaw = value.x;
                _pitch = value.y;
                _pitch = Mathf.Clamp(Pitch, settings.minPitch, settings.maxPitch);
                UpdateTransforms();
            }
        }

        private void Start()
        {
            Pitch = pitch.eulerAngles.x;
            Yaw = yaw.eulerAngles.y;
        }

        private void UpdateTransforms()
        {
            pitch.localRotation = Quaternion.Euler(Pitch, 0, 0);
            yaw.localRotation = Quaternion.Euler(0, Yaw, 0);
        }

        public void ApplyRotationInput(Vector2 delta)
        {
            // Yaw += delta.x;
            // Pitch += delta.y;
            // Pitch = Mathf.Clamp(Pitch, settings.minPitch, settings.maxPitch);
            //
            // pitch.localRotation = Quaternion.Euler(Pitch, 0, 0);
            // yaw.localRotation = Quaternion.Euler(0, Yaw, 0);
            Rotation += new Vector3(delta.x, delta.y, 0);
        }

    }
}
