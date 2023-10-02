using UnityEngine;

namespace pt_player_3d.Scripts.Interaction
{
    public class InputInteractionController : MonoBehaviour
    {
        [SerializeField]
        private KeyCode interactKey = KeyCode.E;

        [SerializeField]
        private GameObject interactionSystem;

        private IInteractionSystem _interactionSystem;

        private void Awake()
        {
            _interactionSystem = interactionSystem.GetComponent<IInteractionSystem>();
        }

        private void Update()
        {
            _interactionSystem.IsInteractHeld = Input.GetKey(interactKey);
        }
    }
}
