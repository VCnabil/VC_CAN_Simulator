using Kvaser.CanLib;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VC_CAN_Simulator.Backend
{
    public class CanManager
    {
        private int handle;
        public delegate void MessageReceivedHandler(string message);
        public event MessageReceivedHandler OnMessageReceived;
        byte[] datareceivedFFFA;
        string strid = "";
        public CanManager()
        {
            Canlib.canInitializeLibrary();
            datareceivedFFFA = new byte[8];
        }

        public void ListChannels()
        {
            Canlib.canStatus stat = Canlib.canGetNumberOfChannels(out int numberOfChannels);
            CheckStatus(stat, "canGetNumberOfChannels");

            if (stat == Canlib.canStatus.canOK)
            {
                Console.WriteLine($"Found {numberOfChannels} channels");

                for (int i = 0; i < numberOfChannels; i++)
                {
                    stat = Canlib.canGetChannelData(i, Canlib.canCHANNELDATA_DEVDESCR_ASCII, out object deviceName);
                    CheckStatus(stat, "canGetChannelData (Device Name)");

                    stat = Canlib.canGetChannelData(i, Canlib.canCHANNELDATA_CHAN_NO_ON_CARD, out object deviceChannel);
                    CheckStatus(stat, "canGetChannelData (Channel Number)");

                    Console.WriteLine($"Found channel: {i} {deviceName} {((UInt32)deviceChannel + 1)}");
                }
            }
        }


        public void OpenChannel(int channelNumber)
        {
            handle = Canlib.canOpenChannel(channelNumber, Canlib.canOPEN_ACCEPT_VIRTUAL);
            CheckStatus((Canlib.canStatus)handle, "canOpenChannel");
        }

        public void SetBusParams()
        {
            var status = Canlib.canSetBusParams(handle, Canlib.canBITRATE_250K, 0, 0, 0, 0);
            CheckStatus(status, "canSetBusParams");
        }

        public void GoOnBus()
        {
            var status = Canlib.canBusOn(handle);
            CheckStatus(status, "canBusOn");
        }

        public void SendMessageold(int id, byte[] message)
        {
            var status = Canlib.canWrite(handle, id, message, 8, Canlib.canMSG_EXT);
            CheckStatus(status, "canWrite");
        }
        public void SendMessage(int id, byte[] message)
        {
            var status = Canlib.canWrite(handle, id, message, 8, Canlib.canMSG_EXT);
            // Check if status is canERR_TXBUFOFL
            if (status == Canlib.canStatus.canERR_TXBUFOFL)
            {
                // Handle the transmit buffer overflow situation
                // For example, you might want to log this and stop sending further messages
                // Console.WriteLine("Transmit buffer overflow. Stopping message transmission.");
                return; // Exit the method to stop further message transmission
            }
            // Otherwise, continue to check for other statuses
            CheckStatus(status, "canWrite");
        }

        public string SendMessage_andLogIt(int id, byte[] data, bool arg_in_HexFormat)
        {
            string str_Hex_ID = "";
            if (arg_in_HexFormat)
            {
                str_Hex_ID = id.ToString("X8");
            }
            else
            {
                str_Hex_ID = id.ToString("D9");
            }

            string str_space_ceparated_data = " ";

            for (int x = 0; x < data.Length; x++)
            {
                if (arg_in_HexFormat)
                {
                    str_space_ceparated_data += data[x].ToString("X2") + " ";

                }
                else
                {
                    str_space_ceparated_data += data[x].ToString("D3") + " ";
                }
            }
            string logMessage = ".";



            var status = Canlib.canWrite(handle, id, data, 8, Canlib.canMSG_EXT);
            CheckStatus(status, "canWrite");
            if (status == Canlib.canStatus.canOK)
            {
                logMessage = str_Hex_ID + str_space_ceparated_data;

            }
            else
            {
                logMessage = "ERROR";
            }

            return logMessage;
        }


        public void ReceiveMessageold()
        {
            Canlib.canStatus status;
            byte[] data = new byte[8];
            int id;
            int dlc;
            int flags;
            long timestamp;
            bool finished = false;

            Console.WriteLine("Press the Spacebar to stop receiving messages.");

            while (!finished)
            {
                status = Canlib.canReadWait(handle, out id, data, out dlc, out flags, out timestamp, 100);

                if (status == Canlib.canStatus.canOK)
                {
                    Console.WriteLine($"Received Message: ID={id}, DLC={dlc}, Data={BitConverter.ToString(data, 0, dlc)}, Timestamp={timestamp}");
                }
                else if (status != Canlib.canStatus.canERR_NOMSG)
                {
                    CheckStatus(status, "canReadWait");
                    break;  // Exit the loop if an error occurs
                }

                if (Console.KeyAvailable)
                {
                    if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                    {
                        finished = true;
                    }
                }
            }
        }
        bool receivingMessages = true; // Flag to start/stop receiving messages


        public void ReceiveMessage(bool start)
        {
            if (start)
            {
                byte[] data = new byte[8];
                int id;
                int dlc;
                int flags;
                long timestamp;
                Canlib.canStatus status;

                status = Canlib.canReadWait(handle, out id, data, out dlc, out flags, out timestamp, 100);

                if (status == Canlib.canStatus.canOK)
                {
                    string message = $"Received Message: ID={id}, DLC={dlc}, Data={BitConverter.ToString(data, 0, dlc)}, Timestamp={timestamp}";
                    OnMessageReceived?.Invoke(message);
                }
                else if (status != Canlib.canStatus.canERR_NOMSG)
                {
                    CheckStatus(status, "canReadWait");
                }
            }
        }

        public string ReceiveMessageV2(bool start)
        {
            string meg = ".";
            Canlib.canStatus status;
            byte[] data = new byte[8];
            int id;
            int dlc;
            int flags;
            long timestamp;
            bool finished = false;

            Console.WriteLine("Press the Spacebar to stop receiving messages.");


            status = Canlib.canReadWait(handle, out id, data, out dlc, out flags, out timestamp, 100);

            if (status == Canlib.canStatus.canOK)
            {
                meg = $"Received Message: ID={id}, DLC={dlc}, Data={BitConverter.ToString(data, 0, dlc)}, Timestamp={timestamp}";
            }
            else if (status != Canlib.canStatus.canERR_NOMSG)
            {
                CheckStatus(status, "canReadWait");
                meg = "caneait"; // Exit the loop if an error occurs
            }

            return meg;

        }

        public string ReceiveMessageVALSEER(bool arg_in_HexFormat)
        {
            string meg = ".";
            Canlib.canStatus status;
            byte[] data = new byte[8];
            int id;
            int dlc;
            int flags;
            long timestamp;
            bool finished = false;




            status = Canlib.canReadWait(handle, out id, data, out dlc, out flags, out timestamp, 100);

            if (status == Canlib.canStatus.canOK)
            {
                string str_Hex_ID = "";
                if (arg_in_HexFormat)
                {
                    str_Hex_ID = id.ToString("X8");
                }
                else
                {
                    str_Hex_ID = id.ToString("D9");
                }

                string str_space_ceparated_data = " ";

                for (int x = 0; x < data.Length; x++)
                {
                    if (arg_in_HexFormat)
                    {
                        str_space_ceparated_data += data[x].ToString("X2") + " ";

                    }
                    else
                    {
                        str_space_ceparated_data += data[x].ToString("D3") + " ";
                    }
                }

                meg = str_Hex_ID + str_space_ceparated_data;
            }
            else if (status != Canlib.canStatus.canERR_NOMSG)
            {
                CheckStatus(status, "canReadWait");
                meg = "ERROR"; // Exit the loop if an error occurs
            }

            return meg;

        }


        public byte[] ReceiveMessageSpecificForAxioTest()
        {
            string meg = ".";
            Canlib.canStatus status;
            byte[] data = new byte[8];
            int id;
            int dlc;
            int flags;
            long timestamp;
            bool finished = false;

            Console.WriteLine("Press the Spacebar to stop receiving messages.");


            status = Canlib.canReadWait(handle, out id, data, out dlc, out flags, out timestamp, 100);

            if (status == Canlib.canStatus.canOK)
            {
                meg = $"Received Message: ID={id}, DLC={dlc}, Data={BitConverter.ToString(data, 0, dlc)}, Timestamp={timestamp}";

                if (id == 0x18FFA00)
                {
                    data[0] = 1;
                    data[1] = 1;

                    return data;
                }
            }
            else if (status != Canlib.canStatus.canERR_NOMSG)
            {
                CheckStatus(status, "canReadWait");
                meg = "caneait"; // Exit the loop if an error occurs
            }

            return data;

        }

        public byte[] RGetdatas()
        {
            string meg = ".";
            Canlib.canStatus status;
            byte[] data = new byte[8];
            int id;
            int dlc;
            int flags;
            long timestamp;
            bool finished = false;

            //Console.WriteLine("Press the Spacebar to stop receiving messages.");


            status = Canlib.canReadWait(handle, out id, data, out dlc, out flags, out timestamp, 100);

            if (status == Canlib.canStatus.canOK)
            {
                //meg = $"Received Message: ID={id}, DLC={dlc}, Data={BitConverter.ToString(data, 0, dlc)}, Timestamp={timestamp}";

                if (id == 419428864/*0x18FFA00*/)
                {


                    // return data;
                    datareceivedFFFA[0] = data[0];
                    datareceivedFFFA[1] = data[1];
                    datareceivedFFFA[2] = data[2];
                    datareceivedFFFA[3] = data[3];
                    datareceivedFFFA[4] = data[4];
                    datareceivedFFFA[5] = data[5];
                    datareceivedFFFA[6] = data[6];
                    datareceivedFFFA[7] = data[7];
                }
            }
            else if (status != Canlib.canStatus.canERR_NOMSG)
            {
                CheckStatus(status, "canReadWait");
                //meg = "caneait"; // Exit the loop if an error occurs
            }

            if (id == 419428864)
                strid = id.ToString();
            return datareceivedFFFA;

        }
        public string getid()
        {

            return strid;
        }

        public void GoOffBus()
        {
            var status = Canlib.canBusOff(handle);
            CheckStatus(status, "canBusOff");
        }

        public void CloseChannel()
        {
            var status = Canlib.canClose(handle);
            CheckStatus(status, "canClose");
        }


        private void CheckStatus(Canlib.canStatus status, string method)
        {
            if (status < 0)
            {
                string errorText;
                Canlib.canGetErrorText(status, out errorText);

                // Check if there's an open form
                if (System.Windows.Forms.Application.OpenForms.Count > 0)
                {
                    // Use the first open form to invoke the MessageBox
                    System.Windows.Forms.Application.OpenForms[0].Invoke(new MethodInvoker(delegate
                    {
                        MessageBox.Show($"{method} failed: {errorText}");
                    }));
                }
                else
                {
                    // Fallback if no form is open
                    Console.WriteLine($"{method} failed: {errorText}");
                }
            }
        }
        public void SendTestCan()
        {
            byte[] testarra = new byte[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
            var status = Canlib.canWrite(handle, 0x18BAAD00, testarra, 8, Canlib.canMSG_EXT);

        }
        private void CheckStatussold(Canlib.canStatus status, string method)
        {
            if (status < 0)
            {
                string errorText;
                Canlib.canGetErrorText(status, out errorText);
                Console.WriteLine($"{method} failed: {errorText}");
            }
        }

        public static int HexStringToInt(string hexString)
        {
            if (string.IsNullOrEmpty(hexString))
            {
                throw new ArgumentException("The string cannot be null or empty.", nameof(hexString));
            }

            // Removing the '0x' prefix if it exists
            hexString = hexString.Replace("0x", "").Replace("0X", "");

            // Converting the hexadecimal string to an integer
            return int.Parse(hexString, NumberStyles.HexNumber);
        }
    }
}
