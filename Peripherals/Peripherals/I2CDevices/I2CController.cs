using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.I2c;

namespace Peripherals.I2CDevices
{
    class I2CController
    {
        I2cDevice device = null;
        public byte addr;

        public I2CController(byte address)
        {
            addr = address;
            InitializeComponent();
        }

        public async void InitializeComponent()
        {
            string aqs = I2cDevice.GetDeviceSelector();
            DeviceInformationCollection collection = await DeviceInformation.FindAllAsync(aqs);

            I2cConnectionSettings settings = new I2cConnectionSettings(addr);
            settings.BusSpeed = I2cBusSpeed.FastMode; // 400kHz clock
            settings.SharingMode = I2cSharingMode.Exclusive;
            device = await I2cDevice.FromIdAsync(collection[0].Id, settings);
        }

        public byte ReadByte(byte regAddr)
        {
            byte[] buffer = new byte[1];
            buffer[0] = regAddr;
            byte[] value = new byte[1];
            device.WriteRead(buffer, value);
            return value[0];
        }

        public byte[] ReadBytes(byte regAddr, int length)
        {
            byte[] values = new byte[length];
            byte[] buffer = new byte[1];
            buffer[0] = regAddr;
            device.WriteRead(buffer, values);
            return values;
        }

        public void WriteByte(byte regAddr, byte data)
        {
            byte[] buffer = new byte[2];
            buffer[0] = regAddr;
            buffer[1] = data;
            device.Write(buffer);
        }

        public void writeBytes(byte regAddr, byte[] values)
        {
            byte[] buffer = new byte[1 + values.Length];
            buffer[0] = regAddr;
            Array.Copy(values, 0, buffer, 1, values.Length);
            device.Write(buffer);
        }
    }
}
