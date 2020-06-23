using Cim.Lib.CommandHandler;
using Cim.Lib.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cim.Con
{
    public static class Factory
    {
        public static IGui CreateGui()
        {
            return new Gui();
        }
        public static IAddHandler CreateAddHandler()
        {
            return new AddHandler();
        }
        public static IListHandler CreateListHandler()
        {
            return new ListHandler();
        }
    }
}
