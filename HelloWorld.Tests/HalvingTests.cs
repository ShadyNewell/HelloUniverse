using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorld.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        double original;
        List<double> halves;
        readonly Halving halving = new Halving(new DoSomethingElse());
                
        [TestMethod]
        public void UnassignedHalvesRaisesError()
        {
            // Arrange
            halves = null;

            // Act
            try
            {
                halving.HalfIt(original, halves);
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
            halving.HalfIt(original, halves);

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
            halving.HalfIt(original, halves);

            // Assert
            Assert.AreEqual(0.5, halves[0]);
        }

        [TestMethod]
        public void halvingStopsAtPoint001()
        {
            // Arrange
            halves = new List<double>();
            original = 0.002;

            // Act
            halving.HalfIt(original, halves);

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
            halving.HalfIt(original, halves);

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
            halving.HalfIt(original, halves);

            // Assert
            for (var index = 0; index < expectHalves.Count; index++)
            {
                var actual = halves[index];
                var expected = expectHalves[index];
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void OriginalOf1ProduceHalves()
        {
            // Arrange
            halves = new List<double>();
            original = 1;
            var expectHalves = new List<double>() { 0.5, 0.25, 0.125, 0.0625, 0.03125, 0.015625, 0.0078125, 0.00390625, 0.001953125};

            // Act
            halving.HalfIt(original, halves);

            // Assert
            for (var index = 0; index < expectHalves.Count; index++)
            {
                var actual = halves[index];
                var expected = expectHalves[index];
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void OriginalOf0ProduceHalves()
        {
            // Arrange
            halves = new List<double>();
            original = 0;
            var expectHalves = new List<double>() {};

            // Act
            halving.HalfIt(original, halves);

            // Assert
            for (var index = 0; index < expectHalves.Count; index++)
            {
                var actual = halves[index];
                var expected = expectHalves[index];
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void OriginalOf2ProduceHalves()
        {
            // Arrange
            halves = new List<double>();
            original = 2;
            var expectHalves = new List<double>()
            {
                1,
                0.5,
                0.25,
                0.125,
                0.0625,
                0.03125,
                0.015625,
                0.0078125,
                0.00390625,
                0.001953125
            };
        }

        public void OriginalOf4ProduceHalves()
        {
            // Arrange
            halves = new List<double>();
            original = 4;
            var expectHalves = new List<double>() { 2, 1, 0.5, 0.25, 0.125, 0.0625, 0.03125, 0.015625, 0.0078125, 0.00390625, 0.001953125 };

            // Act
            halving.HalfIt(original, halves);

            // Assert
            for (var index = 0; index < expectHalves.Count; index++)
            {
                var actual = halves[index];
                var expected = expectHalves[index];
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void SquareOf0Gives0()
        {
            // Arrange
            // Act
            var result = halving.SquareIt(0);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SquareOfMinus1Gives1()
        {
            // Arrange
            // Act
            long result = halving.SquareIt(-1);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void SquareOf10Gives100()
        {
            // Arrange
            // Act
            var result = halving.SquareIt(10);

            // Assert
            Assert.AreEqual(100, result);
        }

        [TestMethod]
        public void SquareOf99999999999Gives1864711849423024129()
        {
            // Arrange
            // Act
            var result = halving.SquareIt(99999999999);

            // Assert
            Assert.AreEqual(1864711849423024129, result);
        }

        [TestMethod]
        public void FailingTest()
        {
            // Assert
            Assert.AreEqual(1, 0);
        }
    }
}
