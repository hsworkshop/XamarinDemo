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
    public partial class HelloXamlPage : ContentPage
    {
        public static string defval;
        public HelloXamlPage()
        {
            InitializeComponent();
            defval = "Welcome to Xamarin.Forms!";
            look_lab.Text = defval;
        }

        private void sli_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            look_lab.Text = e.NewValue != 0 ? e.NewValue.ToString() : defval;
            btn_one.IsEnabled = e.NewValue != 0  ? true : false;
        }

        private async void btn_one_Clicked(object sender, EventArgs e)
        {
            if(await DisplayAlert("确认变更", "是否重置为初始值？", "是", "否"))
            {
                sli.Value = 0;
                look_lab.Text = defval;
            }


        }
    }
}