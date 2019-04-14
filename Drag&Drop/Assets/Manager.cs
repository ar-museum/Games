using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject firstName, secondName, thirdName, fourthName, fifthName, 
        firstInput, secondInput, thirdInput, fourthInput, fifthInput, 
        firstPhoto, secondPhoto, thirdPhoto, fourthPhoto, fifthPhoto,
        verifyButton;

    public Vector2 firstInitialPos, secondInitialPos, thirdInitialPos, fourthInitialPos, fifthInitialPos;

    public Text scoreText;

    void Start()
    {
        firstInitialPos = firstName.transform.position;
        secondInitialPos = secondName.transform.position;
        thirdInitialPos = thirdName.transform.position;
        fourthInitialPos = fourthName.transform.position;
        fifthInitialPos = fifthName.transform.position;
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
    }
}
