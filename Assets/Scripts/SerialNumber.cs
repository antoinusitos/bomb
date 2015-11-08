using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SerialNumber : MonoBehaviour {

    List<int> Number;
    List<int> NumberImpair;
    string theSerial = "";

	// Use this for initialization
	void Start () 
    {
        Number = new List<int>();
        NumberImpair = new List<int>();
        for (int i = 0; i < 10; i+=2)
        {
            Number.Add(i);
        }
        for (int i = 1; i < 10; i += 2)
        {
            NumberImpair.Add(i);
        }
        RandomizeText();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void RandomizeText()
    {
        while(Number.Count > 0)
        {
           int rand = Random.Range(0, Number.Count);
           theSerial += Number[rand].ToString();
           Number.RemoveAt(rand);

           rand = Random.Range(0, NumberImpair.Count);
           theSerial += NumberImpair[rand].ToString();
           NumberImpair.RemoveAt(rand);
        }
        GetComponent<Text>().text = theSerial;
    }
}
