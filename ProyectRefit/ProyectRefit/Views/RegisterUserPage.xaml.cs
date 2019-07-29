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
	public partial class RegisterUserPage : ContentPage
	{
        private RegisterUserViewModel _contextUser;
		public RegisterUserPage ()
		{
			InitializeComponent ();
            _contextUser = new RegisterUserViewModel();
		}
        private void nameEntry_Unfocused(object sender, FocusEventArgs e)
        {
            _contextUser.FirstName.Validate();
        }
        private void lastNameEntry_Unfocused(object sender, FocusEventArgs e)
        {
            _contextUser.LastName.Validate();
        }
        private void addressEntry_Unfocused(object sender, FocusEventArgs e)
        {
            _contextUser.Address.Validate();
        }
        private void telEntry_Unfocused(object sender, FocusEventArgs e)
        {
            _contextUser.Tel.Validate();
        }
        private void emailEntry_Unfocused(object sender, FocusEventArgs e)
        {
            _contextUser.Email.Validate();
        }
        private void passwordEntry_Unfocused(object sender, FocusEventArgs e)
        {
            _contextUser.Email.Validate();
        }
    }
}