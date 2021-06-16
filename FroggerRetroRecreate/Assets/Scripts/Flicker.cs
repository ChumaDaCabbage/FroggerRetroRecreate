using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{

    public bool isFrog = false;

    public Transform frog;
    public Transform whiteFrog;

    Color transparent;
    Color defualtC;

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();

        defualtC = sr.color;
        transparent = sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f); ;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFrog)
        {
            if (transform.position.y > -3)
            {
                sr.color = transparent;
            }
            else
            {
                sr.color = defualtC;
            }
        }
        else
        {

            Debug.Log(Mathf.Round(frog.position.y * 100f) / 100f + " == " + Mathf.Round(transform.position.y * 100f) / 100f);

            if (Mathf.Round(frog.position.y * 100f) / 100f == Mathf.Round(transform.position.y * 100f) / 100f) //||
                    //(Mathf.Round(whiteFrog.position.y) * 100f) / 100f == (Mathf.Round(transform.position.y) * 100f) / 100f)
            {
                sr.color = transparent;
            }
            else
            {
                sr.color = defualtC;
            }
        }
    }
}

