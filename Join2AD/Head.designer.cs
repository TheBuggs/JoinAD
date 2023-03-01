
using System.Collections.Generic;

namespace Join2AD
{   
    partial class Head
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Head));
            this.lbFirstName = new System.Windows.Forms.Label();
            this.txtBoxFirstName = new System.Windows.Forms.TextBox();
            this.lbLastName = new System.Windows.Forms.Label();
            this.txtBoxLastName = new System.Windows.Forms.TextBox();
            this.lbLocation = new System.Windows.Forms.Label();
            this.cboBoxLocation = new System.Windows.Forms.ComboBox();
            this.lbRoom = new System.Windows.Forms.Label();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.comboBoxDirectorate = new System.Windows.Forms.ComboBox();
            this.lbDirectorate = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.lbType = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Button();
            this.next = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbFirstName
            // 
            this.lbFirstName.AutoSize = true;
            this.lbFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbFirstName.Location = new System.Drawing.Point(22, 22);
            this.lbFirstName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbFirstName.Name = "lbFirstName";
            this.lbFirstName.Size = new System.Drawing.Size(126, 17);
            this.lbFirstName.Text = "Име на латиница:";
            // 
            // txtBoxFirstName
            // 
            this.txtBoxFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBoxFirstName.Location = new System.Drawing.Point(25, 50);
            this.txtBoxFirstName.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxFirstName.Name = "txtBoxFirstName";
            this.txtBoxFirstName.Size = new System.Drawing.Size(280, 26);
            this.txtBoxFirstName.TabIndex = 0;
            this.txtBoxFirstName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // lbLastName
            // 
            this.lbLastName.AutoSize = true;
            this.lbLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbLastName.Location = new System.Drawing.Point(22, 92);
            this.lbLastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbLastName.Name = "lbLastName";
            this.lbLastName.Size = new System.Drawing.Size(162, 17);
            this.lbLastName.Text = "Фамилия на латиница:";
            // 
            // txtBoxLastName
            // 
            this.txtBoxLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBoxLastName.Location = new System.Drawing.Point(25, 120);
            this.txtBoxLastName.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxLastName.Name = "txtBoxLastName";
            this.txtBoxLastName.Size = new System.Drawing.Size(280, 26);
            this.txtBoxLastName.TabIndex = 1;
            // 
            // lbLocation
            // 
            this.lbLocation.AutoSize = true;
            this.lbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbLocation.Location = new System.Drawing.Point(22, 162);
            this.lbLocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbLocation.Name = "lbLocation";
            this.lbLocation.Size = new System.Drawing.Size(69, 17);
            this.lbLocation.Text = "Локация:";
            // 
            // cboBoxLocation
            // 
            this.cboBoxLocation.DropDownWidth = 280;
            this.cboBoxLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboBoxLocation.Location = new System.Drawing.Point(22, 190);
            this.cboBoxLocation.MaxDropDownItems = 5;
            this.cboBoxLocation.Name = "cboBoxLocation";
            this.cboBoxLocation.Size = new System.Drawing.Size(280, 25);
            this.cboBoxLocation.TabIndex = 2;
            this.cboBoxLocation.DataSource = new System.Windows.Forms.BindingSource( Data.locations, null);          
            this.cboBoxLocation.DisplayMember = "Value";
            this.cboBoxLocation.ValueMember = "Key";
            // 
            // lbRoom
            // 
            this.lbRoom.AutoSize = true;
            this.lbRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbRoom.Location = new System.Drawing.Point(22, 232);
            this.lbRoom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbRoom.Name = "lbRoom";
            this.lbRoom.Size = new System.Drawing.Size(44, 17);
            this.lbRoom.Text = "Стая:";
            // 
            // txtRoom
            // 
            this.txtRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtRoom.Location = new System.Drawing.Point(22, 260);
            this.txtRoom.Margin = new System.Windows.Forms.Padding(2);
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Size = new System.Drawing.Size(280, 26);
            this.txtRoom.TabIndex = 3;
            // 
            // comboBoxDirectorate
            // 
            this.comboBoxDirectorate.DropDownWidth = 280;
            this.comboBoxDirectorate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxDirectorate.FormattingEnabled = true;
            this.comboBoxDirectorate.Location = new System.Drawing.Point(22, 340);
            this.comboBoxDirectorate.Name = "comboBoxDirectorate";
            this.comboBoxDirectorate.Size = new System.Drawing.Size(280, 25);
            this.comboBoxDirectorate.TabIndex = 4;
            this.comboBoxDirectorate.DataSource = new System.Windows.Forms.BindingSource(Data.dictorates, null);  
            this.comboBoxDirectorate.DisplayMember = "Value";
            this.comboBoxDirectorate.ValueMember = "Key";
          
            //string value = ((KeyValuePair<string, string>)this.comboBoxDirectorate.SelectedItem).Value;
            // 
            // lbDirectorate
            // 
            this.lbDirectorate.AutoSize = true;
            this.lbDirectorate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbDirectorate.Location = new System.Drawing.Point(22, 311);
            this.lbDirectorate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDirectorate.Name = "lbDirectorate";
            this.lbDirectorate.Size = new System.Drawing.Size(78, 17);
            this.lbDirectorate.Text = "Отдел:";
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownWidth = 280;
            this.comboBoxType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(22, 427);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(280, 25);
            this.comboBoxType.TabIndex = 5;
            this.comboBoxType.DataSource = new System.Windows.Forms.BindingSource(Data.types, null);         
            this.comboBoxType.DisplayMember = "Value";
            this.comboBoxType.ValueMember = "Key";
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbType.Location = new System.Drawing.Point(22, 381);
            this.lbType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(150, 17);
            this.lbType.Text = "Вид на устройството:";
            // 
            // close
            // 
            this.close.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.close.Location = new System.Drawing.Point(208, 496);
            this.close.Margin = new System.Windows.Forms.Padding(2);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(100, 32);
            this.close.TabIndex = 7;
            this.close.Text = "Изход";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // next
            // 
            this.next.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.next.Location = new System.Drawing.Point(22, 496);
            this.next.Margin = new System.Windows.Forms.Padding(2);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(100, 32);
            this.next.TabIndex = 6;
            this.next.Text = "Продължи";
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 552);
            this.ControlBox = false;
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.lbDirectorate);
            this.Controls.Add(this.comboBoxDirectorate);
            this.Controls.Add(this.cboBoxLocation);
            this.Controls.Add(this.lbRoom);
            this.Controls.Add(this.txtRoom);
            this.Controls.Add(this.txtBoxLastName);
            this.Controls.Add(this.lbLocation);
            this.Controls.Add(this.lbLastName);
            this.Controls.Add(this.close);
            this.Controls.Add(this.next);
            this.Controls.Add(this.lbFirstName);
            this.Controls.Add(this.txtBoxFirstName);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hostname";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtBoxFirstName;
        private System.Windows.Forms.TextBox txtBoxLastName;
        private System.Windows.Forms.ComboBox cboBoxLocation;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.Label lbFirstName;
        private System.Windows.Forms.Label lbLastName;
        private System.Windows.Forms.Label lbLocation;
        private System.Windows.Forms.Label lbRoom;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.ComboBox comboBoxDirectorate;
        private System.Windows.Forms.Label lbDirectorate;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label lbType;
    }
}
