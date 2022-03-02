using System;
using System.Collections.Generic;
using Test_IBA.Models;

namespace Test_IBA.Repositories
{
    public interface ITransportInfo
    {
        public void AddTransportInfo(TransportInfo transportInfo);

        public List<TransportInfo> GetTrasportInfoByDateAndSpeed(string date, double speed);

        public List<TransportInfo> GetMaxAndMinTransportInfo(string date);
    }
}
