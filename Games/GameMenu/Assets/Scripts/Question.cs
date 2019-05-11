using System;
using System.IO;
using manageQuestions;
using UnityEngine;
using meniu;
using System.Collections.Generic;

namespace manageQuestions
{
    [System.Serializable]
    public class Question
    {
        public Question()
        {

        }
        public string difficult;
        public string question;
        public string[] allAnswers;
        public string rightAnswer;

        public string getDificulty()
        {
            return difficult;
        }
        public string getQuestion()
        {
            return question;
        }

        public string[] getAllAnswers()
        {
            return allAnswers;
        }

        public string getRightAnswer()
        {
            return rightAnswer;
        }

        public void setQuestion(string q)
        {
            question = q;
        }

        public void setAllAnswers(string[] aa)
        {
            allAnswers = aa;
        }

        public void setRightAnswer(string a)
        {
            rightAnswer = a;
        }
        public void setDificulty(string a)
        {
            difficult = a;
        }
    }

    [Serializable]
    public class QuestionArray
    {
        public List<Question> questions;
    }

    [Serializable]
    public class JsonToObject
    {
        public QuestionArray loadJson()
        {
            Debug.Log(MenuManager.getDifficulty());
            string language = MenuManager.getLanguage();
            if (language == "Romanian")
            {
                TextAsset r = (TextAsset)Resources.Load("Stiinta/romana", typeof(TextAsset));
               
                string json = r.text;
                    //Debug.Log(json);
                    //List<Question> deserialized = JsonUtility.FromJson<List<Question>>(json);
                    QuestionArray deserialized = JsonUtility.FromJson<QuestionArray>(json);
                    
                    Debug.Log(deserialized.questions[0].getQuestion());
                    for (int i = 0; i < deserialized.questions.Count; i++)
                    {
                        if (deserialized.questions[i].getDificulty() != MenuManager.getDifficulty())
                        { deserialized.questions.RemoveAt(i); i--; }
                        else
                        {
                            //Debug.Log(deserialized.questions[i].question);
                        }
                    }
                    //Debug.Log(deserialized.questions.Count);
                    return deserialized;
                
            }
            else if (language == "English")
            {
                TextAsset r = (TextAsset)Resources.Load("Stiinta/engleza", typeof(TextAsset));

                string json = r.text;
               
                    //Debug.Log(json);
                    //List<Question> deserialized = JsonUtility.FromJson<List<Question>>(json);
                    QuestionArray deserialized = JsonUtility.FromJson<QuestionArray>(json);

                    //Debug.Log(deserialized.questions[0].getQuestion());
                    for (int i = 0; i < deserialized.questions.Count; i++)
                    {
                        if (deserialized.questions[i].getDificulty() != MenuManager.getDifficulty())
                        { deserialized.questions.RemoveAt(i); i--; }
                        else
                        {
                            //Debug.Log(deserialized.questions[i].question);
                        }
                    }
                    //Debug.Log(deserialized.questions.Count);
                    return deserialized;
                
            }
            else
            {
                TextAsset r = (TextAsset)Resources.Load("Stiinta/franceza", typeof(TextAsset));

                string json = r.text;
                //Debug.Log(json);
                //List<Question> deserialized = JsonUtility.FromJson<List<Question>>(json);
                QuestionArray deserialized = JsonUtility.FromJson<QuestionArray>(json);

                    //Debug.Log(deserialized.questions[0].getQuestion());
                    for (int i = 0; i < deserialized.questions.Count; i++)
                    {
                        if (deserialized.questions[i].getDificulty() != MenuManager.getDifficulty())
                        { deserialized.questions.RemoveAt(i); i--; }
                        else
                        {
                            //Debug.Log(deserialized.questions[i].question);
                        }
                    }
                    //Debug.Log(deserialized.questions.Count);
                    return deserialized;
                
            }
        }
    }
}

