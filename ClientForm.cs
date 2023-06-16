using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Курсовая_Севастюк_Сергей_Сергеевич__623п
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }
        public void RemoveVoidAddClient()
        {
            lblReestr.Visible = true;
            lblName.Visible = true;
            txtBName.Visible = true;
            lblSurname.Visible = true;
            txtBSurname.Visible = true;
            lblAge.Visible = true;
            txtBAge.Visible = true;
            lblNumberPhone.Visible = true;
            txtBNumberPhone.Visible = true;
            lblIdPassport.Visible = true;
            txtBNumberDrivarsLecense.Visible = true;
            butAddClient.Visible = true;
        }
        public void RemoveVoidBackCar()
        {
            lblIdClientBackCar.Visible = true;
            txtBIDClientBack.Visible = true;
            lblBackCar.Visible = true;
            lblBackID.Visible = true;
            txtBBackID.Visible = true;
            lblBackCharacter.Visible = true;
            txtBBackCharacter.Visible = true;
            butBackCarClient.Visible = true;
        }
        public void RemoveVoidOplata()
        {
            lblNumDClientOrenda.Visible = true;
            txtBNumDClientOrenda.Visible = true;
            lblOplata.Visible = true;
            lblIDCarOplata.Visible = true;
            txtBIDOrenda.Visible = true;
            lblOrendaHoursOplata.Visible = true;
            txtBCountHoursOplata.Visible = true;
            lblResSumOplata.Visible = true;
            txtBSumOplata.Visible = true;
            butOrenda.Visible = true;
            lblNumCard.Visible = true;
            txtNumberCard.Visible = true;
        }
        List<Car> carListOrenda = new List<Car>();
        List<Client> clientList = new List<Client>();
        string pathCar = @"C:\Users\sergey\Desktop\list2.txt";
        string pathClient = @"C:\Users\sergey\Desktop/listClient.txt";
        string pathOrenda = @"C:\Users\sergey\Desktop\carOrenda.txt";
        private void butAddClient_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtBName.Text;
                string surname = txtBSurname.Text;
                int age = int.Parse(txtBAge.Text);
                int numberPhone = int.Parse(txtBNumberPhone.Text);
                int numberDriversLicense = int.Parse(txtBNumberDrivarsLecense.Text);
                Client client = new Client(name, surname, age, numberPhone, numberDriversLicense);
                clientList.Add(client);
                string json = JsonConvert.SerializeObject(clientList);
                File.WriteAllText(pathClient, json);
                MessageBox.Show("Реєстрація пройшла успішно!");
            }
            catch
            {
                MessageBox.Show("Виникла помилка при реєстрації");
            }
            finally
            {
                txtBAge.Clear();
                txtBName.Clear();
                txtBNumberDrivarsLecense.Clear();
                txtBNumberPhone.Clear();
                txtBSurname.Clear();
            }
        }

        private void butOrenda_Click(object sender, EventArgs e)
        {
            Client client1 = new Client("NameTest", "SurnameTest", 20, 12345678, 12345678);
            client1.OrendaClient(int.Parse(txtBNumDClientOrenda.Text), txtNumberCard.Text, int.Parse(txtBIDOrenda.Text));
            txtBIDOrenda.Clear();
            txtBCountHoursOplata.Clear();
            txtBNumDClientOrenda.Clear();
            txtBSumOplata.Clear();
            txtNumberCard.Clear();
        }

        private void butBackCarClient_Click(object sender, EventArgs e)
        {
            Client client1 = new Client("NameTest", "SurnameTest", 20, 12345678, 12345678);
            client1.BackCarClient(int.Parse(txtBIDClientBack.Text), int.Parse(txtBBackID.Text), txtBBackCharacter.Text);
        }


        private void butShowCarClient_Click(object sender, EventArgs e)//NO SHOW
        {
            LessorForm lessorForm = new LessorForm();
            lessorForm.ShowCarInStockLessor();
        }

        public int price;
        private void txtBCountHoursOplata_TextChanged(object sender, EventArgs e)
        {
            Car car = new Car(1, "MarkTest", 1996, 100, "ChTest");
            List<Car> carList = JsonConvert.DeserializeObject<List<Car>>(File.ReadAllText(pathCar));
            int hour = 0;
            if (int.TryParse(txtBCountHoursOplata.Text, out hour))
            {
                Car carPriceHour = carList.Find(cars => car.Id == int.Parse(txtBIDOrenda.Text));
                if (carPriceHour != null)
                {
                    LessorForm lessorForm = new LessorForm();
                    price = carPriceHour.Price * hour;
                    txtBSumOplata.Text = price.ToString();
                    List<Car> allcar = car.ReadJsonCar();
                    carListOrenda.Add(carPriceHour);
                    string json = JsonConvert.SerializeObject(carListOrenda);
                    File.WriteAllText(pathOrenda, json);
                    allcar.Remove(carPriceHour);//НЕ УДАЛЯЕТ
                    car.SaveList(allcar);
                }
            }
        }

        private void txtNumberCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            char inputOnlyNumb = e.KeyChar;//e.KeyChar программа заносит в нашу переменную символ введенной клавиши
            if (!Char.IsDigit(inputOnlyNumb))//если символ из переменной number не относится к категории десятичных цифр
            {
                e.Handled = true;//тогда не обрабатывать введенный символ 
                MessageBox.Show("Номер картки \nМожна вводити тільки цифри");
            }


        }

        private void txtBNumberDrivarsLecense_KeyPress(object sender, KeyPressEventArgs e)
        {
            char inputOnlyNumb = e.KeyChar;//e.KeyChar программа заносит в нашу переменную символ введенной клавиши
            if (!Char.IsDigit(inputOnlyNumb))//если символ из переменной number не относится к категории десятичных цифр
            {
                e.Handled = true;//тогда не обрабатывать введенный символ 
                MessageBox.Show("Номер водійського посвідчення \nМожна вводити тільки цифри");
            }

        }

        private void txtBNumberPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char inputOnlyNumb = e.KeyChar;//e.KeyChar программа заносит в нашу переменную символ введенной клавиши
            if (!Char.IsDigit(inputOnlyNumb))//если символ из переменной number не относится к категории десятичных цифр
            {
                e.Handled = true;//тогда не обрабатывать введенный символ 
                MessageBox.Show("Номер телефону \nМожна вводити тільки цифри");
            }
        }

        private void txtBAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            char inputOnlyNumb = e.KeyChar;//e.KeyChar программа заносит в нашу переменную символ введенной клавиши
            if (!Char.IsDigit(inputOnlyNumb))//если символ из переменной number не относится к категории десятичных цифр
            {
                e.Handled = true;//тогда не обрабатывать введенный символ 
                MessageBox.Show("Вік клієнту \nМожна вводити тільки цифри");
            }
        }

        private void txtBNumberDrivarsLecense_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                var selectionStart = txtBNumberDrivarsLecense.SelectionStart;
                if (txtBNumberDrivarsLecense.SelectionLength > 0)
                {
                    txtBNumberDrivarsLecense.Text = txtBNumberDrivarsLecense.Text.Substring(0, selectionStart) + txtBNumberDrivarsLecense.Text.Substring(selectionStart + txtBNumberDrivarsLecense.SelectionLength);
                    txtBNumberDrivarsLecense.SelectionStart = selectionStart;
                }
                else if (selectionStart > 0)
                {
                    txtBNumberDrivarsLecense.Text = txtBNumberDrivarsLecense.Text.Substring(0, selectionStart - 1) + txtBNumberDrivarsLecense.Text.Substring(selectionStart);
                    txtBNumberDrivarsLecense.SelectionStart = selectionStart - 1;
                }

                e.Handled = true;
            }
        }
        private void txtBNumberPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                var selectionStart = txtBNumberPhone.SelectionStart;
                if (txtBNumberPhone.SelectionLength > 0)
                {
                    txtBNumberPhone.Text = txtBNumberPhone.Text.Substring(0, selectionStart) + txtBNumberPhone.Text.Substring(selectionStart + txtBNumberPhone.SelectionLength);
                    txtBNumberPhone.SelectionStart = selectionStart;
                }
                else if (selectionStart > 0)
                {
                    txtBNumberPhone.Text = txtBNumberPhone.Text.Substring(0, selectionStart - 1) + txtBNumberPhone.Text.Substring(selectionStart);
                    txtBNumberPhone.SelectionStart = selectionStart - 1;
                }

                e.Handled = true;
            }
        }

        private void txtBAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                var selectionStart = txtBAge.SelectionStart;
                if (txtBAge.SelectionLength > 0)
                {
                    txtBAge.Text = txtBNumberPhone.Text.Substring(0, selectionStart) + txtBAge.Text.Substring(selectionStart + txtBAge.SelectionLength);
                    txtBAge.SelectionStart = selectionStart;
                }
                else if (selectionStart > 0)
                {
                    txtBAge.Text = txtBAge.Text.Substring(0, selectionStart - 1) + txtBAge.Text.Substring(selectionStart);
                    txtBAge.SelectionStart = selectionStart - 1;
                }

                e.Handled = true;
            }
        }

        private void txtBNumDClientOrenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                var selectionStart = txtBNumDClientOrenda.SelectionStart;
                if (txtBNumDClientOrenda.SelectionLength > 0)
                {
                    txtBNumDClientOrenda.Text = txtBNumDClientOrenda.Text.Substring(0, selectionStart) + txtBNumDClientOrenda.Text.Substring(selectionStart + txtBNumDClientOrenda.SelectionLength);
                    txtBNumDClientOrenda.SelectionStart = selectionStart;
                }
                else if (selectionStart > 0)
                {
                    txtBNumDClientOrenda.Text = txtBNumDClientOrenda.Text.Substring(0, selectionStart - 1) + txtBNumDClientOrenda.Text.Substring(selectionStart);
                    txtBNumDClientOrenda.SelectionStart = selectionStart - 1;
                }

                e.Handled = true;
            }
        }

        private void txtBNumDClientOrenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            char inputOnlyNumb = e.KeyChar;//e.KeyChar программа заносит в нашу переменную символ введенной клавиши
            if (!Char.IsDigit(inputOnlyNumb))//если символ из переменной number не относится к категории десятичных цифр
            {
                e.Handled = true;//тогда не обрабатывать введенный символ 
                MessageBox.Show("Номер водійського посвідчення \nМожна вводити тільки цифри");
            }
        }

        private void txtBCountHoursOplata_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                var selectionStart = txtBCountHoursOplata.SelectionStart;
                if (txtBCountHoursOplata.SelectionLength > 0)
                {
                    txtBCountHoursOplata.Text = txtBCountHoursOplata.Text.Substring(0, selectionStart) + txtBCountHoursOplata.Text.Substring(selectionStart + txtBCountHoursOplata.SelectionLength);
                    txtBCountHoursOplata.SelectionStart = selectionStart;
                }
                else if (selectionStart > 0)
                {
                    txtBCountHoursOplata.Text = txtBCountHoursOplata.Text.Substring(0, selectionStart - 1) + txtBCountHoursOplata.Text.Substring(selectionStart);
                    txtBCountHoursOplata.SelectionStart = selectionStart - 1;
                }

                e.Handled = true;
            }
        }

        private void txtBCountHoursOplata_KeyPress(object sender, KeyPressEventArgs e)
        {
            char inputOnlyNumb = e.KeyChar;//e.KeyChar программа заносит в нашу переменную символ введенной клавиши
            if (!Char.IsDigit(inputOnlyNumb))//если символ из переменной number не относится к категории десятичных цифр
            {
                e.Handled = true;//тогда не обрабатывать введенный символ 
                MessageBox.Show("Кількість годин оренди авто \nМожна вводити тільки цифри");
            }
        }

        private void txtNumberCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                var selectionStart = txtNumberCard.SelectionStart;
                if (txtNumberCard.SelectionLength > 0)
                {
                    txtNumberCard.Text = txtNumberCard.Text.Substring(0, selectionStart) + txtNumberCard.Text.Substring(selectionStart + txtNumberCard.SelectionLength);
                    txtNumberCard.SelectionStart = selectionStart;
                }
                else if (selectionStart > 0)
                {
                    txtNumberCard.Text = txtNumberCard.Text.Substring(0, selectionStart - 1) + txtNumberCard.Text.Substring(selectionStart);
                    txtNumberCard.SelectionStart = selectionStart - 1;
                }

                e.Handled = true;
            }
        }

        private void txtBBackID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                var selectionStart = txtBBackID.SelectionStart;
                if (txtBBackID.SelectionLength > 0)
                {
                    txtBBackID.Text = txtBBackID.Text.Substring(0, selectionStart) + txtBBackID.Text.Substring(selectionStart + txtBBackID.SelectionLength);
                    txtBBackID.SelectionStart = selectionStart;
                }
                else if (selectionStart > 0)
                {
                    txtBBackID.Text = txtBBackID.Text.Substring(0, selectionStart - 1) + txtBBackID.Text.Substring(selectionStart);
                    txtBBackID.SelectionStart = selectionStart - 1;
                }

                e.Handled = true;
            }
        }

        private void txtBBackID_KeyPress(object sender, KeyPressEventArgs e)
        {
            char inputOnlyNumb = e.KeyChar;//e.KeyChar программа заносит в нашу переменную символ введенной клавиши
            if (!Char.IsDigit(inputOnlyNumb))//если символ из переменной number не относится к категории десятичных цифр
            {
                e.Handled = true;//тогда не обрабатывать введенный символ 
                MessageBox.Show("ID авто \nМожна вводити тільки цифри");
            }
        }

    }
}
