using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using Trivia;
using manageQuestions;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class TimerTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TimerSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TimerColorRedWithEnumeratorPasses()//la fel ca mai jos
        {
            SceneManager.LoadScene("MainLevel");
            yield return new WaitForSeconds(1);
            yield return new WaitForSeconds(GameManager.getMainTimer()-3);
          Text timer = GameObject.Find("Timer").GetComponent<Text>();
            Debug.Log(timer.text);
            Assert.AreEqual(timer.color, Color.red);
            yield return null;
        }
        [UnityTest]
        public IEnumerator TimerColorWithEnumeratorPasses()//verific daca timpul isi modifica culoarea in functie de valoarea sa
        {
            SceneManager.LoadScene("MainLevel");
            yield return new WaitForSeconds(1);
           
            Text timer = GameObject.Find("Timer").GetComponent<Text>();
            Debug.Log(timer.text);
            Assert.AreEqual(timer.color, timer.color);
            yield return null;
        }

        [UnityTest]
        public IEnumerator RightScoreIncrementWithEnumeratorPasses()//verific daca scorul se incarca cum trebuie
        {
            SceneManager.LoadScene("MainLevel");
            yield return new WaitForSeconds(0.5f);


            float myScore = GameManager.score;
            float difficulty = GameManager.scoreDifficulty;

            Text question = GameObject.Find("Question").GetComponent<Text>();
            List < Question > myQuestions= GameManager.questions;
            for(int i=0;i<myQuestions.Count;i++)
            {
                if(question.text.ToString()==myQuestions[i].question)
                {
                     Button[] buttons = GameObject.FindObjectsOfType<Button>();

                    Button b1 = buttons[0];
                    Button b2 = buttons[1];
                    Button b3 = buttons[2];
                    //Debug.Log(b1);
                    
                    if (b1.GetComponentInChildren<Text>().text == myQuestions[i].getRightAnswer())
                    {
                        Debug.Log(b1.GetComponentInChildren<Text>().text+" "+ myQuestions[i].getRightAnswer());
                        b1.onClick.Invoke();
                    }
                    else if (b2.GetComponentInChildren<Text>().text == myQuestions[i].getRightAnswer())
                    {
                        Debug.Log(b2.GetComponentInChildren<Text>().text + " " + myQuestions[i].getRightAnswer());
                        b2.onClick.Invoke();
                    }

                    else
                    {
                        Debug.Log(b3.GetComponentInChildren<Text>().text + " " + myQuestions[i].getRightAnswer());
                        b3.onClick.Invoke();
                    }
                }
            }
            Assert.AreEqual(myScore + GameManager.scoreDifficulty+1, GameManager.score);
            //yield return null;
        }
    }
    public class nextQuestion
    {
        [UnityTest]
        public IEnumerator nextQuestionComestWithEnumeratorPasses()//verific daca dupa ce expira timpul se incarca urmatoarea intrebare
        {
            SceneManager.LoadScene("MainLevel");
            yield return new WaitForSeconds(0.5f);
            Text currentQuestion = GameObject.Find("Question").GetComponent<Text>();
            string stringCurrentQuestion = currentQuestion.text;
            Debug.Log(GameManager.getMainTimer()+1);
            yield return new WaitForSeconds(GameManager.getMainTimer()+1);
            Text newQuestion = GameObject.Find("Question").GetComponent<Text>();
            string stringNewQuestion =newQuestion.text;
           
            Assert.AreNotEqual(stringCurrentQuestion, stringNewQuestion);
        }
    }
}
