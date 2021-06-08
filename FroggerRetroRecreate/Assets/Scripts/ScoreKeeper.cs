using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    [HideInInspector]
    public static int score = 0;

    Text t;

    // Start is called before the first frame update
    void Start()
    {
        t = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        t.text = score.ToString();
    }

    public static void addScore(int amount)
    {
        score += amount;
    }
}
