using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Курсовая_Севастюк_Сергей_Сергеевич__623п
{
    [Serializable]
    public class Car
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public int Age { get; set; }
        public int Price { get; set; }
        public string Characteristik { get; set; }
        string pathCar = @"C:\Users\sergey\Desktop\list2.txt";
        public Car(int id, string mark, int age, int price, string characteristik)
        {
            Id = id;
            Mark = mark;
            Age = age;
            Price = price;
            Characteristik = characteristik;
        }
        public void SaveList(List<Car> carsList)
        {
            string json = JsonConvert.SerializeObject(carsList);
            File.WriteAllText(pathCar, json);
        }
        public List<Car> ReadJsonCar()
        {
            string json = File.ReadAllText(pathCar);
            List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(json);
            return cars ?? new List<Car>();
        }
        public void RemoveCar(int id)
        {
            Car car = new Car(1, "MarkTest", 1996, 100, "ChTest");

            List<Car> allcar = ReadJsonCar();
            Car carremove = allcar.FirstOrDefault(u => u.Id == id);
            if (carremove != null)
            {
                allcar.Remove(carremove);
                SaveList(allcar);
                MessageBox.Show("Машина видалена!");
            }
        }
        public void NewCharacteristik(int iid, string newCharact)
        {
            List<Car> carList = JsonConvert.DeserializeObject<List<Car>>(File.ReadAllText(pathCar));
            Car carnewCharacter = carList.Find(car => car.Id == iid);
            if (carnewCharacter != null)
            {
                carnewCharacter.Characteristik = newCharact;
            }
            File.WriteAllText(pathCar, JsonConvert.SerializeObject(carList));
            MessageBox.Show("Характеристика додана!");
        }
        public override string ToString()
        {
            return $"ID: {Id} Mark: {Mark} Age: {Age}  Price: {Price}  Characteristik: {Characteristik}";
        }
    }
}
