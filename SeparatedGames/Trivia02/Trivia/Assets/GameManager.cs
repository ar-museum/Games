﻿using System.Collections;
using System.Collections.Generic;
using manageQuestions;
using UnityEngine;
using UnityEngine.UI; 


using UnityEngine.SceneManagement;

using TMPro;

namespace Trivia
{
    [System.Serializable]
    public class GameManager : MonoBehaviour
    {
        //dificulty easy=1,medium1.5,hard =2
        public static List<Question> questions;
        public static int difficulty = 2;
        float scoreDificulty;
        //static string language;//s-ar putea sa nu avem nevoie de el

        bool wasClicked = false;
        public static int score;
        [SerializeField]//to be setted from unity
        private float mainTimer;

        private float startTime;
        private float fixedTime;
        [SerializeField]
        private Text timer;

        private Question currentQuestion;
        [SerializeField]
        private Text Score;
        [SerializeField]
        private Text toBeDisplayed;
        [SerializeField]
        public Button b1, b2, b3;
        [SerializeField]
        private float timeBetweenQ = 1f;


        public void Start()
        {
            wasClicked = false;
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

            else if (questions.Count == 0)
            {
                //Debug.Log(questions.Count);
                questions = null;
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene("GameOverScene");
            }
            if (difficulty == 1) { mainTimer = 5.04f; scoreDificulty = 1; }//setam dificultate +score+timp pe easy
            else if (difficulty == 2) { mainTimer = 4.04f; scoreDificulty = 1.5f; }//setam pentru mediu
            else { mainTimer = 3.04f; scoreDificulty = 2; }

            startTime = mainTimer;
            timer.text = startTime.ToString();
            setCurrentQuestion();
            setCurrentButtons();

            Score.text = "Score: " + score.ToString();
            //Debug.Log(currentQuestion.getQuestion());
        }
        public void setCurrentQuestion()
        {
            // Debug.Log(questions.Count);
            if (questions != null)
            {
                int randomIndexQuestion = Random.Range(0, questions.Count);

                currentQuestion = questions[randomIndexQuestion];
                toBeDisplayed.text = currentQuestion.question;
            }

        }
        public void setCurrentButtons()
        {
            if (questions != null)
            {
                //Debug.Log(b1.GetComponentInChildren<TextMeshPro>().text);
                b1.GetComponentInChildren<Text>().text = currentQuestion.getAllAnswers()[0];
                b2.GetComponentInChildren<Text>().text = currentQuestion.getAllAnswers()[1];
                b3.GetComponentInChildren<Text>().text = currentQuestion.getAllAnswers()[2];
            }
        }
        public Button getB1()
        {
            return b1;
        }

        public Question getCurrentQuestion()
        {
            return this.currentQuestion;
        }
        IEnumerator nextQuestion()
        {
            questions.Remove(currentQuestion);
            yield return new WaitForSeconds(timeBetweenQ);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void userSelect(Button b)
        {
            if (wasClicked == false)
            {
                fixedTime = startTime;
                timer.text = fixedTime.ToString("F");
                wasClicked = true;
                if (b.GetComponentInChildren<Text>().text == currentQuestion.getRightAnswer())
                {
                    b.GetComponentInChildren<Text>().color = Color.green;
                    b.GetComponentInChildren<Text>().text = "Correct!";
                    if (startTime > 2.5)
                        score++;
                    timer.color = Color.green;
                    score += difficulty;
                    Score.text = "Score:" + score.ToString();

                }
                else
                {
                    b.GetComponentInChildren<Text>().text = "Wrong!";
                    timer.color = Color.red;
                    b.GetComponentInChildren<Text>().color = Color.red;
                    getRightOption().GetComponentInChildren<Text>().color = Color.green;
                }

                StartCoroutine(nextQuestion());
            }
        }
        private Button getRightOption()
        {
            if (b1.GetComponentInChildren<Text>().text == currentQuestion.getRightAnswer())
            {
                return b1;
            }
            else if (b2.GetComponentInChildren<Text>().text == currentQuestion.getRightAnswer())
            {
                return b2;
            }
            return b3;
        }
        private void Update()
        {
            if (startTime >= 0.0f && wasClicked == false)
            {
                if (startTime<=2.5f)
                    timer.color = Color.red;

                startTime -= Time.deltaTime;
                timer.text = startTime.ToString("F");
            }
            else if (wasClicked == false)
            {
                timer.text = "0.00";

                getRightOption().GetComponent<Image>().color = Color.green;

                StartCoroutine(nextQuestion());
            }
        }

    }
}