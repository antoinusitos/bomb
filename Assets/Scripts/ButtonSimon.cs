using UnityEngine;
using System.Collections;

public class ButtonSimon : MonoBehaviour {

    Simon simon;
    public GameObject theLed;
    public bool activated;

    public enum ButtonColor
    {
        green = 0,
        red = 1,
        blue = 2,
        yellow = 3,

    }

    public ButtonColor currentColor;

	// Use this for initialization
	void Start () 
    {
        simon = transform.parent.GetComponent<Simon>();
	}

    public void SetActivate(bool newState)
    {
        activated = newState;
    }

    public void OnClick()
    {
        if (activated)
        {
            theLed.GetComponent<LedSimon>().Activate();
            simon.ReceiveInput(currentColor);
        }
    }
}
