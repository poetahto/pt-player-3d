using poetools.Core.Abstraction;
using UnityEngine;

namespace pt_player_3d.Scripts.Movement
{
    public class StandardMovementSystem : MonoBehaviour, IMovementSystem
    {
        [SerializeField]
        private Transform yawTransform;

        public bool autoUpdate = true;
        public PhysicsComponent body;
        public StandardMovementSettings settings;

        private Vector3 _targetDirection;

        public void ApplyMovementInput(Vector3 direction)
        {
            _targetDirection = yawTransform.localToWorldMatrix.MultiplyVector(direction);
        }

        public void ApplyMovementInput(Vector3 direction, float yaw)
        {
            _targetDirection = Quaternion.Euler(0, yaw, 0) * direction;
        }

        private void FixedUpdate()
        {
            if (autoUpdate)
                Tick(Time.deltaTime);
        }

        public void Tick(float deltaTime)
        {
            if (deltaTime <= 0)
                deltaTime = Time.deltaTime;

            Vector3 targetVelocity = _targetDirection * settings.speed;

            if (_targetDirection != Vector3.zero)
                Accelerate(deltaTime, targetVelocity);

            else Decelerate(deltaTime, targetVelocity);
        }

        private void Accelerate(float deltaTime, Vector3 targetVelocity)
        {
            Vector3 velocity = Vector3.MoveTowards(body.Velocity, targetVelocity, settings.acceleration * deltaTime);
            velocity.y = body.Velocity.y;
            body.Velocity = velocity;
        }

        private void Decelerate(float deltaTime, Vector3 targetVelocity)
        {
            Vector3 velocity = Vector3.Lerp(body.Velocity, targetVelocity, settings.decceleration * deltaTime);
            velocity.y = body.Velocity.y;
            body.Velocity = velocity;
        }
    }
}
