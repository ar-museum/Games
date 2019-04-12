using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OverScreenManager : MonoBehaviour
{
    [SerializeField]
    private Text score;
    [SerializeField]
    private Button tryAgain;
    void Start()
    {
        score.text = "Game Over!\n" + "Your score is " + GameManager.score;
        tryAgain.GetComponentInChildren<Text>().text = "Try Again?";
    }
    public void tryAgainPressed()
    {
        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("MainLevel");
    }

    
}
