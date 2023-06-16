using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Курсовая_Севастюк_Сергей_Сергеевич__623п
{
    public partial class LessorForm : Form
    {
        public LessorForm()
        {
            InitializeComponent();
        }
        public void RemoveModeAdd()
        {
            lblAddCarL.Visible = true;
            lblIDCarL.Visible = true;
            txtBIdCarL.Visible = true;
            lblMarkaCarL.Visible = true;
            txtBMarkaCarL.Visible = true;
            lblYearCar.Visible = true;
            txtBYearCar.Visible = true;
            lblPriceCar.Visible = true;
            txtBPriceCar.Visible = true;
            lblCharacterAddCar.Visible = true;
            txtBCharacterAddCar.Visible = true;
            butAddCarLessor.Visible = true;
            lblListCarL.Visible = true;
            listBoxCarLessor.Visible = true;
        }
        public void RemoveModeRemoveCar()
        {
            lblRemoveCAr.Visible = true;
            lblIndexCarRemove.Visible = true;
            txtBIndexCarRemove.Visible = true;
            butRemoveCarLessor.Visible = true;
            listBoxCarLessor.Visible = true;
        }
        public void RemoveModeNewCharacteristic()
        {
            lblIDCarCharacter.Visible = true;
            txtBMarkaCarCharacter.Visible = true;
            lblNewCharacter.Visible = true;
            txtBNewCharacter.Visible = true;
            butNewCharaterLessor.Visible = true;
        }
        public void RemoveModeListCarLessor()
        {
            lblListCarL.Visible = true;
            listBoxCarLessor.Visible = true;
        }
        public void RemoveModeListClientLessor()
        {
            butShowClientLessor.Visible = true;
            lblListClient.Visible = true;
            listBoxClient.Visible = true;
        }
        public void SaveToCar(List<Car> cars)
        {
            try
            {
                int id = int.Parse(txtBIdCarL.Text);
                string mark = txtBMarkaCarL.Text;
                int age = int.Parse(txtBYearCar.Text);
                int price = int.Parse(txtBPriceCar.Text);
                string characteristik = txtBCharacterAddCar.Text;
                Car car = new Car(id, mark, age, price, characteristik);
                carList.Add(car);
                string json = JsonConvert.SerializeObject(carList);
                File.WriteAllText(pathCar, json);
                MessageBox.Show("Машина додана!");
            }
            catch
            {
                MessageBox.Show("Машина додана!");
            }
        }
        public void ShowCarInStockLessor()
        {
            listBoxCarLessor.Items.Clear();
            string json = File.ReadAllText(pathCar);//PATHCAR AND LIST2->LISTCAR
            carList = JsonConvert.DeserializeObject<List<Car>>(json);
            // Add all cars to list box
            foreach (Car car in carList)
            {
                listBoxCarLessor.Items.Add(car);
                listBoxCarLessor.Items.ToString();
            }
            int lineCount = File.ReadAllText(pathCar).Count();
            if (lineCount == 0)
            {
                MessageBox.Show("Список авто в наявності порожній!");
            }
        }
        public void butRemoveCarLessor_Click(object sender, EventArgs e)
        {
            car.RemoveCar(int.Parse(txtBIndexCarRemove.Text));
        }

        private void butNewCharaterLessor_Click(object sender, EventArgs e)
        {
            car.NewCharacteristik(int.Parse(txtBMarkaCarCharacter.Text), txtBNewCharacter.Text);
        }

        private void butShowClientLessor_Click(object sender, EventArgs e)
        {
            listBoxClient.Items.Clear();
            string json = File.ReadAllText(pathClient);
            clientList = JsonConvert.DeserializeObject<List<Client>>(json);
            foreach (Client client in clientList)
            {
                listBoxClient.Items.Add(client);
                listBoxClient.Items.ToString();
            }
            int lineCount = File.ReadAllText(pathClient).Count();
            if (lineCount == 0)
            {
                MessageBox.Show("Список клієнтів порожній!");
            }
        }

        private void butListCarOrenda_Click(object sender, EventArgs e)
        {
            listBoxCarLessor.Items.Clear();
            string json = File.ReadAllText(pathOrenda);
            carList = JsonConvert.DeserializeObject<List<Car>>(json);
            // Add all cars to list box
            foreach (Car car in carListOrenda)
            {
                listBoxCarLessor.Items.Add(car);
                listBoxCarLessor.Items.ToString();
            }
            int lineCount = File.ReadAllText(pathOrenda).Count();
            if (lineCount == 0)
            {
                MessageBox.Show("Список орендованих машин порожній!");
            }
        }

        private void butList2CarOrenda_Click(object sender, EventArgs e)
        {
            SaveToCar(carList);
            txtBIdCarL.Clear();
            txtBMarkaCarL.Clear();
            txtBPriceCar.Clear();
            txtBYearCar.Clear();
            txtBCharacterAddCar.Clear();
        }
        string pathCar = @"C:\Users\sergey\Desktop\list2.txt";
        private List<Car> carList = new List<Car>();
        private List<Car> carListOrenda = new List<Car>();
        string pathOrenda = @"C:\Users\sergey\Desktop\carOrenda.txt";
        string pathClient = @"C:\Users\sergey\Desktop/listClient.txt";
        List<Client> clientList = new List<Client>();
        Car car = new Car(1, "MarkTest", 1996, 100, "ChTest");
        private void txtBIdCarL_KeyPress(object sender, KeyPressEventArgs e)
        {
            char inputOnlyNumb = e.KeyChar;//e.KeyChar программа заносит в нашу переменную символ введенной клавиши
            if (!Char.IsDigit(inputOnlyNumb))//если символ из переменной number не относится к категории десятичных цифр
            {
                e.Handled = true;//тогда не обрабатывать введенный символ 
                MessageBox.Show("Id авто \nМожна вводити тільки цифри");
            }
        }


        private void txtBYearCar_KeyPress(object sender, KeyPressEventArgs e)
        {
            char inputOnlyNumb = e.KeyChar;//e.KeyChar программа заносит в нашу переменную символ введенной клавиши
            if (!Char.IsDigit(inputOnlyNumb))//если символ из переменной number не относится к категории десятичных цифр
            {
                e.Handled = true;//тогда не обрабатывать введенный символ 
                MessageBox.Show("Рік випуску авто \nМожна вводити тільки цифри 1885-2023");
            }
        }

        private void txtBPriceCar_KeyPress(object sender, KeyPressEventArgs e)
        {
            char inputOnlyNumb = e.KeyChar;//e.KeyChar программа заносит в нашу переменную символ введенной клавиши
            if (!Char.IsDigit(inputOnlyNumb))//если символ из переменной number не относится к категории десятичных цифр
            {
                e.Handled = true;//тогда не обрабатывать введенный символ 

                MessageBox.Show("Ціна авто \nМожна вводити тільки цифри");
            }
        }

        private void txtBIdCarL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                var selectionStart = txtBIdCarL.SelectionStart;
                if (txtBIdCarL.SelectionLength > 0)
                {
                    txtBIdCarL.Text = txtBIdCarL.Text.Substring(0, selectionStart) + txtBIdCarL.Text.Substring(selectionStart + txtBIdCarL.SelectionLength);
                    txtBIdCarL.SelectionStart = selectionStart;
                }
                else if (selectionStart > 0)
                {
                    txtBIdCarL.Text = txtBIdCarL.Text.Substring(0, selectionStart - 1) + txtBIdCarL.Text.Substring(selectionStart);
                    txtBIdCarL.SelectionStart = selectionStart - 1;
                }

                e.Handled = true;
            }
        }

        private void txtBYearCar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                var selectionStart = txtBYearCar.SelectionStart;
                if (txtBYearCar.SelectionLength > 0)
                {
                    txtBYearCar.Text = txtBYearCar.Text.Substring(0, selectionStart) + txtBYearCar.Text.Substring(selectionStart + txtBYearCar.SelectionLength);
                    txtBYearCar.SelectionStart = selectionStart;
                }
                else if (selectionStart > 0)
                {
                    txtBYearCar.Text = txtBYearCar.Text.Substring(0, selectionStart - 1) + txtBYearCar.Text.Substring(selectionStart);
                    txtBYearCar.SelectionStart = selectionStart - 1;
                }

                e.Handled = true;
            }
        }

        private void txtBPriceCar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                var selectionStart = txtBPriceCar.SelectionStart;
                if (txtBPriceCar.SelectionLength > 0)
                {
                    txtBPriceCar.Text = txtBYearCar.Text.Substring(0, selectionStart) + txtBPriceCar.Text.Substring(selectionStart + txtBPriceCar.SelectionLength);
                    txtBPriceCar.SelectionStart = selectionStart;
                }
                else if (selectionStart > 0)
                {
                    txtBPriceCar.Text = txtBPriceCar.Text.Substring(0, selectionStart - 1) + txtBPriceCar.Text.Substring(selectionStart);
                    txtBPriceCar.SelectionStart = selectionStart - 1;
                }

                e.Handled = true;
            }
        }

        private void txtBMarkaCarCharacter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                var selectionStart = txtBMarkaCarCharacter.SelectionStart;
                if (txtBMarkaCarCharacter.SelectionLength > 0)
                {
                    txtBMarkaCarCharacter.Text = txtBMarkaCarCharacter.Text.Substring(0, selectionStart) + txtBMarkaCarCharacter.Text.Substring(selectionStart + txtBMarkaCarCharacter.SelectionLength);
                    txtBMarkaCarCharacter.SelectionStart = selectionStart;
                }
                else if (selectionStart > 0)
                {
                    txtBMarkaCarCharacter.Text = txtBMarkaCarCharacter.Text.Substring(0, selectionStart - 1) + txtBMarkaCarCharacter.Text.Substring(selectionStart);
                    txtBMarkaCarCharacter.SelectionStart = selectionStart - 1;
                }

                e.Handled = true;
            }
        }

        private void txtBIndexCarRemove_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                var selectionStart = txtBIndexCarRemove.SelectionStart;
                if (txtBIndexCarRemove.SelectionLength > 0)
                {
                    txtBIndexCarRemove.Text = txtBIndexCarRemove.Text.Substring(0, selectionStart) + txtBIndexCarRemove.Text.Substring(selectionStart + txtBIndexCarRemove.SelectionLength);
                    txtBIndexCarRemove.SelectionStart = selectionStart;
                }
                else if (selectionStart > 0)
                {
                    txtBIndexCarRemove.Text = txtBIndexCarRemove.Text.Substring(0, selectionStart - 1) + txtBIndexCarRemove.Text.Substring(selectionStart);
                    txtBIndexCarRemove.SelectionStart = selectionStart - 1;
                }

                e.Handled = true;
            }
        }

        private void txtBIndexCarRemove_KeyPress(object sender, KeyPressEventArgs e)//Id
        {
            char inputOnlyNumb = e.KeyChar;//e.KeyChar программа заносит в нашу переменную символ введенной клавиши
            if (!Char.IsDigit(inputOnlyNumb))//если символ из переменной number не относится к категории десятичных цифр
            {
                e.Handled = true;//тогда не обрабатывать введенный символ 
                MessageBox.Show("Id авто \nМожна вводити тільки цифри");
            }
        }

        private void txtBMarkaCarCharacter_KeyPress(object sender, KeyPressEventArgs e)//Id
        {
            char inputOnlyNumb = e.KeyChar;//e.KeyChar программа заносит в нашу переменную символ введенной клавиши
            if (!Char.IsDigit(inputOnlyNumb))//если символ из переменной number не относится к категории десятичных цифр
            {
                e.Handled = true;//тогда не обрабатывать введенный символ 
                MessageBox.Show("Id авто \nМожна вводити тільки цифри");
            }
        }

    }
}
/*
 ADD
// SaveToCar();
            //string mark = txtBMarkaCarL.Text;
            //int age = int.Parse(txtBYearCar.Text);
            //int price = int.Parse(txtBPriceCar.Text);
            //string characteristik = txtBCharacterAddCar.Text;
            //Car car = new Car(mark, age, price, characteristik);
            //carList.Add(car);
            //UpdateCarList(carList);





        public LessorForm(List<Car> carList)//konstruktor form
        {
            this.carList = carList;
            this.FormClosing += new FormClosingEventHandler(LessorForm_FormClosing);
        }
 string mark = txtBMarkaCarL.Text;
 int age = int.Parse(txtBYearCar.Text);
 int price = int.Parse(txtBPriceCar.Text);
 string characteristik = txtBCharacterAddCar.Text;
 Car car = new Car(mark, age, price, characteristik);
 carList.Add(new Car(mark, age, price, characteristik));
 listBoxCarLessor.Items.Add("Mark: " + car.Mark + "  Age: " + car.Age +
   "\nPrice:" + car.Price + "  Characteristik: " + car.Characteristik);
 UpdateCarList(carList);
 MessageBox.Show(car.ToString());
 this.Close();




DELETE
/*
            string path = @"C:\Users\nasty\Desktop\list.txt";
            using (StreamReader reader=new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    richTxtBCar.AppendText(reader.ReadLine());
                }
            }
            
            UpdateCarList(carList);
            MessageBox.Show(carList.Count.ToString());
            int indexRemove = int.Parse(txtBIndexCarRemove.Text);
            if (indexRemove >= 0 )
            {
                carList.RemoveAt(indexRemove);
                listBoxCarLessor.Items.RemoveAt(indexRemove);
                MessageBox.Show("Delete");
            }
            else
            {
                MessageBox.Show("Неправильний індекс авто!");
            }


public void saveListCar()
        {
            string path = @"C:\Users\nasty\Desktop\list.txt";
            FileStream file = new FileStream(path, FileMode.Append);
            StreamWriter streamWriter = new StreamWriter(file);
            streamWriter.WriteLine(carList.ToString());
            streamWriter.Close();
            file.Close();
            /*
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        listBoxCarLessor.Items.Add(line);
                    }
                }
            }
            */
