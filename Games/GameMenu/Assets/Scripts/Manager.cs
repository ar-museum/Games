using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Net;
using System.IO;

using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Images
{
    string link;
   Texture2D texture;

    public Texture2D getMyTexture()
    {
        return texture;
    }
    public void setLink(string link)
    {
        this.link = link;
    }
    public string getMyLink()
    {

        StringBuilder str = new StringBuilder(link);
        str[0] = char.ToUpper(str[0]);
        link = str.ToString();
        var thing = link.Split('/');

        return thing[thing.Length - 1].Substring(0, thing[thing.Length-1].Length-4);
    }
    public void setTexture(Texture2D texture)
    {
        this.texture = texture;
    }

}

public class Manager : MonoBehaviour
{
    public GameObject firstName, secondName, thirdName, fourthName, fifthName, firstInput, secondInput, thirdInput, fourthInput, fifthInput, verifyButton;
    [SerializeField]
    Image firstPhoto, secondPhoto, thirdPhoto, fourthPhoto, fifthPhoto;
    public Sprite[] icons;

    public static List<Images> images=new List<Images>();
    public static List<string> names = new List<string>();

    public Vector2 firstInitialPos, secondInitialPos, thirdInitialPos, fourthInitialPos, fifthInitialPos, temp;

    static Vector3[] namePositionArray;
    static Vector3[] photoPositionArray;
    static Vector3[] inputPositionArray;
    public TextMeshProUGUI scoreText;

    public static List<Images> getImages()
    {
        return images;
    }

    public  void setImage(Image  image1, Texture2D myTex)
    {
        Sprite phote = Sprite.Create(myTex, new Rect(0.0f, 0.0f, myTex.width, myTex.height), new Vector2(0.5f, 0.5f), 100.0f);
        image1.sprite = phote;
    }
    void Images()
    {
        images = images.OrderBy(x => Random.value).ToList();
        setImage(firstPhoto, images[0].getMyTexture()); firstName.GetComponentInChildren<Text>().text = images[0].getMyLink();
        setImage(secondPhoto, images[1].getMyTexture()); secondName.GetComponentInChildren<Text>().text = images[1].getMyLink();
        setImage(thirdPhoto, images[2].getMyTexture()); thirdName.GetComponentInChildren<Text>().text = images[2].getMyLink();
        setImage(fourthPhoto, images[3].getMyTexture()); fourthName.GetComponentInChildren<Text>().text = images[3].getMyLink();
        setImage(fifthPhoto, images[4].getMyTexture()); fifthName.GetComponentInChildren<Text>().text = images[4].getMyLink();
    }
    void Start()
    {
        Images();
        getInitialPositions();
        //Debug.Log(firstPhoto.name + " " + secondPhoto.name + " " + thirdPhoto.name + " " + fourthPhoto.name + " " + fifthPhoto.name + " ");
        for (int i = 0; i < 5; i++)
        {
            int rnd = Random.Range(0, 5);
            temp = namePositionArray[rnd];
            namePositionArray[rnd] = namePositionArray[i];
            namePositionArray[i] = temp;
        }
        //namePositionArray.OrderBy(x => Random.value).ToArray();
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
