using System;
using System.IO;
using manageQuestions;
using System.Web.Script.Serialization;
using System.Collections.Generic;

namespace manageQuestions
{
    public class Question
    {
        public Question()
        {

        }

        public string question { get; set; }
        public string[] allAnswers { get; set; }
        public string rightAnswer { get; set; }

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

        public void setQQuestion(string q)
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
    }
}


public class JsonToObject
{
    public List<Question> LoadJson()
    {
        using (StreamReader r = new StreamReader("intrebari.json"))
        {
            string json = r.ReadToEnd();
            JavaScriptSerializer j = new JavaScriptSerializer();
            List<Question> deserialized = j.Deserialize<List<Question>>(json);
            return deserialized;
            /*foreach(Question q in deserialized)
            {
                Console.WriteLine(q.getQuestion());
                Console.Write("a)"); Console.WriteLine(q.getAllAnswers()[0]);
                Console.Write("b)"); Console.WriteLine(q.getAllAnswers()[1]);
                Console.Write("c)"); Console.WriteLine(q.getAllAnswers()[2]);
                Console.WriteLine();
            }*/
        }
    }
    /*static void Main()
    {
        JsonToObject op = new JsonToObject();
        op.LoadJson();
    }*/
}
