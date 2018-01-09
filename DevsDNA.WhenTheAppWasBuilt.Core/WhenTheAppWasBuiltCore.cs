using System;
using System.Collections.Generic;
using System.Linq;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using Xamarin.Forms;

namespace DevsDNA
{
    public abstract class WhenTheAppWasBuiltCore
    {
        static readonly Func<int> GetDistanceThreeshold = () =>
        {
            int threeshold;

            switch (Device.RuntimePlatform)
            { 
                case Device.iOS:
                    threeshold = 4;
                    break;
                default:
                case Device.Android:
                    threeshold = 30;
                    break;
            }

            return threeshold;
        };

		static bool alreadyDisplaying;
        static List<MotionVector> lastMotionVectors = new List<MotionVector>();

        public static DateTime BuildDate { get; private set; }

        protected static void GatherDateTimeFrom(Version version)
		{
			var buildDateTime = new DateTime(2000, 1, 1).Add(new TimeSpan(
				TimeSpan.TicksPerDay * version.Build + // days since 1 January 2000
				TimeSpan.TicksPerSecond * 2 * version.Revision)); // seconds since midnight, (multiply by 2 to get original)

            BuildDate = buildDateTime;
		}

        protected static void Init()
        {
            CrossDeviceMotion.Current.Start(MotionSensorType.Accelerometer);
            CrossDeviceMotion.Current.SensorValueChanged += Current_SensorValueChanged;
        }

        static void Current_SensorValueChanged(object sender, SensorValueChangedEventArgs e)
        {
            var motionVector = e.Value as MotionVector;
            lastMotionVectors.Add(motionVector);

            if (lastMotionVectors.Count == 10)
            {
                var minX = lastMotionVectors.Min(vector => vector.X);
                var maxX = lastMotionVectors.Max(vector => vector.X);

                var minY = lastMotionVectors.Min(vector => vector.Y);
                var maxY = lastMotionVectors.Max(vector => vector.Y);

                var minZ = lastMotionVectors.Min(vector => vector.Z);
                var maxZ = lastMotionVectors.Max(vector => vector.Z);

                var distanceX = Math.Abs(maxX - minX);
                var distanceY = Math.Abs(maxY - minY);
                var distanceZ = Math.Abs(maxZ - minZ);
                var threeshold = GetDistanceThreeshold();

                if ((distanceX >= threeshold || distanceY >= threeshold || distanceZ >= threeshold) && 
                    !alreadyDisplaying)
                {
                    DisplayBuildDateAlert();
                }

                lastMotionVectors.Clear();
            }
        }

        static async void DisplayBuildDateAlert()
        {
            var mainPage = Application.Current.MainPage;
            var buildDate = BuildDate.ToString("f");
            alreadyDisplaying = true;
            await mainPage?.DisplayAlert(null, $"Built on {buildDate}", "OK");
            alreadyDisplaying = false;
        }
    }
}
