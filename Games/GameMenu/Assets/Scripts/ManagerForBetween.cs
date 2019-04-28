using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class ManagerForBetween : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Text wait;
    void Start()
    {
        wait.text = "ihdsa";
        StartCoroutine(CountDown());
    }
    IEnumerator CountDown()
    {
        wait.text = "Starting in 3...";
        yield return new WaitForSeconds(1);
        wait.text = "Starting in 2...";
        yield return new WaitForSeconds(1);
        wait.text = "Starting in 1...";
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainLevel");
    }
}
