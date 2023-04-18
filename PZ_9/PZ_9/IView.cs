using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_9
{
    public interface IView
    {
        void ShowMessage(string message);
        void ShowDouble(double d);
        void ShowInt(int i);
        void ShowChar(char c);
    }
}
