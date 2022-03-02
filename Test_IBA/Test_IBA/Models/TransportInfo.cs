using System.ComponentModel.DataAnnotations;

namespace Test_IBA.Models
{
    public class TransportInfo
    {
        [RegularExpression(@"^([1-9]|([012][0-9])|(3[01])).([0]{0,1}[1-9]|1[012]).\d\d\d\d (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d$")]
        public string DateTime { get; set; }

        [RegularExpression(@"\d{4} [A-Z]{2}-\d{1}")]
        public string CarNumber { get; set; }

        public double CarSpeed { get; set; }

        public override string ToString()
        {
            return DateTime + ";" + CarNumber + ";" + CarSpeed;
        }
    }
}
