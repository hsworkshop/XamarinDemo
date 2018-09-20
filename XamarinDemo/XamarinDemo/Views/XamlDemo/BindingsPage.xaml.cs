using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinDemo.Views.XamlDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BindingsPage : ContentPage
    {
        public BindingsPage()
        {
            InitializeComponent();
        }
    }
}