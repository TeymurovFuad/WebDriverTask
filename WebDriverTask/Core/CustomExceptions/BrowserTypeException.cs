﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverTask.Core.CustomExceptions
{
    public class BrowserTypeException : Exception
    {
        public BrowserTypeException(): base()
        {
        }

        public BrowserTypeException(string message): base(message)
        {
        }

        public BrowserTypeException(string message, Exception innerException): base(message, innerException)
        {
        }
    }
}
