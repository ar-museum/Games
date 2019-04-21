using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    public static int sc;
    void Start()
    {
       score= GetComponent<Text>();
        score.text = "score:" + "0";
    }

    
     void Update()
    {
       
        score = GetComponent<Text>();
        score.text = "score:" + sc.ToString();

    }
}
