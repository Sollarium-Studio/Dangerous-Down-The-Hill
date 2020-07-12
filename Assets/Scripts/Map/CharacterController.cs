using System;
using UnityEngine;

namespace Map
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private float side;
        [SerializeField] private float speed;
        [SerializeField] private bool goRight;
        [SerializeField] private bool controlIsActive = true;
        private void Update()
        {
            transform.Translate(Vector3.up * (-speed * Time.deltaTime));
            if (controlIsActive)
            {
                if (Input.GetMouseButton(0))
                {
                    if (goRight)
                    {
                        transform.Translate(Vector3.right * side * Time.deltaTime);
                    }
                    else
                    {
                        transform.Translate(-Vector3.right * side * Time.deltaTime);
                    }
                }

                if (Input.GetMouseButtonUp(0))
                {
                    if (goRight)
                        goRight = false;
                    else
                        goRight = true;
                }
            }
        }
    }
}
