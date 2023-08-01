using UnityEngine;

namespace pt_player_3d.Scripts.Rotation
{
    public class InputRotationController : MonoBehaviour
    {
        [SerializeField] private RotationSystem rotationSystem;

        private void Update()
        {
            Vector2 delta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            rotationSystem.ApplyRotation(delta);
        }
    }
}
