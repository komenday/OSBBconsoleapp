using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBBConsoleApp
{
    interface IPayStuff
    {
        void PayDirector(object sender, SalaryEventArgs e);
        void PayAccounter(object sender, SalaryEventArgs e);
        void PayCleaner(object sender, SalaryEventArgs e);
        void PayTrashman(object sender, SalaryEventArgs e);
    }
}
