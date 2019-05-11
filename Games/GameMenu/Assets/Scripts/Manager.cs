﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Net;
using System.IO;

using System.Text.RegularExpressions;
using System.Collections.Generic;

public class Manager : MonoBehaviour
{
    public GameObject firstName, secondName, thirdName, fourthName, fifthName, firstInput, secondInput, thirdInput, fourthInput, fifthInput, verifyButton;
    [SerializeField]
    Image firstPhoto, secondPhoto, thirdPhoto, fourthPhoto, fifthPhoto;
    public Sprite[] icons;
  

    public Vector2 firstInitialPos, secondInitialPos, thirdInitialPos, fourthInitialPos, fifthInitialPos, temp;

    static Vector3[] namePositionArray;
    static Vector3[] photoPositionArray;
    static Vector3[] inputPositionArray;
    public TextMeshProUGUI scoreText;
    
    IEnumerator GetTexture()
    {
        string uri = "http://134.209.234.39/games/";
        WebRequest request = WebRequest.Create(uri);
        WebResponse response = request.GetResponse();
        Regex regex = new Regex("<a href=\".*\">(?<name>.*.jpg)</a>");
        List<string> links = new List<string>();
        int numberofLinks = 0;
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
        for (int i = 0; i <5; i++)
        {
            Random rnd = new Random();
            int x = Random.Range(0, links.Count);
            
            UnityWebRequest www = UnityWebRequestTexture.GetTexture("http://134.209.234.39/games/"+links[x]);
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }

            else
            {
                Texture2D myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                if (i == 0) { setImage(firstPhoto, myTexture); firstName.GetComponentInChildren<Text>().text = links[x].Substring(0, links[x].Length - 4); }
                else if (i == 1) { setImage(secondPhoto, myTexture); secondName.GetComponentInChildren<Text>().text = links[x].Substring(0, links[x].Length - 4); }
                else if (i == 2) { setImage(thirdPhoto, myTexture); thirdName.GetComponentInChildren<Text>().text = links[x].Substring(0,links[x].Length-4); }
                else if (i == 3) { setImage(fourthPhoto, myTexture);fourthName.GetComponentInChildren<Text>().text = links[x].Substring(0, links[x].Length - 4); }
                else { setImage(fifthPhoto, myTexture);fifthName.GetComponentInChildren<Text>().text = links[x].Substring(0, links[x].Length - 4); }

            }
                    links.Remove(links[x]);
                }



                }
    public  void setImage(Image  image, Texture2D myTexture)
    {
        Sprite phote = Sprite.Create(myTexture, new Rect(0.0f, 0.0f, myTexture.width, myTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
        image.sprite = phote;
    }
    void Start()
    {
        StartCoroutine(GetTexture());
        getInitialPositions(); 
        for (int i = 0; i < 5; i++)
        {
            int rnd = Random.Range(0, 5);
            temp = namePositionArray[rnd];
            namePositionArray[rnd] = namePositionArray[i];
            namePositionArray[i] = temp;
        }
        firstName.transform.position = firstInitialPos = namePositionArray[0];
        secondName.transform.position = secondInitialPos = namePositionArray[1];
        thirdName.transform.position = thirdInitialPos = namePositionArray[2];
        fourthName.transform.position = fourthInitialPos = namePositionArray[3];
        fifthName.transform.position = fifthInitialPos = namePositionArray[4];
        for (int i = 0; i < 5; i++)
        {
            int rnd = Random.Range(0, 5);
            temp = photoPositionArray[rnd];
            photoPositionArray[rnd] = photoPositionArray[i];
            photoPositionArray[i] = temp;

            temp = inputPositionArray[rnd];
            inputPositionArray[rnd] = inputPositionArray[i];
            inputPositionArray[i] = temp;

        }
        firstPhoto.transform.position = photoPositionArray[0];
        secondPhoto.transform.position = photoPositionArray[1];
        thirdPhoto.transform.position = photoPositionArray[2];
        fourthPhoto.transform.position = photoPositionArray[3];
        fifthPhoto.transform.position = photoPositionArray[4];
        firstInput.transform.position = inputPositionArray[0];
        secondInput.transform.position = inputPositionArray[1];
        thirdInput.transform.position = inputPositionArray[2];
        fourthInput.transform.position = inputPositionArray[3];
        fifthInput.transform.position = inputPositionArray[4];
        firstInitialPos = firstName.transform.position;
        secondInitialPos = secondName.transform.position;
        thirdInitialPos = thirdName.transform.position;
        fourthInitialPos = fourthName.transform.position;
        fifthInitialPos = fifthName.transform.position;
    }
    public void set()
    {


        object[] loadedIcons = Resources.LoadAll("Textures", typeof(Sprite));
        for (int x = 0; x < loadedIcons.Length; x++)
        {
            Debug.Log(loadedIcons[x].ToString());
        }
        firstName.GetComponent<Text>().text = loadedIcons[0].ToString();
        secondName.GetComponent<Text>().text = loadedIcons[1].ToString();
        thirdName.GetComponent<Text>().text = loadedIcons[2].ToString();
        fourthName.GetComponent<Text>().text = loadedIcons[3].ToString();
        fifthName.GetComponent<Text>().text = loadedIcons[4].ToString();

        icons = new Sprite[loadedIcons.Length];
        for (int x = 0; x < loadedIcons.Length; x++)
        {
            icons[x] = (Sprite)loadedIcons[x];

        }
        firstPhoto.sprite = icons[0];
        secondPhoto.sprite = icons[1];
        thirdPhoto.sprite = icons[2];
        fourthPhoto.sprite = icons[3];
        fifthPhoto.sprite = icons[4];

        // Debug.Log(loadedIcons.Length);
    }

    public void getInitialPositions()
    {
        photoPositionArray = new[] { firstPhoto.transform.position,
        secondPhoto.transform.position,
        thirdPhoto.transform.position,
        fourthPhoto.transform.position,
        fifthPhoto.transform.position};

        namePositionArray = new[] { firstName.transform.position,
        secondName.transform.position,
        thirdName.transform.position,
        fourthName.transform.position,
        fifthName.transform.position};

        inputPositionArray = new[] { firstInput.transform.position,
        secondInput.transform.position,
        thirdInput.transform.position,
        fourthInput.transform.position,
        fifthInput.transform.position};
    }

    public void DragFirst()
    {
        firstName.transform.position = Input.mousePosition;
    }

    public void DragSecond()
    {
        secondName.transform.position = Input.mousePosition;
    }
    
    public void DragThird()
    {
        thirdName.transform.position = Input.mousePosition;
    }

    public void DragFourth()
    {
        fourthName.transform.position = Input.mousePosition;
    }

    public void DragFifth()
    {
        fifthName.transform.position = Input.mousePosition;
    }

    public void DropFirst()
    {
        float distance = Vector3.Distance(firstName.transform.position, firstInput.transform.position);
        if (distance < 50)
            firstName.transform.position = firstInput.transform.position;
        else
        {
            distance = Vector3.Distance(firstName.transform.position, secondInput.transform.position);
            if (distance < 50)
                firstName.transform.position = secondInput.transform.position;
            else
            {
                distance = Vector3.Distance(firstName.transform.position, thirdInput.transform.position);
                if (distance < 50)
                    firstName.transform.position = thirdInput.transform.position;
                else
                {
                    distance = Vector3.Distance(firstName.transform.position, fourthInput.transform.position);
                    if (distance < 50)
                        firstName.transform.position = fourthInput.transform.position;
                    else
                    {
                        distance = Vector3.Distance(firstName.transform.position, fifthInput.transform.position);
                        if (distance < 50)
                            firstName.transform.position = fifthInput.transform.position;
                        else firstName.transform.position = firstInitialPos;
                    }
                }
            }
        }
        if (firstName.transform.position == secondName.transform.position)
            secondName.transform.position = secondInitialPos;
        else if (firstName.transform.position == thirdName.transform.position)
            thirdName.transform.position = thirdInitialPos;
        else if (firstName.transform.position == fourthName.transform.position)
            fourthName.transform.position = fourthInitialPos;
        else if (firstName.transform.position == fifthName.transform.position)
            fifthName.transform.position = fifthInitialPos;
    }

    public void DropSecond()
    {
        float distance = Vector3.Distance(secondName.transform.position, secondInput.transform.position);
        if (distance < 50)
            secondName.transform.position = secondInput.transform.position;
        else
        {
            distance = Vector3.Distance(secondName.transform.position, firstInput.transform.position);
            if (distance < 50)
                secondName.transform.position = firstInput.transform.position;
            else
            {
                distance = Vector3.Distance(secondName.transform.position, thirdInput.transform.position);
                if (distance < 50)
                    secondName.transform.position = thirdInput.transform.position;
                else
                {
                    distance = Vector3.Distance(secondName.transform.position, fourthInput.transform.position);
                    if (distance < 50)
                        secondName.transform.position = fourthInput.transform.position;
                    else
                    {
                        distance = Vector3.Distance(secondName.transform.position, fifthInput.transform.position);
                        if (distance < 50)
                            secondName.transform.position = fifthInput.transform.position;
                        else secondName.transform.position = secondInitialPos;
                    }
                }
            }
        }
        if (secondName.transform.position == firstName.transform.position)
            firstName.transform.position = firstInitialPos;
        else if (secondName.transform.position == thirdName.transform.position)
            thirdName.transform.position = thirdInitialPos;
        else if (secondName.transform.position == fourthName.transform.position)
            fourthName.transform.position = fourthInitialPos;
        else if (secondName.transform.position == fifthName.transform.position)
            fifthName.transform.position = fifthInitialPos;
    }

    public void DropThird()
    {
        float distance = Vector3.Distance(thirdName.transform.position, thirdInput.transform.position);
        if (distance < 50)
            thirdName.transform.position = thirdInput.transform.position;
        else
        {
            distance = Vector3.Distance(thirdName.transform.position, secondInput.transform.position);
            if (distance < 50)
                thirdName.transform.position = secondInput.transform.position;
            else
            {
                distance = Vector3.Distance(thirdName.transform.position, firstInput.transform.position);
                if (distance < 50)
                    thirdName.transform.position = firstInput.transform.position;
                else
                {
                    distance = Vector3.Distance(thirdName.transform.position, fourthInput.transform.position);
                    if (distance < 50)
                        thirdName.transform.position = fourthInput.transform.position;
                    else
                    {
                        distance = Vector3.Distance(thirdName.transform.position, fifthInput.transform.position);
                        if (distance < 50)
                            thirdName.transform.position = fifthInput.transform.position;
                        else thirdName.transform.position = thirdInitialPos;
                    }
                }
            }
        }
        if (thirdName.transform.position == secondName.transform.position)
            secondName.transform.position = secondInitialPos;
        else if (thirdName.transform.position == firstName.transform.position)
            firstName.transform.position = firstInitialPos;
        else if (thirdName.transform.position == fourthName.transform.position)
            fourthName.transform.position = fourthInitialPos;
        else if (thirdName.transform.position == fifthName.transform.position)
            fifthName.transform.position = fifthInitialPos;
    }

    public void DropFourth()
    {
        float distance = Vector3.Distance(fourthName.transform.position, fourthInput.transform.position);
        if (distance < 50)
            fourthName.transform.position = fourthInput.transform.position;
        else
        {
            distance = Vector3.Distance(fourthName.transform.position, secondInput.transform.position);
            if (distance < 50)
                fourthName.transform.position = secondInput.transform.position;
            else
            {
                distance = Vector3.Distance(fourthName.transform.position, thirdInput.transform.position);
                if (distance < 50)
                    fourthName.transform.position = thirdInput.transform.position;
                else
                {
                    distance = Vector3.Distance(fourthName.transform.position, firstInput.transform.position);
                    if (distance < 50)
                        fourthName.transform.position = firstInput.transform.position;
                    else
                    {
                        distance = Vector3.Distance(fourthName.transform.position, fifthInput.transform.position);
                        if (distance < 50)
                            fourthName.transform.position = fifthInput.transform.position;
                        else fourthName.transform.position = fourthInitialPos;
                    }
                }
            }
        }
        if (fourthName.transform.position == secondName.transform.position)
            secondName.transform.position = secondInitialPos;
        else if (fourthName.transform.position == thirdName.transform.position)
            thirdName.transform.position = thirdInitialPos;
        else if (fourthName.transform.position == firstName.transform.position)
            firstName.transform.position = firstInitialPos;
        else if (fourthName.transform.position == fifthName.transform.position)
            fifthName.transform.position = fifthInitialPos;
    }

    public void DropFifth()
    {
        float distance = Vector3.Distance(fifthName.transform.position, fifthInput.transform.position);
        if (distance < 50)
            fifthName.transform.position = fifthInput.transform.position;
        else
        {
            distance = Vector3.Distance(fifthName.transform.position, secondInput.transform.position);
            if (distance < 50)
                fifthName.transform.position = secondInput.transform.position;
            else
            {
                distance = Vector3.Distance(fifthName.transform.position, thirdInput.transform.position);
                if (distance < 50)
                    fifthName.transform.position = thirdInput.transform.position;
                else
                {
                    distance = Vector3.Distance(fifthName.transform.position, fourthInput.transform.position);
                    if (distance < 50)
                        fifthName.transform.position = fourthInput.transform.position;
                    else
                    {
                        distance = Vector3.Distance(fifthName.transform.position, firstInput.transform.position);
                        if (distance < 50)
                            fifthName.transform.position = firstInput.transform.position;
                        else fifthName.transform.position = fifthInitialPos;
                    }
                }
            }
        }
        if (fifthName.transform.position == secondName.transform.position)
            secondName.transform.position = secondInitialPos;
        else if (fifthName.transform.position == thirdName.transform.position)
            thirdName.transform.position = thirdInitialPos;
        else if (fifthName.transform.position == fourthName.transform.position)
            fourthName.transform.position = fourthInitialPos;
        else if (fifthName.transform.position == firstName.transform.position)
            firstName.transform.position = firstInitialPos;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3);
        scoreText.text = "Restarting game in 3...";
        yield return new WaitForSeconds(1);
        scoreText.text = "Restarting game in 2...";
        yield return new WaitForSeconds(1);
        scoreText.text = "Restarting game in 1...";
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CalculateScore()
    {
        int score = 0;
        if (firstInput.transform.position == firstName.transform.position)
            score++;
        if (secondInput.transform.position == secondName.transform.position)
            score++;
        if (thirdInput.transform.position == thirdName.transform.position)
            score++;
        if (fourthInput.transform.position == fourthName.transform.position)
            score++;
        if (fifthInput.transform.position == fifthName.transform.position)
            score++;
        scoreText.text = "Your score: " + score.ToString();
        StartCoroutine(Timer());
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
