using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{

    Slider s;

    // Start is called before the first frame update
    void Start()
    {
        s = gameObject.GetComponent<Slider>();

        StartCoroutine(sliderDown());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator sliderDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            s.value -= 0.025f;

            if (s.value <= 0.15)
            {

            }
            else
            { 
            
            }
        }
    }
}
