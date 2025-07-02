using System.IO.Ports;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System;
using System.Linq;
using System.Speech.Synthesis;
using System.Numerics;
namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort1;

        private byte byte_recieved;
        private int statusbyte ;
        private byte statusbyte1 = 0x00;
        private int v = 1;
        private System.Windows.Forms.Timer timer;




        public Form1()
        {
            InitializeComponent();
            serialPort1 = new SerialPort();
            serialPort1.DataReceived += SerialPort1_DataReceived;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;// 10ms interval
            timer.Tick += Timer_Tick; // Attach event handler

            getAvaiableports();
        }

        void getAvaiableports()
        {
            String[] ports = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if ((comboBox1.Text == "" || comboBox2.Text == "") || (textBox6.Text == "") || (textBox8.Text == "") || (textBox9.Text == ""))
                {
                    textBox2.Text = "please select port setting or slave config";
                }
                else
                {
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text);
                    serialPort1.DataBits = 8;
                    serialPort1.StopBits = StopBits.Two;
                    serialPort1.Parity = Parity.None;
                    serialPort1.ReadTimeout = 200;
                    serialPort1.Open();
                    timer.Start(); // Start the timer
                    progressBar1.Value = 100;
                    button1.Enabled = true;
                    button2.Enabled = true;
                    textBox1.Enabled = true;
                    button3.Enabled = false;
                    button4.Enabled = true;
                    textBox6.ReadOnly = true;
                    textBox11.ReadOnly = true;
                    textBox8.ReadOnly = true;
                    textBox9.ReadOnly = true;
                }
            }
            catch (UnauthorizedAccessException)
            {
                textBox2.Text = "unauthorize access";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer.Stop(); // Start the timer
            serialPort1.Close();
            progressBar1.Value = 0;
            button1.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            button3.Enabled = true;
            textBox1.Enabled = false;
            textBox6.ReadOnly = false;
            textBox11.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox9.ReadOnly = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;
            byte[] dataToSend = Encoding.ASCII.GetBytes(inputText);
            serialPort1.Write(dataToSend, 0, dataToSend.Length);
            textBox1.Text = "";

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Do something when the timer ticks

            SendModbusMessage(serialPort1, textBox6.Text, comboBox3.Text, textBox8.Text, textBox9.Text, textBox11.Text);
            // ReadModbusResponse(serialPort1);
            UpdateLed();

        }
        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {

                this.Invoke(new Action(() =>
                {
                    ReadModbusResponse(serialPort1);

                }));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// send data modbus//////////////////////////////////////////////
        /// </summary>
        public void SendModbusMessage(SerialPort serialport, string textBox6, string textBox7, string textBox8, string textBox9, string textBox11)
        {
            try
            {
                // Convert inputs from textboxes (decimal strings) to byte
                ushort tempAdd = Convert.ToByte(textBox8, 10);
                ushort tempNumber = Convert.ToByte(textBox9, 10);
                byte slaveAddress = Convert.ToByte(textBox6, 10);
                byte functionCode = Convert.ToByte(textBox7, 10);
                byte startAddressHi = (byte)((tempAdd << 8) & 0xFF);
                byte startAddressLo = (byte)(tempNumber & 0xFF);
                byte numRegistersHi = (byte)((tempAdd << 8) & 0xFF);
                byte numRegistersLo = (byte)(tempNumber & 0xFF);

                byte[] message;

                if (functionCode == 0x10) // Function 16 - Preset Multiple Registers
                {
                    string[] registerStrings = textBox11.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    int registerCount = registerStrings.Length;

                    // Validate register count
                    if (registerCount != (numRegistersLo + (numRegistersHi << 8)))
                    {
                        MessageBox.Show("Number of data registers doesn't match the 'Number of Registers' field!", "Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Convert to bytes
                    List<byte> dataBytes = new List<byte>();
                    foreach (string regStr in registerStrings)
                    {
                        ushort value = Convert.ToUInt16(regStr, 10);
                        dataBytes.Add((byte)(value >> 8));     // High byte
                        dataBytes.Add((byte)(value & 0xFF));   // Low byte
                    }

                    byte byteCount = (byte)dataBytes.Count;

                    // Construct message
                    List<byte> messageList = new List<byte>
            {
                slaveAddress,
                functionCode,
                startAddressHi,
                startAddressLo,
                numRegistersHi,
                numRegistersLo,
                byteCount
            };
                    messageList.AddRange(dataBytes);
                    message = messageList.ToArray();
                }
                else if (functionCode == 0x03) // Function 3 - Read Holding Registers
                {
                    message = new byte[]
                    {
                slaveAddress,
                functionCode,
                startAddressHi,
                startAddressLo,
                numRegistersHi,
                numRegistersLo
                    };
                }
                else
                {
                    MessageBox.Show("Unsupported function code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Compute CRC16 checksum
                byte[] crc = ComputeCRC(message, message.Length);

                // Append CRC to message
                byte[] fullMessage = message.Concat(crc).ToArray();

                // Send message over serial port
                if (serialport.IsOpen)
                {
                    serialport.Write(fullMessage, 0, fullMessage.Length);
                    string hexString = string.Join(" ", fullMessage.Select(b => b.ToString("X2")));
                    textBox10.Text = hexString;
                }
                else
                {
                    MessageBox.Show("Serial port is not open!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CRC16 calculation function (Modbus standard)
        private byte[] ComputeCRC(byte[] data, int length)
        {
            byte[] auchCRCLo = new byte[256]
       {
        0x00, 0xC0, 0xC1, 0x01, 0xC3, 0x03, 0x02, 0xC2, 0xC6, 0x06, 0x07, 0xC7, 0x05, 0xC5, 0xC4, 0x04,
        0xCC, 0x0C, 0x0D, 0xCD, 0x0F, 0xCF, 0xCE, 0x0E, 0x0A, 0xCA, 0xCB, 0x0B, 0xC9, 0x09, 0x08, 0xC8,
        0xD8, 0x18, 0x19, 0xD9, 0x1B, 0xDB, 0xDA, 0x1A, 0x1E, 0xDE, 0xDF, 0x1F, 0xDD, 0x1D, 0x1C, 0xDC,
        0x14, 0xD4, 0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 0xD2, 0x12, 0x13, 0xD3, 0x11, 0xD1, 0xD0, 0x10,
        0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3, 0xF2, 0x32, 0x36, 0xF6, 0xF7, 0x37, 0xF5, 0x35, 0x34, 0xF4,
        0x3C, 0xFC, 0xFD, 0x3D, 0xFF, 0x3F, 0x3E, 0xFE, 0xFA, 0x3A, 0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38,
        0x28, 0xE8, 0xE9, 0x29, 0xEB, 0x2B, 0x2A, 0xEA, 0xEE, 0x2E, 0x2F, 0xEF, 0x2D, 0xED, 0xEC, 0x2C,
        0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26, 0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0,
        0xA0, 0x60, 0x61, 0xA1, 0x63, 0xA3, 0xA2, 0x62, 0x66, 0xA6, 0xA7, 0x67, 0xA5, 0x65, 0x64, 0xA4,
        0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F, 0x6E, 0xAE, 0xAA, 0x6A, 0x6B, 0xAB, 0x69, 0xA9, 0xA8, 0x68,
        0x78, 0xB8, 0xB9, 0x79, 0xBB, 0x7B, 0x7A, 0xBA, 0xBE, 0x7E, 0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C,
        0xB4, 0x74, 0x75, 0xB5, 0x77, 0xB7, 0xB6, 0x76, 0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71, 0x70, 0xB0,
        0x50, 0x90, 0x91, 0x51, 0x93, 0x53, 0x52, 0x92, 0x96, 0x56, 0x57, 0x97, 0x55, 0x95, 0x94, 0x54,
        0x9C, 0x5C, 0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E, 0x5A, 0x9A, 0x9B, 0x5B, 0x99, 0x59, 0x58, 0x98,
        0x88, 0x48, 0x49, 0x89, 0x4B, 0x8B, 0x8A, 0x4A, 0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C,
        0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 0x82, 0x42, 0x43, 0x83, 0x41, 0x81, 0x80, 0x40
       };
            byte[] auchCRCHi = new byte[256]
      {
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
        0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
        0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
        0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1,
        0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1,
        0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
        0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40,
        0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1,
        0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
        0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40,
        0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
        0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
        0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
        0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
        0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
        0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
        0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40,
        0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1,
        0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
        0x80, 0x41, 0x00, 0xC1, 0x81, 0x40
      };

            byte uchCRCHi = 0xFF;
            byte uchCRCLo = 0xFF;
            int uIndex;

            for (int i = 0; i < length; i++)
            {
                uIndex = uchCRCHi ^ data[i];
                uchCRCHi = (byte)(uchCRCLo ^ auchCRCHi[uIndex]);
                uchCRCLo = auchCRCLo[uIndex];
            }

            return new byte[] { uchCRCHi, uchCRCLo }; // Big-endian
        }

        /// <summary>
        /// recieve data modbus//////////////////////////////////////////////
        /// </summary>
        public void ReadModbusResponse(SerialPort serialport)
        {
            try
            {
                // Read header (Address, Function Code, Byte Count or High Byte of Address)
                byte[] header = new byte[3];
                serialport.Read(header, 0, 3);

                int functionCode = header[1];
                string baseMessage = $"Function Code: 0x{functionCode:X2} - ";

                byte[] response;
                int responseLength;

                if (functionCode == 0x03) // Read Holding Registers
                {
                    int byteCount = header[2];
                    responseLength = byteCount + 5; // Addr + Func + ByteCount + Data + CRC(2)
                    response = new byte[responseLength];

                    Array.Copy(header, 0, response, 0, 3);
                    serialport.Read(response, 3, responseLength - 3);

                    string rawMessage = BitConverter.ToString(response).Replace("-", " ");
                    textBox3.Text = baseMessage + "Raw: " + rawMessage;

                    // Optional: Parse values
                    byte[] registerData = new byte[byteCount];
                    Array.Copy(response, 3, registerData, 0, byteCount);

                    string decimalString = "";
                    for (int i = 0; i < byteCount; i += 2)
                    {
                        if (i + 1 < byteCount)
                        {
                            ushort value = (ushort)((registerData[i] << 8) | registerData[i + 1]);
                            decimalString += value.ToString() + " ";
                        }
                    }

                    byte_recieved = registerData.Length >= 2 ? registerData[0] : (byte)0;
                    textBox2.Text = decimalString.Trim();
                }
                else if (functionCode == 0x10) // Write Multiple Registers response
                {
                    responseLength = 8; // Addr + Func + StartAddr(2) + RegCount(2) + CRC(2)
                    response = new byte[responseLength];

                    Array.Copy(header, 0, response, 0, 3);
                    serialport.Read(response, 3, responseLength - 3);

                    string rawMessage = BitConverter.ToString(response).Replace("-", " ");
                    textBox3.Text = baseMessage + "Raw: " + rawMessage;
                }
                else
                {
                    // Read more bytes anyway to complete a generic Modbus frame
                    byte[] tail = new byte[5];
                    serialport.Read(tail, 0, 5);

                    byte[] response1 = new byte[header.Length + tail.Length];
                    Array.Copy(header, response1, header.Length);
                    Array.Copy(tail, 0, response1, header.Length, tail.Length);

                    string rawMessage = BitConverter.ToString(response1).Replace("-", " ");
                    string msg = baseMessage + "Raw (unknown function): " + rawMessage;
                    textBox3.Text = msg;

                    SpeechSynthesizer synth = new SpeechSynthesizer();
                    synth.SpeakAsync(msg);
                }
            }
            catch (Exception ex)
            {
                textBox3.Text = $"Error: {ex.Message}";
            }
        }



        // CRC16 validation function (Modbus standard)
        private bool ValidateCRC(byte[] data)
        {
            int length = data.Length;
            if (length < 2) return false;

            byte[] receivedCRC = { data[length - 2], data[length - 1] };
            byte[] calculatedCRC = ComputeCRC(data, length - 2);

            return receivedCRC[0] == calculatedCRC[0] && receivedCRC[1] == calculatedCRC[1];
        }





        private void UpdateLed()
        {
            if ((byte_recieved & (1 << 0)) != 0)
            {
                label3.BackColor = Color.Green;
            }
            else if ((byte_recieved & (1 << 0)) == 0)
            {
                label3.BackColor = Color.WhiteSmoke;
            }
            if ((byte_recieved & (1 << 1)) != 0)
            {
                label4.BackColor = Color.Green;
            }
            else if ((byte_recieved & (1 << 1)) == 0)
            {
                label4.BackColor = Color.WhiteSmoke;
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void UpdateTextBox11()
        {
            int bit0 = (statusbyte >> 0) & 1;
            int bit1 = (statusbyte >> 1) & 1;
            int bit2 = (statusbyte >> 2) & 1;
            textBox11.Text = $"{bit0} {bit1} {bit2}";
        }

        private void button5_Click(object sender, EventArgs e) // OFF bit 0
        {
            statusbyte &= ~(1 << 0);
            UpdateTextBox11();
        }

        private void button6_Click(object sender, EventArgs e) // ON bit 0
        {
            statusbyte |= (1 << 0);
            UpdateTextBox11();
        }

        private void button7_Click(object sender, EventArgs e) // OFF bit 1
        {
            statusbyte &= ~(1 << 1);
            UpdateTextBox11();
        }

        private void button8_Click(object sender, EventArgs e) // ON bit 1
        {
            statusbyte |= (1 << 1);
            UpdateTextBox11();
        }

        private void button9_Click(object sender, EventArgs e) // OFF bit 2
        {
            statusbyte &= ~(1 << 2);
            UpdateTextBox11();
        }

        private void button10_Click(object sender, EventArgs e) // ON bit 2
        {
            statusbyte |= (1 << 2);
            UpdateTextBox11();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                byte[] data = BitConverter.GetBytes(Convert.ToUInt16(textBox5.Text.Substring(2), 16));
                ushort crc = 0xFFFF;

                foreach (byte b in data)
                {
                    crc ^= b;

                    for (int i = 0; i < 8; i++)
                    {
                        if ((crc & 0x0001) != 0)
                        {
                            crc = (ushort)((crc >> 1) ^ 0xA001);
                        }
                        else
                        {
                            crc >>= 1;
                        }
                    }
                }

                textBox5.Text = "";
                string hexString = $"0x{crc:X4}";
                textBox4.Text = hexString;
            }
        }

      
    }
}

