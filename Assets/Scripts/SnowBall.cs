using UnityEngine;

public class SnowBall : MonoBehaviour
{
    [SerializeField] private float size;
    [SerializeField] private float speed;
    [SerializeField] private float posY;
    [SerializeField] private float count;
    [SerializeField] private float waitTime;

    private void Start()
    {
        posY = transform.position.y;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        count += Time.deltaTime;
        if (count >= waitTime)
        {
            count = 0.0f;
            transform.localScale = transform.localScale + new Vector3(1f, 1f, 1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            GameController.instance.GameOver();
        if (other.CompareTag("Dynamite"))
        {
            var go = other.gameObject;
            Destroy(go);
            transform.localScale = new Vector3(100f, 100f, 100f);
        }
    }
}