using System;
using poetools.Core.Abstraction;
using UnityEngine;
using UnityEngine.Events;

namespace pt_player_3d.Scripts
{
    public class JumpingSystem : MonoBehaviour, IJumpingSystem
    {
        [SerializeField]
        [Tooltip("The ground check used to determining if the object can jump, and the jump direction.")]
        private GroundCheck3d groundCheck;

        [SerializeField]
        [Tooltip("The body that the jump velocity should be applied to.")]
        private PhysicsComponent body;

        [SerializeField]
        [Tooltip("The settings used to control the characteristics of the jump.")]
        private JumpingSettings settings;

        public UnityEvent<JumpEvent> onJump = new UnityEvent<JumpEvent>();

        private float _timeSinceJumpAttempt;
        private bool _isJumpQueued;
        private bool _isCoyoteAvailable;
        private bool _isJumping;
        private bool _isJumpHeld;
        private bool _wasJumpHeld;

        public bool IsJumpHeld { get; set; }
        public float TimeSpentInAir { get; private set; }
        public float TimeSpentOnGround { get; private set; }

        private void OnEnable()
        {
            groundCheck.onGroundLand.AddListener(HandleLand);
        }

        private void OnDisable()
        {
            groundCheck.onGroundLand.RemoveListener(HandleLand);
        }

        private void HandleLand(GroundCheck3d.OnGroundLandEvent eventData)
        {
            TimeSpentInAir = 0;
            _isCoyoteAvailable = true;
            _isJumping = false;
        }

        private void Update()
        {
            if (IsJumpHeld)
                _isJumpHeld = true;
        }

        private void FixedUpdate()
        {
            // Check if player just pressed the jump button.
            if (!_wasJumpHeld && _isJumpHeld)
            {
                _timeSinceJumpAttempt = 0;
                _isJumpQueued = true;
            }

            // Updating timing information.
            _timeSinceJumpAttempt += Time.deltaTime;

            if (!groundCheck.IsGrounded)
                TimeSpentInAir += Time.deltaTime;

            else TimeSpentOnGround += Time.deltaTime;

            // This is to catch the case where you hit head on ceiling and never receive an "on land" callback.
            if (_isJumping && TimeSpentOnGround > Time.fixedDeltaTime)
            {
                HandleLand(default);
            }

            if (!_isJumping && _isJumpQueued && _timeSinceJumpAttempt <= settings.jumpBufferDuration)
                TryJump();

            _wasJumpHeld = _isJumpHeld;
            _isJumpHeld = false;
        }

        private void TryJump()
        {
            if (groundCheck.IsGrounded || (_isCoyoteAvailable && TimeSpentInAir <= settings.coyoteTime))
            {
                JumpEvent eventData = new JumpEvent();
                eventData.HasGround = groundCheck.TryGetGround(out eventData.Ground);
                eventData.IsCoyote = !groundCheck.IsGrounded;
                Vector3 normal = Vector3.up;
                eventData.Velocity = normal * settings.jumpSpeed;
                Vector3 curVel = body.Velocity;
                curVel.y = eventData.Velocity.y;
                body.Velocity = curVel;
                _isJumpQueued = false;
                _isCoyoteAvailable = false;
                _isJumping = true;
                TimeSpentOnGround = 0;
                onJump.Invoke(eventData);
            }
        }

        public struct JumpEvent
        {
            public bool IsCoyote;
            public GroundData3d Ground;
            public bool HasGround;
            public Vector3 Velocity;
        }
    }
}
