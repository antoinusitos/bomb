using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Led : MonoBehaviour {

    Image image;
    public Color colorBase;
    public Color colorLight;

    // Use this for initialization
    void Awake()
    {
        image = GetComponent<Image>();
        UnLight();
    }

    public void Light()
    {
        image.color = colorLight;
    }

    public void UnLight()
    {
        image.color = colorBase;
    }
}
