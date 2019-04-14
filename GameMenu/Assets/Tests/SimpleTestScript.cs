using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class SimpleTestScript
    {
        // A Test behaves as an ordinary method
        [Test]
        public void SimpleSum()
        {
            int x = 5, y = 2;
            int sum = x + y;


            Assert.AreEqual(7, sum);
        }

        [Test]
        public void SimpleNumberOfCharacters()
        {
            string input = "ana";
            input += "aremere";

            Assert.AreEqual(10, input.Length);
        }

        [Test]
        public void SimpleMultiply()
        {
            double x = 1.5, y = 2.5;
            double result = x * y;

            Assert.AreEqual(3.25, result);
        }
    }
}
