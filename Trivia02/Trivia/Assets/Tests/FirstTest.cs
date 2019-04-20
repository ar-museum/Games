﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using Trivia;
using UnityEngine.SceneManagement;
using manageQuestions;

namespace Tests
{
    public class NewTestScript
    {
        // A Test behaves as an ordinary method
        [Test]
        public void NewTestScriptSimplePasses()
        {
            // Use the Assert class to test conditions

        }

        [UnityTest]
        public IEnumerator TestScriptForRightAnswerButton1()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            SceneManager.LoadScene("MainLevel");
            yield return new WaitForSeconds(1);

            Button[] buttons = GameObject.FindObjectsOfType<Button>();
            Button b11 = buttons[0];
            string rightAnswer = b11.GetComponentInChildren<Text>().text.ToString();
        
            var question = GameObject.Find("Question");
            List<Question> expectedQuestions = GameManager.questions;

            string expectedAnswer;

            for (int i = 0; i < expectedQuestions.Count; i++)
            {
                
                if (question.GetComponentInChildren<Text>().text == expectedQuestions[i].question)
                {
                    expectedAnswer = expectedQuestions[i].getRightAnswer();
                     b11.onClick.Invoke();
                    if (b11.GetComponentInChildren<Text>().text == "Correct!")
                        Assert.AreEqual(expectedAnswer, rightAnswer);
                    else
                        Assert.AreNotEqual(expectedAnswer, rightAnswer);
                }
            }
        }

        [UnityTest]
        public IEnumerator TestScriptForRightAnswerButton2()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            SceneManager.LoadScene("MainLevel");
            yield return new WaitForSeconds(1);

            Button[] buttons = GameObject.FindObjectsOfType<Button>();
            Button b = buttons[1];
            string rightAnswer = b.GetComponentInChildren<Text>().text.ToString();

            var question = GameObject.Find("Question");
            List<Question> expectedQuestions = GameManager.questions;

            string expectedAnswer;

            for (int i = 0; i < expectedQuestions.Count; i++)
            {

                if (question.GetComponentInChildren<Text>().text == expectedQuestions[i].question)
                {
                    expectedAnswer = expectedQuestions[i].getRightAnswer();
                    b.onClick.Invoke();
                    if (b.GetComponentInChildren<Text>().text == "Correct!")
                        Assert.AreEqual(expectedAnswer, rightAnswer);
                    else
                        Assert.AreNotEqual(expectedAnswer, rightAnswer);
                }
            }
        }

        [UnityTest]
        public IEnumerator TestScriptForRightAnswerButton3()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            SceneManager.LoadScene("MainLevel");
            yield return new WaitForSeconds(1);

            Button[] buttons = GameObject.FindObjectsOfType<Button>();
            Button b = buttons[2];
            string rightAnswer = b.GetComponentInChildren<Text>().text.ToString();

            var question = GameObject.Find("Question");
            List<Question> expectedQuestions = GameManager.questions;

            string expectedAnswer;

            for (int i = 0; i < expectedQuestions.Count; i++)
            {

                if (question.GetComponentInChildren<Text>().text == expectedQuestions[i].question)
                {
                    expectedAnswer = expectedQuestions[i].getRightAnswer();
                    b.onClick.Invoke();
                    if (b.GetComponentInChildren<Text>().text == "Correct!")
                        Assert.AreEqual(expectedAnswer, rightAnswer);
                    else
                        Assert.AreNotEqual(expectedAnswer, rightAnswer);
                }
            }
        }


        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            SceneManager.LoadScene("MainLevel");
            yield return new WaitForSeconds(1);

            var b1 = GameObject.Find("Option1");
            var b2 = GameObject.Find("Option2");
            var b3 = GameObject.Find("Option3");
            Button b11 = GameObject.FindObjectOfType<Button>();
            b11.onClick.Invoke();
            // var b22 = b2.GetComponent<Button>();
            // var b33 = b2.GetComponent<Button>();
            var question = GameObject.Find("Question");
            Debug.Log(b11.GetComponentInChildren<Text>().text);
            //b11.onClick.Invoke();
            /*JsonToObject desirializer = new JsonToObject();
            QuestionArray expectedQuestions = desirializer.loadJson();*/
            List<Question> expectedQuestions = GameManager.questions;
            for (int i = 0; i < expectedQuestions.Count; i++)
            {
                if (question.GetComponentInChildren<Text>().text == expectedQuestions[i].question)
                {
                    Assert.AreEqual(expectedQuestions[i].getAllAnswers()[0], b1.GetComponentInChildren<Text>().text);
                    Assert.AreEqual(expectedQuestions[i].getAllAnswers()[1], b2.GetComponentInChildren<Text>().text);
                    Assert.AreEqual(expectedQuestions[i].getAllAnswers()[2], b3.GetComponentInChildren<Text>().text);
                }

            }

            //yield return null;
        }



        //yield return null;
    }
}

