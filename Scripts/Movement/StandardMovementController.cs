using System;
using poetools.Core.Abstraction;
using UnityEngine;

namespace pt_player_3d.Scripts.Movement
{
    public class StandardMovementController : MovementController
    {
        [SerializeField] private Transform yawTransform;
        public PhysicsComponent body;
        public StandardMovementSettings settings;

        private Vector3 _targetVelocity;

        public override void ApplyInput(Vector3 direction)
        {
            _targetVelocity = yawTransform.localToWorldMatrix.MultiplyVector(direction * settings.speed);
        }

        private void Update()
        {
            if (_targetVelocity != Vector3.zero)
                Accelerate();

            else Decelerate();
        }

        private void Accelerate()
        {
            Vector3 velocity = Vector3.MoveTowards(body.Velocity, _targetVelocity, settings.acceleration * Time.deltaTime);
            velocity.y = body.Velocity.y;
            body.Velocity = velocity;
        }

        private void Decelerate()
        {
            Vector3 velocity = Vector3.Lerp(body.Velocity, _targetVelocity, settings.decceleration * Time.deltaTime);
            velocity.y = body.Velocity.y;
            body.Velocity = velocity;
        }
    }
}
