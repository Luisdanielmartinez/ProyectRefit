

namespace ProyectRefit.Insfratructure
{
    using ProyectRefit.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class InstanceLocator
    {

        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            Main = MainViewModel.GetInstance();
        }
    }
}
