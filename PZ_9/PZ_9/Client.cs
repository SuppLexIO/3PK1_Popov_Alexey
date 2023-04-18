using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PZ_9
{
    public class Client : Origin
    {
        public void ClientDouble(double d)
        {
            OriginDouble(d);
        }
        public void ClientInt(int i)
        {
            OriginInt(i * 2);
        }
        public void ClientChar(char c)
        {
            string b ="";
            for (int i = 0; i < 5; i++)
            {
                b += Convert.ToString(c);
            }
            MessageBox.Show(Convert.ToString(b));
        }
    }
}
