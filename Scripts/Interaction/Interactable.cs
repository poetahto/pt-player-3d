using UnityEngine;
using UnityEngine.Events;

namespace pt_player_3d.Scripts.Interaction
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField]
        private bool debugInteractions;

        [SerializeField]
        private float maxDistance = 3;

        public UnityEvent onInteract;

        public virtual bool CanInteract(GameObject source)
        {
            return (source.transform.position - transform.position).sqrMagnitude < maxDistance * maxDistance;
        }

        public virtual void Interact()
        {
            if (debugInteractions)
            {
                Debug.Log($"{name} was interacted with.");
            }

            onInteract.Invoke();
        }
    }
}
