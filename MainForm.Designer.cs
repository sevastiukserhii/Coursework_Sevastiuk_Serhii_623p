namespace Курсовая_Севастюк_Сергей_Сергеевич__623п
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbClient = new System.Windows.Forms.RadioButton();
            this.rbLessor = new System.Windows.Forms.RadioButton();
            this.butShowCarClient = new System.Windows.Forms.Button();
            this.butreestationC = new System.Windows.Forms.Button();
            this.butOrendaC = new System.Windows.Forms.Button();
            this.butBackCarC = new System.Windows.Forms.Button();
            this.butAddCarL = new System.Windows.Forms.Button();
            this.butRemoveCarl = new System.Windows.Forms.Button();
            this.butAddCharacterL = new System.Windows.Forms.Button();
            this.butShowListClientL = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbClient
            // 
            this.rbClient.AutoSize = true;
            this.rbClient.Location = new System.Drawing.Point(64, 38);
            this.rbClient.Name = "rbClient";
            this.rbClient.Size = new System.Drawing.Size(57, 17);
            this.rbClient.TabIndex = 0;
            this.rbClient.TabStop = true;
            this.rbClient.Text = "Клієнт";
            this.rbClient.UseVisualStyleBackColor = true;
            this.rbClient.CheckedChanged += new System.EventHandler(this.rbClient_CheckedChanged);
            // 
            // rbLessor
            // 
            this.rbLessor.AutoSize = true;
            this.rbLessor.Location = new System.Drawing.Point(322, 38);
            this.rbLessor.Name = "rbLessor";
            this.rbLessor.Size = new System.Drawing.Size(99, 17);
            this.rbLessor.TabIndex = 1;
            this.rbLessor.TabStop = true;
            this.rbLessor.Text = "Орендодавець";
            this.rbLessor.UseVisualStyleBackColor = true;
            this.rbLessor.CheckedChanged += new System.EventHandler(this.rbLessor_CheckedChanged);
            // 
            // butShowCarClient
            // 
            this.butShowCarClient.Location = new System.Drawing.Point(12, 87);
            this.butShowCarClient.Name = "butShowCarClient";
            this.butShowCarClient.Size = new System.Drawing.Size(164, 23);
            this.butShowCarClient.TabIndex = 2;
            this.butShowCarClient.Text = "Показати список авто";
            this.butShowCarClient.UseVisualStyleBackColor = true;
            this.butShowCarClient.Click += new System.EventHandler(this.butShowCarClient_Click);
            // 
            // butreestationC
            // 
            this.butreestationC.Location = new System.Drawing.Point(28, 130);
            this.butreestationC.Name = "butreestationC";
            this.butreestationC.Size = new System.Drawing.Size(121, 23);
            this.butreestationC.TabIndex = 3;
            this.butreestationC.Text = "Зареєструватись";
            this.butreestationC.UseVisualStyleBackColor = true;
            this.butreestationC.Click += new System.EventHandler(this.butreestationC_Click);
            // 
            // butOrendaC
            // 
            this.butOrendaC.Location = new System.Drawing.Point(28, 178);
            this.butOrendaC.Name = "butOrendaC";
            this.butOrendaC.Size = new System.Drawing.Size(121, 23);
            this.butOrendaC.TabIndex = 4;
            this.butOrendaC.Text = "Орендувати авто";
            this.butOrendaC.UseVisualStyleBackColor = true;
            this.butOrendaC.Click += new System.EventHandler(this.butOrendaC_Click);
            // 
            // butBackCarC
            // 
            this.butBackCarC.Location = new System.Drawing.Point(28, 230);
            this.butBackCarC.Name = "butBackCarC";
            this.butBackCarC.Size = new System.Drawing.Size(121, 23);
            this.butBackCarC.TabIndex = 5;
            this.butBackCarC.Text = "Повернути авто";
            this.butBackCarC.UseVisualStyleBackColor = true;
            this.butBackCarC.Click += new System.EventHandler(this.butBackCarC_Click);
            // 
            // butAddCarL
            // 
            this.butAddCarL.Location = new System.Drawing.Point(305, 87);
            this.butAddCarL.Name = "butAddCarL";
            this.butAddCarL.Size = new System.Drawing.Size(125, 23);
            this.butAddCarL.TabIndex = 6;
            this.butAddCarL.Text = "Додати авто";
            this.butAddCarL.UseVisualStyleBackColor = true;
            this.butAddCarL.Click += new System.EventHandler(this.butAddCarL_Click);
            // 
            // butRemoveCarl
            // 
            this.butRemoveCarl.Location = new System.Drawing.Point(313, 130);
            this.butRemoveCarl.Name = "butRemoveCarl";
            this.butRemoveCarl.Size = new System.Drawing.Size(108, 23);
            this.butRemoveCarl.TabIndex = 7;
            this.butRemoveCarl.Text = "Видалити авто";
            this.butRemoveCarl.UseVisualStyleBackColor = true;
            this.butRemoveCarl.Click += new System.EventHandler(this.butRemoveCarl_Click);
            // 
            // butAddCharacterL
            // 
            this.butAddCharacterL.Location = new System.Drawing.Point(295, 178);
            this.butAddCharacterL.Name = "butAddCharacterL";
            this.butAddCharacterL.Size = new System.Drawing.Size(147, 23);
            this.butAddCharacterL.TabIndex = 8;
            this.butAddCharacterL.Text = "Додати характеристику";
            this.butAddCharacterL.UseVisualStyleBackColor = true;
            this.butAddCharacterL.Click += new System.EventHandler(this.butAddCharacterL_Click);
            // 
            // butShowListClientL
            // 
            this.butShowListClientL.Location = new System.Drawing.Point(313, 230);
            this.butShowListClientL.Name = "butShowListClientL";
            this.butShowListClientL.Size = new System.Drawing.Size(108, 23);
            this.butShowListClientL.TabIndex = 9;
            this.butShowListClientL.Text = "Показати клієнтів";
            this.butShowListClientL.UseVisualStyleBackColor = true;
            this.butShowListClientL.Click += new System.EventHandler(this.butShowListClientL_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 314);
            this.Controls.Add(this.butShowListClientL);
            this.Controls.Add(this.butAddCharacterL);
            this.Controls.Add(this.butRemoveCarl);
            this.Controls.Add(this.butAddCarL);
            this.Controls.Add(this.butBackCarC);
            this.Controls.Add(this.butOrendaC);
            this.Controls.Add(this.butreestationC);
            this.Controls.Add(this.butShowCarClient);
            this.Controls.Add(this.rbLessor);
            this.Controls.Add(this.rbClient);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbClient;
        private System.Windows.Forms.RadioButton rbLessor;
        private System.Windows.Forms.Button butShowCarClient;
        private System.Windows.Forms.Button butreestationC;
        private System.Windows.Forms.Button butOrendaC;
        private System.Windows.Forms.Button butBackCarC;
        private System.Windows.Forms.Button butAddCarL;
        private System.Windows.Forms.Button butRemoveCarl;
        private System.Windows.Forms.Button butAddCharacterL;
        private System.Windows.Forms.Button butShowListClientL;
    }
}

