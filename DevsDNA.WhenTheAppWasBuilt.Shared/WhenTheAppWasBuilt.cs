namespace DevsDNA
{
    using System;

    /// <summary>
    /// When the app was built.
    /// </summary>
    public class WhenTheAppWasBuilt : WhenTheAppWasBuiltCore
    {
        /// <summary>
        /// Tells me when the app was built on a shake gesture.
        /// </summary>
        /// <param name="projectTypeToGatherBuildDate">Project type to gather build date. In most of the cases this' 
        /// your own Xamarin.Forms.Application class.</param>
        public static void TellMeWhenShaking(Type projectTypeToGatherBuildDate)
        {
            var version = projectTypeToGatherBuildDate.Assembly.GetName().Version;
            GatherDateTimeFrom(version);

            Init();
        }
    }
}
