using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleButton : MonoBehaviour
{
    public static bool clicked = false;
    public static int nrClicked = 0;
    void LateUpdate()
    {
        clicked = false;
    }

    public void Click()
    {
        clicked = true;
        nrClicked++;
        Debug.Log("dasdadasdsfgfjdgnnfjdgjf");
        
    }
}
