using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;
using System.Runtime.InteropServices;



namespace ArduinoControl
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        private void WriteDebug(string i_msg)
        {
            Debug.WriteLine(i_msg);
            listBoxMsg.Items.Insert(0, i_msg);

            if (listBoxMsg.Items.Count > 50)
                listBoxMsg.Items.RemoveAt(listBoxMsg.Items.Count - 1);
        }

        private bool Send(string i_msg)
        {
            while (true)
            {
                UdpClient udpClient = SendMsg(i_msg);

                string ret_msg = ReceiveMsg(udpClient);

                if (ret_msg == "ok")
                    return true;

                if (ret_msg == "error")
                    return false;
            }
        }

        private UdpClient SendMsg(string i_msg)
        {
            WriteDebug("-> " + i_msg);

            Int32 port;
            Int32.TryParse(textBox_Port.Text, out port);
            UdpClient udpClient = new UdpClient(textBox_IP.Text, port);


            Int32 sendTimeout;
            Int32 receiveTimeout;

            Int32.TryParse(textBox_SendTimeout.Text, out sendTimeout);
            Int32.TryParse(textBox_ReceiveTimeout.Text, out receiveTimeout);


            udpClient.Client.SendTimeout = sendTimeout;
            udpClient.Client.ReceiveTimeout = receiveTimeout;

            Byte[] sendBytes = Encoding.ASCII.GetBytes(i_msg);
            try
            {
                udpClient.Send(sendBytes, sendBytes.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return udpClient;
        }

        private string ReceiveMsg(UdpClient i_client)
        {
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

            try
            {

                // Blocks until a message returns on this socket from a remote host.
                Byte[] receiveBytes = i_client.Receive(ref RemoteIpEndPoint);

                string returnData = Encoding.ASCII.GetString(receiveBytes);

                WriteDebug(returnData.ToString());
                //Console.WriteLine("This message was sent from " +
                //                            RemoteIpEndPoint.Address.ToString() +
                //                            " on their port number " +
                //                            RemoteIpEndPoint.Port.ToString());

                return returnData.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return "error";
        }

        private bool forward_pressed = false;
        private bool backward_pressed = false;
        private bool left_pressed = false;
        private bool right_pressed = false;


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                if (forward_pressed == false && backward_pressed == false)
                {
                    forward_pressed = Send("forward1");
                }
            }

            if (e.KeyData == Keys.Down)
            {
                if (backward_pressed == false && forward_pressed == false)
                {
                    backward_pressed = Send("backward1");
                }
            }

            if (e.KeyData == Keys.Left)
            {
                if (left_pressed == false && right_pressed == false)
                {
                    left_pressed = Send("left1");
                }
            }

            if (e.KeyData == Keys.Right)
            {
                if (right_pressed == false && left_pressed == false)
                {
                    right_pressed = Send("right1");
                }
            }
            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                forward_pressed = false;
                Send("forward0");                
            }

            if (e.KeyData == Keys.Down)
            {
                backward_pressed = false;
                Send("backward0");    
            }

            if (e.KeyData == Keys.Left)
            {
                left_pressed = false;
                Send("left0");    
            }

            if (e.KeyData == Keys.Right)
            {
                right_pressed = false;
                Send("right0");    
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            while (true)
            {
                UdpClient udpClient = SendMsg("update");

                string ret_msg = ReceiveMsg(udpClient);

                if (ret_msg.StartsWith("vlt"))
                {
                    ret_msg = ret_msg.Remove(0, 4);

                    Int32 millivolt;
                    Int32.TryParse(ret_msg, out millivolt);

                    float voltage = 1.14f* millivolt / 1000.0f;

                    if (voltage < 6.5)
                    {
                        Console.Beep(8000, 500);
                        label_Voltage.ForeColor = Color.Red;                        
                    }
                    else
                    {
                        label_Voltage.ForeColor = Color.Black;
                    }

                    label_Voltage.Text = "Voltage " + voltage.ToString() + "V";
                    return;
                }

                if (ret_msg == "error")
                    break;
            }

            label_Voltage.Text = "Voltage error";
        }
    }
}
