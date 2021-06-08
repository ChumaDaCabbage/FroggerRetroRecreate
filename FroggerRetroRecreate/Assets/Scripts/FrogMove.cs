using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMove : MonoBehaviour
{
    public Sprite turnedFrog;
    Sprite defualtFrog;

    [HideInInspector]
    public float highestPos;

    SpriteRenderer sr;
    FrogDie fd;
    WinFrog wf;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        fd = gameObject.GetComponent<FrogDie>();
        wf = gameObject.GetComponent<WinFrog>();

        defualtFrog = sr.sprite;
        highestPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 0.6625512f);
            Debug.DrawRay(transform.position, transform.up, Color.white, 10);
            if (hit == false || hit.transform.tag == "Death")
            {
                transform.position += new Vector3(0, 0.6625512f, 0);

                if (transform.position.y > highestPos)
                {
                    ScoreKeeper.addScore(1);
                    highestPos = transform.position.y;
                }
            }

            if (hit != false && hit.transform.tag == "Win")
            {
                wf.frogWin();
            }
            else if (hit != false && hit.transform.tag == "DeathWall")
            {
                fd.startDeath();
            }
            else
            {
                sr.sprite = defualtFrog;
                sr.flipY = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 0.6625512f);
            Debug.DrawRay(transform.position, -transform.up, Color.white, 10);
            if (hit == false || hit.transform.tag == "Death")
            {
                transform.position += new Vector3(0, -0.6625512f, 0);
            }

            if (hit != false && hit.transform.tag == "DeathWall")
            {
                fd.startDeath();
            }
            else
            {
                sr.sprite = defualtFrog;
                sr.flipY = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.right, 0.88888888888f);
            Debug.DrawRay(transform.position, -transform.right, Color.white, 10);
            if (hit == false || hit.transform.tag == "Death")
            {
                transform.position += new Vector3(-0.88888888888f, 0, 0);
            }

            if (hit != false && hit.transform.tag == "DeathWall")
            {
                fd.startDeath();
            }
            else
            {
                sr.sprite = turnedFrog;
                sr.flipX = true;
            }
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 0.88888888888f);
            Debug.DrawRay(transform.position, transform.right, Color.white, 10);
            if (hit == false || hit.transform.tag == "Death")
            {
                transform.position += new Vector3(0.88888888888f, 0, 0);
            }

            if (hit != false && hit.transform.tag == "DeathWall")
            {
                fd.startDeath();
            }
            else
            {
                sr.sprite = turnedFrog;
                sr.flipX = false;
            }
        }
    }
}
