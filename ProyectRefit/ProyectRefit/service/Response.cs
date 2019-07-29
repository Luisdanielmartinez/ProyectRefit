
namespace ProyectRefit.service
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Response
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public Object Result { get; set; }
    }
}
