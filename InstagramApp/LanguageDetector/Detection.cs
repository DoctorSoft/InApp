using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageDetector
{
    public class Detection
    {
        public string language { get; set; }
        public bool isReliable { get; set; }
        public float confidence { get; set; }
    }
}
