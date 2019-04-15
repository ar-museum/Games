using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using manageQuestions;

namespace Tests
{
    public class FirstTest
    {
        // A Test behaves as an ordinary method
        //Button b;
        [Test]
        public void FirstTestSimplePasses()
        {
            // Use the Assert class to test conditions
            Question q=new Question();
            q.setDificulty("easy");

            Assert.AreEqual("easy", q.difficult);
            //GameObject b = new GameObject();
            //b.GetComponentInChildren<Text>().text = "ceva";

            //Assert.AreEqual("ceva", b.GetComponentInChildren<Text>().text);

        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator FirstTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
