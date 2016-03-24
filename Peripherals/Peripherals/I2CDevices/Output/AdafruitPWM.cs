using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;

namespace Peripherals.I2CDevices.Output
{
    class AdafruitPWM
    {

        #region byte constants
        //Registers
        byte MODE1 =            0x00;
        byte MODE2 =            0x01;
        byte SUBADR1 =          0x02;
        byte SUBADR2 =          0x03;
        byte SUBADR3 =          0x04;
        byte PRESCALE =         0xFE;
        byte LED0_ON_L =        0x06;
        byte LED0_ON_H =        0x07;
        byte LED0_OFF_L =       0x08;
        byte LED0_OFF_H =       0x09;
        byte ALL_LED_ON_L =     0xFA;
        byte ALL_LED_ON_H =     0xFB;
        byte ALL_LED_OFF_L =    0xFC;
        byte ALL_LED_OFF_H =    0xFD;

        //Bits
        byte RESTART =          0x80;
        byte SLEEP =            0x10;
        byte ALLCALL =          0x01;
        byte INVRT =            0x10;
        byte OUTDRV =           0x04;

        #endregion

        public byte addr = 0x40;

        public AdafruitPWM(byte address)
        {
            addr = address;
            InitializeHardware();
        }

        public async void InitializeHardware()
        {
            
        }
    }
}
