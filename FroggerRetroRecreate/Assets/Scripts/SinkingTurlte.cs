using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkingTurlte : MonoBehaviour
{

    float timeBetween = 5;

    //1 == up
    //2 == going down
    //3 == down
    //4 == goin up
    public int state = 2;

    public Sprite sinkingTurtle;
    Sprite defualtS;

    BoxCollider2D bc2d;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        bc2d = gameObject.GetComponent<BoxCollider2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();

        defualtS = sr.sprite;
        sr.sprite = sinkingTurtle;

        StartCoroutine(sinkers());
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case 1:
                sr.sprite = defualtS;
                bc2d.enabled = true;
                break;
            case 2:
                sr.sprite = sinkingTurtle;
                bc2d.enabled = true;
                break;
            case 3:
                sr.enabled = false;
                bc2d.enabled = false;
                break;
            case 4:
                sr.sprite = sinkingTurtle;
                sr.enabled = true;
                bc2d.enabled = true;
                break;
        }
    }

    private IEnumerator sinkers()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetween);

            if (state == 4)
            {
                state = 1;
            }
            else
            {
                state++;
            }
        }
    }
}
