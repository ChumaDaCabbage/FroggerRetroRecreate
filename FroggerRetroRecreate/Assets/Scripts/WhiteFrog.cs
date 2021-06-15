using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteFrog : MonoBehaviour
{
    //[HideInInspector]
    public int times = 1;

    public float jumpTime;

    Vector3 startPos;
    public int states = 1;
    public bool left = false;

    SpriteRenderer sr;
    BoxCollider2D bc2D;
    WaterMove wm;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        bc2D = gameObject.GetComponent<BoxCollider2D>();
        wm = gameObject.GetComponent<WaterMove>();

        startPos = transform.position;

        StartCoroutine(move());
    }

    // Update is called once per frame
    void Update()
    {
        if (wm.jumped && times > 0)
        {
            times--;
            wm.jumped = false;
        }
        else if (wm.jumped)
        {
            times++;
            wm.jumped = false;
        }

        if (times == 0)
        {
            if(sr.enabled == false)
            {
                StartCoroutine(wait());
            }
        }
        else
        {
            sr.enabled = false;
            bc2D.enabled = false;
        }
    }

    public void frogHit()
    {
        sr.enabled = false;
        if (times < 4)
        {
            times = 4;
        }
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
        sr.enabled = true;
        bc2D.enabled = true;
    }


    private IEnumerator move()
    {
        while (true)
        {
            if (times == 0)
            {
                yield return new WaitForSeconds(jumpTime);

                if (states < 3 && !left)
                {
                    transform.position += new Vector3(0.88888888888f + 0.08349f, 0, 0);
                    states++;
                }
                else if (states == 3 && !left)
                {
                    left = true;
                }

                if (states > 1 && left)
                {
                    transform.position += new Vector3(-0.88888888888f - 0.08349f, 0, 0);
                    states--;
                }
            }
            else
            {
                left = false;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
