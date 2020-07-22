using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MarsRover.UnitTests
{
    [TestClass]
    public class MarsRoverActionTests
    {
        [TestMethod]
        public void MarsRoverAction_Case1()
        {
            MarsRoverAction action = new MarsRoverAction();
            string result = action.Action("5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM");

            Assert.AreEqual("1 3 N\r\n5 1 E", result);
        }

        [TestMethod]
        public void MarsRoverAction_Case2()
        {
            MarsRoverAction action = new MarsRoverAction();
            string result = action.Action("5 5", "0 0 N", "MMMMM", "3 3 E", "MMLMMLMMLMML");

            Assert.AreEqual("0 5 N\r\n3 3 E", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MarsRoverAction_IncorrectMarsPlateauInput()
        {
            MarsRoverAction action = new MarsRoverAction();
            action.Action("5 X", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MarsRoverAction_IncorrectRobotPositionInput()
        {
            MarsRoverAction action = new MarsRoverAction();
            action.Action("5 5", "1 2N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MarsRoverAction_IncorrectRobotCommandsInput()
        {
            MarsRoverAction action = new MarsRoverAction();
            action.Action("5 5", "1 2N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRMW");
        }
    }
}
