using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Test_IBA.Models;

namespace Test_IBA.Repositories
{
    public class TransportInfoRepository : ITransportInfo
    {
        const string pathCsvFile = "..\\Test_IBA\\Data.csv";      

        public void AddTransportInfo(TransportInfo transportInfo)
        {
            using var write = new StreamWriter(pathCsvFile, true);           
            write.WriteLine(transportInfo.ToString());
        }

        public List<TransportInfo> GetTrasportInfoByDateAndSpeed(string date, double speed)
        {
            var transportInfos = GetTransportInfos().Where(t => t.DateTime.Contains(date) && t.CarSpeed > speed).ToList();
            return transportInfos;
        }

        public List<TransportInfo> GetMaxAndMinTransportInfo(string date)
        {
            var transportInfos = GetTransportInfos().Where(t => t.DateTime.Contains(date)).ToList();
            if(transportInfos.Count == 0)
            {
                return transportInfos;
            } 
            
            var transportInfosByMaxSpeed = transportInfos.OrderByDescending(sp => sp.CarSpeed).First();
            var transportInfosByMinSpeed = transportInfos.OrderBy(sp => sp.CarSpeed).First();
            return new List<TransportInfo>() { transportInfosByMaxSpeed, transportInfosByMinSpeed};
        }

        private List<TransportInfo> GetTransportInfos() 
        {
            var transportInfos = new List<TransportInfo>();
            foreach (var line in File.ReadLines(pathCsvFile))
            {
                var words = line.Split(';');
                transportInfos.Add(new TransportInfo() { DateTime = words[0], CarNumber = words[1], CarSpeed = Convert.ToDouble(words[2]) });
            }

            return transportInfos;
        }

    }
}
