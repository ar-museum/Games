using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;
using meniu;

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

            Debug.Log(b.GetComponentInChildren<Text>().text);

            b.onClick.Invoke();
            MenuManager.setDifficulty("Easy");
            MenuManager.setLanguage("Romanian");
            yield return new WaitForSeconds(5);
          
            Scene currentScene = SceneManager.GetActiveScene();
           Assert.AreEqual("MainLevel", currentScene.name);

            yield return null;
        }

        [UnityTest]
        public IEnumerator LoadQuestionWithEnumeratorPasses()
        {

            SceneManager.LoadScene("GameOverScene");
            yield return new WaitForSeconds(2);

            Button b = GameObject.FindObjectOfType<Button>();

            Debug.Log(b.GetComponentInChildren<Text>().text);

            b.onClick.Invoke();
            MenuManager.setLanguage("Romanian");
            MenuManager.setDifficulty("Easy");
            yield return new WaitForSeconds(6);
            Debug.Log(SceneManager.GetActiveScene());
            var question = GameObject.Find("Question");
           //Debug.Log(question.GetComponentInChildren<Text>().text);
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
