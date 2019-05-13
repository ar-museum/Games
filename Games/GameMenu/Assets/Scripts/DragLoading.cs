using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class DragLoading : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;

    IEnumerator GetTexture()
    {
        text.GetComponentInChildren<TextMeshProUGUI>().text = "Loading";
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
            if (x % 4 == 0)
                text.GetComponentInChildren<TextMeshProUGUI>().text = "Loading";
            else text.GetComponentInChildren<TextMeshProUGUI>().text = text.GetComponentInChildren<TextMeshProUGUI>().text + ".";
            Images image = new Images();
            image.setLink(links[x]);

            UnityWebRequest www = UnityWebRequestTexture.GetTexture(uri + links[x]);
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
