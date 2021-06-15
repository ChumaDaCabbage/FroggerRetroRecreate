using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogDie : MonoBehaviour
{

    public Sprite frogDeath;
    public Sprite defualtSprite;

    public GameObject[] livesBar = new GameObject[4];

    int lives = 5;
    bool stopped = false;

    public static bool dead = false;

    public LayerMask LayerMask;
    public LayerMask frogMask;

    Vector3 startPos;

    SpriteRenderer sr;
    FrogMove fm;
    public WhiteFrog whf;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        fm = gameObject.GetComponent<FrogMove>();

        startPos = transform.position;
    }

    private void Update()
    {
        if (transform.position.y < 1.207858f)
        {
            if (!stopped)
            {
                RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + 0.3304425f, transform.position.y), Vector2.up, 0.01f);
                RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(transform.position.x - 0.3304425f, transform.position.y), Vector2.up, 0.01f);
                if (hit != false)
                {
                    if (hit.transform.tag == "Death")
                    {
                        stopped = true;
                        startDeath();
                    }
                }
                else if (hit2 != false)
                {
                    if (hit2.transform.tag == "Death")
                    {
                        stopped = true;
                        startDeath();
                    }
                }
            }
        }
        else
        {
            if (!stopped)
            {
                RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + 0.3304425f, transform.position.y), Vector2.up, 0.01f, LayerMask);
                RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(transform.position.x - 0.3304425f, transform.position.y), Vector2.up, 0.01f, LayerMask);
              
                RaycastHit2D frogHit = Physics2D.Raycast(transform.position, transform.up, 0.6625512f, frogMask);
                RaycastHit2D frogHit2 = Physics2D.Raycast(transform.position, transform.up, 0.6625512f, frogMask);
                if (frogHit != false || frogHit2 != false)
                {
                    whf.frogHit();
                }


                if (hit == false && hit2 == false)
                {
                    stopped = true;
                    startDeath();
                }
            }
        }
    }

    public void startDeath()
    {
        dead = true;

        lives--;
        if (lives != 0)
        {
            livesBar[lives - 1].SetActive(false);
        }

        fm.enabled = false;
        sr.flipY = false;
        sr.flipX = false;
        sr.sprite = frogDeath;
        StartCoroutine(deathPause());
    }

    public IEnumerator deathPause()
    {
        yield return new WaitForSeconds(1.5f);

        if (lives > 0)
        {
            dead = false;
            transform.position = startPos;
            sr.sprite = defualtSprite;
            fm.enabled = true;
            fm.highestPos = transform.position.y;
            stopped = false;
        }
        else
        {
            sr.enabled = false;
        }
    }

}
