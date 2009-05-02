using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoGrid
{
    public class JobState : ValueModifier
    {
        public JobState(string value) : base("job.state", value)
        {
        }

        public static JobState Any
        {
            get { return new JobState(string.Empty); }
        }

        public static JobState Queued
        {
            get { return new JobState("Queued"); }
        }

        public static JobState Processing
        {
            get { return new JobState("Processing"); }
        }

        public static JobState Succeeded
        {
            get { return new JobState("Succeeded"); }
        }

        public static JobState Failed
        {
            get { return new JobState("Failed"); }
        }

        public static JobState Canceled
        {
            get { return new JobState("Canceled"); }
        }

        public static JobState Fatal
        {
            get { return new JobState("Fatal"); }
        }

        public static JobState Created
        {
            get { return new JobState("Created"); }
        }
    }
}
