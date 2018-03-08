using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moteur;

namespace Tests
{
    [TestClass]
    public class TestsPositionMain
    {
        [TestMethod]
        public void TestPapierNominal()
        {
            Assert.AreEqual(
                "Papier", 
                new PositionMain().DeterminerPosition(
                    0.000f, 
                    0.122f, -0.989f, -0.080f));
        }
    }
}
