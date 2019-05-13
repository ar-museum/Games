using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;
using meniu;
using static UnityEditor.Menu;
    namespace Tests
    {
        public class SimpleTestScript
        {

           
            [UnityTest]
        public IEnumerator Difficulty_Initialization_Test()
        {
            SceneManager.LoadScene("Menu");
            yield return new WaitForSeconds(1);
            string expectedAnswer = "Easy";
            string diff = MenuManager.getDifficulty();
            Assert.AreEqual(expectedAnswer, diff);

        }


            [UnityTest]
        public IEnumerator Language_Initialization_Test()
            {
            SceneManager.LoadScene("Menu");
            yield return new WaitForSeconds(1);
            string expectedAnswer = "Romanian";
            Assert.AreEqual(expectedAnswer, MenuManager.getLanguage());
            }


        [UnityTest]
        public IEnumerator Check_Music_Selection()
        {
            SceneManager.LoadScene("Menu");
            yield return new WaitForSeconds(1);
            string expectedAnswer = "On";
            Assert.AreEqual(expectedAnswer, MenuManager.getMusic());
        }

        [UnityTest]
        public IEnumerator Music_Setting_Diff_Scenes()
        {
            int compare1=1, compare2=1;
            SceneManager.LoadScene("Menu");
            yield return new WaitForSeconds(1);

            string expectedAnswer1 = MenuManager.getMusic();
            SceneManager.LoadScene("MainLevel");
            yield return new WaitForSeconds(1);
            string expectedAnswer2 = MenuManager.getMusic();
            SceneManager.LoadScene("SampleScene");
            yield return new WaitForSeconds(1);
            string expectedAnswer3 = MenuManager.getMusic();

            compare1 = string.Compare(expectedAnswer1, expectedAnswer2);
            compare2 = string.Compare(expectedAnswer2, expectedAnswer3);

            Assert.AreEqual(compare1, compare2);

        }

        [UnityTest]
        public IEnumerator Check_Games_Button()
        {
            SceneManager.LoadScene("Menu");
            string expectedAnswer = "MainLevel";
            yield return new WaitForSeconds(1);

            Button[] buttons = GameObject.FindObjectsOfType<Button>();
            Button a = buttons[0];
            a.onClick.Invoke();
            Button btn = GameObject.Find("TriviaButton").GetComponent<Button>();
            btn.onClick.Invoke();
            yield return new WaitForSeconds(5);
            Assert.AreEqual(expectedAnswer, SceneManager.GetActiveScene().name);
            
        }

        [UnityTest]
        public IEnumerator Check_DD_Button()
        {
            SceneManager.LoadScene("Menu");
            string expectedAnswer = "SampleScene";
            yield return new WaitForSeconds(1);

            Button[] buttons = GameObject.FindObjectsOfType<Button>();
            Button a = buttons[0];
            a.onClick.Invoke();
            Button btn = GameObject.Find("D&DButton").GetComponent<Button>();
            btn.onClick.Invoke();
            yield return new WaitForSeconds(5);
            Assert.AreEqual(expectedAnswer, SceneManager.GetActiveScene().name);

        }
    }
    }

