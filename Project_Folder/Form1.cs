﻿
//#define DERS 34

using System;
using System.Collections.Generic;
using System.ComponentModel;


using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Xml.Linq;
using System.IO;
using NPlot;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;






//namespace VOI_DAQ
namespace SensorData
{

    public partial class Form1 : Form
    {






        // int BaseCounter;
        int Timer_1sec;
        byte Task_Counter;

        //  string MaxPointProfileClose;
        //  string MaxPointProfileOpen;
        //  Int32 Speed_PID;
        //   Int32 Final_PID;
        //   UInt16 SpeedAverage_S_Profile;
        //   UInt16 Speed_Target;
        //   byte ProfilePulse_Command;
        //     UInt16 Speed_Actual;
        //     byte ProfilePulse_Direction;

        //   byte ProfilePulse_Mode;
        //   byte ProfilePulse_Mode_Prev;
        //   byte MainMode;
        //       Int16 EncPulse_DoorLength;

        public void Plot_Init()
        {
            
            NPlot.Grid grid = new NPlot.Grid();
            NPlot.LinePlot Graph1 = new NPlot.LinePlot();
            NPlot.LinePlot Graph2 = new NPlot.LinePlot();
            NPlot.LinePlot Graph3 = new NPlot.LinePlot();
            NPlot.LinePlot Graph4 = new NPlot.LinePlot();

            Graph1.Pen = new Pen(Color.Red, 1);
            Graph2.Pen = new Pen(Color.Blue, 2);
            Graph3.Pen = new Pen(Color.Green, 1);
            Graph4.Pen = new Pen(Color.Gold, 1);   //

            grid.VerticalGridType = NPlot.Grid.GridType.Coarse;
            grid.HorizontalGridType = NPlot.Grid.GridType.Coarse;
            grid.MajorGridPen = new Pen(Color.LightGray, 1.0f);
            grid.MinorGridPen = new Pen(Color.LightGray, 1.0f);

            plotSurface2D1.Clear();
            //pictureBox2.Visible = false;


        }

        public Form1()
        {
            InitializeComponent();
            //   Plot_Init();

            try
            {
               // pictureBox1.Image = Image.FromFile("C:\\Projects\\.Net\\VOI_DAQ\\VOI_DAQ\\Pics\\spinning_wheel3.jpg");
               // pictureBox2.BackgroundImage = Image.FromFile("C:\\Projects\\.Net\\VOI_DAQ\\VOI_DAQ\\Pics\\DataBox.gif");
                //pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("There was an error opening the pictures." + "  Please check the path.");
            }

            CheckForIllegalCrossThreadCalls = false;
            SP1_IO_Serial_UpdateCOMPortList();

           SetArrayColors();
       //     DAQ.Slope = (double)numericUpDown_incline.Value;
         //   DAQ.Wheel_Diameter = (Int16)numericUpDown_Wheel.Value;

            SP1_textBox_PortName.Text = "No Connection";

        //    richTextBox_Current.Text = DAQ.Current_Simulator.ToString();
       //     richTextBox_Voltage.Text = DAQ.Voltage_Simulator.ToString();
       //     Simulator.ActiveForm.Text = DAQ.Current_Simulator.ToString();

        }
  
        public void SP1_IO_Serial_UpdateCOMPortList()
        {
            /*
            int i; i = 0; bool foundDifference;
            foundDifference = false;
            //   textBox_PortName.Text = PortConnectName;
            //If the number of COM ports is different than the last time we
            //  checked, then we know that the COM ports have changed and we
            //  don't need to verify each entry.
 
            if (SP1_IO_Serial_lstCOMPorts.Items.Count == SerialPort.GetPortNames().Length)
            {
                try
                {
                    foreach (string s in SerialPort.GetPortNames())
                    {
                        if (SP1_IO_Serial_lstCOMPorts.Items[i++].Equals(s) == false)
                        {
                            foundDifference = true;

                        }
                    }
                }
                catch { }
            }
            else foundDifference = true;
            if (foundDifference == false) return;
            //If something has changed, then clear the list
            SP1_IO_Serial_lstCOMPorts.Items.Clear();
            String PortPosition = "Not Connected";
            //Add all of the current COM ports to the list
            foreach (string s in SerialPort.GetPortNames())
            {
                SP1_IO_Serial_lstCOMPorts.Items.Add(s);
                if (s == SP1.PortConnectName) PortPosition = SP1.PortConnectName;
                //    SP1_IO_Serial_lstCOMPorts.SelectedIndex = 0;  // 25.04.2014
            }
            if (PortPosition == "Not Connected")
            {

                SP1_DisConnect_Procedure();
            }
            SP1_textBox_PortName.Text = PortPosition;
            */
       
        }
        /*
        void  Check_Com_VID_PID(String VID, String PID)
        {
            SP1_SendtextBox.Text = " ";
            //    return "COM11";
            List<string> ComPortNames(String VID, String PID)
            {
                String pattern = String.Format("^VID_{0}.PID_{1}", VID, PID);
                Regex _rx = new Regex(pattern, RegexOptions.IgnoreCase);
                List<string> comports = new List<string>();
                RegistryKey rk1 = Registry.LocalMachine;
                RegistryKey rk2 = rk1.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum");
                foreach (String s3 in rk2.GetSubKeyNames())
                {
                    RegistryKey rk3 = rk2.OpenSubKey(s3);
                    foreach (String s in rk3.GetSubKeyNames())
                    {
                        if (_rx.Match(s).Success)
                        {
                            RegistryKey rk4 = rk3.OpenSubKey(s);
                            foreach (String s2 in rk4.GetSubKeyNames())
                            {
                                RegistryKey rk5 = rk4.OpenSubKey(s2);
                                RegistryKey rk6 = rk5.OpenSubKey("Device Parameters");
                                comports.Add((string)rk6.GetValue("PortName"));
                            }
                        }
                    }
                }
                return comports;
            }

       //    List<string> names = ComPortNames(SP1.Def_VID, SP1.Def_PID);
                   List<string> names = ComPortNames(SP1.Def_VID, SP1.Def_PID);
         //   List<string> names = ComPortNames("2341", "0042");
            if (names.Count > 0)
            {
     //           SP1_textBox_PortName.Text = "No Matching Port ";
           //     textBox1.Text = "No Matching Port ";
                foreach (String s in SerialPort.GetPortNames())
                {
                    if (names.Contains(s)) { 
                        //  textBox1.Text = "Port " + s;
                        //  Console.WriteLine("port");
                    //    SP1_textBox_PortName.Text = s;
                        SP1_SendtextBox.Text = s;
                        Newport = s;
                       // return s;
                    }
                }
            }
            //  else
            //   Console.WriteLine("No COM ports found");
            // textBox1.Text = "No COM ports found";
            SP1_SendtextBox.Text = "No COM ports found";
        //    return "No COM ports found";
        }
        */
        String Newport;
        void ComPort_List(String VID, String PID, String NAM)
        {
            SP1_textBox_Device.Text = NAM;
            List<string> names = ComPortNames(VID, PID); // ftdi
            if (names.Count > 0)
            {
                foreach (String s in SerialPort.GetPortNames())
                {
                    if (names.Contains(s))
                    {
                        //   Console.WriteLine("My Arduino port is " + s);
                     //   textBox1.Text += s + "     " + NAM + "\r\n";
                        //SP1.PortConnectName = SP1_serialPort.PortName;
                        //SerialPort.
                        Newport = s;
                        // return s;
                    }
                 //   else SP1_SendtextBox.Text = "No COM ports found";
                }
            }
            else
                //   textBox1.Text = "No COM ports found";  //
                SP1_SendtextBox.Text = "No COM ports found";
            // return "";
        }
        List<string> ComPortNames(String VID, String PID)
        {
            String pattern = String.Format("^VID_{0}.PID_{1}", VID, PID);
            Regex _rx = new Regex(pattern, RegexOptions.IgnoreCase);
            List<string> comports = new List<string>();
            RegistryKey rk1 = Registry.LocalMachine;
            RegistryKey rk2 = rk1.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum");
            foreach (String s3 in rk2.GetSubKeyNames())
            {
                //    textBox1.Text += s3 + "\n";
                // textBox1.Text += s3 + "\r\n";
                //   textBox1.Text += s3 + Environment.NewLine;
                RegistryKey rk3 = rk2.OpenSubKey(s3);
                foreach (String s in rk3.GetSubKeyNames())
                {
                    if (_rx.Match(s).Success)
                    {
                        RegistryKey rk4 = rk3.OpenSubKey(s);
                        foreach (String s2 in rk4.GetSubKeyNames())
                        {
                            RegistryKey rk5 = rk4.OpenSubKey(s2);
                            RegistryKey rk6 = rk5.OpenSubKey("Device Parameters");
                            comports.Add((string)rk6.GetValue("PortName"));
                        }
                    }
                }
            }
            return comports;
        }
        public void Serial_UpdateCOMPortList_VID_PID()
        {
       //     String Newport = Check_Com_VID_PID();
         //   Check_Com_VID_PID(SP1.VID_3, SP1.PID_3);
           // ComPort_List(SP1.VID_3, SP1.PID_3, SP1.NAM_3);
            ComPort_List(SP1.Def_VID, SP1.Def_PID, SP1.Def_NAM);
            if (SP1.PortConnectName != Newport) SP1_DisConnect_Procedure();


        }
            void SP1_Connect_Procedure()
        {
            try
            {
                //Get the port name from the application list box.
                //  the PortName attribute is a string name of the COM
                //  port (e.g. - "COM1").
                //      SP1_IO_Serial_lstCOMPorts.SelectedIndex = 2;
                //      SP1_serialPort.PortName = SP1_IO_Serial_lstCOMPorts.Items[SP1_IO_Serial_lstCOMPorts.SelectedIndex].ToString();
     
            //    SP1_serialPort.PortName = Check_Com_VID_PID();
                
                ComPort_List(SP1.Def_VID, SP1.Def_PID, SP1.Def_NAM);
                SP1_serialPort.PortName = Newport;
                //    SP1_IO_Serial_lstCOMPorts.Items[SP1_IO_Serial_lstCOMPorts.SelectedIndex].ToString()

                SP1.PortConnectName = SP1_serialPort.PortName;
                //      SP1_textBox_PortName.Text = SP1.PortConnectName;
                //Open the COM port.
                //     SP1_serialPort.BaudRate = 9600;
               // SP1_serialPort.BaudRate = 57600;
                 SP1_serialPort.BaudRate = 115200;
                //    SP1_serialPort.BaudRate = 128000;

                SP1_textBox_PortName.Text = SP1_serialPort.PortName + DAQ.nl;
                SP1_textBox_PortName.Text += SP1_serialPort.BaudRate.ToString() + " bps" + DAQ.nl;
                SP1_textBox_PortName.Text += "VID " + SP1.Def_VID + DAQ.nl;
                SP1_textBox_PortName.Text += "PID " + SP1.Def_PID;
                SP1_serialPort.Parity = Parity.None;
                SP1_serialPort.StopBits = StopBits.One;
                SP1_serialPort.DataBits = 8;
                SP1_serialPort.Handshake = Handshake.None;
                //        SP1_serialPort.RtsEnable = true;   // SERIAL_8N1 (the default)
                SP1_serialPort.Open();

                SP1_ConnectButton.Text = "Disconnect";
                SP1_IO_Serial_lstCOMPorts.Enabled = false;
                //   btnClose.Enabled = true;
              //  SP1_DisConnectButton.Enabled = true;
                //            textBox1.Clear(); 
                //            textBox1.AppendText("Connected.\r\n");
              startToolStripMenuItem.Enabled = true;

            }
            catch
            {
                SP1_DisConnect_Procedure();
            }
        }

        void SP1_DisConnect_Procedure()
        {
            SP1_textBox_Device.Text = " ";
            SP1.PortConnectName = "No Connection";
            DAQ.Connect = false;
            SP1_ConnectButton.Text = "Connect";

            //Reset the state of the application objects
            SP1_textBox_PortName.Text =  "No Connection";
            SP1_IO_Serial_lstCOMPorts.Enabled = true;

       //     startToolStripMenuItem.Enabled = false;
      //      stopToolStripMenuItem.Enabled = false;

            DAQ.Index = 0; // index
            DAQ.Offset = 0; // index
            DAQ.Log_Counter = 0;
            DAQ.Log_SampleCounter = 0;
            SP1.ReadSequence = 0;
            try
            {
                if (SP1_serialPort.IsOpen)
                {
                    SP1_serialPort.ReadExisting();
                    SP1_serialPort.DiscardInBuffer();
                    SP1_serialPort.DiscardOutBuffer();
                }
                SP1_serialPort.Close();
            }
            catch { }

            //Dispose the In and Out buffers;
            //    SP1_serialPort.ReadExisting();
            //This section of code will try to close the COM port.
            //  Please note that it is important to use a try/catch
            //  statement when closing the COM port.  If a USB virtual
            //  COM port is removed and the PC software tries to close
            //  the COM port before it detects its removal then
            //  an exeception is thrown.  If the execption is not in a
            //  try/catch statement this could result in the application
            //  crashing.
            try
            {
                //Dispose the In and Out buffers;
                SP1_serialPort.DiscardInBuffer();
                SP1_serialPort.DiscardOutBuffer();
                //Close the COM port
                SP1_serialPort.Close();
            }
            //If there was an exeception then there isn't much we can
            //  do.  The port is no longer available.
            catch { }
        }

        void SP1_ReceiveData_Procedure()
        {
            try
            {
                if (SP1.ReadSequence == 0)
                {
                    if (SP1_serialPort.BytesToRead >= (SP1.PREAMBLE_BYTES + SP1.DATALENGTH_BYTES)) // READ PREAMBLE AND LENGTH BYTES
                    {
                        SP1_serialPort.Read(SP1.Buffer, 0, (SP1.PREAMBLE_BYTES + SP1.DATALENGTH_BYTES));

                        SP1.Preamble = (UInt16)((SP1.Buffer[0] << SP1.SHIFT8) + SP1.Buffer[1]);
                        //    SP1.Length = (UInt16)((SP1.Buffer[2] << SP1.SHIFT8) + SP1.Buffer[3]);

                        SP1.Length = SP1.DEFAULT_LENGTH;

                        if (SP1.Preamble == SP1.DEFAULT_PREAMBLE) // CHECK IF PREAMLE IS EQUAL TO THE DEFAULT ONE
                        {
                            SP1.ReadSequence = 1; // PREAMBLE MATCHES WITH THE DEFAULT ONE
                                                  // SP1.Preamble_Fail = 0;
                        }
                        else
                        {
                            SP1.Preamble_Trial++;
                            /*
                            if(SP1.Preamble_Fail > 128)
                            {
                                SP1_DisConnect_Procedure();
                                return;
                            }
                            */
                            //  SP1_serialPort.DiscardInBuffer();
                            SP1.ReadSequence = 0;   // PREAMBLE MATCH FAIL
                                                    //  SP1_serialPort.ReadExisting();
                                                    //   return;
                                                    // SP1.Length = (UInt16)(SP1.PREAMBLE_BYTES + SP1.DATALENGTH_BYTES); // default
                            SP1.Length = SP1.DEFAULT_LENGTH;

                            //        SP1_serialPort.ReadExisting();
                        }
                    }
                }
                if (SP1.ReadSequence == 1) // IF MATCH SUCCESFULL GO ON READING THE REMAINING
                {
                    if (SP1_serialPort.BytesToRead >= SP1.Length - (SP1.PREAMBLE_BYTES + SP1.DATALENGTH_BYTES)) // READ REMAINING CRC AND DATA BYTES IF ALL AT BUFFER
                    {
                        SP1_serialPort.Read(SP1.ReceiveBuf, 0, (int)SP1.Length - (SP1.PREAMBLE_BYTES + SP1.DATALENGTH_BYTES));  // READ REMAINING CRC AND DATA BYTES
                        SP1.ReadSequence = 2;
                        SP1_CalculateRcvData();
                        SP1.ReadSequence = 0;
                    }
                }

                /*
                SP1_serialPort.Read(SP1.Buffer, 0, (SP1.PREAMBLE_BYTES + SP1.DATALENGTH_BYTES));
                SP1.Preamble = (UInt16)((SP1.Buffer[0] << SP1.SHIFT8) + SP1.Buffer[1]);
                //SP1.Preamble = SP1.Buffer[0];
                SP1.Length = (UInt16)((SP1.Buffer[2] << SP1.SHIFT8) + SP1.Buffer[3]);
                */

            }
            catch
            {
                SP1_DisConnect_Procedure();
                //       TxtData = "hata";
                //;  TrigDisp = 1;
                SP1.ReadSequence = 0;
            }
        }

        void SP1_SendData_Procedure()
        {
           // array < unsigned char> ^USB_SendBuf = gcnew array < unsigned char> (NUMBER_DATA_PC2MICRO_SEND);

            
            try
            {
                     //         SP1_CalculateSendData();
                             
            //          SP1_SendtextBox.Text = SP1_SendTextData();
            //        SP1_DataRcvtextBox.Text = SP1_PrintSendText();
            SP1.SendBuf[0] = 0xA;
            SP1.SendBuf[1] = 0xA;
                SP1.SendBuf[2] = 0xA;
                SP1.SendBuf[3] = 0xA;
                SP1_serialPort.Write(SP1.SendBuf, 0, 24);

            //    SP1_serialPort.Write(SP1.SendBuf, 0, (int)SP1.DEFAULT_LENGTH);

                /*
                SendBuf[1] = Relays.Valve4Way;
                SendBuf[2] = Motor.Final.TargetFrequency;
                USB_SendBuf[3] = EEV.Final.CycleTargetPulse >> 8;
                USB_SendBuf[4] = EEV.Final.CycleTargetPulse;
                USB_SendBuf[5] = Fan.FinalRpm >> 8;
                USB_SendBuf[6] = Fan.FinalRpm;
                USB_SendBuf[7] = Fan.Indoor.FinalRpm >> 8;
                USB_SendBuf[8] = Fan.Indoor.FinalRpm;
                USB_SendBuf[9] = IndoorCommand.SwingYatay.Mode;
                USB_SendBuf[10] = IndoorCommand.SwingDikey.Mode;

                unsigned int CRC = 0XA0A0;
                for (unsigned char i = 0; i < 11; i++)
                {
                    CRC ^= USB_SendBuf[i];
                }
                USB_SendBuf[11] = CRC >> 8;
                USB_SendBuf[12] = CRC;
                USB_serialPort1->Write(USB_SendBuf, 0, NUMBER_DATA_PC2MICRO_SEND - 1);// Writes a specified number of bytes to the serial port using d
                */


            }
            catch
            {
                SP1_DisConnect_Procedure();
            }
        }
        void SP1_serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            SP1_ReceiveData_Procedure();
        }

        void SP1_ConnectButton_Click(object sender, EventArgs e)
        {
            if (DAQ.Connect == false)
            {// disconneccted -< connect
                SP1_Connect_Procedure();
                DAQ.Connect = true;
            }
            else
            {
                SP1_DisConnect_Procedure();
                DAQ.Connect = false;
            }

        }

        void SP1_SendButton_Click(object sender, EventArgs e)
        {
            SP1_SendData_Procedure();
        }

        void button1_Click(object sender, EventArgs e)
        {
            SP1_richTextBox.Clear();
            SP1_DatatextBox.Clear();
            SP1.CRC_Error = 0;
        }
          
        void SP1_DisConnectButton_Click(object sender, EventArgs e)
        {
            SP1_DisConnect_Procedure();
        }

        /*              ******************  serial port1 ***********************************************************/
        unsafe void SP1_CalculateRcvData()
        {

            //      DAQ.EncPulse_InspectedMax = (Int32)((SP1.ReceiveBuf[0] << SP1.SHIFT24) + (SP1.ReceiveBuf[1] << SP1.SHIFT16) + (SP1.ReceiveBuf[2] << SP1.SHIFT8) + SP1.ReceiveBuf[3]);
            //     DAQ.EncPulse_Current = (Int32)((SP1.ReceiveBuf[4] << SP1.SHIFT24) + (SP1.ReceiveBuf[5] << SP1.SHIFT16) + (SP1.ReceiveBuf[6] << SP1.SHIFT8) + SP1.ReceiveBuf[7]);
            //    Speed_PID = (Int16)((SP1.ReceiveBuf[8] << SP1.SHIFT8) + SP1.ReceiveBuf[9]);
            //     Final_PID = (Int16)((SP1.ReceiveBuf[10] << SP1.SHIFT8) + SP1.ReceiveBuf[11]);
            //      DAQ.PID = (UInt16)Final_PID;
            /*

            ProfilePulse_Mode = SP1.ReceiveBuf[12];
            MainMode = SP1.ReceiveBuf[13];

            EncPulse_DoorLength = (Int16)((SP1.ReceiveBuf[14] << SP1.SHIFT8) + SP1.ReceiveBuf[15]);

            SpeedAverage_S_Profile = (UInt16)((SP1.ReceiveBuf[16] << SP1.SHIFT8) + SP1.ReceiveBuf[17]);
            Speed_Target = (UInt16)((SP1.ReceiveBuf[18] << SP1.SHIFT8) + SP1.ReceiveBuf[19]);
            ProfilePulse_Command = SP1.ReceiveBuf[20];
            Speed_Actual = (UInt16)((SP1.ReceiveBuf[21] << SP1.SHIFT8) + SP1.ReceiveBuf[22]);
            ProfilePulse_Direction = SP1.ReceiveBuf[23];
            */

            /*
            DAQ.Current_Setlevel = (UInt16)((SP1.ReceiveBuf[24] << SP1.SHIFT8) + SP1.ReceiveBuf[25]);
            DAQ.Current_Sampled = (UInt16)((SP1.ReceiveBuf[26] << SP1.SHIFT8) + SP1.ReceiveBuf[27]);

            DAQ.Error = (Int16)((SP1.ReceiveBuf[28] << SP1.SHIFT8) + SP1.ReceiveBuf[29]);
   //         MLDC.CurrentError = (Int16)((SP1.ReceiveBuf[30] << SP1.SHIFT8) + SP1.ReceiveBuf[31]);
            DAQ.PID_HIGHLIMT = (UInt16)((SP1.ReceiveBuf[30] << SP1.SHIFT8) + SP1.ReceiveBuf[31]);
            DAQ.PID_LOWLIMT = (UInt16)((SP1.ReceiveBuf[32] << SP1.SHIFT8) + SP1.ReceiveBuf[33]);
        //    UInt16 temp = 500;
            DAQ.Current_Diff = (Int32)(DAQ.Current_Sampled - 524);
            DAQ.Current_Set = (Int32)(DAQ.Current_Setlevel - 524);
            */
            UInt16 MaxLength = (UInt16)(SP1.Length - (SP1.PREAMBLE_BYTES + SP1.DATALENGTH_BYTES));
            SP1.CRC_Received = (UInt16)((SP1.ReceiveBuf[(MaxLength - 2)] << SP1.SHIFT8) + SP1.ReceiveBuf[MaxLength - 1]);
            //      SP1.CRC_Received = (UInt16)((SP1.ReceiveBuf[34] << SP1.SHIFT8) + SP1.ReceiveBuf[35]);

            SP1.CRC_Calc = SP1.DEFAULT_CRC_INIT;


            for (int i = SP1.PREAMBLE_BYTES; i < (SP1.PREAMBLE_BYTES + SP1.DATALENGTH_BYTES); i++)  //  data crc
            {
                SP1.CRC_Calc ^= SP1.Buffer[i];
            }     
            for (int i = 0; i < (MaxLength - SP1.CRC_BYTES); i++)  //  data crc
            {
                SP1.CRC_Calc ^= SP1.ReceiveBuf[i];
            }

            SP1.CRC_Calc <<= 8;

            for (int i = SP1.PREAMBLE_BYTES; i < (SP1.PREAMBLE_BYTES + SP1.DATALENGTH_BYTES); i++)  //  data crc
            {
                SP1.CRC_Calc ^= SP1.Buffer[i];
            }
            for (int i = 0; i < (MaxLength - SP1.CRC_BYTES); i++)  //  data crc
            {
                SP1.CRC_Calc ^= SP1.ReceiveBuf[i];
            }

            /*

            */
            if (SP1.CRC_Calc != SP1.CRC_Received)
            {
                SP1.CRC_Error++;
            }
            else
            {
                SP1.CRC_Success++;

                byte B_Count = 1;  //  ++
                float Sign = -1.00f;

                UInt32 Rec_Val = (UInt32)((SP1.ReceiveBuf[B_Count] << SP1.SHIFT24) + (SP1.ReceiveBuf[++B_Count] << SP1.SHIFT16) +
                                (SP1.ReceiveBuf[++B_Count] << SP1.SHIFT8) + SP1.ReceiveBuf[++B_Count]);  //32 bit
                Int32 Temp = (Int32)Rec_Val;


                if (Rec_Val > 0x7FFFFFFF) // 0x7FFFFFFF
                {
                    Temp *= -1;  // NEGATIVE
                    Temp--;
                    Sign = -1.00f;
                }
                else Sign = 1.00f;
                DAQ.Temperature_OnBoard = (float)Temp / 100;
                DAQ.Temperature_OnBoard *= Sign;
                if (DAQ.Temperature_OnBoard > 60.0) DAQ.Temperature_OnBoard = 60;
                if (DAQ.Temperature_OnBoard < -10.0) DAQ.Temperature_OnBoard = -10;

                //   DAQ.Temperature_Float = ((float)DAQ.Temperature_Convert/100).ToString.Replace(",", "."));
                DAQ.Temperature_Float = ((float)Temp / 100).ToString();
                DAQ.Temperature_Float = DAQ.Temperature_Float.Replace(",", ".");




            //    DAQ.BME680_Temp_1 = DAQ.Temperature_Float;

                Rec_Val = (UInt32)((SP1.ReceiveBuf[++B_Count] << SP1.SHIFT24) + (SP1.ReceiveBuf[++B_Count] << SP1.SHIFT16) +
                                (SP1.ReceiveBuf[++B_Count] << SP1.SHIFT8) + SP1.ReceiveBuf[++B_Count]);  //32 bit
                Temp = (Int32)Rec_Val;
                if (Rec_Val > 0x7FFFFFFF) // 0x7FFFFFFF
                {
                    Temp *= -1;// NEGATIVE
                    Temp--;
                    Sign = -1.00f;
                }
                else Sign = 1.00f;
                DAQ.Humidity_OnBoard = (float)Temp / 100;
                DAQ.Humidity_OnBoard *= Sign;
                if (DAQ.Humidity_OnBoard > 90.0) DAQ.Humidity_OnBoard = 90;
                if (DAQ.Humidity_OnBoard < 10.0) DAQ.Humidity_OnBoard = 10;

                DAQ.Humidity_Float = ((float)Temp / 100).ToString(("#.##"));
                DAQ.Humidity_Float = DAQ.Humidity_Float.Replace(",", ".");
               // DAQ.BME680_Hum_1 = DAQ.Humidity_Float;

                DAQ.Light_Visible = (UInt16)((SP1.ReceiveBuf[++B_Count] << SP1.SHIFT8) + SP1.ReceiveBuf[++B_Count]);  //16 bit
                DAQ.Light_Infrared = (UInt16)((SP1.ReceiveBuf[++B_Count] << SP1.SHIFT8) + SP1.ReceiveBuf[++B_Count]);  //16 bi
                ///// voc /////////////////
                Rec_Val = (UInt32)((SP1.ReceiveBuf[++B_Count] << SP1.SHIFT24) + (SP1.ReceiveBuf[++B_Count] << SP1.SHIFT16) +
                                (SP1.ReceiveBuf[++B_Count] << SP1.SHIFT8) + SP1.ReceiveBuf[++B_Count]);  //32 bit
                Temp = (Int32)Rec_Val;
                if (Rec_Val > 0x7FFFFFFF) // 0x7FFFFFFF
                {
                    Temp *= -1;// NEGATIVE
                    Temp--;
                    Sign = -1.00f;
                }
                else Sign = 1.00f;
                DAQ.Accelometer_x = (float)Temp / 100;
                DAQ.Accelometer_x *= Sign;
                DAQ.AccelometerX = (DAQ.Accelometer_x).ToString(("#.##"));

                /// 2.BME
                Rec_Val = (UInt32)((SP1.ReceiveBuf[++B_Count] << SP1.SHIFT24) + (SP1.ReceiveBuf[++B_Count] << SP1.SHIFT16) +
                                (SP1.ReceiveBuf[++B_Count] << SP1.SHIFT8) + SP1.ReceiveBuf[++B_Count]);  //32 bit
                Temp = (Int32)Rec_Val;
                if (Rec_Val > 0x7FFFFFFF) // 0x7FFFFFFF
                {
                    Temp *= -1;  // NEGATIVE
                    Temp--;
                    Sign = -1.00f;
                }
                else Sign = 1.00f;
                DAQ.Accelometer_y = (float)Temp / 100;
                DAQ.Accelometer_y *= Sign;
                DAQ.AccelometerY = (DAQ.Accelometer_y).ToString(("#.##"));

                /// 4. BME
                Rec_Val = (UInt32)((SP1.ReceiveBuf[++B_Count] << SP1.SHIFT24) + (SP1.ReceiveBuf[++B_Count] << SP1.SHIFT16) +
                (SP1.ReceiveBuf[++B_Count] << SP1.SHIFT8) + SP1.ReceiveBuf[++B_Count]);  //32 bit
                Temp = (Int32)Rec_Val;
                if (Rec_Val > 0x7FFFFFFF) // 0x7FFFFFFF
                {
                    Temp *= -1;  // NEGATIVE
                    Temp--;
                    Sign = -1.00f;
                }
                else Sign = 1.00f;
                DAQ.Accelometer_z = (float)Temp / 100;
                DAQ.Accelometer_z *= Sign;
                DAQ.AccelometerZ = (DAQ.Accelometer_z).ToString(("#.##"));


                Rec_Val = (UInt32)((SP1.ReceiveBuf[++B_Count] << SP1.SHIFT24) + (SP1.ReceiveBuf[++B_Count] << SP1.SHIFT16) +
                             (SP1.ReceiveBuf[++B_Count] << SP1.SHIFT8) + SP1.ReceiveBuf[++B_Count]);  //32 bit
                Temp = (Int32)Rec_Val;
                if (Rec_Val > 0x7FFFFFFF) // 0x7FFFFFFF
                {
                    Temp *= -1;  // NEGATIVE
                    Temp--;
                    Sign = -1.00f;
                   
                }
                else Sign = 1.00f;
                DAQ.Gyrometer_x = (float)Temp / 100;
                DAQ.Gyrometer_x *= Sign;
                DAQ.GyrometerX = (DAQ.Gyrometer_x).ToString(("#.##"));
                

                Rec_Val = (UInt32)((SP1.ReceiveBuf[++B_Count] << SP1.SHIFT24) + (SP1.ReceiveBuf[++B_Count] << SP1.SHIFT16) +
                             (SP1.ReceiveBuf[++B_Count] << SP1.SHIFT8) + SP1.ReceiveBuf[++B_Count]);  //32 bit
                Temp = (Int32)Rec_Val;
                if (Rec_Val > 0x7FFFFFFF) // 0x7FFFFFFF
                {
                    Temp *= -1;  // NEGATIVE
                    Temp--;
                    Sign = -1.00f;
                    Sign = -1.00f;
                }
                else Sign = 1.00f;
                DAQ.Gyrometer_y = (float)Temp / 100;
                DAQ.Gyrometer_y *= Sign;
                DAQ.GyrometerY = (DAQ.Gyrometer_y).ToString(("#.##"));

                Rec_Val = (UInt32)((SP1.ReceiveBuf[++B_Count] << SP1.SHIFT24) + (SP1.ReceiveBuf[++B_Count] << SP1.SHIFT16) +
                           (SP1.ReceiveBuf[++B_Count] << SP1.SHIFT8) + SP1.ReceiveBuf[++B_Count]);  //32 bit
                Temp = (Int32)Rec_Val;
                if (Rec_Val > 0x7FFFFFFF) // 0x7FFFFFFF
                {
                    Temp *= -1;  // NEGATIVE
                    Temp--;
                    Sign = -1.00f;
                }
                else Sign = 1.00f;
                DAQ.Gyrometer_z = (float)Temp / 100;
                DAQ.Gyrometer_z *= Sign;
                DAQ.GyrometerZ = (DAQ.Gyrometer_z).ToString(("#.##"));

                Rec_Val = (UInt32)((SP1.ReceiveBuf[++B_Count] << SP1.SHIFT24) + (SP1.ReceiveBuf[++B_Count] << SP1.SHIFT16) +
                           (SP1.ReceiveBuf[++B_Count] << SP1.SHIFT8) + SP1.ReceiveBuf[++B_Count]);  //32 bit
                Temp = (Int32)Rec_Val;
               
                if (Rec_Val > 0x7FFFFFFF) // 0x7FFFFFFF
                {
                    Temp *= -1;  // NEGATIVE
                    Temp--;
                     Sign = -1.00f;
                }
                else Sign = 1.00f;
                DAQ.Magnetometer_x = (float)Temp / 1000;
                DAQ.Magnetometer_x *= Sign;
                DAQ.MagnetometerX = (DAQ.Magnetometer_x).ToString(("#.##"));

                Rec_Val = (UInt32)((SP1.ReceiveBuf[++B_Count] << SP1.SHIFT24) + (SP1.ReceiveBuf[++B_Count] << SP1.SHIFT16) +
                           (SP1.ReceiveBuf[++B_Count] << SP1.SHIFT8) + SP1.ReceiveBuf[++B_Count]);  //32 bit
                Temp = (Int32)Rec_Val;
                if (Rec_Val > 0x7FFFFFFF) // 0x7FFFFFFF
                {
                    Temp *= -1;  // NEGATIVE
                    Temp--;
                    Sign = -1.00f;
                }
                else Sign = 1.00f;
                DAQ.Magnetometer_y = (float)Temp / 1000;
                DAQ.Magnetometer_y *= Sign;
                DAQ.MagnetometerY = (DAQ.Magnetometer_y).ToString(("#.##"));

                Rec_Val = (UInt32)((SP1.ReceiveBuf[++B_Count] << SP1.SHIFT24) + (SP1.ReceiveBuf[++B_Count] << SP1.SHIFT16) +
           (SP1.ReceiveBuf[++B_Count] << SP1.SHIFT8) + SP1.ReceiveBuf[++B_Count]);  //32 bit
                Temp = (Int32)Rec_Val;
                if (Rec_Val > 0x7FFFFFFF) // 0x7FFFFFFF
                {
                    Temp *= -1;  // NEGATIVE
                    Temp--;
                    Sign = -1.00f;
                }
                else Sign = 1.00f;
                DAQ.Magnetometer_z = (float)Temp / 1000;
                DAQ.Magnetometer_z *= Sign;
                DAQ.MagnetometerZ = (DAQ.Magnetometer_z).ToString(("#.##"));




                //       DAQ.Battery_Volt = (UInt16)((SP1.ReceiveBuf[++B_Count] << SP1.SHIFT8) + SP1.ReceiveBuf[++B_Count]);  //16 bit
                //       DAQ.Power_State =SP1.ReceiveBuf[++B_Count];
                //       DAQ.Fan_Volt = (UInt16)((SP1.ReceiveBuf[++B_Count] << SP1.SHIFT8) + SP1.ReceiveBuf[++B_Count]);  //16 bit
                //       DAQ.Light_Visible = (UInt16)((SP1.ReceiveBuf[++B_Count] << SP1.SHIFT8) + SP1.ReceiveBuf[++B_Count]);  //16 bit
                //       DAQ.Light_Infrared = (UInt16)((SP1.ReceiveBuf[++B_Count] << SP1.SHIFT8) + SP1.ReceiveBuf[++B_Count]);  //16 bi
                DAQ.Median_Total_VOC1 += DAQ.Multi_Gas_1_VOC;
                DAQ.Median_Total_VOC2 += DAQ.Multi_Gas_2_VOC;
                DAQ.Median_Total_VOC3 += DAQ.Multi_Gas_3_VOC;
                DAQ.Median_Total_VOC4 += DAQ.Multi_Gas_4_VOC;
                DAQ.Median_Counter++;
                if (DAQ.Median_Counter >= 100)
                {
                    DAQ.Median_Counter = 0;
                    DAQ.Median_Total_VOC1 /= 100;

                }
                DAQ.Int_Counter++;
                if (DAQ.Int_Counter >= 10)
                {
                    DAQ.Int_Counter = 0;
                    //    Array_Fill();
                    //   Plot_Chart();
                }



                 Array_Fill();
                Plot_Chart();


                if (DAQ.Log_Status == true)
                {
                    if (SP1_serialPort.IsOpen == false)
                    {
                        DAQ.Log_Status = false;
                        MessageBox.Show("Com Port Error!" + DAQ.nl + "Loggging Disabled");
                        DAQ.Log_Counter = 0;
                        startToolStripMenuItem.Enabled = true;
                        stopToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        LOG_DataLogProcess(DAQ.Original_Log_File);
                        startToolStripMenuItem.Enabled = false;
                       // stopToolStripMenuItem.Enabled = false;
                    }
                }
            }
        }

        String SP1_GetTextdata2()
        {

            String Textdata = "";
            try
            {
                for (int i = 0; i < (SP1.PREAMBLE_BYTES + SP1.DATALENGTH_BYTES); i++)
                {
                    //  Textdata += i.ToString() + " : " + SP1_Buffer[i].ToString() + " / 0 X" + SP1_Buffer[i].ToString("X") + System.Environment.NewLine;
                    Textdata += i.ToString() + "." + SP1.Buffer[i].ToString() + "  ";
                }
                Textdata += System.Environment.NewLine;
                int k = 0; int j = 0;
                for (int i = (SP1.PREAMBLE_BYTES + SP1.DATALENGTH_BYTES); i < SP1.Length; i++)
                {

                    // Textdata += i.ToString() + " : " + SP1_ReceiveBuf[k].ToString() +  " / 0 X"+SP1_ReceiveBuf[k].ToString("X") + System.Environment.NewLine;
                    Textdata += i.ToString() + "." + SP1.ReceiveBuf[k].ToString() + "  ";
                    k++;
                    j++;
                    if (j > 4)
                    {
                        Textdata += System.Environment.NewLine;
                        j = 0;
                    }
                }

            }
            catch { }
            return Textdata;
        }
        String SP1_GetTextdata()
        {
            //String Textdata = "";

          //  String Textdata = "Received Data " + System.Environment.NewLine;
            String Textdata = "Preamble " + "0X" + SP1.Preamble.ToString("X");
            Textdata += "   Sync "  + SP1.Preamble_Trial.ToString( );

            Textdata += "  Length:" + SP1.Length.ToString() + DAQ.nl;
            Textdata += "CRC_Recv." + "0X" + SP1.CRC_Received.ToString("X");
            Textdata += "     Calc. " + "0X" + SP1.CRC_Calc.ToString("X") + DAQ.nl;

            Textdata += "CRC_Err. " + SP1.CRC_Error.ToString();
            Textdata += "    Suc.  " + SP1.CRC_Success.ToString() + DAQ.nl;

            if (SP1.CRC_Success != 0)
            {
                float ErroRate = SP1.CRC_Error * 100000 / SP1.CRC_Success;
                if (ErroRate > 0) {
                    Textdata += "Error Rate : %" + (ErroRate / 1000).ToString();
                }
                else Textdata += "Error Rate : %0.0000";
            }
            else Textdata += "Error Rate : % 0.0000";

            Textdata += System.Environment.NewLine + DAQ.nl;

            Textdata += "Temperature  :  " + DAQ.Temperature_Float + " °C " + DAQ.nl;
            Textdata += "Humidity  % :  " + DAQ.Humidity_Float + "  " + DAQ.nl;
            Textdata += "Visible Light  :  " + DAQ.Light_Visible + " Lux  " + DAQ.nl;
            Textdata += "Infrared Light  :  " + DAQ.Light_Infrared + " Lux  " + DAQ.nl;
            Textdata += "Acceleration X  :  " + DAQ.AccelometerX + " m/s²  " + DAQ.nl;
            Textdata += "Acceleration Y  :  " + DAQ.AccelometerY + " m/s²  " + DAQ.nl;
            Textdata += "Acceleration Z  :  " + DAQ.AccelometerZ + " m/s²  " + DAQ.nl;
            Textdata += "Gyrometer X  :  " + DAQ.GyrometerX + " rad/s  " + DAQ.nl;
            Textdata += "Gyrometer Y  :  " + DAQ.GyrometerY + " rad/s  " + DAQ.nl;
            Textdata += "Gyrometer Z  :  " + DAQ.GyrometerZ + " rad/s  " + DAQ.nl;
            Textdata += "Magnetometer X  :  " + DAQ.MagnetometerX + " uT  " + DAQ.nl;
            Textdata += "Magnetometer Y  :  " + DAQ.MagnetometerY + " uT  " + DAQ.nl;
            Textdata += "Magnetometer Z  :  " + DAQ.MagnetometerZ + " uT  " + DAQ.nl;



            /*
            Textdata += "Multi_Gas_1_VOC  : " + DAQ.Multi_Gas_1_VOC.ToString() + "  " + DAQ.nl;
            Textdata += "Multi_Gas_1_C2H5OH:" + DAQ.Multi_Gas_1_C2H5OH.ToString() + "  " + DAQ.nl;
            Textdata += "Multi_Gas_1_CO  :  " + DAQ.Multi_Gas_1_CO.ToString() + "  " + DAQ.nl;
            Textdata += "Multi_Gas_1_NO2 :  " + DAQ.Multi_Gas_1_NO2.ToString() + "  " + DAQ.nl + DAQ.nl;

            Textdata += "Multi_Gas_2_VOC  : " + DAQ.Multi_Gas_2_VOC.ToString() + "  " + DAQ.nl;
            Textdata += "Multi_Gas_2_C2H5OH:" + DAQ.Multi_Gas_2_C2H5OH.ToString() + "  " + DAQ.nl;
            Textdata += "Multi_Gas_2_CO  :  " + DAQ.Multi_Gas_2_CO.ToString() + "  " + DAQ.nl;
            Textdata += "Multi_Gas_2_NO2 :  " + DAQ.Multi_Gas_2_NO2.ToString() + "  " + DAQ.nl + DAQ.nl;

            Textdata += "Multi_Gas_3_VOC  : " + DAQ.Multi_Gas_3_VOC.ToString() + "  " + DAQ.nl;
            Textdata += "Multi_Gas_3_C2H5OH:" + DAQ.Multi_Gas_3_C2H5OH.ToString() + "  " + DAQ.nl;
            Textdata += "Multi_Gas_3_CO  :  " + DAQ.Multi_Gas_3_CO.ToString() + "  " + DAQ.nl;
            Textdata += "Multi_Gas_3_NO2 :  " + DAQ.Multi_Gas_3_NO2.ToString() + "  " + DAQ.nl + DAQ.nl;

            Textdata += "Multi_Gas_4_VOC  : " + DAQ.Multi_Gas_4_VOC.ToString() + "  " + DAQ.nl;
            Textdata += "Multi_Gas_4_C2H5OH:" + DAQ.Multi_Gas_4_C2H5OH.ToString() + "  " + DAQ.nl;
            Textdata += "Multi_Gas_4_CO  :  " + DAQ.Multi_Gas_4_CO.ToString() + "  " + DAQ.nl;
            Textdata += "Multi_Gas_4_NO2 :  " + DAQ.Multi_Gas_4_NO2.ToString() + "  " + DAQ.nl + DAQ.nl;
            */

            /*
            float TempVal = (float)DAQ.Battery_Volt;
            TempVal /= 1000;

            Textdata += "Battery  :  " + TempVal.ToString() + " Volt " ;
            //   Textdata += "Battery State :  ";
            //      if DAQ.Power_Statee == 0) Textdata += "  USB + BATTERY CHARG"; 
            //       else Textdata += "  USB  + NO BATTERY  "; Textdata += DAQ.nl;
            if (DAQ.Power_State == DAQ.ONLY_BATTERY) Textdata += " ONLY BATTERY";
            if (DAQ.Power_State == DAQ.ONLY_USB) Textdata += " ONLY_USB";
            if (DAQ.Power_State == DAQ.BATTERY_USB) Textdata += " BATTERY_USB";
            Textdata += DAQ.nl;

            Textdata += "FAN  :  " + DAQ.Fan_Volt.ToString() + " Volt " + DAQ.nl; 
            */




            return Textdata;
        }
        String Print_BME680_1()
        {
            String Textdata = "";
            Textdata += "BME680_1 : " + DAQ.nl;
            Textdata += "VOC  : " + DAQ.BME680_Voc_1.ToString() + "  " + DAQ.nl;
            Textdata += "Temp :" + DAQ.BME680_Temp_1.ToString() + "  " + DAQ.nl;
            Textdata += "Hum  :  " + DAQ.BME680_Hum_1.ToString() + "  " + DAQ.nl;
            Textdata += "Press :  " + DAQ.BME680_Prs_1.ToString() + "  " + DAQ.nl + DAQ.nl;
            Textdata += "BME680_2 : " + DAQ.nl;
            Textdata += "VOC  : " + DAQ.BME680_Voc_2.ToString() + "  " + DAQ.nl;
            Textdata += "Temp :" + DAQ.BME680_Temp_2.ToString() + "  " + DAQ.nl;
            Textdata += "Hum  :  " + DAQ.BME680_Hum_2.ToString() + "  " + DAQ.nl;
            Textdata += "Press :  " + DAQ.BME680_Prs_2.ToString() + "  " + DAQ.nl + DAQ.nl;
            return Textdata;
        }
        String Print_BME680_2()
        {
            String Textdata = "";
            Textdata += "BME680_3 : " + DAQ.nl;
            Textdata += "VOC  : " + DAQ.BME680_Voc_3.ToString() + "  " + DAQ.nl;
            Textdata += "Temp :" + DAQ.BME680_Temp_3.ToString() + "  " + DAQ.nl;
            Textdata += "Hum  :  " + DAQ.BME680_Hum_3.ToString() + "  " + DAQ.nl;
            Textdata += "Press :  " + DAQ.BME680_Prs_3.ToString() + "  " + DAQ.nl + DAQ.nl;
            Textdata += "BME680_4 : " + DAQ.nl;
            Textdata += "VOC  : " + DAQ.BME680_Voc_4.ToString() + "  " + DAQ.nl;
            Textdata += "Temp :" + DAQ.BME680_Temp_4.ToString() + "  " + DAQ.nl;
            Textdata += "Hum  :  " + DAQ.BME680_Hum_4.ToString() + "  " + DAQ.nl;
            Textdata += "Press :  " + DAQ.BME680_Prs_4.ToString() + "  " + DAQ.nl + DAQ.nl;
            return Textdata;
        }
        String Print_Light()
        {
            String Textdata = "";
            Textdata += "Light : " + DAQ.nl;
            Textdata += "Visible  : " + DAQ.Light_Visible.ToString() + " Lux " + DAQ.nl;
            Textdata += "Infrared  : " + DAQ.Light_Infrared.ToString() + "Lux " + DAQ.nl;
            return Textdata;
        }
            
        void Base_Timer1mSec_Tick(object sender, EventArgs e)
        {
            Timer_1sec++; // 16mSec
            if (Timer_1sec > 8)
            {
                Timer_1sec = 0;
                   Task_Counter++;
                    if (Task_Counter > 4) Task_Counter = 0;  // 8-> 1 sec                     
                                                             //      Update_Chart = 1;
                                                             //       Plot_Chart();

       
                    SP1_richTextBox.Text = SP1_GetTextdata(); // main informative screen
           
                   SP1_DatatextBox.Text = SP1_GetTextdata2();  // all data in hex format screen           

                if (DAQ.Enable_Menu_Time_Update == true)
                    systemTimeToolStripMenuItem.Text = "Time & Date: " + COMMON_GetDateTime();

            }
            if (DAQ.EnableInitTimer == true)
            {
                DAQ.InitTimer++;
                if (DAQ.InitTimer > 75) {
                    DAQ.EnableInitTimer = false;
                 //     plotSurface2D1.BackgroundImage = null;
                    //   Plot_Chart();
                //    pictureBox2.Visible = false;
                }
            }  
            try
            {
                if (SP1_serialPort.BytesToRead != 0)
                {
                    SP1.ComTimeout++;

                }
                else SP1.ComTimeout = 0;
                if (SP1.ComTimeout > 2)
                {
                   
                    // clear buffer
                    SP1_serialPort.ReadExisting();
                    SP1.ErrorCount++;
                }
            }
            catch { }
            //BaseCounter++;
            // BaseCounter = 0;
            //   if (TrigDisp == 1){
            if (SP1.ReadSequence == 2)
            {
                //        SP1.ReadSequence = 0;

                //          SP1_CalculateRcvData();

            }
            try
            {
                //      SP1_IO_Serial_UpdateCOMPortList();
                /*
                if (SP1_serialPort.IsOpen)
                    Serial_UpdateCOMPortList_VID_PID();
                */
            }
            catch { }

        }
        void Array_Fill()
        {
            // return;
            if (DAQ.sp >= DAQ.MAX_ARRAY_SIZE - 1) // sp   899 . 900 1799>=1799
            {
                DAQ.sp = DAQ.MAX_ARRAY_SIZE - 1;
                for (int t = 1; t <= DAQ.sp; t++) // sp 0<-1 898<-899  DAQ.MAX_ARRAY_SIZE - 2  0-1798
                {
                    //   DAQ.Index_Arr[t-1] = DAQ.Index_Arr[t];//0
                    DAQ.VOC_Arr1[t - 1] = DAQ.VOC_Arr1[t];
                    DAQ.VOC_Arr3[t - 1] = DAQ.VOC_Arr3[t];
                    DAQ.VOC_Arr2[t - 1] = DAQ.VOC_Arr2[t];
                    DAQ.VOC_Arr4[t - 1] = DAQ.VOC_Arr4[t];
                    DAQ.BME_VOC_Arr1[t - 1] = DAQ.BME_VOC_Arr1[t];
                    DAQ.BME_VOC_Arr2[t - 1] = DAQ.BME_VOC_Arr2[t];
                    DAQ.BME_VOC_Arr3[t - 1] = DAQ.BME_VOC_Arr3[t];
                    DAQ.BME_VOC_Arr4[t - 1] = DAQ.BME_VOC_Arr4[t];

                    DAQ.Temperature_Arr[t - 1] = DAQ.Temperature_Arr[t];
                    DAQ.Humidity_Arr[t - 1] = DAQ.Humidity_Arr[t];
                    DAQ.Inf_Light_Arr[t - 1] = DAQ.Inf_Light_Arr[t];
                    DAQ.Visible_Light_Arr[t - 1] = DAQ.Visible_Light_Arr[t];
                    DAQ.Fan_Arr[t - 1] = DAQ.Fan_Arr[t];

                //    DAQ.MaxNo[t - 1] = DAQ.MaxNo[t];
                    DAQ.MaxNo[t - 1] = "0";
                    //       DAQ.Arr5[t - 1] = DAQ.Arr5[t];
                    //      DAQ.Arr6[t - 1] = DAQ.Arr6[t];


                }
            }
            else
            {
                DAQ.sp++; // sp  0 - 898
            }
      //      DAQ.Speed_Arr[DAQ.sp] = DAQ.Vehicle_Speed.ToString();

            DAQ.VOC_Arr1[DAQ.sp] = DAQ.Accelometer_x.ToString();
            DAQ.VOC_Arr2[DAQ.sp] = DAQ.Accelometer_y.ToString();
            DAQ.VOC_Arr3[DAQ.sp] = DAQ.Accelometer_z.ToString();

            DAQ.VOC_Arr4[DAQ.sp] = DAQ.Gyrometer_x.ToString();
            DAQ.BME_VOC_Arr1[DAQ.sp] = (DAQ.Gyrometer_y ).ToString();
            DAQ.BME_VOC_Arr2[DAQ.sp] = (DAQ.Gyrometer_z).ToString();

            DAQ.BME_VOC_Arr3[DAQ.sp] = (DAQ.BME_Voc3 / 100).ToString();
            DAQ.BME_VOC_Arr4[DAQ.sp] = (DAQ.BME_Voc4 / 100).ToString();

            DAQ.Temperature_Arr[DAQ.sp]   = DAQ.Temperature_OnBoard.ToString();   // DAQ.Temperature_Float;
            DAQ.Humidity_Arr[DAQ.sp]      = DAQ.Humidity_OnBoard.ToString();      // DAQ.Humidity_Float
            DAQ.Inf_Light_Arr[DAQ.sp]     = DAQ.Light_Infrared.ToString();
            DAQ.Visible_Light_Arr[DAQ.sp] = DAQ.Light_Visible.ToString();
            DAQ.Fan_Arr[DAQ.sp] =           DAQ.Fan_Volt.ToString();

            DAQ.MaxNumber = 10;
            /*

            if (checkBox_Voc1.Checked == true) DAQ.MaxNumber =  DAQ.Multi_Gas_1_VOC;
             else DAQ.MaxNumber = 0;
             if (checkBox_Voc2.Checked == true) { 
                 if (DAQ.Multi_Gas_2_VOC > DAQ.MaxNumber) DAQ.MaxNumber = DAQ.Multi_Gas_2_VOC;
             }
             if (checkBox_Voc3.Checked == true) { 
                 if (DAQ.Multi_Gas_3_VOC > DAQ.MaxNumber) DAQ.MaxNumber = DAQ.Multi_Gas_3_VOC;
             }
             /*
             if (checkBox_Voc4.Checked == true) { 
                 if (DAQ.Multi_Gas_4_VOC > DAQ.MaxNumber) DAQ.MaxNumber = DAQ.Multi_Gas_4_VOC;
             }

             if (checkBox_Voc1_Median.Checked == true) { 
                 if ((DAQ.BME_Voc1 / 100) > DAQ.MaxNumber) DAQ.MaxNumber =(UInt32) (DAQ.BME_Voc1 / 100);
             }
             if (checkBox_Voc2_Median.Checked == true) { 
                 if ((DAQ.BME_Voc2 / 100) > DAQ.MaxNumber) DAQ.MaxNumber = (UInt32)(DAQ.BME_Voc2 / 100);
             }
             if (checkBox_Voc3_Median.Checked == true) { 
                 if ((DAQ.BME_Voc3 / 100) > DAQ.MaxNumber) DAQ.MaxNumber = (UInt32)(DAQ.BME_Voc3 / 100);
             }
             if (checkBox_Voc4_Median.Checked == true) {
                 if ((DAQ.BME_Voc4 / 100) > DAQ.MaxNumber) DAQ.MaxNumber = (UInt32)(DAQ.BME_Voc4 / 100);
             }
             */

            if (checkBox_Temperature.Checked == true)
            {
                if (DAQ.Temperature_OnBoard > DAQ.MaxNumber) DAQ.MaxNumber = (UInt32)DAQ.Temperature_OnBoard;
            }
            if (checkBox_Humidity.Checked == true)
            {
                if (DAQ.Humidity_OnBoard > DAQ.MaxNumber) DAQ.MaxNumber = (UInt32)DAQ.Humidity_OnBoard;
            }
            if (checkBox_InfraLight.Checked == true)
            {
                if (DAQ.Light_Infrared > DAQ.MaxNumber) DAQ.MaxNumber = (UInt32)DAQ.Light_Infrared;
            }
            if (checkBox_Light.Checked == true)
            {
                if (DAQ.Light_Visible > DAQ.MaxNumber) DAQ.MaxNumber = (UInt32)DAQ.Light_Visible;
            }  
         
            if (checkBox_FanSpeed.Checked == true)
            {
                if (DAQ.Fan_Volt > DAQ.MaxNumber) DAQ.MaxNumber = (UInt32)DAQ.Fan_Volt;
            }
            if (DAQ.MaxNumber > DAQ.MaxNumberFull) DAQ.MaxNumberFull = DAQ.MaxNumber;
            //     DAQ.MaxNo[DAQ.sp] = DAQ.MaxNumberFull.ToString();
         
            DAQ.MaxNo[DAQ.sp] = (DAQ.MaxNumber * 1.3 ).ToString();
            if(DAQ.sp != 0)  DAQ.MaxNo[DAQ.sp-1] = "0";

            // Adjust bp
            if (DAQ.sp >= DAQ.ChartSize) // 300 550 // bp->250
                DAQ.bp = (Int16)(DAQ.sp - DAQ.ChartSize);//1-300
            else DAQ.bp = 0;

        }
        /*
            if(checkBox_Temperature.Checked == true) {plotSurface2D1.Add(Graph9); Check++; }
            if(checkBox_Humidity.Checked == true){ plotSurface2D1.Add(Graph10); Check++;}
 plotSurface2D1.Add(Graph11); Check++; }
 plotSurface2D1.Add(Graph12); Check++; }
 plotSurface2D1.Add(Graph13); Check++; }
*/
void Plot_Chart()
        {
            //  return;
            /*
            if (DAQ.Plot_Init != 32)
            {
                DAQ.Plot_Init = 32;
                // plotSurface2D1.BackgroundImage = null;
                //pictureBox2.Visible = false;
            }
            */
            NPlot.Grid grid = new NPlot.Grid();
            NPlot.LinePlot Graph1 = new NPlot.LinePlot();
            NPlot.LinePlot Graph2 = new NPlot.LinePlot();
            NPlot.LinePlot Graph3 = new NPlot.LinePlot();
            NPlot.LinePlot Graph4 = new NPlot.LinePlot();
            NPlot.LinePlot Graph5 = new NPlot.LinePlot();
            NPlot.LinePlot Graph6 = new NPlot.LinePlot();
            NPlot.LinePlot Graph7 = new NPlot.LinePlot();
            NPlot.LinePlot Graph8 = new NPlot.LinePlot();
            NPlot.LinePlot Graph9 = new NPlot.LinePlot();
            NPlot.LinePlot Graph10 = new NPlot.LinePlot();
            NPlot.LinePlot Graph11 = new NPlot.LinePlot();
            NPlot.LinePlot Graph12 = new NPlot.LinePlot();
            NPlot.LinePlot Graph13 = new NPlot.LinePlot();

            NPlot.LinePlot Graph20 = new NPlot.LinePlot();
            //    NPlot.LinePlot Graph20 = new NPlot.LinePlot();


            /*
                        Graph1.Pen = new Pen(Color.Red, 1);
                        Graph2.Pen = new Pen(Color.Blue, 2);
                        Graph3.Pen = new Pen(Color.Green, 1);
                        Graph4.Pen = new Pen(Color.Gold, 1);   // 
                        Graph5.Pen = new Pen(Color.Pink, 1);
                        Graph6.Pen = new Pen(Color.Black, 1);   // 
                        Graph7.Pen = new Pen(Color.Red, 1);
                        Graph8.Pen = new Pen(Color.Blue, 2);
            */

            Graph1.Pen = new Pen(Color.DimGray, 1);
            Graph2.Pen = new Pen(Color.DimGray, 1);
            Graph3.Pen = new Pen(Color.DimGray, 1); // accel z

            Graph4.Pen = new Pen(Color.CornflowerBlue, 1);   // 
            Graph5.Pen = new Pen(Color.CornflowerBlue, 1);
            Graph6.Pen = new Pen(Color.CornflowerBlue, 1);   // gyro z

            Graph7.Pen = new Pen(Color.Blue, 1);
            Graph8.Pen = new Pen(Color.Blue, 1);   // 
            
            Graph9.Pen = new Pen(Color.DarkOrange, 1);
            Graph10.Pen = new Pen(Color.DarkOliveGreen, 1);

            Graph11.Pen = new Pen(Color.IndianRed, 1);
            Graph12.Pen = new Pen(Color.BlueViolet,1);   // 

            Graph13.Pen = new Pen(Color.Maroon, 1);   // 

            Graph20.Pen = new Pen(Color.White, 1);   //
        //    Graph20.Pen = new Pen(Color.DarkGreen, 1);   //




            List<String> X_Data = new List<String>();
            List<String> Data1 = new List<String>();
            List<String> Data2 = new List<String>();
            List<String> Data3 = new List<String>();
            List<String> Data4 = new List<String>();
            List<String> Data5 = new List<String>();
            List<String> Data6 = new List<String>();
            List<String> Data7 = new List<String>();
            List<String> Data8 = new List<String>();
            List<String> Data10 = new List<String>();
            List<String> Data9 = new List<String>();
            List<String> Data11 = new List<String>();
            List<String> Data12 = new List<String>();
            List<String> Data13 = new List<String>();

            List<String> Data20 = new List<String>();

            plotSurface2D1.Clear();

            //     Plot_Create_Instance();
            //     Plot_Init();
            X_Data.Clear();
            Data1.Clear();
            Data2.Clear();
            Data3.Clear();
            Data4.Clear();
            Data5.Clear();
            Data6.Clear();
            Data7.Clear();
            Data8.Clear();
            Data10.Clear();
            Data9.Clear();
            Data11.Clear();
            Data12.Clear();
            Data13.Clear();

            Data20.Clear();
            //     plotSurface2D1.Clear();
            /*
                        grid.VerticalGridType = NPlot.Grid.GridType.Coarse;
                        grid.HorizontalGridType = NPlot.Grid.GridType.Coarse;
                        grid.MajorGridPen = new Pen(Color.LightGray, 1.0f);
                        grid.MinorGridPen = new Pen(Color.LightGray, 1.0f);
            */
            plotSurface2D1.Add(grid);

            for (Int16 t = DAQ.bp; t <= DAQ.sp; t++)
            {
                //   Single.TryParse(DAQ.Index_Arr[t], out FloatNum); X_Data.Add(FloatNum.ToString());
                //    X_Data.Add(DAQ.Index_Arr[t].ToString());
                X_Data.Add(t.ToString());
                //     Single.TryParse(DAQ.Speed_Arr[t], out FloatNum); Data1.Add(FloatNum.ToString());
                Data1.Add(DAQ.VOC_Arr1[t].ToString());
                //      Single.TryParse(DAQ.Current_Arr[t], out FloatNum); Data2.Add(FloatNum.ToString());
                Data2.Add(DAQ.VOC_Arr2[t].ToString());
                //       Single.TryParse(DAQ.Voltage_Arr[t], out FloatNum); Data3.Add(FloatNum.ToString());
                Data3.Add(DAQ.VOC_Arr3[t].ToString());
                //  Single.TryParse(DAQ.Temperature_Arr[t], out FloatNum); Data4.Add(FloatNum.ToString()); //  se
                Data4.Add(DAQ.VOC_Arr4[t].ToString());

                Data5.Add(DAQ.BME_VOC_Arr1[t].ToString()); // x
                Data6.Add(DAQ.BME_VOC_Arr2[t].ToString()); // y
                Data7.Add(DAQ.BME_VOC_Arr3[t].ToString()); // z
                Data8.Add(DAQ.BME_VOC_Arr4[t].ToString());

                Data9.Add(DAQ.Temperature_Arr[t].ToString());
                Data10.Add(DAQ.Humidity_Arr[t].ToString());
                Data11.Add(DAQ.Inf_Light_Arr[t].ToString());
                Data12.Add(DAQ.Visible_Light_Arr[t].ToString());
                Data13.Add(DAQ.Fan_Arr[t].ToString());

            }

            Graph1.AbscissaData = X_Data;
            Graph1.DataSource = Data1;
            Graph2.AbscissaData = X_Data;
            Graph2.DataSource = Data2;
            Graph3.AbscissaData = X_Data;
            Graph3.DataSource = Data3;
            Graph4.AbscissaData = X_Data;
            Graph4.DataSource = Data4;

            Graph5.AbscissaData = X_Data;
            Graph5.DataSource = Data5;
            Graph6.AbscissaData = X_Data;
            Graph6.DataSource = Data6;
            Graph7.AbscissaData = X_Data;
            Graph7.DataSource = Data7;
            Graph8.AbscissaData = X_Data;
            Graph8.DataSource = Data8;

            Graph9.AbscissaData = X_Data;
            Graph9.DataSource = Data9;

            Graph10.AbscissaData = X_Data;
            Graph10.DataSource = Data10;

            Graph11.AbscissaData = X_Data;
            Graph11.DataSource = Data11;

            Graph12.AbscissaData = X_Data;
            Graph12.DataSource = Data12;

            Graph13.AbscissaData = X_Data;
            Graph13.DataSource = Data13;

            for (Int16 t = DAQ.bp; t <= DAQ.sp; t++)
            {
                Data20.Add(DAQ.MaxNo[t].ToString());
            }

            Graph20.AbscissaData = X_Data;
            Graph20.DataSource = Data20;
            plotSurface2D1.Add(Graph20);


            int Check = 0;
            
            if (checkBox_AccX.Checked == true) {plotSurface2D1.Add(Graph1);  Check++; } // VOC 1
            if (checkBox_AccY.Checked == true) {plotSurface2D1.Add(Graph2); Check++; }  // VOC 2
            if (checkBox_AccZ.Checked == true) {plotSurface2D1.Add(Graph3); Check++; }  // VOC 3
            
            if (checkBox_GyrX.Checked == true) {plotSurface2D1.Add(Graph4); Check++; }  // VOC 4
            if (checkBox_GyrY.Checked == true) {plotSurface2D1.Add(Graph5); Check++; } 
            if (checkBox_GyrZ.Checked == true) {plotSurface2D1.Add(Graph6); Check++; } 
            /*
            if (checkBox_Voc3_Median.Checked == true) {plotSurface2D1.Add(Graph7); Check++; }
            if (checkBox_Voc4_Median.Checked == true) {plotSurface2D1.Add(Graph8); Check++; }     
            */
            if ( Check == 0)
            {
               // plotSurface2D1.Add(Graph7);
            }
            if(checkBox_Temperature.Checked == true) {plotSurface2D1.Add(Graph9); Check++; }
            if(checkBox_Humidity.Checked == true){ plotSurface2D1.Add(Graph10); Check++;}
            if (checkBox_InfraLight.Checked == true) { plotSurface2D1.Add(Graph11); Check++; }
            if (checkBox_Light.Checked == true) { plotSurface2D1.Add(Graph12); Check++; }
            if (checkBox_FanSpeed.Checked == true) { plotSurface2D1.Add(Graph13); Check++; }




            plotSurface2D1.ShowCoordinates = true;
            //      plotSurface2D1.YAxis1.Label = "";
            plotSurface2D1.YAxis1.LabelOffsetAbsolute = true;
            plotSurface2D1.YAxis1.LabelOffset = 0;
            plotSurface2D1.YAxis1.HideTickText = false;

            //     plotSurface2D1.XAxis1.Label = " Test Variables ";
                 plotSurface2D1.Padding = 5;
            //      plotSurface2D1.AutoScaleTitle = true;


            //     plotSurface2D1.Top.CompareTo(plotSurface2D1.Top);
            //     plotSurface2D1.Size.Height.CompareTo(plotSurface2D1.Size.Height);
            //      plotSurface2D1.Size.Equals(34);
            //    plotSurface2D1.Size.Height.Equals(1000);
            //   plotSurface2D1.Size.Height.ToString("1000");
            //       plotSurface2D1.Size.Width.CompareTo(1000);
   //        plotSurface2D1.YAxis1.SmallTickSize.Equals(Data1);
    //        plotSurface2D1.YAxis1.AutoScaleTicks.Equals(Data2);
      //      plotSurface2D1.YAxis1.LargeTickSize.Equals(Data2);
       //     plotSurface2D1.YAxis1.LargeTickSize.CompareTo(100);
        //    plotSurface2D1.YAxis1.LargeTickSize.Equals(100);
        //    plotSurface2D1.YAxis1.AutoScaleTicks.Equals(false);
       //     plotSurface2D1.YAxis1.AutoScaleTicks.Equals(2000);
      //      plotSurface2D1.YAxis1.LabelOffset = 220;
        //    plotSurface2D1.YAxis1.LabelOffsetAbsolute = true;
/*
            plotSurface2D1.YAxis1.TickTextNextToAxis = true;

            plotSurface2D1.YAxis1.TickTextColor = Color.BlueViolet;
            plotSurface2D1.YAxis1.TicksIndependentOfPhysicalExtent = true;
            plotSurface2D1.YAxis1.LargeTickSize = 1000;
            plotSurface2D1.YAxis1.SmallTickSize = 10;
            plotSurface2D1.YAxis1.MinPhysicalLargeTickStep = 1000;
            plotSurface2D1.YAxis1.SmallTickSize.Equals(true);

            plotSurface2D1.YAxis1.AutoScaleTicks.Equals(false);
            plotSurface2D1.YAxis1.AutoScaleText = false;
*/
            //   plotSurface2D1.YAxis1.WorldMin.Equals(true);
            //   plotSurface2D1.
            //  plotSurface2D1.BackColor = 
            /*
            if (!((checkBox_Speed.Checked == false) && (checkBox_Current.Checked == false) &&
                    (checkBox_Voltage.Checked == false) && (checkBox_Temperature.Checked == false)))
            {
                plotSurface2D1.Refresh();
            }
            */
            plotSurface2D1.Refresh();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit form = new Exit();
            //    form.MdiParent = this;
            //     form.ShowDialog();
            //  form.BackColor = Color.
            form.Show();
        }

        private void dataLoggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DAQ.Enable_Menu_Time_Update = true;
            // systemTimeToolStripMenuItem.Text = "Time & Date: " + COMMON_GetDateTime();
        }
        public String COMMON_GetDateTime()
        {
            //	DateTime oldDate = DateTime.Parse("11/9/03 12:00");

            DateTime d1 = DateTime.Now;
            int Hour = d1.Hour; int Min = d1.Minute; int Sec = d1.Second; int Day = d1.Day; int Month = d1.Month; int Year = d1.Year;
            String HourZero = ""; String MinZero = ""; String SecZero = "";
            if (Hour < 10) HourZero = "0";// else HourZero = "";
            if (Min < 10) MinZero = "0"; //else MinZero = "";
            if (Sec < 10) SecZero = "0";// else SecZero = "";
            //		   String ^ Mystring = Day.ToString() + "." +  Month.ToString() + "."+ Year.ToString() + ",";
            //			Mystring += HourZero +  Hour.ToString()+":"+MinZero+Min.ToString()+":"+SecZero+Sec.ToString() ;

            String Mystring = HourZero + Hour.ToString() + ":" + MinZero + Min.ToString() + ":" + SecZero + Sec.ToString() + "    ";
            Mystring += Day.ToString() + "." + Month.ToString() + "." + Year.ToString();
            return Mystring;

        }
        public void LOG_SaveLogFile() { 
            if (LOG_File_SaveAs() == false) return;
        }
          
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //LOG_SaveLogFile();
            if (LOG_File_SaveAs() == false) return;
        }
        public bool LOG_File_SaveAs()
        {
            if (SP1_serialPort.IsOpen == false) { 
                MessageBox.Show("Com Port Not Open"); 
                return false; 
            }
      //   ((   if (Okyanus.Variables.Log_Status == true) { MessageBox.Show("First Stop Logging "); return false; }

            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = DAQ.WorkDrive + DAQ.Log_Directory;
            saveFileDialog1.Title = "Select  a File to Log Data";
            /*
            if (!(Directory.Exists(DAQ.WorkDrive + DAQ.Log_Directory)))
            { // directory yoksa my documents dan basliyor
                try { Directory.CreateDirectory(DAQ.WorkDrive + DAQ.Log_Directory); }
                catch (IOException)
                {
                    DAQ.Log_Error = true;
                    MessageBox.Show("Log Save Error !!");
                    //    return;
                }// e->GetType()->Name ;
            }
            */
            String str = LOG_GetTime() + ".csv";
         //   String str =  ".csv";
            saveFileDialog1.FileName = str;
            saveFileDialog1.Filter = "Txt files (*.txt)|*.txt | Csv files (*.csv)|*.csv";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {     // hata dosya aciksa kitleniyor burad            
                       DAQ.Original_Log_File = saveFileDialog1.FileName; //secilen isimle dosya ismini tut
                       DAQ.Original_Log_File_Base = DAQ.Original_Log_File; // Okyanus.Definitions.WorkDrive +
                       DAQ.Log_Status = true;

                        
                       DAQ.Log_Error = false;
                        myStream.Close();
                    }
                }
                catch (IOException)
                {
                           DAQ.Log_Error = true;
                           DAQ.Log_Status = false;
                    MessageBox.Show("File Error !!"  + "Close File If Open");
                    return false;
                }

                LOG_LogStatusUpdate();
                stopToolStripMenuItem.Enabled = true;
               
            }
            
                DAQ.Log_SampleCounter = 0;
            return true;
        }
        public void LOG_File_Stop()
        {
            
            if (DAQ.Log_Status == false) { MessageBox.Show("No Log File to Stop "); return; }
            DAQ.Log_Status = false;

            DAQ.Log_Counter = 0;
            LOG_LogStatusUpdate();
            DAQ.Log_SampleCounter = 0;
            stopToolStripMenuItem.Enabled = false;
            startToolStripMenuItem.Enabled = true;

        }
        public void LOG_LogStatusUpdate()
        {
            String Str;
            if (DAQ.Log_Status == true)
            {


                if (DAQ.Log_Error == true)
                {
                    Str = "Stopped @: " + COMMON_GetDateTime() + "Did You Open the File?";
                  //  startTimeToolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    Str = "Started @ " + COMMON_GetDateTime() + " to " + DAQ.Original_Log_File;
                 //   startTimeToolStripMenuItem1.ForeColor = System.Drawing.Color.Green;
                }
           //     startTimeToolStripMenuItem1.Text = Str;
           //     dataLogOnOffToolStripMenuItem1.Text = "Logging to : " + DAQ.Original_Log_File;
           //     dataLogOnOffToolStripMenuItem1.ForeColor = System.Drawing.Color.Green;
           //     stopTimeToolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                if (DAQ.Log_Error == true) { Str = "Stopped @: " + COMMON_GetDateTime() + "  Is  File Already Open?"; }
                else { Str = "Stopped @: " + COMMON_GetDateTime() + " to " + DAQ.Original_Log_File; }
           //     stopTimeToolStripMenuItem1.Text = Str;
           //     dataLogOnOffToolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
           //     dataLogOnOffToolStripMenuItem1.Text = "Logging Off   ";
           //     stopTimeToolStripMenuItem1.ForeColor = System.Drawing.Color.Red;
            //    startTimeToolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            }
        }
        public String LOG_GetTime()
        {
            DateTime d1 = DateTime.Now;
            int Day = d1.Day; int Month = d1.Month; int Year = d1.Year; int Hour = d1.Hour; int Min = d1.Minute;

            String Mystring = "";
            if (Day < 10) Mystring += "0"; else Mystring += "";
            Mystring += Day.ToString() + ".";
            if (Month < 10) Mystring += "0"; else Mystring += "";
            Mystring += Month.ToString() + ".";
            Mystring += Year.ToString() + "__";
            if (Hour < 10) Mystring += "0"; else Mystring += "";
            Mystring += Hour.ToString() + ".";
            if (Min < 10) Mystring += "0"; else Mystring += "";
            Mystring += Min.ToString();
            return Mystring;
        }

        public void LOG_DataLogProcess(String FileName)
        {
            //       if (LOG_SampleCount() != 0) return;

            String path = FileName;
            //				path= Environment::SpecialFolder::MyDocuments;
            if (!(File.Exists(path)))
            {
                try
                {
                    FileStream fs = File.Create(path);
                    //	delete fs;
                }
                catch (IOException) { return; }
            }
            // create a strem reader
            StreamReader sr;
            try { sr = new StreamReader(path); }
            catch (IOException) { DAQ.Log_Error = true; return; }

            String DataFile;
            //        DataFile = LOG_ReadStream(sr, path); // read data from file
            DataFile = LOG_ReadStream(sr); // read data from file
            if (DataFile == "false") return;
            if (LOG_DeleteStreamReader(sr) == "false") return;	 //
            // create a stream writer
            StreamWriter sw;
            try { sw = new StreamWriter(path); }
            catch (IOException) { DAQ.Log_Error = true; return; }
            // wite 2 stream
            if (LOG_WriteStream(sw, path, DataFile) == "false") return;	 // write  data to file
            if (LOG_DeleteStreamWriter(sw) == "false") return;	 // write  data to file
            /*
            String fr;
            if (Okyanus.Variables.Log_Counter >= Okyanus.Chart.MAXLOGCOUNT)
            {			 // DEFAULT_LOGMAXHOUR

                Okyanus.Variables.Log_FileCount += Okyanus.Variables.Log_Counter;
                Okyanus.Variables.Log_Counter = 0;
                Okyanus.Variables.Log_Original_Log_File_post_add++;

                if (Okyanus.Variables.Log_Original_Log_File_post_add < 10) fr = "00";
                else if (Okyanus.Variables.Log_Original_Log_File_post_add < 100) fr = "0";
                else fr = "";
                //      Okyanus.Definitions.WorkDrive + 
                Okyanus.Definitions.Original_Log_File = Okyanus.Definitions.Original_Log_File_Base + fr + Okyanus.Variables.Log_Original_Log_File_post_add.ToString();	 // add 

            }
            else
            {

                Okyanus.Variables.Log_Counter++;
            }
            */
        }
        //    public String LOG_ReadStream(StreamReader Sr, String path)
        public String LOG_ReadStream(StreamReader Sr)
        {
            try
            {
                if (Sr != null)
                {     // hata dosya aciksa kitleniyor burada
                    return Sr.ReadToEnd();
                }
            }
            catch (IOException) { DAQ.Log_Error = true; return "false"; }
            return "false";
        }
        public String LOG_WriteStream(StreamWriter Sw, String path, String data)
        {
            try
            {
                if (Sw != null)
                    if (DAQ.Log_Counter != 0)
                    {
                        Sw.WriteLine(data + (DAQ.Log_Counter + DAQ.Log_FileCount).ToString() + LOG_PrepareData_2WriteFile_01());
                        DAQ.Log_Counter++;
                    }
                    // ilk sira     
                    else
                    {
                        DAQ.Log_Counter = 1;
                        String Mystring = " Log No,   Date, Time , Temperature (C),Humidity %,Vis. Light, Inf. Light";
                        /*
                        for (int i = 0; i < DAQ.RawIndex; i++)
                        {
                            Mystring += DAQ.Variables_Name[i] + ",";
                        }
                        */
                        Sw.WriteLine(data + Mystring);
                    }
            }
            catch (IOException) { DAQ.Log_Error = true; return "false"; };
            return "true";
        }
        public String LOG_PrepareData_2WriteFile_01()
        {

            DateTime d1 = DateTime.Now;

            int Hour = d1.Hour; int Min = d1.Minute; int Sec = d1.Second; int Day = d1.Day; int Month = d1.Month; int Year = d1.Year;
            String HourZero = "";
            String MinZero = "";
            String SecZero = "";
            if (Hour < 10) HourZero = "0"; else HourZero = "";
            if (Min < 10) MinZero = "0"; else MinZero = "";
            if (Sec < 10) SecZero = "0"; else SecZero = "";

            String Mystring = ",";
            Mystring += Day.ToString() + "." + Month.ToString() + "." + Year.ToString() + ",";
            Mystring += HourZero + Hour.ToString() + ":" + MinZero + Min.ToString() + ":" + SecZero + Sec.ToString();
            Mystring += ",";
            /*
            for (int i = 0; i < DAQ.RawIndex; i++)
            {
                Mystring += DAQ.Variables_Data[i] + ",";
            }
            */
            //      Mystring += DAQ.Enc_Ang_Speed_Abs.ToString() + "," + DAQ.Encoder_Tot_Distance.ToString() + "," + DAQ.Voltage_d.ToString() + "," + DAQ.Current_d.ToString() +
            //            "," + DAQ.Temperature.ToString() + ",";
            Mystring +=    DAQ.Temperature_Float + ","+ DAQ.Humidity_Float +  "," + DAQ.Light_Visible + "," + DAQ.Light_Infrared + ",";



            return Mystring;
        }
        public String LOG_DeleteStreamWriter(StreamWriter Sw)
        {
            try
            {
                if (Sw != null)
                {

                    Sw.Close();

                }
            }
            catch (IOException) { DAQ.Log_Error = true; return "false"; };
            return "true";
        }
        public String LOG_DeleteStreamReader(StreamReader Sr)
        {
            try
            {
                if (Sr != null)	//delete Sr;
                    Sr.Close();
            }
            catch (IOException) { DAQ.Log_Error = true; return "false"; }
            return "true";
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   Okyanus.Chart.Play = false;
         //   ChartPlayPause();
            LOG_File_Stop();
            startToolStripMenuItem.Enabled = true;
        }

        public void SetArrayColors()
        {
            toolStripMenuItem2.ForeColor = Color.Black;
            toolStripMenuItem3.ForeColor = Color.Black;
            toolStripMenuItem4.ForeColor = Color.Black;
            toolStripMenuItem5.ForeColor = Color.Black;
            toolStripMenuItem6.ForeColor = Color.Black;

            switch (DAQ.ChartSize)
            {
                case DAQ.SAMPLE_10SEC:
                    toolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                 
                    break;
                case DAQ.SAMPLE_20SEC:
                    toolStripMenuItem3.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                  
                    break;
                case DAQ.SAMPLE_1MIN:
                    toolStripMenuItem4.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                    
                    break;
                case DAQ.SAMPLE_2MIN:
                    toolStripMenuItem5.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                    
                    break;
                case DAQ.SAMPLE_3MIN:
                    toolStripMenuItem6.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                   
                    break;
            }





        //    DAQ.Max_Array_Size = Ref;
        //    if (DAQ.Index > DAQ.Max_Array_Size) DAQ.Index = 0;
       
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DAQ.ChartSize = DAQ.SAMPLE_10SEC;
            SetArrayColors();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            DAQ.ChartSize = DAQ.SAMPLE_20SEC;
            SetArrayColors();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            DAQ.ChartSize = DAQ.SAMPLE_1MIN;
            SetArrayColors();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            DAQ.ChartSize = DAQ.SAMPLE_2MIN;
            SetArrayColors();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {   
            DAQ.ChartSize = DAQ.SAMPLE_3MIN;
            SetArrayColors();
        }

        private void button_Reset_Distance_Click(object sender, EventArgs e)
        {
            //  DAQ.Encoder_Abs_Init = DAQ.Encoder_Abs; // First Data read from dspic
        }
        /*
private void label2_Click(object sender, EventArgs e)
{

}

private void pictureBox1_Click(object sender, EventArgs e)
{

}

private void Speed_richTextBox_TextChanged(object sender, EventArgs e)
{

}

private void label2_Click(object sender, EventArgs e)
{

}


private void systemTimeToolStripMenuItem_Click(object sender, EventArgs e)
{

}
*/


        void FuncT() { 
        
        }

//        private void numericUpDown_incline_ValueChanged(object sender, EventArgs e)
 //       {
         //   DAQ.Slope = (double) numericUpDown_incline.Value;
  //      }

        private void communicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            Simulator form = new Simulator();
            form.Init_Text();
            form.button_Current_Click(sender, e);
            form.Show();
            DAQ.Simulator_Electric = true;
            form.checkBox_Simulator_State.Checked = true;
            */
        }

        private void deviceManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("devmgmt.msc");
        }
        void ComPort_List_ForTable(String VID, String PID, String NAM)
        {
            List<string> names = ComPortNames(VID, PID); // ftdi
            if (names.Count > 0)
            {
                foreach (String s in SerialPort.GetPortNames())
                {
                    if (names.Contains(s))
                    {

                        SP1_SendtextBox.Text += s + "     " + NAM + "\r\n";

                  //  SP1_SendtextBox.Text = s;
                       
                      //  Newport = s;
                       
                    }
                }
            }
            else
                SP1_SendtextBox.Text = "No COM ports found";  //  return s;
        }

        private void comPortListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComPort_List_ForTable(SP1.VID_1, SP1.PID_1, SP1.NAM_1);
            ComPort_List_ForTable(SP1.VID_2, SP1.PID_2, SP1.NAM_2);
            ComPort_List_ForTable(SP1.VID_3, SP1.PID_3, SP1.NAM_3);
            ComPort_List_ForTable(SP1.VID_4, SP1.PID_4, SP1.NAM_4);
            ComPort_List_ForTable(SP1.VID_5, SP1.PID_5, SP1.NAM_5);
            ComPort_List_ForTable(SP1.VID_6, SP1.PID_6, SP1.NAM_6);
            //    ComPort_List(VID_1, PID_1, NAM_1);
            //     ShowComs form = new ShowComs();
            //    form.MdiParent = this;
            //     form.ShowDialog();
            //  form.BackColor = Color.
            //    form.Show();
        }

        private void checkBox_Temperature_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox_Voc4_Median_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        //    private void numericUpDown_Wheel_ValueChanged(object sender, EventArgs e)
        //    {
        //        DAQ.Wheel_Diameter = (Int16)numericUpDown_Wheel.Value;
        //     }

    }


}

