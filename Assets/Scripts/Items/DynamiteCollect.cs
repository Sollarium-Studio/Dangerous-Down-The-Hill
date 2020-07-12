using UnityEngine;

namespace Items
{
    public class DynamiteCollect : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GameController.instance.AddDynamite();
                Destroy(gameObject);
            }
        }
    }
}