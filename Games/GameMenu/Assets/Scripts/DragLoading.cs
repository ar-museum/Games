using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class DragLoading : MonoBehaviour
{

    IEnumerator GetTexture()
    {
        string uri = "http://134.209.234.39/games/";
        WebRequest request = WebRequest.Create(uri);
        WebResponse response = request.GetResponse();
        Regex regex = new Regex("<a href=\".*\">(?<name>.*.jpg)</a>");
        List<string> links = new List<string>();
        using (var reader = new StreamReader(response.GetResponseStream()))
        {
            string result = reader.ReadToEnd();

            MatchCollection matches = regex.Matches(result);
            if (matches.Count == 0)
            {
                Debug.Log("parse failed.");

            }

            foreach (Match match in matches)
            {
                if (!match.Success) { continue; }
                links.Add((match.Groups["name"]).ToString());
            }
        }

        for (int x = 0; x < links.Count; x++)
        {
            Images image = new Images();
            image.setLink(links[x]);

            UnityWebRequest www = UnityWebRequestTexture.GetTexture("http://134.209.234.39/games/" + links[x]);
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }

            else
            {
                Texture2D myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                image.setTexture(myTexture);
                Manager.images.Add(image);

            }
        }
        SceneManager.LoadScene("SampleScene");
    }

    void Start()
    {
        StartCoroutine(GetTexture());
    }

}
