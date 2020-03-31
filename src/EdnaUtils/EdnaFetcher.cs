using System;
using System.Collections.Generic;
using System.Text;
using InStep.eDNA.EzDNAApiNet;

namespace EdnaUtils
{
    public class EdnaFetcher
    {
        public RTValue FetchRealTimeData(string pnt)
        {
            int nret = 0;
            double dval = 0;
            DateTime timestamp = DateTime.Now;
            string status = "";
            string desc = "";
            string units = "";
            RTValue rtVal;
            try
            {
                nret = RealTime.DNAGetRTAll(pnt, out dval, out timestamp, out status, out desc, out units);//get RT value
                if (nret == 0)
                {
                    rtVal = new RTValue { Dval = dval, Timestamp = timestamp, Status = status, Units = units };
                    return rtVal;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while fetching realtime result " + ex.Message);
                return null;
            }
            return null;
        }
    }
}
