using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ClientTest
{
    [TestClass]
    public class ClientTest1
    {
        [TestMethod]
        public void TestReestrationClient()
        {
            Client client = new Client("NameTest", "SurnameTest", 20, 05034956, 20000002);
            List<Client> clientList = new List<Client> { new Client("Stas", "Voroshka", 26, 09987654, 10000001) };
            client.SaveListClient(clientList);
            var savedClient = client.ReadJsonClient();
            Assert.AreEqual(clientList.Count, savedClient.Count);
            for (int i = 0; i < clientList.Count; i++)
            {
                Assert.AreEqual(clientList[i].Name, savedClient[i].Name);
                Assert.AreEqual(clientList[i].Surname, savedClient[i].Surname);
                Assert.AreEqual(clientList[i].Age, savedClient[i].Age);
                Assert.AreEqual(clientList[i].NumberPhone, savedClient[i].NumberPhone);
                Assert.AreEqual(clientList[i].NumberDriversLicense, savedClient[i].NumberDriversLicense);
            }
        }

        [TestMethod]
        public void TestBackCarClient()
        {
            string pathOrenda = @"C:\Users\nasty\Desktop\carOrenda.txt";
            Client client = new Client("NameTest", "SurNameTest", 0, 12345678, 12345678);
            Car car = new Car(1, "Mers", 1996, 100, "Normal");
            List<Client> clientList = new List<Client> { new Client("Stas", "Voroshka", 26, 09987654, 30000003) };
            List<Car> carListOrenda = new List<Car> { new Car(33, "BMW", 2020, 500, "Good condition"), new Car(2, "Mers", 1995, 100, "Normal") };
            //car.saveListOrendar(carListOrenda);
            File.WriteAllText(pathOrenda, JsonConvert.SerializeObject(carListOrenda));
            client.BackCarClient(30000003, 33, "STO");

            var savedCars = car.ReadJsonCar();
            Assert.AreEqual(2, savedCars[0].Id);//index car
            Assert.AreEqual("Mers", savedCars[0].Mark);
            Assert.AreEqual(1995, savedCars[0].Age);
            Assert.AreEqual(100, savedCars[0].Price);
            Assert.AreEqual("Normal", savedCars[0].Characteristik);
        }
        [TestMethod]
        public void TestOrendaCar()
        {
            OrendaClass orendaClass = new OrendaClass(1, 1);
            string pathCar = @"C:\Users\nasty\Desktop\list2.txt";
            string pathClient = @"C:\Users\nasty\Desktop/listClient.txt";
            Client client = new Client("Name", "Surname", 19, 12345678, 12345678);
            List<Client> clientList = new List<Client> { new Client("Stas", "Voroshka", 26, 09987654, 30000003) };
            File.WriteAllText(pathClient, JsonConvert.SerializeObject(clientList));
            // client.SaveListClient(clientList);
            List<Car> carList = new List<Car> { new Car(33, "BMW", 2020, 500, "Good condition"), new Car(2, "Mers", 1995, 100, "Normal") };
            File.WriteAllText(pathCar, JsonConvert.SerializeObject(carList));


            client.OrendaClient(30000003, "20202020", 33);

            var savedCarsOrenda = orendaClass.ReadJsonCarOrenda();
            Assert.AreEqual(33, savedCarsOrenda[0].Id);//index car
            Assert.AreEqual("BMW", savedCarsOrenda[0].Mark);
            Assert.AreEqual(2020, savedCarsOrenda[0].Age);
            Assert.AreEqual(500, savedCarsOrenda[0].Price);
            Assert.AreEqual("Good condition", savedCarsOrenda[0].Characteristik);
        }
    }

}
