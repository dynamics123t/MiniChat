﻿namespace CHAT
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.lsvMessage = new System.Windows.Forms.RichTextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.txbMessage = new System.Windows.Forms.RichTextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnIcon = new System.Windows.Forms.Button();
            this.btnImage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsvMessage
            // 
            this.lsvMessage.Location = new System.Drawing.Point(391, 6);
            this.lsvMessage.Name = "lsvMessage";
            this.lsvMessage.Size = new System.Drawing.Size(743, 487);
            this.lsvMessage.TabIndex = 7;
            this.lsvMessage.Text = "";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 232);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(304, 260);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseLeave += new System.EventHandler(this.listView1_MouseLeave);
            // 
            // txbMessage
            // 
            this.txbMessage.Location = new System.Drawing.Point(391, 498);
            this.txbMessage.Name = "txbMessage";
            this.txbMessage.Size = new System.Drawing.Size(660, 54);
            this.txbMessage.TabIndex = 11;
            this.txbMessage.Text = "";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(174, 501);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 52);
            this.btnRemove.TabIndex = 12;
            this.btnRemove.Text = "Gỡ tin";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSend
            // 
            this.btnSend.Image = global::CHAT.Properties.Resources.icons8_send_32;
            this.btnSend.Location = new System.Drawing.Point(1058, 498);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(76, 55);
            this.btnSend.TabIndex = 4;
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnFile
            // 
            this.btnFile.Image = global::CHAT.Properties.Resources.icons8_file_48;
            this.btnFile.Location = new System.Drawing.Point(255, 501);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(75, 52);
            this.btnFile.TabIndex = 13;
            this.btnFile.UseVisualStyleBackColor = true;
            // 
            // btnIcon
            // 
            this.btnIcon.Image = global::CHAT.Properties.Resources.icons8_smile_24;
            this.btnIcon.Location = new System.Drawing.Point(12, 498);
            this.btnIcon.Name = "btnIcon";
            this.btnIcon.Size = new System.Drawing.Size(75, 54);
            this.btnIcon.TabIndex = 9;
            this.btnIcon.UseVisualStyleBackColor = true;
            this.btnIcon.Click += new System.EventHandler(this.btnIcon_Click);
            // 
            // btnImage
            // 
            this.btnImage.Image = global::CHAT.Properties.Resources.icons8_image_48;
            this.btnImage.Location = new System.Drawing.Point(93, 499);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(75, 54);
            this.btnImage.TabIndex = 8;
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1163, 585);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.txbMessage);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnIcon);
            this.Controls.Add(this.btnImage);
            this.Controls.Add(this.lsvMessage);
            this.Controls.Add(this.btnSend);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "SERVER";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RichTextBox lsvMessage;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.Button btnIcon;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.RichTextBox txbMessage;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnFile;
    }
}

