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
            //difficultyDropdownMenu.GetComponentInChildren<Text>() = difficulty;
            if (difficulty == null) difficulty = "Easy";
            if (language == null) language = "Romanian";
            if (language == "Romanian") languageDropdownMenu.value = 0;
            else if (language == "English") languageDropdownMenu.value = 1;
            else if(language == "French") languageDropdownMenu.value = 2;
            if (difficulty=="Easy") difficultyDropdownMenu.value = 0;
            else if (difficulty == "Medium") difficultyDropdownMenu.value = 1;
            else if (difficulty == "Hard") difficultyDropdownMenu.value = 2;

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
                    difficultyDropdownMenu.GetComponentInChildren<Text>().text = difficulty;
                    Debug.Log("Easy");
                    break;
                case 1:
                    difficulty = difficultyDropdownMenu.options[difficultyDropdownMenu.value].text;
                    difficultyDropdownMenu.GetComponentInChildren<Text>().text = difficulty;
                    break;
                case 2:
                    difficulty = difficultyDropdownMenu.options[difficultyDropdownMenu.value].text;
                    difficultyDropdownMenu.GetComponentInChildren<Text>().text = difficulty;
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
