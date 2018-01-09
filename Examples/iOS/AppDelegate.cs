using System;
using System.Collections.Generic;
using System.Linq;
using DevsDNA;
using Foundation;
using UIKit;

namespace WhenTheAppWasBuiltExample.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            WhenTheAppWasBuilt.TellMeWhenShaking(typeof(WhenTheAppWasBuiltExample.App));

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
