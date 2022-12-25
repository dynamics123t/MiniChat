using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace CLIENT
{
    public partial class frmCLIENT : Form
    {
        public frmCLIENT()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;//tránh việc đụng độ khi sử dụng tài nguyên giữa các thread
            Connect();
        }

        private void frmCLIENT_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        IPEndPoint IP;
        Socket client;
        Image icon;
        string path = "";

        //kết nối đến server
        void Connect()
        {
            //IP là địa chỉ của server.Khởi tạo địa chỉ IP và socket để kết nối
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2001);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            //bắt đầu kết nôi. Nếu ko kết nối được thì hiện thông báo
            try
            {
                client.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Control.CheckForIllegalCrossThreadCalls = false;
            //tạo luồng lắng nghe server khi vừa kết nối tới
            Thread listen = new Thread(Receive);
            listen.SetApartmentState(ApartmentState.STA);
            listen.IsBackground = true;
            listen.Start();
        }

        //đóng kết nối đến server
        void Close()
        {
            client.Close();
        }

        //gửi dữ liệu
        void Send()
        {
            //nếu textboc khác rỗng thì mới gửi tin
           /* if(txbMessage.Text != string.Empty)
            {
                client.Send(Serialize(txbMessage.Text));
            }*/
            if (txbMessage.Text != String.Empty && path == "" && icon == null)
            {
                string str = txbMessage.Text.ToString();
                byte[] data = new byte[1024 * 5000];
                data = Serialize(str);
                client.Send(data);
                //client.Send(Serialize(txbMessage.Text));
                lsvMessage.AppendText("Tôi " + " " + "(" + DateTime.Now.ToString("h:mm:ss tt") + "): \n" + txbMessage.Text + "\n");
                txbMessage.Text = "";
            }
            else if (icon != null)
            {
                byte[] data = new byte[1024 * 5000];
                data = ImageToByteArray(icon);
                client.Send(data);
                //client.Send(Serialize(data));
                lsvMessage.AppendText("Tôi " + " " + "(" + DateTime.Now.ToString("h:mm:ss tt") + ") \n");
                lsvMessage.Paste();
                lsvMessage.AppendText("\n");
                icon = null;
                txbMessage.Text = "";
            }
            else if (path != "")
            {
                Image image = Image.FromFile(path);
                byte[] data = new byte[1024 * 10000];
                data = ImageToByteArray(image);
                client.Send(data);
                //client.Send(Serialize(data));
                lsvMessage.AppendText("Tôi " + " " + "(" + DateTime.Now.ToString("h:mm:ss tt") + "): \n");
                lsvMessage.Paste();
                lsvMessage.AppendText("\n");
                path = "";
                txbMessage.Text = "";
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tin nhắn !");
            }
        }

        //nhận dữ liệu
        void Receive()
        {
             try
             {
                while (true)
                {
                    //khai báo mảng byte để nhận dữ liệu dưới mảng byte
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    //chuyển data từ dạng byte sang dạng string
                    /*string message = (string)Deseriliaze(data);
                    AddMessage(message);*/
                    if (IsValidImage(data))
                    {
                        Image image = byteArrayToImage(data);
                        Clipboard.SetDataObject(image, false, 1, 200);
                        lsvMessage.AppendText("Sever " + " " + "(" + DateTime.Now.ToString("h:mm:ss tt") + "): \n");
                        lsvMessage.Paste();
                        lsvMessage.AppendText("\n");
                    }
                    else if (!IsValidImage(data))
                    {
                        /*object ob = Deseriliaze(data);
                        String str = ob as string;*/
                        string str = Deseriliaze(data);
                        if (str != null || str != String.Empty)
                        {
                            lsvMessage.AppendText("Sever" + " " + "(" + DateTime.Now.ToString("h:mm:ss tt") + "): \n" + str);
                            lsvMessage.AppendText("\n");
                        }
                    }
                }
             }
             catch (Exception ex)
             {
                MessageBox.Show(ex.ToString(), "Có lỗi !");
                lsvMessage.AppendText(ex.ToString());
                this.Close();
             }                   
        }

        //add mesage vào khung chat
        void AddMessage(string s)
        {
            lsvMessage.AppendText("Tôi " + " " + "(" + DateTime.Now.ToString("h:mm:ss tt") + ") \n");
            //lsvMessage.Items.Add(new ListViewItem() { Text = s });
            lsvMessage.AppendText(s + "\n");
            txbMessage.Clear(); 
        }

        //Hàm phân mảnh dữ liệu cần gửi từ dạng string sang dạng byte để gửi đi
        byte[] Serialize (string s)
        {
            return Encoding.Unicode.GetBytes(s);
        }

        //Hàm gom mảnh các byte nhận được rồi chuyển sang kiểu string để hiện thị lên màn hình
        string Deseriliaze (byte[] data)
        {
           return Encoding.Unicode.GetString(data);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Send();
            //AddMessage(txbMessage.Text);
        }
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
    }
}
