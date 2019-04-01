using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{
    public Text highscore=null;
    
   
    // Start is called before the first frame update
    void Start()
    {
        highscore = GetComponent<Text>();
        highscore.text= "Highscore: "+ Questions.HighScore(Score.sc)+"\nYour Score: " + Score.sc;

    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
