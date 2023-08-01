using UnityEngine;

namespace pt_player_3d.Scripts
{
    public class CursorHider : MonoBehaviour
    {
        private void OnEnable()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void OnDisable()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
