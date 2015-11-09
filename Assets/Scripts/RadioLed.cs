using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RadioLed : MonoBehaviour {

    Image image;
    public Color colorBase;
    public Color colorLight;

    float timeToLight = 0;
    float delayToLight = 1;
    bool good = false;

    // Use this for initialization
    void Awake()
    {
        image = GetComponent<Image>();
        image.color = colorBase;
    }

    void Update()
    {
        if (!good)
        {
            timeToLight += Time.deltaTime;
            if (timeToLight >= 2.0f)
            {
                Activate();
                timeToLight = 0;
            }
        }
        else
        {
            Light();
        }
    }

    public void SetDelayToLight(float time)
    {
        delayToLight = time;
        Debug.Log("delay:" + delayToLight);
        if(delayToLight <= .01f)
        {
            Debug.Log("good");
            good = true;
            Light();
        }
        else if(good)
        {
            good = false;
        }
    }

    public void Light()
    {
        image.color = colorLight;
    }

    public void UnLight()
    {
        image.color = colorBase;
    }

    public void Activate()
    {
        StartCoroutine(Show());
    }

    IEnumerator Show()
    {
        Light();
        yield return new WaitForSeconds(delayToLight);
        UnLight();
    }
}
