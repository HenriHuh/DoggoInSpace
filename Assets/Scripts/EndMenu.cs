using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{

    static public float timeEnd;

    public Text textBox;



   void Start()
    {
        //GameObject.Find("StatsCount");
        //GameObject.Find("StatsCount").GetComponent<Countdown>().timeStart;
        //GameObject.Find("StatsCount").GetComponent<Countdown>().timeStart;



        textBox.text = timeEnd.ToString();
        textBox.text = Mathf.Round(timeEnd).ToString();
        

    }
    

    void Update()
    {
        
    }
}
