using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinDemo.Views.Phoneword
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PhoneIndex : ContentPage
	{
        string translatedNumber;
        public static List<string> PhoneNumbers { get; set; }

        public PhoneIndex ()
		{
			InitializeComponent ();
            Title = "拨号小程序";
            PhoneNumbers = new List<string>();
        }


        private void translateButon_Clicked(object sender, EventArgs e)
        {
            translatedNumber = PhoneTranslator.ToNumber(phoneNumberText.Text);
            if (!string.IsNullOrWhiteSpace(translatedNumber)) {
                callButton.IsEnabled = true;
                callButton.Text = "立即拨打：" + translatedNumber;
            }
            else
            {
                callButton.IsEnabled = false;
                callButton.Text = "拨号";
            }
        }

        private async void callButton_Clicked(object sender, EventArgs e)
        {

            PhoneNumbers.Add(translatedNumber);
            callHistory.IsEnabled = true;
            //TODO：等待对应平台实现后再将以上代价加入。

            if (await this.DisplayAlert("拨号确认","确认后立刻拨打"+translatedNumber,"确认","取消"))
            {
                //此处需在各平台上去实现接口来完成拨号。.form本身不具备
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                {
                    dialer.Dial(translatedNumber);
                }

            }
        }

        private async void callHistory_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CallHistoryPage());
        }
    }
}