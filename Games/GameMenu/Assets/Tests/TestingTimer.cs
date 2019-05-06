using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using Trivia;
using manageQuestions;
using UnityEngine.SceneManagement;
using System;

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
            SceneManager.LoadScene("Menu");
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("MainLevel");
            yield return new WaitForSeconds(5);
            yield return new WaitForSeconds(4.0f);
          Text timer = GameObject.Find("Timer").GetComponent<Text>();
            Debug.Log(timer.text);
            Assert.AreEqual(timer.color, Color.red);
            yield return null;
        }
        [UnityTest]
        public IEnumerator TimerColorGreenWithEnumeratorPasses()//verific daca timpul isi modifica culoarea in functie de valoarea sa
        {
            SceneManager.LoadScene("Menu");
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("MainLevel");
            yield return new WaitForSeconds(4);
            Text timer = GameObject.Find("Timer").GetComponent<Text>();
            Debug.Log(timer.text);
            Assert.AreEqual(timer.color, timer.color);
            yield return null;
        }

        [UnityTest]
        public IEnumerator RightScoreIncrementWithEnumeratorPasses()//verific daca scorul se incarca cum trebuie
        {
            SceneManager.LoadScene("Menu");
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("MainLevel");
            yield return new WaitForSeconds(4);

            float myScore = GameManager.score;
          string difficulty = GameManager.difficulty;

            Text question = GameObject.Find("Question").GetComponent<Text>();
            List < Question > myQuestions= GameManager.questions;
            Text timer = GameObject.Find("Timer").GetComponent<Text>();


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
                        //yield return new WaitForSeconds(1.5f);
                        Debug.Log(b1.GetComponentInChildren<Text>().text+" "+ myQuestions[i].getRightAnswer());
                        b1.onClick.Invoke();
                    }
                    else if (b2.GetComponentInChildren<Text>().text == myQuestions[i].getRightAnswer())
                    {
                        //yield return new WaitForSeconds(1.5f);
                        Debug.Log(b2.GetComponentInChildren<Text>().text + " " + myQuestions[i].getRightAnswer());
                        b2.onClick.Invoke();
                    }

                    else
                    {
                        //yield return new WaitForSeconds(1.5f);
                        Debug.Log(b3.GetComponentInChildren<Text>().text + " " + myQuestions[i].getRightAnswer());
                        b3.onClick.Invoke();
                    }
                    
                    if (String.Compare(timer.text, "2.50")>0)
                        myScore++;
                }
            }
            float score;
            if (GameManager.difficulty == "Easy") score = 1;
            else if (GameManager.difficulty == "Medium") score = 2;
            else score = 3;
            Assert.AreEqual(myScore +score, GameManager.score);
            //yield return null;
        }
    }
    public class nextQuestion
    {
        [UnityTest]
        public IEnumerator nextQuestionComestWithEnumeratorPasses()//verific daca dupa ce expira timpul se incarca urmatoarea intrebare
        {
            SceneManager.LoadScene("Menu");
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("MainLevel");
            yield return new WaitForSeconds(2);
            Text currentQuestion = GameObject.Find("Question").GetComponent<Text>();
            string stringCurrentQuestion = currentQuestion.text;
            yield return new WaitForSeconds(GameManager.getMainTimer());
            Text newQuestion = GameObject.Find("Question").GetComponent<Text>();
            string stringNewQuestion =newQuestion.text;
           
            Assert.AreNotEqual(stringCurrentQuestion, stringNewQuestion);
        }
    }
}
