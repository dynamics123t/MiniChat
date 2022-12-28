namespace CLIENT
{
    partial class frmCLIENT
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receiveMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.txbMessage = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnIcon = new System.Windows.Forms.Button();
            this.btnImage = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvMessage
            // 
            this.lsvMessage.ContextMenuStrip = this.contextMenuStrip1;
            this.lsvMessage.Location = new System.Drawing.Point(338, 12);
            this.lsvMessage.Name = "lsvMessage";
            this.lsvMessage.Size = new System.Drawing.Size(793, 445);
            this.lsvMessage.TabIndex = 4;
            this.lsvMessage.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeMessageToolStripMenuItem,
            this.transferMessageToolStripMenuItem,
            this.receiveMessageToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(195, 76);
            // 
            // removeMessageToolStripMenuItem
            // 
            this.removeMessageToolStripMenuItem.Name = "removeMessageToolStripMenuItem";
            this.removeMessageToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.removeMessageToolStripMenuItem.Text = "Remove message";
            this.removeMessageToolStripMenuItem.Click += new System.EventHandler(this.removeMessageToolStripMenuItem_Click);
            // 
            // transferMessageToolStripMenuItem
            // 
            this.transferMessageToolStripMenuItem.Name = "transferMessageToolStripMenuItem";
            this.transferMessageToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.transferMessageToolStripMenuItem.Text = "Transfer message";
            this.transferMessageToolStripMenuItem.Click += new System.EventHandler(this.transferMessageToolStripMenuItem_Click);
            // 
            // receiveMessageToolStripMenuItem
            // 
            this.receiveMessageToolStripMenuItem.Name = "receiveMessageToolStripMenuItem";
            this.receiveMessageToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.receiveMessageToolStripMenuItem.Text = "Receive message";
            this.receiveMessageToolStripMenuItem.Click += new System.EventHandler(this.receiveMessageToolStripMenuItem_Click);
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
            this.listView1.Location = new System.Drawing.Point(14, 215);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(318, 242);
            this.listView1.TabIndex = 11;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.Visible = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseLeave += new System.EventHandler(this.listView1_MouseLeave);
            // 
            // txbMessage
            // 
            this.txbMessage.Location = new System.Drawing.Point(338, 463);
            this.txbMessage.Name = "txbMessage";
            this.txbMessage.Size = new System.Drawing.Size(710, 55);
            this.txbMessage.TabIndex = 12;
            this.txbMessage.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Image = global::CLIENT.Properties.Resources.icons8_send_32;
            this.btnSend.Location = new System.Drawing.Point(1055, 462);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(76, 55);
            this.btnSend.TabIndex = 0;
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnFile
            // 
            this.btnFile.Image = global::CLIENT.Properties.Resources.icons8_file_48;
            this.btnFile.Location = new System.Drawing.Point(176, 464);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(75, 52);
            this.btnFile.TabIndex = 14;
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnIcon
            // 
            this.btnIcon.Image = global::CLIENT.Properties.Resources.icons8_smile_24;
            this.btnIcon.Location = new System.Drawing.Point(14, 462);
            this.btnIcon.Name = "btnIcon";
            this.btnIcon.Size = new System.Drawing.Size(75, 55);
            this.btnIcon.TabIndex = 10;
            this.btnIcon.UseVisualStyleBackColor = true;
            this.btnIcon.Click += new System.EventHandler(this.btnIcon_Click);
            // 
            // btnImage
            // 
            this.btnImage.Image = global::CLIENT.Properties.Resources.icons8_image_48;
            this.btnImage.Location = new System.Drawing.Point(95, 463);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(75, 54);
            this.btnImage.TabIndex = 9;
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // frmCLIENT
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1167, 549);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.txbMessage);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnIcon);
            this.Controls.Add(this.btnImage);
            this.Controls.Add(this.lsvMessage);
            this.Controls.Add(this.btnSend);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCLIENT";
            this.Text = "CLIENT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCLIENT_FormClosed);
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receiveMessageToolStripMenuItem;
    }
}

