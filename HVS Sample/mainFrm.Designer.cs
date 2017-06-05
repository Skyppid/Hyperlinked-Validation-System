namespace HVS_Sample
{
    partial class mainFrm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txb_name = new System.Windows.Forms.TextBox();
            this.btn_activate = new System.Windows.Forms.Button();
            this.chb_tou = new System.Windows.Forms.CheckBox();
            this.txb_lastname = new System.Windows.Forms.TextBox();
            this.txb_email = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.validationCheckTimer = new System.Windows.Forms.Timer(this.components);
            this.chb_optionalName = new System.Windows.Forms.CheckBox();
            this.chb_optionalLastname = new System.Windows.Forms.CheckBox();
            this.chb_optionalEmail = new System.Windows.Forms.CheckBox();
            this.txb_password = new System.Windows.Forms.TextBox();
            this.txb_repeatPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chb_optionalPass = new System.Windows.Forms.CheckBox();
            this.chb_optionalRepPass = new System.Windows.Forms.CheckBox();
            this.chb_optionalCondition = new System.Windows.Forms.CheckBox();
            this.hvs = new HyperlinkedValidationSystem.HVS();
            this.SuspendLayout();
            // 
            // txb_name
            // 
            this.txb_name.Location = new System.Drawing.Point(121, 16);
            this.txb_name.Name = "txb_name";
            this.txb_name.Size = new System.Drawing.Size(151, 20);
            this.txb_name.TabIndex = 0;
            // 
            // btn_activate
            // 
            this.btn_activate.Location = new System.Drawing.Point(251, 175);
            this.btn_activate.Name = "btn_activate";
            this.btn_activate.Size = new System.Drawing.Size(103, 23);
            this.btn_activate.TabIndex = 4;
            this.btn_activate.Text = "Activate account";
            this.btn_activate.UseVisualStyleBackColor = true;
            // 
            // chb_tou
            // 
            this.chb_tou.AutoSize = true;
            this.chb_tou.Location = new System.Drawing.Point(16, 156);
            this.chb_tou.Name = "chb_tou";
            this.chb_tou.Size = new System.Drawing.Size(161, 17);
            this.chb_tou.TabIndex = 5;
            this.chb_tou.Text = "I accept the Terms of Usage";
            this.chb_tou.UseVisualStyleBackColor = true;
            // 
            // txb_lastname
            // 
            this.txb_lastname.Location = new System.Drawing.Point(121, 42);
            this.txb_lastname.Name = "txb_lastname";
            this.txb_lastname.Size = new System.Drawing.Size(151, 20);
            this.txb_lastname.TabIndex = 1;
            // 
            // txb_email
            // 
            this.txb_email.Location = new System.Drawing.Point(121, 68);
            this.txb_email.Name = "txb_email";
            this.txb_email.Size = new System.Drawing.Size(151, 20);
            this.txb_email.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Last Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "E-Mail:";
            // 
            // chb_optionalName
            // 
            this.chb_optionalName.AutoSize = true;
            this.chb_optionalName.Location = new System.Drawing.Point(278, 18);
            this.chb_optionalName.Name = "chb_optionalName";
            this.chb_optionalName.Size = new System.Drawing.Size(76, 17);
            this.chb_optionalName.TabIndex = 2;
            this.chb_optionalName.TabStop = false;
            this.chb_optionalName.Text = "Is Optional";
            this.chb_optionalName.UseVisualStyleBackColor = true;
            this.chb_optionalName.CheckedChanged += new System.EventHandler(this.chb_optionalName_CheckedChanged);
            // 
            // chb_optionalLastname
            // 
            this.chb_optionalLastname.AutoSize = true;
            this.chb_optionalLastname.Location = new System.Drawing.Point(278, 44);
            this.chb_optionalLastname.Name = "chb_optionalLastname";
            this.chb_optionalLastname.Size = new System.Drawing.Size(76, 17);
            this.chb_optionalLastname.TabIndex = 2;
            this.chb_optionalLastname.TabStop = false;
            this.chb_optionalLastname.Text = "Is Optional";
            this.chb_optionalLastname.UseVisualStyleBackColor = true;
            this.chb_optionalLastname.CheckedChanged += new System.EventHandler(this.chb_optionalLastname_CheckedChanged);
            // 
            // chb_optionalEmail
            // 
            this.chb_optionalEmail.AutoSize = true;
            this.chb_optionalEmail.Location = new System.Drawing.Point(278, 70);
            this.chb_optionalEmail.Name = "chb_optionalEmail";
            this.chb_optionalEmail.Size = new System.Drawing.Size(76, 17);
            this.chb_optionalEmail.TabIndex = 2;
            this.chb_optionalEmail.TabStop = false;
            this.chb_optionalEmail.Text = "Is Optional";
            this.chb_optionalEmail.UseVisualStyleBackColor = true;
            this.chb_optionalEmail.CheckedChanged += new System.EventHandler(this.chb_optionalEmail_CheckedChanged);
            // 
            // txb_password
            // 
            this.txb_password.Location = new System.Drawing.Point(121, 94);
            this.txb_password.Name = "txb_password";
            this.txb_password.Size = new System.Drawing.Size(151, 20);
            this.txb_password.TabIndex = 3;
            // 
            // txb_repeatPassword
            // 
            this.txb_repeatPassword.Location = new System.Drawing.Point(121, 120);
            this.txb_repeatPassword.Name = "txb_repeatPassword";
            this.txb_repeatPassword.Size = new System.Drawing.Size(151, 20);
            this.txb_repeatPassword.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Repeat Password:";
            // 
            // chb_optionalPass
            // 
            this.chb_optionalPass.AutoSize = true;
            this.chb_optionalPass.Location = new System.Drawing.Point(278, 96);
            this.chb_optionalPass.Name = "chb_optionalPass";
            this.chb_optionalPass.Size = new System.Drawing.Size(76, 17);
            this.chb_optionalPass.TabIndex = 2;
            this.chb_optionalPass.TabStop = false;
            this.chb_optionalPass.Text = "Is Optional";
            this.chb_optionalPass.UseVisualStyleBackColor = true;
            this.chb_optionalPass.CheckedChanged += new System.EventHandler(this.chb_optionalPass_CheckedChanged);
            // 
            // chb_optionalRepPass
            // 
            this.chb_optionalRepPass.AutoSize = true;
            this.chb_optionalRepPass.Location = new System.Drawing.Point(278, 122);
            this.chb_optionalRepPass.Name = "chb_optionalRepPass";
            this.chb_optionalRepPass.Size = new System.Drawing.Size(76, 17);
            this.chb_optionalRepPass.TabIndex = 2;
            this.chb_optionalRepPass.TabStop = false;
            this.chb_optionalRepPass.Text = "Is Optional";
            this.chb_optionalRepPass.UseVisualStyleBackColor = true;
            this.chb_optionalRepPass.CheckedChanged += new System.EventHandler(this.chb_optionalRepPass_CheckedChanged);
            // 
            // chb_optionalCondition
            // 
            this.chb_optionalCondition.AutoSize = true;
            this.chb_optionalCondition.Location = new System.Drawing.Point(360, 122);
            this.chb_optionalCondition.Name = "chb_optionalCondition";
            this.chb_optionalCondition.Size = new System.Drawing.Size(112, 17);
            this.chb_optionalCondition.TabIndex = 6;
            this.chb_optionalCondition.TabStop = false;
            this.chb_optionalCondition.Text = "Optional Condition";
            this.chb_optionalCondition.UseVisualStyleBackColor = true;
            this.chb_optionalCondition.CheckedChanged += new System.EventHandler(this.chb_optionalCondition_CheckedChanged);
            // 
            // mainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 210);
            this.Controls.Add(this.chb_optionalCondition);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txb_repeatPassword);
            this.Controls.Add(this.txb_password);
            this.Controls.Add(this.txb_email);
            this.Controls.Add(this.txb_lastname);
            this.Controls.Add(this.chb_optionalRepPass);
            this.Controls.Add(this.chb_optionalPass);
            this.Controls.Add(this.chb_optionalEmail);
            this.Controls.Add(this.chb_optionalLastname);
            this.Controls.Add(this.chb_optionalName);
            this.Controls.Add(this.chb_tou);
            this.Controls.Add(this.btn_activate);
            this.Controls.Add(this.txb_name);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HVS Sample Form";
            this.Load += new System.EventHandler(this.mainFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txb_name;
        private System.Windows.Forms.Button btn_activate;
        private System.Windows.Forms.CheckBox chb_tou;
        private System.Windows.Forms.TextBox txb_lastname;
        private System.Windows.Forms.TextBox txb_email;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer validationCheckTimer;
        private System.Windows.Forms.CheckBox chb_optionalName;
        private System.Windows.Forms.CheckBox chb_optionalLastname;
        private System.Windows.Forms.CheckBox chb_optionalEmail;
        private System.Windows.Forms.TextBox txb_password;
        private System.Windows.Forms.TextBox txb_repeatPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chb_optionalPass;
        private System.Windows.Forms.CheckBox chb_optionalRepPass;
        private System.Windows.Forms.CheckBox chb_optionalCondition;
        private HyperlinkedValidationSystem.HVS hvs;
    }
}

