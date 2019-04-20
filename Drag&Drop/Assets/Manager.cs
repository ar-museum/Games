using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Manager : MonoBehaviour
{
    public GameObject firstName, secondName, thirdName, fourthName, fifthName, 
        firstInput, secondInput, thirdInput, fourthInput, fifthInput, 
        firstPhoto, secondPhoto, thirdPhoto, fourthPhoto, fifthPhoto,
        verifyButton;

    public Vector2 firstInitialPos, secondInitialPos, thirdInitialPos, fourthInitialPos, fifthInitialPos, temp;

    Vector2[] namePositionArray = new[] { new Vector2(Screen.width/2 + Screen.width/4.5f, Screen.height/2 - Screen.height/2.5f),
        new Vector2(Screen.width / 2 , Screen.height / 2 - Screen.height/4),
        new Vector2(Screen.width / 2 - Screen.width / 3, Screen.height / 2 - Screen.height/7),
        new Vector2(Screen.width / 2 + Screen.width / 3, Screen.height / 2 - Screen.height/4.5f),
        new Vector2(Screen.width / 2 - Screen.width/2.5f , Screen.height / 2 - Screen.height/3) };

    Vector2[] photoPositionArray = new[] { new Vector2(Screen.width / 2 - Screen.width / 2.7f, Screen.height/2 + Screen.height / 4.5f),
        new Vector2(Screen.width / 2 - Screen.width / 5.32f, Screen.height / 2 + Screen.height / 4.5f),
        new Vector2(Screen.width/2, Screen.height / 2 + Screen.height / 4.5f),
        new Vector2(Screen.width / 2 + Screen.width / 5.32f, Screen.height / 2 + Screen.height / 4.5f),
        new Vector2(Screen.width / 2 + Screen.width / 2.7f, Screen.height / 2 + Screen.height / 4.5f) };

    Vector2[] inputPositionArray = new[] { new Vector2(Screen.width / 2 - Screen.width / 2.7f, Screen.height/2),
        new Vector2(Screen.width / 2 - Screen.width / 5.32f, Screen.height / 2),
        new Vector2(Screen.width/2, Screen.height / 2),
        new Vector2(Screen.width / 2 + Screen.width / 5.32f, Screen.height / 2),
        new Vector2(Screen.width / 2 + Screen.width / 2.7f, Screen.height / 2) };

    public Text scoreText;

    void Start()
    {
        for(int i=0;i<5;i++)
        {
            int rnd = Random.Range(0,5);
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
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3);
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
        scoreText.text = score.ToString();
        StartCoroutine(Timer());
    }
}
