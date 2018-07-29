using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using starshipStops;
using starshipStops.Model;

namespace UnitTestingProject
{
    [TestClass]
    public class UnitTestsStarship
    {
        [TestMethod]
        public void MillenniumFalcon_Empty()
        {
            // Arrange
            Starship nave = new Starship
            {
                MGLT = "75",
                Consumables = "2 months"
            };

            // Act
            nave.CalculateNoStops();
            int expected = 9;

            // Assert
            Assert.AreEqual(nave.NoStops, expected);
        }

        [TestMethod]
        public void MillenniumFalcon_Negative1()
        {
            // Arrange
            Starship nave = new Starship
            {
                MGLT = "75",
                Consumables = "2 months"
            };

            // Act
            nave.CalculateNoStops(-1);
            int expected = 0;

            // Assert
            Assert.AreEqual(nave.NoStops, expected);
        }

        [TestMethod]
        public void MillenniumFalcon_Zero()
        {
            // Arrange
            Starship nave = new Starship
            {
                MGLT = "75",
                Consumables = "2 months"
            };

            // Act
            nave.CalculateNoStops(0);
            int expected = 0;

            // Assert
            Assert.AreEqual(nave.NoStops, expected);
        }


        [TestMethod]
        public void MillenniumFalcon_Positive1()
        {
            // Arrange
            Starship nave = new Starship
            {
                MGLT = "75",
                Consumables = "2 months"
            };

            // Act
            nave.CalculateNoStops(1);
            int expected = 0;

            // Assert
            Assert.AreEqual(nave.NoStops, expected);
        }

        [TestMethod]
        public void MillenniumFalcon_100799()
        {
            // Arrange
            Starship nave = new Starship
            {
                MGLT = "75",
                Consumables = "2 months"
            };

            // Act
            nave.CalculateNoStops(100799);
            int expected = 0;

            // Assert
            Assert.AreEqual(nave.NoStops, expected);
        }


        [TestMethod]
        public void MillenniumFalcon_100800()
        {
            // Arrange
            Starship nave = new Starship
            {
                MGLT = "75",
                Consumables = "2 months"
            };

            // Act
            nave.CalculateNoStops(100800);
            int expected = 1;

            // Assert
            Assert.AreEqual(nave.NoStops, expected);
        }

        [TestMethod]
        public void MillenniumFalcon_100801()
        {
            // Arrange
            Starship nave = new Starship
            {
                MGLT = "75",
                Consumables = "2 months"
            };

            // Act
            nave.CalculateNoStops(100801);
            int expected = 1;

            // Assert
            Assert.AreEqual(nave.NoStops, expected);
        }

        [TestMethod]
        public void MillenniumFalcon_1000000()
        {
            // Arrange
            Starship nave = new Starship
            {
                MGLT = "75",
                Consumables = "2 months"
            };

            // Act
            nave.CalculateNoStops(1000000);
            int expected = 9;

            // Assert
            Assert.AreEqual(nave.NoStops, expected);
        }
    }
}
