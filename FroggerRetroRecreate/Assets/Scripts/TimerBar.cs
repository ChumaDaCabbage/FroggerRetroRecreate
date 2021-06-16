using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    public GameObject timerBar;
    public FrogDie fd;

    Image bI;
    Slider s;

    // Start is called before the first frame update
    void Start()
    {
        s = gameObject.GetComponent<Slider>();
        bI = timerBar.GetComponent<Image>();

        StartCoroutine(sliderDown());
    }

    // Update is called once per frame
    void Update()
    {
        if (s.value <= 0.1525)
        {
            bI.color = new Color(0.5058824f, 0.2745098f, 0.09411766f);
        }
        else
        {
            bI.color = Color.black;
        }
    }

    private IEnumerator sliderDown()
    {
        while (fd.lives > 0)
        {
            yield return new WaitForSeconds(1);
            s.value -= 0.025f;

            if (s.value <= 0)
            {
                fd.startDeath();
                yield return new WaitForSeconds(1.5f);
                s.value = 1;
            }
        }
    }
}
