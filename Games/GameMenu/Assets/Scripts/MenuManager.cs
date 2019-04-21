using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private static string difficulty="Medium";//in cazul in care nu se seteaza nimic
    private static string language = "English";//      -      //         -
    public TMP_Dropdown difficultyDropdownMenu;
    public TMP_Dropdown languageDropdownMenu;

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

    public void DifficultyManager() // done
    {
        switch (difficultyDropdownMenu.value)
        {
            case 0:
                difficulty = difficultyDropdownMenu.options[difficultyDropdownMenu.value].text;
                Debug.Log("Easy");
                break;
            case 1:
                difficulty = difficultyDropdownMenu.options[difficultyDropdownMenu.value].text;
                break;
            case 2:
                difficulty = difficultyDropdownMenu.options[difficultyDropdownMenu.value].text;
                break;
        }
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
    }

    public void loadTrivia()
    {
        SceneManager.LoadScene("MainLevel");
    }

}
