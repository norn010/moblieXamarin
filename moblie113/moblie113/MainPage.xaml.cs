using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace moblie113
{
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            // ทำให้ Tab อยู่ด้านล่างสำหรับ iOS
            /*On<iOS>().SetTabBarPosition(TabBarPosition.Bottom);*/

            // ทำให้ Tab อยู่ด้านล่างสำหรับ Android
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}
