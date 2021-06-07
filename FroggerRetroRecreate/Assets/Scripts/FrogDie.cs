using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogDie : MonoBehaviour
{

    public Sprite frogDeath;
    public Sprite defualtSprite;

    public GameObject[] livesBar = new GameObject[4];

    int lives = 5;

    Vector3 startPos;

    SpriteRenderer sr;
    FrogMove fm;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        fm = gameObject.GetComponent<FrogMove>();

        startPos = transform.position;
    }

    public void startDeath()
    {
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
            transform.position = startPos;
            sr.sprite = defualtSprite;
            fm.enabled = true;
        }
        else
        {
            sr.enabled = false;
        }
    }
}
