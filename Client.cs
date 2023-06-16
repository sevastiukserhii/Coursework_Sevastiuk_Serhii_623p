using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Курсовая_Севастюк_Сергей_Сергеевич__623п
{
    public class Client
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int NumberPhone { get; set; }
        public int NumberDriversLicense { get; set; }
        public Client(string name, string surname, int age, int numberPhone, int numberDrivaersLicense)
        {
            Name = name;
            Surname = surname;
            Age = age;
            NumberPhone = numberPhone;
            NumberDriversLicense = numberDrivaersLicense;
        }
        string pathCar = @"C:\Users\sergey\Desktop\list2.txt";
        string pathClient = @"C:\Users\sergey\Desktop/listClient.txt";
        string pathOrenda = @"C:\Users\sergey\Desktop\carOrenda.txt";
        string pathOrendaID = @"C:\Users\sergey\Desktop\carOrendaId.txt";
        public void SaveListClient(List<Client> clientist)
        {
            string json = JsonConvert.SerializeObject(clientist);
            File.WriteAllText(pathClient, json);
        }
        public List<Client> ReadJsonClient()
        {
            string json = File.ReadAllText(pathClient);
            List<Client> clients = JsonConvert.DeserializeObject<List<Client>>(json);
            return clients ?? new List<Client>();
        }
        Car car = new Car(1, "MarkTest", 1996, 100, "ChTest");
        public void BackCarClient(int NDClientBack, int idcarBack, string characteristiBack)
        {
            OrendaClass orendaClass = new OrendaClass(0, 0);
            List<Car> carListOrenda = JsonConvert.DeserializeObject<List<Car>>(File.ReadAllText(pathOrenda));
            List<Car> carOrenda = orendaClass.ReadJsonCarOrenda();
            List<OrendaClass> carListOrendaID = JsonConvert.DeserializeObject<List<OrendaClass>>(File.ReadAllText(pathOrendaID));
            List<OrendaClass> carIDFindOrenda = orendaClass.ReadJsonCarOrendaId();
            OrendaClass findClientNDBackCar = carIDFindOrenda.Find(client => client.NumberDriversLicensClient == NDClientBack);
            if (findClientNDBackCar != null)
            {
                Car carBack = carOrenda.Find(car => car.Id == idcarBack);
                if (carBack != null)
                {
                    List<Car> cars = car.ReadJsonCar();
                    cars.Add(carBack);

                    carBack.Characteristik = characteristiBack;

                    string json = JsonConvert.SerializeObject(cars);
                    File.WriteAllText(pathCar, json);

                    carIDFindOrenda.Remove(findClientNDBackCar);
                    carOrenda.Remove(carBack);

                    orendaClass.saveListOrendaId(carIDFindOrenda);
                    orendaClass.saveListOrendar(carOrenda);
                    MessageBox.Show("Машина повернена на автомайданчік");
                }
                else
                {
                    MessageBox.Show("Список авто порожній!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Немає такого номеру водійського посвідчення");
                return;
            }
        }

        public void OrendaClient(int numDClientOrenda, string numCardClient, int idCarOrenda)
        {
            Car car = new Car(1, "MarkTest", 1996, 100, "ChTest");
            OrendaClass orendaClass = new OrendaClass(0, 0);
            try
            {
                List<Client> clientList = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(pathClient));
                Client client = clientList.Find(clients => clients.NumberDriversLicense == numDClientOrenda);
                if (client == null)
                {
                    MessageBox.Show("Зареєструйтесь!!!");
                }
                else
                {
                    orendaClass.NumberDriversLicensClient = client.NumberDriversLicense;
                }
            }
            catch
            {
                MessageBox.Show("id клаєнта не може бути порожнім рядком або літерою");
            }
            if (numCardClient.Length == 8)
            {
                List<Car> carlist = JsonConvert.DeserializeObject<List<Car>>(File.ReadAllText(pathCar));
                List<Car> availableCars = car.ReadJsonCar();
                Car carFindId = availableCars.Find(cars => car.Id == idCarOrenda);
                if (carFindId != null)
                {
                    List<Car> allcarOrenda = orendaClass.ReadJsonCarOrenda();
                    allcarOrenda.Add(carFindId);
                    string json = JsonConvert.SerializeObject(allcarOrenda);
                    File.WriteAllText(pathOrenda, json);

                    orendaClass.IdCar = carFindId.Id;
                    List<OrendaClass> idUserAndCarOrenda = orendaClass.ReadJsonCarOrendaId();
                    idUserAndCarOrenda.Add(orendaClass);
                    string jsonId = JsonConvert.SerializeObject(idUserAndCarOrenda);
                    File.WriteAllText(pathOrendaID, jsonId);

                    availableCars.Remove(carFindId);
                    car.SaveList(availableCars);
                    MessageBox.Show($"Авто орендовано!");
                }
                else
                {
                    MessageBox.Show("Список машин пустий");
                }

            }
            else if (numCardClient.Length < 8 || numCardClient.Length > 8)
            {
                MessageBox.Show("Помилковий номер картки");
            }
        }
        public override string ToString()
        {
            return $"м'я: {Name} Прізвище: {Surname}  Скільки років: {Age}  Номер телефону: {NumberPhone}  Номер водійського посвідчення: {NumberDriversLicense}";
        }
    }
}
