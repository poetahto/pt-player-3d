using UnityEngine;

namespace pt_player_3d.Scripts
{
    public class JumpingSystem : MonoBehaviour
    {
        [SerializeField] private GroundCheck3d groundCheck;
        [SerializeField] private Rigidbody body;
        [SerializeField] private JumpingSettings settings;

        public bool IsJumpHeld { get; set; }

        public void TryJump()
        {
            if (groundCheck.TryGetGround(out GroundData3d groundData))
            {
                body.velocity = groundData.Normal * settings.jumpSpeed;
            }
        }
    }
}
