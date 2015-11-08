using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SerialGame : MonoBehaviour {

    bool result = true;

    public GameObject endedLed;
    public GameObject theBomb;

    public void OnClick()
    {
        if(result)
        {
            endedLed.GetComponent<Image>().color = new Color(1f, 1f, 0f);
            theBomb.GetComponent<Bomb>().FinishedSerial();
        }
    }
}
