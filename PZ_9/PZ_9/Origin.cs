using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PZ_9
{
    public class Origin
    {
        public void OriginDouble(double d)
        {
            MessageBox.Show(Convert.ToString(d));
        }
        public void OriginInt(int i)
        {
            MessageBox.Show(Convert.ToString(i));
        }
        public void OriginChar(char c)
        {
            MessageBox.Show(Convert.ToString(c));
        }
    }


}
