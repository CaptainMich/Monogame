using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.MyEventArgs
{
    class NewInputEventArgs :EventArgs
    {
        // FIELD
        public Input Input { get; set; }

        // CONSTRUCTOR
        public NewInputEventArgs(Input input)
        {
            Input = input;
        }
    }
}
