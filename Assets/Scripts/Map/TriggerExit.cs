using System.Collections;
using UnityEngine;

namespace Map
{
    public class TriggerExit : MonoBehaviour
    {
        public float delay = 5f;
    
        public delegate void ExitAction();
        public static event ExitAction OnChunkExited;

        [SerializeField] private bool exited = false;

        private void OnTriggerExit(Collider other)
        {
            CharacterController characterController = other.GetComponent<CharacterController>();
            if (characterController != null)
            {
                if (!exited)
                {
                    exited = true;
                    OnChunkExited();
                    StartCoroutine(WaitAndDeactivate());
                }
            }
        }

        IEnumerator WaitAndDeactivate()
        {
            // yield return new WaitForSeconds(0.15f);
            // OnChunkExited();
            yield return new WaitForSeconds(delay);

            Destroy(transform.root.gameObject);

        }
    }
}
