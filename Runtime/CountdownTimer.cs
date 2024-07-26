using UnityEngine;

namespace UtilityToolkit.Runtime
{
    public class CountdownTimer
    {
        public bool IsFinished => timeOfCreation + timeToFinish < Time.time;
        public float FractionDone => (Time.time - timeOfCreation) / timeToFinish;
        private readonly float timeToFinish;
        private readonly float timeOfCreation = Time.time;

        public CountdownTimer(float timeToFinish)
        {
            this.timeToFinish = timeToFinish;
        }
    }
}