using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Imaging;
using System.Reflection;

namespace CHAT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
        IPEndPoint IP;
        Socket server;
        Image icon;
        List<Socket> clientList;
        void Connect()
        {
            clientList = new List<Socket>();
            IP = new IPEndPoint(IPAddress.Any, 2001);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            server.Bind(IP);
            Thread Listen = new Thread( ()  => {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        clientList.Add(client);
                        Thread receive = new Thread(Receive);
                        receive.IsBackground = true;
                        receive.SetApartmentState(ApartmentState.STA);
                       
                        receive.Start(client);
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, 2001);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            } );
            Listen.IsBackground = true;
            Listen.Start();
        }
        void Close()
        {
            server.Close();
        }
        void Send(Socket client)
        {
            /*if ( (client != null) && (txbMessage.Text != string.Empty) )
            {
                client.Send(Serialize(txbMessage.Text));
            }*/
            if (txbMessage.Text != String.Empty && icon == null && path == "")
            {
                byte[] data = new Byte[1024 * 5000];
                string str = txbMessage.Text;
                data = Serialize(str);
                client.Send(Serialize(str));
            }
            else if (icon != null && path == "")
            {
                byte[] data = new byte[1024 * 5000];
                data = ImageToByteArray(icon);
                client.Send(data);
            }
            else if (path != "" && icon == null)
            {
                Image image = Image.FromFile(path);
                byte[] data = new byte[1024 * 5000];
                data = ImageToByteArray(image);
                client.Send(data);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tin nhắn !");
            }
        }
        void Receive(object obj)
        {
            Socket client = obj as Socket;
            try
            { 
            while (true)
            {
                byte[] data = new byte[1024 * 5000];
                client.Receive(data);
                /*string message = (string)Deseriliaze(data);
                AddMessage(message);*/
                   if (IsValidImage(data))
                    {
                        Image image = byteArrayToImage(data);
                        Clipboard.SetImage(image);
                        lsvMessage.AppendText("Client " + client.LocalEndPoint + " " + "(" + DateTime.Now.ToString("h:mm:ss tt") + "):  \n");
                        lsvMessage.Paste();
                        lsvMessage.AppendText("\n");
                    }
                    else
                    {
               /* object ob = Deseriliaze(data);
                string str = ob as string;*/
                        string str = Deseriliaze(data);
                        if (str != null || str != String.Empty)
                            lsvMessage.AppendText("Client " + client.LocalEndPoint + " " + "(" + DateTime.Now.ToString("h:mm:ss tt") + "): \n" + str);
                        lsvMessage.AppendText("\n");
                    }
                   // Client gửi nhiều client nhưng mà nó không gửi đc chính nó
                foreach (Socket item in clientList)
                {
                    if (item != null && item != client)
                    {
                        item.Send(data);
                    }
                }
            }
            }
            catch
            {
                clientList.Remove(client);
                client.Close();
                MessageBox.Show("Một Client đã ngắt kết nối !", "Thông báo !");
            }
        }
        void AddMessage(string s)
        {
            lsvMessage.AppendText("Tôi " + " " + "(" + DateTime.Now.ToString("h:mm:ss tt") + ") \n");
            lsvMessage.AppendText(s + "\n");
            //lsvMessage.Items.Add(new ListViewItem() { Text = s });
        }

        byte[] Serialize(string s)
        {
            return Encoding.Unicode.GetBytes(s);
        }

        //Hàm gom mảnh các byte nhận được rồi chuyển sang kiểu string để hiện thị lên màn hình
        string Deseriliaze(byte[] data)
        {
            return Encoding.Unicode.GetString(data);
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txbMessage.Text != String.Empty && path == "" && icon == null)
            {
                lsvMessage.AppendText("Tôi " + " " + "(" + DateTime.Now.ToString("h:mm:ss tt") + "): \n" + txbMessage.Text + "\n");
            }
            else if (icon != null)
            {
                Clipboard.SetImage(icon);
                lsvMessage.AppendText("Tôi " + " " + "(" + DateTime.Now.ToString("h:mm:ss tt") + ") \n");
                lsvMessage.Paste();
                lsvMessage.AppendText("\n");
            }
            else if (path != "")
            {
                Image image1 = Image.FromFile(path);
                Clipboard.SetImage(image1);
                lsvMessage.AppendText("Tôi " + " " + "(" + DateTime.Now.ToString("h:mm:ss tt") + "): \n");
                lsvMessage.Paste();
                lsvMessage.AppendText("\n");
            }
            foreach (Socket item in clientList)
            {
                Send(item);
            }
            path = "";
            txbMessage.Text = "";
            icon = null;
            /*for (int i = 0; i < clientList.Count; i++)
            {
                Socket item = clientList[i];
                Send(item);
            }*/
            //AddMessage(txbMessage.Text);
            txbMessage.Clear();
        }
        string path = "";
        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog image = new OpenFileDialog();
            image.Filter = "Image|*.bmp;*.jpg;*.gif;*.png;*.tif";
            image.ShowDialog();
            path = image.FileName;
            if (path != "")
            {
                Clipboard.SetImage(Image.FromFile(path));
                txbMessage.Paste();
            }
        }
        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);

            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        private bool IsValidImage(byte[] bytes)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(bytes))
                    Image.FromStream(ms);
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }

        private void btnIcon_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(@"D:\Hoc Tap\HK7\Emoji");
            foreach (FileInfo file in dir.GetFiles())
            {
                try
                {
                    this.imageList1.Images.Add(file.Name, Image.FromFile(file.FullName));
                }
                catch
                {
                    Console.WriteLine("This is not an image file");
                }
            }
            this.listView1.View = View.LargeIcon;
            this.imageList1.ImageSize = new Size(32, 32);
            this.listView1.LargeImageList = this.imageList1;

            for (int j = 0; j < this.imageList1.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                this.listView1.Items.Add(item);

            }
            listView1.Visible = true;
        }
        int pos = 0;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView1.FocusedItem == null) return;
                pos = listView1.SelectedIndices[0];
                Clipboard.SetImage(imageList1.Images[pos]);
                icon = imageList1.Images[pos];
                txbMessage.Paste();
            }
            catch (Exception)
            {
                return;
            }
            listView1.Visible = false;
        }

        private void listView1_MouseLeave(object sender, EventArgs e)
        {
            listView1.Visible = false;
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            //lsvMessage.Undo();
            if (lsvMessage.SelectionLength > 0)
                lsvMessage.Cut();
        }
    }
}
