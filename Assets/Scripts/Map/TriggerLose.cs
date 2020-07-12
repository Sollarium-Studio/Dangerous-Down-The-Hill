using UnityEngine;

namespace Map
{
    public class TriggerLose : MonoBehaviour
    {
        [SerializeField] private bool exited = false;
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
                GameController.instance.GameOver();
        }
    }
}
