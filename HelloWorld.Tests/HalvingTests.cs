﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorld;

namespace HelloWorld.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        double original;
        List<double> halves;
                
        [TestMethod]
        public void UnassignedHalvesRaisesError()
        {
            // Arrange
            halves = null;

            // Act
            try
            {
                Halving.HalfIt(original, ref halves);
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentNullException ae)
            {
                Assert.AreEqual("halves must be assigned before use of this method\r\nParameter name: halves", ae.Message);
            }
            catch (Exception e)
            {
                Assert.Fail(
                     string.Format("Unexpected exception of type {0} caught: {1}",
                                    e.GetType(), e.Message)
                );
            }
        }
        
        [TestMethod]
        public void OriginalOfZeroDoesNotProduceHalves()
        {
            // Arrange
            halves = new List<double>();
            original = 0;
            
            // Act
            Halving.HalfIt(original, ref halves);

            // Assert
            Assert.AreEqual(0, halves.Count);            
        }

        [TestMethod]
        public void OriginalOf1ProducesHalf()
        {
            // Arrange
            halves = new List<double>();
            original = 1;

            // Act
            Halving.HalfIt(original, ref halves);

            // Assert
            Assert.AreEqual(0.5, halves[0]);
        }

        [TestMethod]
        public void HalvingStopsAtPoint001()
        {
            // Arrange
            halves = new List<double>();
            original = 0.002;

            // Act
            Halving.HalfIt(original, ref halves);

            // Assert
            Assert.AreEqual(0, halves.Count);
        }

        [TestMethod]
        public void LargeOriginalProduceHalves()
        {
            // Arrange
            halves = new List<double>();
            original = 10;

            // Act
            Halving.HalfIt(original, ref halves);

            // Assert
            Assert.IsTrue(halves.Count > 5);
        }

        [TestMethod]
        public void OriginalOf10ProduceHalves()
        {
            // Arrange
            halves = new List<double>();
            original = 10;
            var expectHalves = new List<double>() { 5.0, 2.5, 1.25, 0.625, 0.3125, 0.15625, 0.078125, 0.0390625, 0.01953125, 0.009765625, 0.0048828125, 0.00244140625, 0.001220703125};

            // Act
            Halving.HalfIt(original, ref halves);

            // Assert
            for (var index = 0; index < expectHalves.Count; index++)
            {
                var actual = halves[index];
                var expected = expectHalves[index];
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
