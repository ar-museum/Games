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
using Assets.Scripts.AR_TEAM.Http;

namespace Assets.Scripts.AR_TEAM.Http
{
    public class CustomCertificateHandler : CertificateHandler
    {
        protected override bool ValidateCertificate(byte[] certificateData)
        {
            return true;
        }
    }
}
public class DragLoading : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;
    List<string> DiskPaths { get; set; }

    public IEnumerator DownloadData(string url, string pathOnDisk)
    {
        Debug.Log(url);
        Debug.Log(pathOnDisk);
        var request = new UnityWebRequest(url, "GET");
        request.downloadHandler = new DownloadHandlerFile(pathOnDisk);
        request.certificateHandler = new CustomCertificateHandler();

        yield return request.SendWebRequest();
        if (request.isNetworkError||request.isHttpError)
        {
            Debug.Log(request.error);
        }
    }

    IEnumerator DownloadAllPhotos()
    {
        var stringBase = "https://armuseum.ml/uploads/photo/dragndrop/MuzeuldeStiinta/";
        WebRequest request = WebRequest.Create(stringBase);
        WebResponse response = request.GetResponse();
        Regex regex = new Regex("<a href=\".*\">(?<name>.*.jpg)</a>");
        List<string> photos = new List<string>();
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
                
                photos.Add((match.Groups["name"]).ToString());
                Debug.Log(photos[photos.Count-1]);
            }
        }


        DiskPaths = new List<string>();
        int j = 0;
        foreach (var i in photos)
        {
            if (j % 4 == 0)
                text.GetComponentInChildren<TextMeshProUGUI>().text = "Loading";
            else text.GetComponentInChildren<TextMeshProUGUI>().text = text.GetComponentInChildren<TextMeshProUGUI>().text + ".";
            var baseName = $"{i}";j++;
            Manager.names.Add($"{i}"); ;
            Debug.Log($"{i}");
            var diskPath = $"{Application.persistentDataPath}/{baseName}";
            DiskPaths.Add(diskPath);
            yield return DownloadData($"{stringBase}/{baseName}", diskPath);
        }
    }

    IEnumerator GetTexture()
    {
        yield return DownloadAllPhotos();

        text.GetComponentInChildren<TextMeshProUGUI>().text = "Loading";
        int i = 0;
        foreach (var path in DiskPaths)
        {
            //Debug.Log(path);


            Images image = new Images();i++;
            image.setLink(path);

            WWW www = new WWW("file:///" + path);
            while (!www.isDone)
                yield return null;
            Texture2D myTexture = www.texture;
            //Debug.Log(myTexture.height);
            image.setTexture(myTexture);
            Manager.images.Add(image);

        }
        SceneManager.LoadScene("SampleScene");
    }

    void Start()
    {
        StartCoroutine(GetTexture());
    }

}
