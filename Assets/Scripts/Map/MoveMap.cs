using UnityEngine;

public class MoveMap : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        transform.Translate(Vector3.up * (speed * Time.deltaTime));
    }
}