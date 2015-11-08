using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class clignottement : MonoBehaviour {

    float currentTime;
    bool view;
    public bool active;

	// Use this for initialization
	void Start () 
    {
        view = false;
        active = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (active)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= 0.25f)
            {
                view = !view;

                if (view)
                {
                    GetComponent<Image>().color = new Color(1f, 0f, 0f, 1f);
                }
                else
                {
                    GetComponent<Image>().color = new Color(1f, 0f, 0f, .5f);
                }

                currentTime = 0.0f;
            }
        }
	}
}
