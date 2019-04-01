using System.Collections;
using System.Collections.Generic;
using manageQuestions;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEngine.UI;


public class Questions : MonoBehaviour
{
    public Text text=null;
    JsonToObject deserializer = new JsonToObject();
    QuestionArray newQuestions;
    public List<string> questions = new List<string>();
    public static int nrQuestion = 0;
    public static string HighScore(int scoreFromScene)
    {
        string fileInput, filePath;
        filePath = @".\highscore.txt";
        int highScore;
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
        return highScore.ToString();
    }
    public void getQuestions()
    {
        newQuestions = deserializer.loadJson();
        for (int i = 0; i < newQuestions.questions.Count; i++)
        {

            questions[i] = newQuestions.questions[i].getQuestion();
            // Debug.Log(questions[i]);
        }
    }
    
    void Start()
    {
        this.getQuestions();    
        text = GetComponent<Text>();
        text.text = questions[0];

        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        //text.text = questions[0];
    }

    // Update is called once per frame
    void Update()
    {
        if ((HandleButton.clicked == true || HandleButton1.clicked == true || HandleButton2.clicked == true || HandleButton3.clicked == true) && nrQuestion < newQuestions.questions.Count)
        {
           
            text = GetComponent<Text>();
            
            //Debug.Log(questions[nrQuestion]);
            //HandleButton.clicked = false;
            HandleButton.nrClicked = 0;
            HandleButton1.nrClicked = 0;
            HandleButton2.nrClicked = 0;
            HandleButton3.nrClicked = 0;
            text.text = questions[++nrQuestion];
        }
        if (nrQuestion == newQuestions.questions.Count)
        {
            
           // EditorSceneManager.UnloadScene(SceneManager.GetSceneByName("SampleScene"));
            SceneManager.LoadScene("End");
        }
            //text.text = questions[++nrQuestion];

        }
}
