using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMove : MonoBehaviour
{

    public Sprite turnedFrog;
    Sprite defualtFrog;

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();

        defualtFrog = sr.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            sr.sprite = defualtFrog;
            sr.flipY = false;
            transform.position += new Vector3(0, 0.6625512f, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            sr.sprite = defualtFrog;
            sr.flipY = true;
            transform.position += new Vector3(0, -0.6625512f, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            sr.sprite = turnedFrog;
            sr.flipX = true;
            transform.position += new Vector3(-0.88888888888f, 0, 0);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            sr.sprite = turnedFrog;
            sr.flipX = false;
            transform.position += new Vector3(0.88888888888f, 0, 0);
        }
    }
}
