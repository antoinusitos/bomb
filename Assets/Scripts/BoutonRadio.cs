using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoutonRadio : MonoBehaviour {

    int number = 0;

    public GameObject radioGame;

    public KeyCode up;
    public KeyCode down;
    public int buttonNumber;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetKeyDown(up))
        {
            number++;
            if(number > 10)
            {
                number = 10;
            }
            transform.GetChild(0).GetComponent<Text>().text = number.ToString("F1");
            radioGame.GetComponent<RadioGame>().ModifyNumberButon(buttonNumber, number);
        }
        if (Input.GetKeyDown(down))
        {
            number--;
            if (number < 0)
            {
                number = 0;
            }
            transform.GetChild(0).GetComponent<Text>().text = number.ToString("F1");
            radioGame.GetComponent<RadioGame>().ModifyNumberButon(buttonNumber, number);
        }
	}
}
