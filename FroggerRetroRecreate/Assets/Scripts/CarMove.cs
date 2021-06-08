using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float offscreenOffset = 8.5f;
    public float direction= 1;
    public float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(move());
    }

    public IEnumerator move()
    {
        while (true)
        {
            transform.position += new Vector3(0.08349f * direction, 0, 0);
            if (transform.position.x > offscreenOffset || transform.position.x < -offscreenOffset)
            {
                transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
            }

            for (int i = 0; i < speed; i++)
            {
                yield return new WaitForFixedUpdate();
            }
        }
    }
}
