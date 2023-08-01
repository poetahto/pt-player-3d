using UnityEngine;

namespace pt_player_3d.Scripts
{
    public class InputJumpingController : MonoBehaviour
    {
        [SerializeField]
        private KeyCode jumpKey = KeyCode.Space;

        [SerializeField]
        private bool holdToJump;

        [SerializeField]
        private bool scrollToJump;

        [SerializeField]
        private JumpingSystem jumpingSystem;

        private void OnDisable()
        {
            jumpingSystem.IsJumpHeld = false;
        }

        private void Update()
        {
            jumpingSystem.IsJumpHeld = Input.GetKey(jumpKey);

            if ((holdToJump && Input.GetKey(jumpKey)) || Input.GetKeyDown(jumpKey) || (scrollToJump && Input.GetAxisRaw("Mouse ScrollWheel") != 0))
                jumpingSystem.ApplyJumpInput();
        }
    }
}
