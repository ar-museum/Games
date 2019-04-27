using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
using UnityEngine;
using Trivia;

public class OverScreenManager : MonoBehaviour
{
    [SerializeField]
    private Text score;
    [SerializeField]
    private Button tryAgain;
    [SerializeField]
    private Button quit;

    private static float oldHighScore;
    
    void Start()
    {
        //score.text = "Game Over!\n" + "Your score is " + GameManager.score;
        score.text = "Game Over!\nScore: " + GameManager.score.ToString() + "\n";
        float high = HighScore(GameManager.score);
       // Debug.Log(high);
       // Debug.Log(GameManager.score);
        if (oldHighScore < GameManager.score) score.text =score.text+ "New Highscore: "+high.ToString()+"!";
        else score.text = score.text + "Highscore: " + high.ToString() + "!";

        tryAgain.GetComponentInChildren<Text>().text = "Try Again?";

        quit.GetComponentInChildren<Text>().text = "QUIT";
    }
    public void tryAgainPressed()
    {
        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("LaunchingTrivia");
    }
    public static float HighScore(float scoreFromScene)
    {
        string fileInput, filePath;
        filePath = @".\Assets\highscore.txt";

        
        float highScore;
        if (File.Exists(filePath))//check the file for the previous high score 
        {
            StreamReader streamReader = new StreamReader(filePath);
            fileInput = streamReader.ReadLine();
            streamReader.Close();

            string[] vecString = fileInput.Split(' ');

            highScore = float.Parse(vecString[1]);
            oldHighScore = highScore;

            if (highScore < scoreFromScene)
            {
                highScore = scoreFromScene;
                File.WriteAllText(filePath, string.Empty);
                string output = "Highscore: " + highScore;
                StreamWriter streamWriter = new StreamWriter(filePath);
                streamWriter.Write(output);
                streamWriter.Close();
            }
        }
        else//if the file doesn't exist make one and initialize the high score with the first score
        {
            StreamWriter streamWriter = File.AppendText(filePath);
            streamWriter.Write("Highscore " + scoreFromScene);
            streamWriter.Close();
            highScore = scoreFromScene;

        }

        return highScore;
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

