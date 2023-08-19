using System;
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
        private GameObject jumpingSystem;

        private IJumpingSystem _system;

        private void Awake()
        {
            _system = jumpingSystem.GetComponent<IJumpingSystem>();
        }

        private void OnDisable()
        {
            _system.IsJumpHeld = false;
        }

        private void Update()
        {
            _system.IsJumpHeld =
                (holdToJump && Input.GetKey(jumpKey)) ||
                Input.GetKeyDown(jumpKey) ||
                (scrollToJump && Input.GetAxisRaw("Mouse ScrollWheel") != 0);
        }
    }
}
