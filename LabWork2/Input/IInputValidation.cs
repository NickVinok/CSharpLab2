using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork2.Input
{
    interface IInputValidation
    {
        int CorrectIntInput(String message, int firstItemNumber = 0, int lastItemNumber = 0);
        char CorrectCharInput();
    }
}
