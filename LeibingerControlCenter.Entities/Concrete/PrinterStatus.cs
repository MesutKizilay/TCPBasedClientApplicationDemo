using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeibingerControlCenter.Entities.Concrete
{
    public class PrinterStatus
    {
        public NozzleState NozzleState { get; set; }
        public MachineState MachineState { get; set; }
        public ParsedErrorInfo ErrorInfo { get; set; }
        public int ErrorNumber { get; set; }
        public bool HeadCoverClosed { get; set; }
        public float CurrentSpeed { get; set; }
        public bool JobChangeFlag { get; set; }
    }

    public enum NozzleState
    {
        Invalid = 0,
        Opens = 1,
        Open = 2,
        Closes = 3,
        Closed = 4,
        InBetween = 5
    }

    public enum MachineState
    {
        Standby = 1,
        Initialization = 2,
        ServicePanel = 3,
        ReadyForAction = 4,
        ReadyForPrint = 5,
        Printing = 6
    }


    public class ParsedErrorInfo
    {
        public ErrorSource Source { get; set; }
        public ShutdownBehavior Shutdown { get; set; }
        public SignalTone Tone { get; set; }
        public DisplayType Display { get; set; }
    }


    public enum ErrorSource
    {
        FepCPU,
        RipCPU,
        SdcCPU,
        Unknown
    }

    public enum ShutdownBehavior
    {
        ShutdownAfter30Min,
        NoShutdown
    }

    public enum SignalTone
    {
        Permanent,
        OneTime,
        None,
        Unknown
    }

    public enum DisplayType
    {
        ErrorWindow,
        WarningWindow,
        MessageWindow,
        Unknown
    }

}