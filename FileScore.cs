using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class FileScore : MonoBehaviour
{
    public int scoreFromScene;
    public Text textName = null;

    void Start()
    {
        HighScore(scoreFromScene);
    }

    void HighScore(int scoreFromScene)
    {
        string fileInput, filePath;
        filePath = @".\highscore.txt";

        if (File.Exists(filePath))//check the file for the previous high score 
        {
            StreamReader streamReader = new StreamReader(filePath);
            fileInput = streamReader.ReadLine();
            streamReader.Close();

            string[] vecString = fileInput.Split(' ');

            int highScore = int.Parse(vecString[1]);

            if (highScore < scoreFromScene)
            {
                StreamReader streamReader123 = new StreamReader(filePath);
                string content = streamReader123.ReadToEnd();
                streamReader123.Close();
                content = Regex.Replace(content, highScore.ToString(), scoreFromScene.ToString());

                StreamWriter streamWriter = new StreamWriter(filePath);
                streamWriter.Write(content);
                streamWriter.Close();

                string output = "High score: " + scoreFromScene + " " + "Your score: " + scoreFromScene;
                textName.text = output;
            }
            else
            {
                string output = "High score: " + highScore + " " + "Your score: " + scoreFromScene;
                textName.text = output;
            }
        }
        else//if the file doesn't exist make one and initialize the high score with the first score
        {
            StreamWriter streamWriter = File.AppendText(filePath);
            streamWriter.Close();

            StreamWriter streamWriter1 = new StreamWriter(filePath);
            streamWriter1.Write("Highscore " + scoreFromScene);
            streamWriter1.Close();

            string output = "High score: " + scoreFromScene + " " + "Your score: " + scoreFromScene;
            textName.text = output;
        }
    }
}
