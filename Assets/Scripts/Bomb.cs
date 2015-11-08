using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Bomb : MonoBehaviour {

    InputButton scriptButton1;
    InputButton scriptButton2;
    InputButton scriptButton3;
    InputButton scriptButton4;
    List<InputButton> TheButtons;
    Text displayText;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public AudioClip beep;
    public GameObject display;
    public GameObject[] lightBomb;

    public GameObject EndingLightRed;
    public GameObject EndingLightYellow;
    public GameObject EndingLightBlue;
    public GameObject EndingLightGreen;
    public int FinishLight;

    public enum State
    {
        armed,
        diffused,
        waiting,
        exploded,
    }

    public State currentState;

    int stateButton1 = 1;
    int stateButton2 = 1;
    int stateButton3 = 1;
    int stateButton4 = 1;

    float timeToChange;
    float currentTime;
    int timeRemaining;
    string displayTime;
    int decount;

    int bon = 1;
    int boom = 3;
    int accel = 2;

    public int serialgame = 0;
    public int simon = 0;

	// Use this for initialization
	void Start ()
    {
        scriptButton1 = button1.GetComponent<InputButton>();
        scriptButton2 = button2.GetComponent<InputButton>();
        scriptButton3 = button3.GetComponent<InputButton>();
        scriptButton4 = button4.GetComponent<InputButton>();

        TheButtons = new List<InputButton>();
        TheButtons.Add(scriptButton1);
        TheButtons.Add(scriptButton2);
        TheButtons.Add(scriptButton3);
        TheButtons.Add(scriptButton4);

        displayText = display.GetComponent<Text>();

        //currentState = State.waiting;
        timeToChange = 1;
        currentTime = 0.0f;
        displayTime = "05:00";
        timeRemaining = 300;
        decount = 1;
        FinishLight = Random.Range(1,5);

        RefreshText();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (currentState == State.waiting)
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                currentState = State.armed;
            }
        }
        else if(currentState == State.armed)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= timeToChange)
            {
                timeRemaining -= decount;
                Camera.main.GetComponent<AudioSource>().PlayOneShot(beep);
                currentTime = 0.0f;
            }

            RefreshText();

            if(timeRemaining < 60)
            {
                for (int i = 0; i < lightBomb.Length; ++i )
                {
                    lightBomb[i].GetComponent<clignottement>().active = true;
                }
            }
            if(timeRemaining <= 0)
            {
                currentState = State.exploded;
                displayText.text = "BOOM";
            }

            stateButton1 = scriptButton1.GetState();
            stateButton2 = scriptButton2.GetState();
            stateButton3 = scriptButton3.GetState();
            stateButton4 = scriptButton4.GetState();

            foreach (InputButton script in TheButtons)
            {
                if (script.GetState() == 0)
                {
                    if (script.currentButton == FinishLight)
                    {
                        currentState = State.diffused;
                        for (int i = 0; i < lightBomb.Length; ++i)
                        {
                            lightBomb[i].GetComponent<clignottement>().active = false;
                        }
                    }
                    /*else if (script.currentButton == boom)
                    {
                        currentState = State.exploded;
                        displayText.text = "BOOM";
                    }*/
                    else /*if (script.currentButton == accel)*/
                    {
                        currentState = State.exploded;
                        displayText.text = "BOOM";
                    }
                }
            }
        }
	}



    public void AddError()
    {
        timeToChange -= 0.1f;
    }

    void RefreshText()
    {
        if (timeRemaining / 60 < 10)
        {
            displayTime = "0";
            displayTime += timeRemaining / 60;
        }
        else
        {
            displayTime = timeRemaining % 60 + "";
        }
        displayTime += ":";
        if (timeRemaining % 60 < 10)
        {
            displayTime += "0";
            displayTime += timeRemaining % 60;
        }
        else
        {
            displayTime += timeRemaining % 60;
        }
        displayText.text = displayTime;
    }

    public void FinishedSimon()
    {
        simon = 1;
        CheckFinished();
    }

    public void FinishedSerial()
    {
        serialgame = 1;
        CheckFinished();
    }

    void CheckFinished()
    {
        if(simon==1 && serialgame==1)
        {
            ShowFinishLed();
        }
    }

    void ShowFinishLed()
    {
        if(FinishLight == 1)
        {
            EndingLightRed.GetComponent<Led>().Light();
        }
        if (FinishLight == 2)
        {
            EndingLightBlue.GetComponent<Led>().Light();
        }
        if (FinishLight == 3)
        {
            EndingLightGreen.GetComponent<Led>().Light();
        }
        if (FinishLight == 4)
        {
            EndingLightYellow.GetComponent<Led>().Light();
        }
    }
}
