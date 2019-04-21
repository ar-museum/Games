using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEngine.UI;

public class TryAgainScript : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.GetComponentInChildren<Text>().text = "Try again?";
    }

    // Update is called once per frame
    void Update()
    {
        if (HandleButton2.clicked == true)
        {
            HandleButton2.clicked = false;
            //SceneManager.UnloadSceneAsync("End");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("SampleScene"));
        }
    }
}
