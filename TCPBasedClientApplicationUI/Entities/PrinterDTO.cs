using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPBasedClientApplicationUI.Entities
{
    public class PrinterDTO
    {
        public PrinterStatus PrinterStatus { get; set; }
        public ErrorStatus ErrorStatus { get; set; }
        public NozzleStatus NozzleStatus { get; set; }
    }

    public enum PrinterStatus
    {
        Close = 0,
        Open = 1,
        Busy = 2
    }

    public enum ErrorStatus
    {
        NoError = 0,
        Error = 1
    }

    public enum NozzleStatus
    {
        Close = 0,
        Open = 1
    }
}
