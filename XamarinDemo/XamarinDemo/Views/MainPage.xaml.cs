using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //后退再进入为new一个新的对象，是否存在销毁？
            Navigation.PushAsync(new Views.Phoneword.PhoneIndex());
        }
    }
}
