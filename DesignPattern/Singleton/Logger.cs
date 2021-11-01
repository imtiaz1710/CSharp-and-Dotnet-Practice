using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Logger
    {
        private static Logger _logger;
        public int Checker { get; set; }

        private Logger()
        { 
        }

        public static Logger GetInstance()
        {
            if(_logger == null)
            {
                _logger = new Logger();
            }

            return _logger;
        }
        
        public void UpdateChecker()
        {
            Checker = 33;
        }
    }
}
