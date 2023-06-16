using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая_Севастюк_Сергей_Сергеевич__623п
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            rbClient.Visible = true;
            rbLessor.Visible = true;
        }

        private void rbClient_CheckedChanged(object sender, EventArgs e)
        {
            //Видимість для клієнта
            butBackCarC.Visible = true;
            butOrendaC.Visible = true;
            butreestationC.Visible = true;
            butShowCarClient.Visible = true;
            //видимість для орендодавця
            butAddCarL.Visible = false;
            butRemoveCarl.Visible = false;
            butShowListClientL.Visible = false;
            butAddCharacterL.Visible = false;
        }

        private void butreestationC_Click(object sender, EventArgs e)
        {
            ClientForm clientForm = new ClientForm();
            clientForm.RemoveVoidAddClient();
            clientForm.ShowDialog();
        }

        private void butOrendaC_Click(object sender, EventArgs e)
        {
            ClientForm clientForm = new ClientForm();
            clientForm.RemoveVoidOplata();
            clientForm.ShowDialog();
        }

        private void butShowCarClient_Click(object sender, EventArgs e)
        {
            ClientForm clientForm = new ClientForm();
            clientForm.ShowDialog();
        }

        private void butBackCarC_Click(object sender, EventArgs e)
        {
            ClientForm clientForm = new ClientForm();
            clientForm.RemoveVoidBackCar();
            clientForm.ShowDialog();
        }
        private void ClirnForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Возвращение фокуса на форму1 после закрытия формы2
            this.Focus();
        }


        private void rbLessor_CheckedChanged(object sender, EventArgs e)
        {
            //Видимість для орендодавця
            butAddCarL.Visible = true;
            butRemoveCarl.Visible = true;
            butAddCharacterL.Visible = true;
            butShowListClientL.Visible = true;
            //Видимість для клієнта
            butreestationC.Visible = false;
            butOrendaC.Visible = false;
            butShowCarClient.Visible = false;
            butBackCarC.Visible = false;
        }

        private void butAddCarL_Click(object sender, EventArgs e)
        {
            LessorForm lessorForm = new LessorForm();
            lessorForm.RemoveModeAdd();
            lessorForm.ShowDialog();
        }

        private void butRemoveCarl_Click(object sender, EventArgs e)
        {
            LessorForm lessorForm = new LessorForm();
            lessorForm.RemoveModeRemoveCar();
            lessorForm.ShowDialog();
        }

        private void butAddCharacterL_Click(object sender, EventArgs e)
        {
            LessorForm lessorForm = new LessorForm();
            lessorForm.RemoveModeNewCharacteristic();
            lessorForm.ShowDialog();
        }

        private void butShowListClientL_Click(object sender, EventArgs e)
        {
            LessorForm lessorForm = new LessorForm();
            lessorForm.RemoveModeListClientLessor();
            lessorForm.ShowDialog();
        }
        private void LessorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Возвращение фокуса на форму1 после закрытия формы3
            this.Focus();
        }

    }
}
