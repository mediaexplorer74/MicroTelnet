using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace MicroTelnet
{
    /// <summary>
    /// Главная страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {


        TcpClient telnetClient;
        //string Addr = "192.168.1.33"; // remote 
        //string Addr = "127.0.0.1"; // remote 
        //int Port = 23; // telnet 


        // constructor
        public MainPage()
        {
            this.InitializeComponent();

            

        }


                

        public static string GetAnswer(TcpClient tc)
        {
            NetworkStream netStream = tc.GetStream();
            byte[] bytes = new byte[tc.ReceiveBufferSize];
            netStream.Read(bytes, 0, (int)tc.ReceiveBufferSize);
            string returndata = Encoding.ASCII.GetString(bytes);
            return ("This is what the host returned to you: " + returndata);
        }

        static void SendCmd(TcpClient tc, string cmd)
        {
            NetworkStream netStream = tc.GetStream();
            if (netStream.CanWrite)
            {
                Byte[] sendBytes = Encoding.ASCII.GetBytes(cmd + "\r\n");
                netStream.Write(sendBytes, 0, sendBytes.Length);
            }
            //Thread.Sleep(1000);
        }

        void SuperWriteLine(string onestring)
        {

            ResponseBox.Items.Add(onestring);
        }

        // Open Picker demo
        private async void openButton_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.Desktop;
            openPicker.CommitButtonText = "Choose XAP file";
            openPicker.FileTypeFilter.Add(".xap");
            var file = await openPicker.PickSingleFileAsync();

            // check the file choosed or not
            if (file != null)
            {
                string text = file.Path;

                
                string newPath = text.Replace("&", "^&");
                SuperWriteLine(newPath);



                // fulfill filePath
                XapPathBox.Text = newPath; //file.Path; 
            }
        }//openButton_Click end

        
        // Win10 <-> WM10 Path sync (NOT READY YET!)
        private void PathSync(string src)
        {
            // TODO
        }

        // Try to Start XAP Delpoy =)
        private async void StartDeploy_Click(object sender, RoutedEventArgs e)
        {
            openButton.IsEnabled = false;
            saveButton.IsEnabled = false;

            StringBuilder sb = new StringBuilder();
            string Parameter1 = XapPathBox.Text; 
            string Parameter2;

            string ipaddress = TelnetIP.Text;

            int port = 23;

            // TO DO
            // IP address checking

            try
            {
                port = Int32.Parse(TelnetPort.Text);
            }
            catch (Exception E2)
            {
                SuperWriteLine("Error! Bad port: " + E2.Message);
                openButton.IsEnabled = true;
                saveButton.IsEnabled = true;
                return;
            }


            // -- 1 -- 
            //create TcpClient object 
            telnetClient = new TcpClient();



            //await telnetClient.ConnectAsync("192.168.1.33", 23);
            try
            {
                SuperWriteLine("Trying to connect to  " + ipaddress + ":" + port);

                // ERROR IF TRY FROM WM !!!
                await telnetClient.ConnectAsync(ipaddress, port);
            }
            catch (Exception e1)
            {
                // DEBUG INFO
                SuperWriteLine("Telnet connect error!\r\n Exception:  " + e1.Message);
                openButton.IsEnabled = true;
                saveButton.IsEnabled = true;
                return;
            }

            try
            {
                var r = GetAnswer(telnetClient);
                // DEBUG: get telnet echo
                SuperWriteLine(r);
            }
            catch (Exception e2)
            {
                // DEBUG INFO
                SuperWriteLine("Telnet data transfer error!\r\n Exception: " + e2.Message);
                openButton.IsEnabled = true;
                saveButton.IsEnabled = true;
                return;
            }



            // --2 --  
            // Parse parameters

            if (toggleSwitch1.IsOn)
            {
                Parameter2 = "1";
            }
            else
            {
                Parameter2 = "0";
            }

            // send loginname
            //SendCmd(telnetClient, "Sirepuser");

            // DEBUG: get telnet echo
            //SuperWriteLine(GetAnswer(telnetClient));


            // send password
            //SendCmd(telnetClient, "1234");

            // DEBUG: get telnet echo
            //SuperWriteLine(GetAnswer(telnetClient));

            // -- 3 --
            // try to install xap
            SendCmd(telnetClient, "xapinst " + Parameter1 + " " + Parameter2  + "\r\n");
            SuperWriteLine("xapinst " + Parameter1 + " " + Parameter2);

            // DEBUG: get telnet echo
            SuperWriteLine(GetAnswer(telnetClient));


            //SuperWriteLine("bb.xap must be installed (by xapinst.bat)");

            //RnD
            //telnetClient.Dispose();
            openButton.IsEnabled = true;
            saveButton.IsEnabled = true;

        }// StartDelpoy_Click end

        private void toggleSwitch1_Toggled(object sender, RoutedEventArgs e)
        {
            //
        }

    }// class end

}// namespase end
