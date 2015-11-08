using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputButton : MonoBehaviour {

    public enum Button
    {
        button1 = 1 ,
        button2 = 2 ,
        button3 = 3,
        button4 = 4,
    };

    public int currentButton;

    int state = 1; //1 = on, 0 = off

    public GameObject Visuel;
	
	// Update is called once per frame
	void Update () 
    {
	    switch(currentButton)
        {
            case 1:
                updateButton1();
                break;

            case 2:
                updateButton2();
                break;

            case 3:
                updateButton3();
                break;

            case 4:
                updateButton4();
                break;
        }
	}

    void updateButton1()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            state = 0;
            Visuel.transform.GetChild(0).GetComponent<Image>().color = new Color(.5f, .5f, .5f);
            Visuel.transform.GetChild(1).GetComponent<Image>().color = new Color(.5f, .5f, .5f);
        }
    }

    void updateButton2()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            state = 0;
            Visuel.transform.GetChild(0).GetComponent<Image>().color = new Color(.5f, .5f, .5f);
            Visuel.transform.GetChild(1).GetComponent<Image>().color = new Color(.5f, .5f, .5f);
        }
    }

    void updateButton3()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            state = 0;
            Visuel.transform.GetChild(0).GetComponent<Image>().color = new Color(.5f, .5f, .5f);
            Visuel.transform.GetChild(1).GetComponent<Image>().color = new Color(.5f, .5f, .5f);
        }
    }

    void updateButton4()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            state = 0;
            Visuel.transform.GetChild(0).GetComponent<Image>().color = new Color(.5f, .5f, .5f);
            Visuel.transform.GetChild(1).GetComponent<Image>().color = new Color(.5f, .5f, .5f);
        }
    }

    public int GetState()
    {
        return state;
    }
}
