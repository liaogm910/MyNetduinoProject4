using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;

namespace MyNetduinoProject
{
    public class Program
    {

        static OutputPort _led = new OutputPort(Pins.ONBOARD_LED, false);

        static InterruptPort _button = new InterruptPort((Cpu.Pin)0x15, false, Port.ResistorMode.Disabled, 
                                                                               Port.InterruptMode.InterruptEdgeBoth);

        public static void Main()
        {
            _led.Write(false);

            _button.OnInterrupt += HandleButtonClick;

            while (true)
            {

            }
        }

        static void HandleButtonClick(uint port, uint data, DateTime time)
        {
            Debug.Print("Data: " + data.ToString());
            _led.Write(data == 1);
        }

    }
}
