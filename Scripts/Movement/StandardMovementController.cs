using UnityEngine;

namespace pt_player_3d.Scripts.Movement
{
    public class StandardMovementController : MovementController
    {
        [SerializeField] private Transform yawTransform;
        [SerializeField] private Rigidbody body;
        [SerializeField] private StandardMovementSettings settings;

        public override void ApplyInput(Vector3 direction)
        {
            Vector3 velocity = yawTransform.localToWorldMatrix.MultiplyVector(direction * settings.speed);
            velocity.y = body.velocity.y;
            body.velocity = velocity;
        }
    }
}
