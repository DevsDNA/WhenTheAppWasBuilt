# WhenTheAppWasBuilt

How many times have you said "when was this app built" or "which version affects this bug"? Forget those, from now on just strongly shake your device and we'll show you when the app was built. That simple. [![NuGet](https://img.shields.io/nuget/v/Xam.Plugin.Battery.svg?label=NuGet)](https://www.nuget.org/packages/DevsDNA.WhenTheAppWasBuilt)

## How to use it

Just three easy steps:

1. Add [DevsDNA.WhenTheAppWasBuilt](https://www.nuget.org/packages/DevsDNA.WhenTheAppWasBuilt) NuGet to both your PCL and platform projects;

2. In your Android's `MainActivity` class, add the following line just after Xamarin.Forms init.:

```c-sharp
DevsDNA.WhenTheAppWasBuilt.TellMeWhenShaking(typeof(WhenTheAppWasBuiltExample.App));
```

3. The same goes for iOS' `AppDelegate` one:

```c-sharp
DevsDNA.WhenTheAppWasBuilt.TellMeWhenShaking(typeof(WhenTheAppWasBuiltExample.App));
```

3. Strongly shake your devices!

*Pst!* Have a look to the [Examples](Examples/) folder to get some inspiration!
