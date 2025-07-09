using LeibingerControlCenter.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeibingerControlCenter.Business.Helpers
{
    public static class RequestHelper
    {
        public static string BuildRequest(string command)
        {
            return $"^0{command}\r";
        }

        public static List<string> ParseResponse(string response)
        {
            // Örnek: ^0=RS4\t4\t0\t0\t0\t0\r
            //if (!response.StartsWith("^") || !response.Contains("="))
            //    throw new ArgumentException("Invalid response format");

            int cmdStart = response.IndexOfAny(['=', '$']) + 3;
            int cmdEnd = response.IndexOfAny(new[] { '\r' }, cmdStart);

            //string command = response.Substring(cmdStart, cmdEnd - cmdStart);

            string payload = response.Remove(cmdEnd).Substring(cmdStart).Trim(); // "\t4\t0\t0\t0\t0\r"
            string[] parts = payload.Split('\t');


            return parts.ToList();
        }

        public static string ConvertDecimalToBinary(int errorNumber)
        {
            // 32 bitlik ikili gösterim (ön ek sıfırlarla doldurulur)
            return Convert.ToString(errorNumber, 2).PadLeft(32, '0');
        }

        public static ParsedErrorInfo ParseErrorBits(string binary)
        {
            // 32 bit olmasını garanti edelim
            binary = binary.PadLeft(32, '0');

            // Bit 31-30 (Display)
            string displayBits = binary.Substring(0, 2);
            DisplayType display = displayBits switch
            {
                "00" => DisplayType.ErrorWindow,
                "01" => DisplayType.WarningWindow,
                "10" => DisplayType.MessageWindow,
                _ => DisplayType.Unknown
            };

            // Bit 29-28 (Signal Tone)
            string toneBits = binary.Substring(2, 2);
            SignalTone tone = toneBits switch
            {
                "00" => SignalTone.Permanent,
                "01" => SignalTone.OneTime,
                "10" => SignalTone.None,
                _ => SignalTone.Unknown
            };

            // Bit 27 (Shutdown)
            char shutdownBit = binary[4];
            ShutdownBehavior shutdown = shutdownBit == '1' ? ShutdownBehavior.NoShutdown : ShutdownBehavior.ShutdownAfter30Min;

            // Bit 26-25 (Error Source)
            string sourceBits = binary.Substring(5, 2);
            ErrorSource source = sourceBits switch
            {
                "00" => ErrorSource.FepCPU,
                "01" => ErrorSource.RipCPU,
                "10" => ErrorSource.SdcCPU,
                _ => ErrorSource.Unknown
            };

            return new ParsedErrorInfo
            {
                Source = source,
                Shutdown = shutdown,
                Tone = tone,
                Display = display
            };
        }
    }
}