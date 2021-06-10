using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogWaterFollow : MonoBehaviour
{
    [HideInInspector]
    public static bool sameMount = false;

    bool left;
    float speed;


    Coroutine coroutine;
    bool CR_running = false;

    public static WaterMove wm = null;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 1f)
        {
            if (!sameMount)
            {
                RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + 0.3304425f, transform.position.y), Vector2.up, 0.01f);
                RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(transform.position.x - 0.3304425f, transform.position.y), Vector2.up, 0.01f);

                Transform mount = null;

                if (hit != false)
                {
                    mount = hit.transform;
                }
                else if (hit2 != false)
                {
                    mount = hit2.transform;
                }

                if (mount != null)
                {                 
                    sameMount = true;

                    wm = mount.GetComponent<WaterMove>();

                    wm.mounted = true;

                    left = wm.left;
                    speed = wm.speed;

                    if (CR_running)
                    {
                        StopCoroutine(coroutine);
                        CR_running = false;
                    }

                    coroutine = StartCoroutine(slide());
                }
            }
        }
    }

    public IEnumerator slide()
    {
        CR_running = true;
        while (transform.position.y > 1f && !FrogDie.dead)
        {
            if (left)
            {
                transform.position += new Vector3(-0.08349f, 0, 0);

                for (int i = 0; i < speed; i++)
                {
                    yield return new WaitForFixedUpdate();
                }
            }   
            else if (!left)
            {
                transform.position += new Vector3(0.08349f, 0, 0);

                for (int i = 0; i < speed; i++)
                {
                    yield return new WaitForFixedUpdate();
                }
            }
        }
        CR_running = false;
    }
}
