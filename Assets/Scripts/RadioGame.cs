using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RadioGame : MonoBehaviour {

    public GameObject theLed;
    public GameObject endedLed;
    public GameObject theBomb;

    int numberB1 = 0;
    int numberB2 = 0;

    int numberToReach1 = 0;
    int numberToReach2 = 0;

    float diff = 1;

    int step = 1;
    bool finished = false;

	// Use this for initialization
	void Start ()
    {
        numberToReach1 = Random.Range(0, 11);
        numberToReach2 = Random.Range(0, 11);
        Debug.Log("n1:" + numberToReach1 + " n2:" + numberToReach2);
    }

    public void ModifyNumberButon(int num, int n)
    {
        if (!finished)
        {
            if (num == 1)
                numberB1 = n;
            else if (num == 2)
                numberB2 = n;

            diff = Mathf.Abs(numberToReach1 - numberB1) + Mathf.Abs(numberToReach2 - numberB2);
            theLed.GetComponent<RadioLed>().SetDelayToLight(diff/10f);
        }
    }

    void ActualiseLed()
    {
        diff = Mathf.Abs(numberToReach1 - numberB1) + Mathf.Abs(numberToReach2 - numberB2);
        Debug.Log("diff:" + diff);
        theLed.GetComponent<RadioLed>().SetDelayToLight(diff/10f);
    }

    public void OnClick()
    {
        if (!finished)
        {
            if (diff <= .09f)
            {
                if (step == 3)
                {
                    finished = true;
                    endedLed.GetComponent<Image>().color = new Color(1f, 1f, 0f);
                    theBomb.GetComponent<Bomb>().FinishedRadio();
                }
                else
                {
                    step++;
                    numberToReach1 = Random.Range(0, 11);
                    numberToReach2 = Random.Range(0, 11);
                    Debug.Log("n1:" + numberToReach1 + " n2:" + numberToReach2);
                    ActualiseLed();
                }
            }
            else
            {
                theBomb.GetComponent<Bomb>().AddError();
            }
        }
    }
}
