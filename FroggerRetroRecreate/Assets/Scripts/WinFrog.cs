using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFrog : MonoBehaviour
{

    Vector3 startPos;
    public Sprite defualtSprite;

    public GameObject[] winFrogs = new GameObject[5];
    public GameObject[] fireFlys = new GameObject[5];

    float timer = 15;
    bool spawned = false;

    SpriteRenderer sr;
    FrogMove fm;
    public SpriteRenderer[] wfSR = new SpriteRenderer[5];

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        fm = gameObject.GetComponent<FrogMove>();

        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (!spawned)
        {
            bool[] locations = new bool[winFrogs.Length];

            for (int i = 0; i < winFrogs.Length; i++)
            {
                if (winFrogs[i].transform.tag == "Wall")
                {
                    locations[i] = false;
                }
                else
                {
                    locations[i] = true;
                }
            }

            int random = Random.Range(0, locations.Length);
            for (int i = 0; i < locations.Length; i++)
            {
                if (i == locations.Length - 1)
                {
                    fireFlys[i].SetActive(true);
                }
                else if (locations[i])
                {
                    if (random == i)
                    {
                        fireFlys[i].SetActive(true);
                        break;
                    }
                }
            }

            spawned = true;
            timer = 4;
        }
        else if (spawned)
        {
            for (int i = 0; i < fireFlys.Length; i++)
            {
                fireFlys[i].SetActive(false);
            }

            spawned = false;
            timer = 15;
        }
    }

    public void frogWin()
    {
        Vector3 distance = winFrogs[0].transform.position - transform.position;
        int wantedPos = 0;
        for (int i = 1; i < winFrogs.Length; i++)
        { 
            if((winFrogs[i].transform.position - transform.position).magnitude < distance.magnitude)
            {
                distance = winFrogs[i].transform.position - transform.position;
                wantedPos = i;
            }
        }

        wfSR[wantedPos].enabled = true;
        winFrogs[wantedPos].transform.tag = "Wall";

        if (fireFlys[wantedPos].activeInHierarchy)
        {
            ScoreKeeper.addScore(50);
            fireFlys[wantedPos].SetActive(false);
        }

        bool done = true;
        for (int i = 0; i < winFrogs.Length; i++)
        {
            if (winFrogs[i].transform.tag == "Win")
            {
                done = false;
                break;
            }
        }

        if (done)
        {
            ScoreKeeper.addScore(Random.Range(14, 51) + 100);

            sr.enabled = false;
            fm.enabled = false;
            StartCoroutine(winAllPause());
        }
        else
        {
            ScoreKeeper.addScore(Random.Range(14, 51));
            transform.position = startPos;
            sr.flipY = false;
            sr.flipX = false;
            sr.sprite = defualtSprite;
            fm.highestPos = transform.position.y;
        }
    }

    public IEnumerator winAllPause()
    {
        yield return new WaitForSeconds(6.5f);

        for (int i = 0; i < winFrogs.Length; i++)
        {
            wfSR[i].enabled = false;
            winFrogs[i].transform.tag = "Win";
        }

        transform.position = startPos;
        sr.enabled = true;
        sr.flipY = false;
        sr.flipX = false;
        sr.sprite = defualtSprite;
        fm.enabled = true;
        fm.highestPos = transform.position.y;
    }
}
