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
        private static string language;//
        private static string music;
        public TMP_Dropdown difficultyDropdownMenu;
        public TMP_Dropdown languageDropdownMenu;
        public Toggle musicOn;

        public void Start()
        {
           if (music == null)
                music = "On";
            if (music == "On") musicOn.isOn = true;
            else {
                musicOn.isOn = false;
                AudioListener.pause = true;
            }

            if (difficulty == null) difficulty = "Easy";
            if (language == null) language = "Romanian";
            if (language == "Romanian") languageDropdownMenu.value = 0;
            else if (language == "English") languageDropdownMenu.value = 1;
            else if(language == "French") languageDropdownMenu.value = 2;
            if (difficulty=="Easy") difficultyDropdownMenu.value = 0;
            else if (difficulty == "Medium") difficultyDropdownMenu.value = 1;
            else if (difficulty == "Hard") difficultyDropdownMenu.value = 2;
            
        }
        public void loadDrag()
        {
            StartCoroutine(LoadAsynchronously());
        }
        IEnumerator LoadAsynchronously()
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync("SampleScene");
            while(!operation.isDone)
            {
                Debug.Log(operation.progress);
                yield return null;
            }
        }
        public void loadDragDrop()
        {
            SceneManager.LoadScene("SampleScene");
        }
        public void MuteSound()
        {
            AudioListener.pause = !AudioListener.pause;
            if (AudioListener.pause == true)
                music = "Off";
            else music = "On";
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
        public static string getMusic()
        {
            return music;
        }
        public static void setMusic(string musicc)
        {
            music = musicc;
        }
        public void DifficultyManager() // done
        {
            switch (difficultyDropdownMenu.value)
            {
                case 0:
                    difficulty = difficultyDropdownMenu.options[difficultyDropdownMenu.value].text;
                   // difficultyDropdownMenu.GetComponentInChildren<Text>().text = difficulty;
                    difficultyDropdownMenu.value = 0;
                    Debug.Log("Easy");
                    break;
                case 1:
                    difficulty = difficultyDropdownMenu.options[difficultyDropdownMenu.value].text;
                  //  difficultyDropdownMenu.GetComponentInChildren<Text>().text = difficulty;
                    difficultyDropdownMenu.value = 1;
                    break;
                case 2:
                    difficulty = difficultyDropdownMenu.options[difficultyDropdownMenu.value].text;
                   // difficultyDropdownMenu.GetComponentInChildren<Text>().text = difficulty;
                    difficultyDropdownMenu.value = 2;
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
                   languageDropdownMenu.value = 0;
                    break;
                case 1:
                    language = languageDropdownMenu.options[languageDropdownMenu.value].text;
                    languageDropdownMenu.value = 1;
                    break;
                case 2:
                    language = languageDropdownMenu.options[languageDropdownMenu.value].text;
                    languageDropdownMenu.value = 2;
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
