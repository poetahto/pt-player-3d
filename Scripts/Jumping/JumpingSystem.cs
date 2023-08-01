using System;
using UnityEngine;

namespace pt_player_3d.Scripts
{
    public class JumpingSystem : MonoBehaviour
    {
        [SerializeField]
        private GroundCheck3d groundCheck;

        [SerializeField]
        private Rigidbody body;

        [SerializeField]
        private JumpingSettings settings;

        private float _timeSinceJumpAttempt;
        private bool _isJumpQueued;

        public bool IsJumpHeld { get; set; }

        public void ApplyJumpInput()
        {
            _timeSinceJumpAttempt = 0;
            _isJumpQueued = true;
        }

        private void Update()
        {
            _timeSinceJumpAttempt += Time.deltaTime;

            if (_isJumpQueued && _timeSinceJumpAttempt <= settings.jumpBufferDuration)
            {
                TryJump();
            }
        }

        private void TryJump()
        {
            if (groundCheck.TryGetGround(out GroundData3d groundData))
            {
                body.velocity = groundData.Normal * settings.jumpSpeed;
                _isJumpQueued = false;
            }
        }
    }
}
