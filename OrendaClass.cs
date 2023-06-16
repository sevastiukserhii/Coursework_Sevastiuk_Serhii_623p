using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Курсовая_Севастюк_Сергей_Сергеевич__623п
{
    public class OrendaClass
    {
            public int NumberDriversLicensClient { get; set; }
            public int IdCar { get; set; }
            string pathOrenda = @"C:\Users\sergey\Desktop\carOrenda.txt";
            string pathOrendaID = @"C:\Users\sergey\Desktop\carOrendaId.txt";
            public void saveListOrendar(List<Car> carListOrenda)
            {
                string json = JsonConvert.SerializeObject(carListOrenda);
                File.WriteAllText(pathOrenda, json);
            }
            public List<Car> ReadJsonCarOrenda()
            {
                string json = File.ReadAllText(pathOrenda);
                List<Car> carsOrenda = JsonConvert.DeserializeObject<List<Car>>(json);
                return carsOrenda ?? new List<Car>();
            }
            public OrendaClass(int numberDriversLicensClient, int idCar)
            {
                NumberDriversLicensClient = numberDriversLicensClient;
                IdCar = idCar;
            }
            public void saveListOrendaId(List<OrendaClass> orendaClass)
            {
                string json = JsonConvert.SerializeObject(orendaClass);
                File.WriteAllText(pathOrendaID, json);
            }
            public List<OrendaClass> ReadJsonCarOrendaId()
            {
                string json = File.ReadAllText(pathOrendaID);
                List<OrendaClass> carsOrendaID = JsonConvert.DeserializeObject<List<OrendaClass>>(json);
                return carsOrendaID ?? new List<OrendaClass>();
            }
            public override string ToString()
            {
                return $"Number Drivers License: {NumberDriversLicensClient} Id car: {IdCar}";
            }
        }

}
