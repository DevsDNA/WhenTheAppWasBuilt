namespace DevsDNA
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DeviceMotion.Plugin;
    using DeviceMotion.Plugin.Abstractions;
    using Xamarin.Forms;

    /// <summary>
    /// When the app was built core.
    /// </summary>
    public abstract class WhenTheAppWasBuiltCore
    {
        const string OKCaption = "OK";
        const string TitleCaption = "🔨🗓";

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

        /// <summary>
        /// Gets the build date.
        /// </summary>
        /// <value>The build date.</value>
        public static DateTime BuildDate { get; private set; }

        /// <summary>
        /// Displays the build date alert.
        /// </summary>
        public static async void DisplayBuildDateAlert()
        {
            var mainPage = Application.Current.MainPage;
            var buildDate = BuildDate.ToString("f");
            alreadyDisplaying = true;
            await mainPage?.DisplayAlert(TitleCaption, buildDate, OKCaption);
            alreadyDisplaying = false;
        }

        /// <summary>
        /// Gathers the date time from.
        /// </summary>
        /// <param name="version">Version.</param>
        protected static void GatherDateTimeFrom(Version version)
		{
			var buildDateTime = new DateTime(2000, 1, 1).Add(new TimeSpan(
				TimeSpan.TicksPerDay * version.Build + // days since 1 January 2000
				TimeSpan.TicksPerSecond * 2 * version.Revision)); // seconds since midnight, (multiply by 2 to get original)

            BuildDate = buildDateTime;
		}

        /// <summary>
        /// Init this instance.
        /// </summary>
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
    }
}
