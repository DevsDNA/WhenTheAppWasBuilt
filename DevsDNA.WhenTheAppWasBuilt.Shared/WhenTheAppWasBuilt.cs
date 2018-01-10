namespace DevsDNA
{
    using System;

    /// <summary>
    /// When the app was built.
    /// </summary>
    public class WhenTheAppWasBuilt : WhenTheAppWasBuiltCore
    {
        /// <summary>
        /// Tells me when the app was built on a shake gesture. In most of the cases 
        /// <paramref name="projectTypeToGatherBuildDate"/> is your own 
        /// <see cref="Xamarin.Forms.Application"/> class.
        /// </summary>
        /// <param name="projectTypeToGatherBuildDate">Project type to gather build date.</param>
        public static void TellMeWhenShaking(Type projectTypeToGatherBuildDate)
        {
            var version = projectTypeToGatherBuildDate.Assembly.GetName().Version;
            GatherDateTimeFrom(version);

            Init();
        }
    }
}
