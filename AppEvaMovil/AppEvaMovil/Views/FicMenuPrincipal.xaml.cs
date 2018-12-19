using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEvaMovil.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicMenuPrincipal : ContentPage
	{
		public FicMenuPrincipal ()
		{
			InitializeComponent ();
            BindingContext = App.FicMetLocator.FicVmMenuPrincipal;
        }
	}
}