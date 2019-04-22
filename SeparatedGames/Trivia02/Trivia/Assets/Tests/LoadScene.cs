using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class LoadScene
    {
        // A Test behaves as an ordinary method
        [Test]
        public void LoadSceneSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator LoadSceneWithEnumeratorPasses()
        {

            SceneManager.LoadScene("GameOverScene");
            yield return new WaitForSeconds(1);

            Button b = GameObject.FindObjectOfType<Button>();

            //Debug.Log(b.GetComponentInChildren<Text>().text);

            b.onClick.Invoke();
            yield return new WaitForSeconds(1);

            Scene currentScene = SceneManager.GetActiveScene();
           Assert.AreEqual("MainLevel", currentScene.name);

            yield return null;
        }

        [UnityTest]
        public IEnumerator LoadQuestionWithEnumeratorPasses()
        {

            SceneManager.LoadScene("GameOverScene");
            yield return new WaitForSeconds(1);

            Button b = GameObject.FindObjectOfType<Button>();

            //Debug.Log(b.GetComponentInChildren<Text>().text);

            b.onClick.Invoke();
            yield return new WaitForSeconds(1);

            var question = GameObject.Find("Question");

            Assert.NotNull(question.GetComponentInChildren<Text>().text);

            yield return null;
        }

        [UnityTest]
        public IEnumerator LoadAnswersWithEnumeratorPasses()
        {

            SceneManager.LoadScene("GameOverScene");
            yield return new WaitForSeconds(1);

            Button b = GameObject.FindObjectOfType<Button>();

            b.onClick.Invoke();
            yield return new WaitForSeconds(1);

            Button[] buttons = GameObject.FindObjectsOfType<Button>();

            Assert.NotNull(buttons);

            yield return null;
        }

    }
}
