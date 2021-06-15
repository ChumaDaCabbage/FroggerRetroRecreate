using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMove : MonoBehaviour
{
    public Sprite turnedFrog;
    Sprite defualtFrog;

    public LayerMask layerMask;
    public LayerMask frogMask;

    [HideInInspector]
    public float highestPos;

    public WhiteFrog whf;

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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            FrogWaterFollow.sameMount = false;
            if (FrogWaterFollow.wm != null)
                FrogWaterFollow.wm.mounted = false;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 0.6625512f);
            RaycastHit2D wallHit = Physics2D.Raycast(transform.position, transform.up, 0.6625512f, layerMask);
            RaycastHit2D frogHit = Physics2D.Raycast(transform.position, transform.up, 0.6625512f, frogMask);
            Debug.DrawRay(transform.position, transform.up, Color.white, 10);
            if ((hit == false || hit.transform.tag == "Death" || hit.transform.tag == "WhiteFrog") && wallHit == false)
            {
                if (frogHit != false && frogHit.transform.tag == "WhiteFrog")
                {
                    whf.frogHit();
                }

                transform.position += new Vector3(0, 0.6625512f, 0);

                if (transform.position.y > highestPos)
                {
                    ScoreKeeper.addScore(1);
                    highestPos = transform.position.y;
                }
            }

            if (wallHit != false && wallHit.transform.tag == "Win")
            {
                wf.frogWin();
            }
            else if (hit != false && wallHit != false && wallHit.transform.tag == "DeathWall")
            {
                fd.startDeath();
            }
            else
            {
                sr.sprite = defualtFrog;
                sr.flipY = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            FrogWaterFollow.sameMount = false;
            if(FrogWaterFollow.wm != null)
                FrogWaterFollow.wm.mounted = false;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 0.6625512f);
            RaycastHit2D wallHit = Physics2D.Raycast(transform.position, -transform.up, 0.6625512f, layerMask);
            RaycastHit2D frogHit = Physics2D.Raycast(transform.position, -transform.up, 0.6625512f, frogMask);
            Debug.DrawRay(transform.position, -transform.up, Color.white, 10);
            if ((hit == false || hit.transform.tag == "Death" || hit.transform.tag == "WhiteFrog") && wallHit == false)
            {
                if (frogHit != false && frogHit.transform.tag == "WhiteFrog")
                {
                    whf.frogHit();
                }

                transform.position += new Vector3(0, -0.6625512f, 0);
            }

            if (hit != false && wallHit != false && wallHit.transform.tag == "DeathWall")
            {
                fd.startDeath();
            }
            else
            {
                sr.sprite = defualtFrog;
                sr.flipY = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            FrogWaterFollow.sameMount = false;
            if (FrogWaterFollow.wm != null)
                FrogWaterFollow.wm.mounted = false;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.right, 0.88888888888f);
            RaycastHit2D frogHit = Physics2D.Raycast(transform.position, -transform.right, 0.88888888888f, frogMask);
            Debug.DrawRay(transform.position, -transform.right, Color.white, 10);
            if (hit == false || hit.transform.tag == "Death" || hit.transform.tag == "WhiteFrog")
            {
                if (frogHit != false && frogHit.transform.tag == "WhiteFrog")
                {
                    whf.frogHit();
                }

                if (FrogWaterFollow.wm != null && transform.position.x - 0.88888888888f < -FrogWaterFollow.wm.offscreenOffset)
                {
                    transform.position = new Vector3(FrogWaterFollow.wm.offscreenOffset, transform.position.y, transform.position.z);
                }

                if (FrogWaterFollow.CR_running && FrogWaterFollow.wm != null)
                {
                    if (FrogWaterFollow.wm.left)
                    {
                        transform.position += new Vector3(-0.88888888888f + 0.08349f, 0, 0);
                    }
                    else
                    {
                        transform.position += new Vector3(-0.88888888888f - 0.08349f, 0, 0);
                    }
                }
                else
                {
                    transform.position += new Vector3(-0.88888888888f, 0, 0);
                }
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
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            FrogWaterFollow.sameMount = false;
            if (FrogWaterFollow.wm != null)
                FrogWaterFollow.wm.mounted = false;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 0.88888888888f);
            RaycastHit2D frogHit = Physics2D.Raycast(transform.position, transform.right, 0.88888888888f, frogMask);
            Debug.DrawRay(transform.position, transform.right, Color.white, 10);
            if (hit == false || hit.transform.tag == "Death" || hit.transform.tag == "WhiteFrog")
            {
                if (frogHit != false && frogHit.transform.tag == "WhiteFrog")
                {
                    whf.frogHit();
                }

                if (FrogWaterFollow.wm != null && transform.position.x + 0.88888888888f > FrogWaterFollow.wm.offscreenOffset)
                {
                    transform.position = new Vector3(-FrogWaterFollow.wm.offscreenOffset, transform.position.y, transform.position.z);
                }

                if (FrogWaterFollow.CR_running && FrogWaterFollow.wm != null)
                {
                    if (!FrogWaterFollow.wm.left)
                    {
                        transform.position += new Vector3(0.88888888888f - 0.08349f, 0, 0);
                    }
                    else
                    {
                        transform.position += new Vector3(0.88888888888f + 0.08349f, 0, 0);
                    }
                }
                else
                {
                    transform.position += new Vector3(0.88888888888f, 0, 0);
                }
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
