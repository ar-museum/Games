using System.Collections;
using System.Collections.Generic;
using manageQuestions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static List<Question> questions;
    public static int score;

    private Question currentQuestion;
    [SerializeField]
    private Text Score;
    [SerializeField]
    private Text toBeDisplayed;
    [SerializeField]
    private Button b1, b2, b3;
    [SerializeField]
    private float timeBetweenQ = 1f;
  

    public void Start()
    {
        if (questions == null)
        {
            QuestionArray quests;
           
            JsonToObject deserializer = new JsonToObject();
            quests = deserializer.loadJson();
            //Debug.Log(quests.questions.Count);
            questions = quests.questions;
            Score.text = "Score: ";
            score = 0;
            //SceneManager.UnloadSceneAsync("GameOverScene");
        }
      
        else if(questions.Count==0)
        {
            //Debug.Log(questions.Count);
            questions = null;
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene("GameOverScene");
        }
        setCurrentQuestion();
        setCurrentButtons();
        Score.text = "Score: " + score.ToString();
        //Debug.Log(currentQuestion.getQuestion());
    }
    public void setCurrentQuestion()
    {
      // Debug.Log(questions.Count);
        int randomIndexQuestion = Random.Range(0, questions.Count);

        currentQuestion = questions[randomIndexQuestion];
        toBeDisplayed.text = currentQuestion.question;
        
    }
    public void setCurrentButtons()
    {
        //Debug.Log(b1.GetComponentInChildren<TextMeshPro>().text);
        b1.GetComponentInChildren<Text>().text = currentQuestion.getAllAnswers()[0];
        b2.GetComponentInChildren<Text>().text = currentQuestion.getAllAnswers()[1];
        b3.GetComponentInChildren<Text>().text = currentQuestion.getAllAnswers()[2];
    }

    IEnumerator nextQuestion()
    {
        questions.Remove(currentQuestion);
        yield return new WaitForSeconds(timeBetweenQ);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void userSelect(Button b)
    {
        //Debug.Log(currentQuestion.getRightAnswer());
        if (b.GetComponentInChildren<Text>().text == currentQuestion.getRightAnswer())
        {
            b.GetComponentInChildren<Text>().text = "Correct!";
            score ++;
            Score.text = "Score:" + score.ToString();
            
        }
        else b.GetComponentInChildren<Text>().text = "Wrong!";

        StartCoroutine(nextQuestion());
    }
}
