using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Simon : MonoBehaviour {

    public GameObject ledRouge;
    public GameObject ledBleue;
    public GameObject ledJaune;
    public GameObject ledVerte;

    public GameObject endedLed;

    public int number;
    public int indexTry;
    public GameObject[] colors;
    public GameObject[] buttons;
    public ButtonSimon.ButtonColor[] colorsToEnter;

    public float timeToShow;
    public float timeShowing;

    public enum Phases
    {
        showing,
        waiting,
        ended,
    }

    public Phases currentPhase;

    public GameObject theBomb;

    int numberIteration = 6;

	// Use this for initialization
	void Start () 
    {
        colorsToEnter = new ButtonSimon.ButtonColor[numberIteration];
        colors = new GameObject[numberIteration];
        currentPhase = Phases.showing;
        number = 1;
        indexTry = 0;
        RandomizeLeds();
        timeToShow = 0f;
        timeShowing = 5f;
        StartCoroutine(ShowColor());
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(currentPhase == Phases.waiting)
        {
            timeToShow += Time.deltaTime;
            if(timeToShow > timeShowing)
            {
                currentPhase = Phases.showing;
                ActivateButtons(false);
                StartCoroutine(ShowColor());
            }
        }
	}

    void RandomizeLeds()
    {
        for (int i = 0; i < colorsToEnter.Length; ++i )
        {
            int rand = Random.Range(0, 4);
            if (rand == 0)
            {
                colorsToEnter[i] = ButtonSimon.ButtonColor.blue;
                colors[i] = ledBleue;
            }
            else if (rand == 1)
            {
                colorsToEnter[i] = ButtonSimon.ButtonColor.red;
                colors[i] = ledRouge;
            }
            else if (rand == 2)
            {
                colorsToEnter[i] = ButtonSimon.ButtonColor.yellow;
                colors[i] = ledJaune;
            }
            else if (rand == 3)
            {
                colorsToEnter[i] = ButtonSimon.ButtonColor.green;
                colors[i] = ledVerte;
            }
        }
    }

    void ActivateButtons(bool state)
    {
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<ButtonSimon>().SetActivate(state);
        }
    }

    public void ReceiveInput(ButtonSimon.ButtonColor color)
    {
        if (currentPhase == Phases.waiting)
        {
            if (colorsToEnter[indexTry] == color)
            {
                indexTry++;
                timeToShow = 0f;
                if (indexTry == number)
                {
                    number++;
                    if (number == numberIteration + 1)
                    {
                        currentPhase = Phases.ended;
                        endedLed.GetComponent<Image>().color = new Color(1f, 1f, 0f);
                        theBomb.GetComponent<Bomb>().FinishedSimon();
                        return;
                    }
                    else
                    {
                        indexTry = 0;
                        currentPhase = Phases.showing;
                        StartCoroutine(ShowColor());
                    }
                }
            }
            else
            {
                theBomb.GetComponent<Bomb>().AddError();
            }
        }
    }

    IEnumerator ShowColor()
    {
        yield return new WaitForSeconds(1);
        for(int toShow = 0; toShow < number; ++toShow)
        {
            colors[toShow].GetComponent<LedSimon>().Light();
            yield return new WaitForSeconds(.5f);
            colors[toShow].GetComponent<LedSimon>().UnLight();
            yield return new WaitForSeconds(0.1f);
        }
        timeToShow = 0f;
        indexTry = 0;
        currentPhase = Phases.waiting;
        ActivateButtons(true);
    }
}
