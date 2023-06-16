using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.ConstrainedExecution;

namespace CarTest
{
    [TestClass]
    public class CarTest1
    {
        // OrendaClass orendaClass = new OrendaClass(1,1);
        LessorForm lessorForm = new LessorForm();
        Car car = new Car(1, "Mers", 1996, 100, "Normal");
        [TestMethod]
        public void TestCarAdd()
        {
            Car car = new Car(100, "MarkTest", 1996, 100, "CHTest");
            List<Car> cars = new List<Car> { new Car(5, "Mers", 1995, 100, "Normal") };
            car.SaveList(cars);
            lessorForm.SaveToCar(cars);
            var savedCars = car.ReadJsonCar();
            Assert.AreEqual(cars.Count, savedCars.Count);
            for (int i = 0; i < cars.Count; i++)
            {
                Assert.AreEqual(cars[i].Id, savedCars[i].Id);
                Assert.AreEqual(cars[i].Mark, savedCars[i].Mark);
                Assert.AreEqual(cars[i].Age, savedCars[i].Age);
                Assert.AreEqual(cars[i].Price, savedCars[i].Price);
                Assert.AreEqual(cars[i].Characteristik, savedCars[i].Characteristik);
            }
        }
        [TestMethod]
        public void TestCarRemove()
        {
            List<Car> cars = new List<Car> { new Car(1, "BMW", 2020, 500, "Good condition"), new Car(2, "Mers", 1995, 100, "Normal") };
            car.SaveList(cars);

            car.RemoveCar(2);

            var savedCars = car.ReadJsonCar();
            Assert.AreEqual(1, savedCars.Count);
            Assert.AreEqual(1, savedCars[0].Id);
            Assert.AreEqual("BMW", savedCars[0].Mark);
            Assert.AreEqual(2020, savedCars[0].Age);
            Assert.AreEqual(500, savedCars[0].Price);
            Assert.AreEqual("Good condition", savedCars[0].Characteristik);
        }
        [TestMethod]
        public void TestCarNewCharacteristik()
        {
            List<Car> cars = new List<Car> { new Car(1, "BMW", 2020, 500, "Good condition"), new Car(2, "Mers", 1995, 100, "Normal") };
            car.SaveList(cars);
            car.NewCharacteristik(1, "STOSTO");
            var saveNewCharakter = car.ReadJsonCar();
            Assert.AreEqual(1, saveNewCharakter[0].Id);
            Assert.AreEqual("BMW", saveNewCharakter[0].Mark);
            Assert.AreEqual(2020, saveNewCharakter[0].Age);
            Assert.AreEqual(500, saveNewCharakter[0].Price);
            Assert.AreEqual("STOSTO", saveNewCharakter[0].Characteristik);
        }

    }
}
