using UnityEngine;

namespace Map
{
    public class TriggerLose : MonoBehaviour
    {
        [SerializeField] private bool exited = false;
        private void OnTriggerExit(Collider other)
        {
            CharacterController characterController = other.GetComponent<CharacterController>();
            if (characterController != null)
            {
                if (!exited)
                {
                    exited = true;
                    
                }
            }
        }
    }
}
