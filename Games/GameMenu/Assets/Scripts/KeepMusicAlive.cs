using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMusicAlive : MonoBehaviour
{
    public void Awake()
    {
        GameObject[] music = GameObject.FindGameObjectsWithTag("music");
        Debug.Log(music.Length);
         if (music.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this);
    }
}
