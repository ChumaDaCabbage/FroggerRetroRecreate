using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMove : MonoBehaviour
{
    [HideInInspector]
    public bool mounted = false;

    GameObject frog;
    public GameObject frogCatch;
    public float offscreenOffset = 8.5f;
    public bool left = true;
    public float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        frog = GameObject.Find("Frog");

        StartCoroutine(move());
    }

    public IEnumerator move()
    {
        while (true)
        {
            if (FrogDie.dead == true)
            {
                mounted = false;
            }

            if (left)
            {
                transform.position += new Vector3(-0.08349f, 0, 0);
                if (transform.position.x < -offscreenOffset)
                {
                    GameObject catcher = null;
                    if (mounted)
                    {
                        catcher = Instantiate(frogCatch, new Vector3(offscreenOffset, transform.position.y, transform.position.z), Quaternion.identity);
                        Destroy(catcher, 0.1f);

                        float difference = frog.transform.position.x - transform.position.x;
                        Debug.Log(difference);
                        frog.transform.position = new Vector3(offscreenOffset + (difference), transform.position.y, transform.position.z);
                    }
                    transform.position = new Vector3(offscreenOffset, transform.position.y, transform.position.z);
                }

                for (int i = 0; i < speed; i++)
                {
                    yield return new WaitForFixedUpdate();
                }
            }
            else if (!left)
            {
                transform.position += new Vector3(0.08349f, 0, 0);
                if (transform.position.x > offscreenOffset)
                {
                    GameObject catcher = null;
                    if (mounted)
                    {
                        catcher = Instantiate(frogCatch, new Vector3(-offscreenOffset, transform.position.y, transform.position.z), Quaternion.identity);
                        Destroy(catcher, 0.1f);
                        frog.transform.position = new Vector3(-offscreenOffset, transform.position.y, transform.position.z);
                    }
                    transform.position = new Vector3(-offscreenOffset, transform.position.y, transform.position.z);
                }

                for (int i = 0; i < speed; i++)
                {
                    yield return new WaitForFixedUpdate();
                }
            }
        }
    }
}
