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

    void Start()
    {
        //score.text = "Game Over!\n" + "Your score is " + GameManager.score;
        score.text = "Game Over!\nScore: " + GameManager.score.ToString() + "\n";
        if (HighScore(GameManager.score) >= GameManager.score) score.text += "New Highscore!!\n";

        tryAgain.GetComponentInChildren<Text>().text = "Try Again?";

        quit.GetComponentInChildren<Text>().text = "QUIT";
    }
    public void tryAgainPressed()
    {
        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("MainLevel");
    }
    public static float HighScore(float scoreFromScene)
    {
        string fileInput, filePath;
        filePath = @".\highscore.txt";
        float highScore;
        if (File.Exists(filePath))//check the file for the previous high score 
        {
            StreamReader streamReader = new StreamReader(filePath);
            fileInput = streamReader.ReadLine();
            streamReader.Close();

            string[] vecString = fileInput.Split(' ');

            highScore = int.Parse(vecString[1]);

            if (highScore < scoreFromScene)
            {
                StreamReader streamReader123 = new StreamReader(filePath);
                string content = streamReader123.ReadToEnd();
                streamReader123.Close();
                content = Regex.Replace(content, highScore.ToString(), scoreFromScene.ToString());

                StreamWriter streamWriter = new StreamWriter(filePath);
                streamWriter.Write(content);
                streamWriter.Close();
                highScore = scoreFromScene;

                string output = "High score: " + scoreFromScene + " " + "Your score: " + scoreFromScene;
                Debug.Log(output);
            }
            else
            {
                string output = "High score: " + highScore + " " + "Your score: " + scoreFromScene;
                Debug.Log(output);
            }
        }
        else//if the file doesn't exist make one and initialize the high score with the first score
        {
            StreamWriter streamWriter = File.AppendText(filePath);
            streamWriter.Close();

            StreamWriter streamWriter1 = new StreamWriter(filePath);
            streamWriter1.Write("Highscore " + scoreFromScene);
            streamWriter1.Close();
            highScore = scoreFromScene;

            string output = "High score: " + scoreFromScene + " " + "Your score: " + scoreFromScene;
            Debug.Log(output);
        }
        return highScore;
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

