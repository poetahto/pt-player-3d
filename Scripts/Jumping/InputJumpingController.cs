using UnityEngine;

namespace pt_player_3d.Scripts
{
    public class InputJumpingController : MonoBehaviour
    {
        [SerializeField]
        private KeyCode jumpKey = KeyCode.Space;

        [SerializeField]
        private bool holdToJump = true;

        [SerializeField]
        private JumpingSystem jumpingSystem;

        private void Update()
        {
            jumpingSystem.IsJumpHeld = Input.GetKey(jumpKey);

            if ((holdToJump && Input.GetKey(jumpKey)) || Input.GetKeyDown(jumpKey))
                jumpingSystem.TryJump();
        }
    }
}
