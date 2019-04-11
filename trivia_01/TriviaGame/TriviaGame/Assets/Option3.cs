using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using manageQuestions;
using System;



public class Option3 : MonoBehaviour
{
    public Button button;
    public List<string> answers = new List<string>();//variante de raspuns pentru intrebari, intrebarea i are ca varianta de raspuns raspunul i
    public int nrAnswers = 0;
    public List<string> right_answers = new List<string>();//raspunsurike corecte pentru fiecare intrebare
    JsonToObject deserializer = new JsonToObject();
    QuestionArray Answers;
    public void get_rightAnswers()
    {
        for (int i = 0; i < Answers.questions.Count; i++)
        {

            right_answers[i] = Answers.questions[i].getRightAnswer();
            //Debug.Log(questions[i]);
        }
    }
    public void getAnswers()
    {
        for (int i = 0; i < Answers.questions.Count; i++)
        {

            answers[i] = Answers.questions[i].getAllAnswers()[1];
            // Debug.Log(questions[i]);
        }
    }

    void Start()
    {
        Answers = deserializer.loadJson();
        get_rightAnswers();
        getAnswers();

        button = GetComponent<Button>();
        button.GetComponentInChildren<Text>().text = answers[0];

    }
    void Update()
    {

        if (HandleButton.clicked == true || HandleButton1.clicked == true || HandleButton2.clicked == true || HandleButton3.clicked == true)
        {
            button = GetComponent<Button>();
            if (button.GetComponentInChildren<Text>().text == right_answers[nrAnswers])
            {
                if(HandleButton2.clicked==true)
                Score.sc++;
            }
            button.GetComponentInChildren<Text>().text = answers[++nrAnswers];
        }

    }
}
