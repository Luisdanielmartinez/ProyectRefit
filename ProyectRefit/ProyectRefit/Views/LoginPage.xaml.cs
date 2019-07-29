using ProyectRefit.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectRefit.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        private LoginViewModel _contextUser;
        public LoginPage ()
		{
			InitializeComponent ();
            _contextUser = new LoginViewModel();
        }
        private void emailFocused(object sender, FocusEventArgs e)
        {
            _contextUser.Email.Validate();
        }
        private void passwordFocused(object sender, FocusEventArgs e)
        {
            _contextUser.Password.Validate();
        }
    }
}