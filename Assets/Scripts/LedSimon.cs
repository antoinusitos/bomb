using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LedSimon : MonoBehaviour {

    Image image;
    public Color colorBase;
    public Color colorLight;

	// Use this for initialization
	void Awake () 
    {
        image = GetComponent<Image>();
        image.color = colorBase;
	}

    public void Light()
    {
        if (image == null)
            Debug.Log("null image");
        image.color = colorLight;
    }

    public void UnLight()
    {
        image.color = colorBase;
    }

    public void Activate()
    {
        StartCoroutine(clicked());
    }

    IEnumerator clicked()
    {
        Light();
        yield return new WaitForSeconds(.1f);
        UnLight();
    }
}
