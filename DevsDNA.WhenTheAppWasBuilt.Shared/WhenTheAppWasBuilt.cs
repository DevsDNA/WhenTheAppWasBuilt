using System;

namespace DevsDNA
{
    public class WhenTheAppWasBuilt : WhenTheAppWasBuiltCore
    {
        public static void TellMeWhenShaking(Type projectTypeToGatherBuildDate)
        {
            var version = projectTypeToGatherBuildDate.Assembly.GetName().Version;
            GatherDateTimeFrom(version);

            Init();
        }
    }
}
