﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.I2c;
using System.Diagnostics;

namespace I2CComm
{
    public sealed partial class MainPage : Page
    {
        private I2cDevice arduino; // Used to Connect to Arduino
        private DispatcherTimer timer = new DispatcherTimer();
        public MainPage()
        {
            this.InitializeComponent();
            Initialiasecom();
        }
        public async void Initialiasecom()
        {
            var settings = new I2cConnectionSettings(0x53); // Slave Address of Arduino Leonardo,0x40 to Uno
            settings.BusSpeed = I2cBusSpeed.FastMode; // this bus has 400Khz speed
            string aqs = I2cDevice.GetDeviceSelector("I2C1"); // This will return Advanced Query String which is used to select i2c device
            var dis = await Windows.Devices.Enumeration.DeviceInformation.FindAllAsync(aqs);
            arduino = await I2cDevice.FromIdAsync(dis[0].Id, settings);
            timer.Tick += Timer_Tick; // We will create an event handler 
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500); // Timer_Tick is executed every 500 milli second
            timer.Start();
        }
        private async void Timer_Tick(object sender, object e)
        {
            byte[] response = new byte[2];
            try
            {
                arduino.Read(response); // this funtion will read data from Arduino 
            }
            catch (Exception p)
            {
                Windows.UI.Popups.MessageDialog msg = new Windows.UI.Popups.MessageDialog(p.Message);
                await msg.ShowAsync(); // this will show error message(if Any)
            }
            ldr_val.Text = response[0].ToString();
            Debug.WriteLine(response[0].ToString());
        }
    }
}