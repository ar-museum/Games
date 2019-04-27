using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Trivia;
using UnityEngine.UI;
namespace meniu
{
    public class MenuManager : MonoBehaviour
    {
        private static string difficulty;//in cazul in care nu se seteaza nimic
        private static string language;//      -      //         -
        public TMP_Dropdown difficultyDropdownMenu;
        public TMP_Dropdown languageDropdownMenu;
        public void Start()
        {
            if (difficulty == null && GameManager.getDifficulty() != null)
                difficulty = GameManager.getDifficulty();
            //else difficulty = "Easy";
            if (language == null && GameManager.getLanguage() != null)
                language = GameManager.getLanguage();
            //else language = "Romanian";
            if (difficulty == null) difficulty = "Easy";
            if (language == null) language = "Romanian";
        }
        public void loadDragDrop()
        {
            SceneManager.LoadScene("SampleScene");
        }
        public void MuteSound()
        {
            AudioListener.pause = !AudioListener.pause;
        }

        public static string getDifficulty()
        {
            return difficulty;
        }

        public static string getLanguage()
        {
            return language;
        }
        public static void setDifficulty(string dificulty)
        {
            difficulty=dificulty;
        }

        public static void setLanguage(string langguage)
        {
            language = langguage;
        }
        public void DifficultyManager() // done
        {
            switch (difficultyDropdownMenu.value)
            {
                case 0:
                    difficulty = difficultyDropdownMenu.options[difficultyDropdownMenu.value].text;
                   // difficultyDropdownMenu.GetComponentInChildren<Text>().GetComponent("Label").text = difficulty;
                    Debug.Log("Easy");
                    break;
                case 1:
                    difficulty = difficultyDropdownMenu.options[difficultyDropdownMenu.value].text;
                    break;
                case 2:
                    difficulty = difficultyDropdownMenu.options[difficultyDropdownMenu.value].text;
                    break;
            }
            Debug.Log(difficulty)   ;
        }

        public void LanguageManager() //done the easy way
        {
            switch (languageDropdownMenu.value)
            {
                case 0:
                    language = languageDropdownMenu.options[languageDropdownMenu.value].text;

                    break;
                case 1:
                    language = languageDropdownMenu.options[languageDropdownMenu.value].text;
                    break;
                case 2:
                    language = languageDropdownMenu.options[languageDropdownMenu.value].text;
                    break;
                   
            }
            Debug.Log(language);
        }

        public void loadTrivia()
        {
            SceneManager.LoadScene("LaunchingTrivia");
        }

    }
}
