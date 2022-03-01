using NLog;
using System;

namespace OZ.Commons
{
    public class NLogAction
    {

        public Logger logger;
        public static NLogAction instance;
        public NLogAction()
        {
            logger = LogManager.GetCurrentClassLogger();
        }

        public static void CreateIntance()
        {
            instance = new NLogAction();
        }
    }
}
