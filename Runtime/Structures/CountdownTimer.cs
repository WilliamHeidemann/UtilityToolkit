using System;

namespace UtilityToolkit.Structures
{
    public class CountdownTimer
    {
        public event Action OnTimerEnded;

        public float SecondsToFinish { get; private set; }
        public float SecondsPassed { get; private set; }
        public float SecondsLeft => Math.Max(0f, SecondsToFinish - SecondsPassed);
        public float FractionDone => SecondsToFinish > 0f ? Math.Clamp(SecondsPassed / SecondsToFinish, 0f, 1f) : 1f;

        public bool IsFinished => SecondsPassed >= SecondsToFinish;
        public bool IsPaused { get; private set; }

        private bool _hasEnded;

        public CountdownTimer(float secondsToFinish)
        {
            SecondsToFinish = secondsToFinish;
        }

        /// <summary>
        /// Advances the timer forward by deltaTime seconds.
        /// Call this from your update loop (e.g., Tick(Time.deltaTime)).
        /// </summary>
        public void Tick(float deltaTime)
        {
            if (IsPaused || _hasEnded) return;

            SecondsPassed += deltaTime;

            if (IsFinished)
            {
                _hasEnded = true;
                OnTimerEnded?.Invoke();
            }
        }

        public void Pause() => IsPaused = true;

        public void Resume() => IsPaused = false;

        public void Reset()
        {
            SecondsPassed = 0f;
            _hasEnded = false;
            IsPaused = false;
        }

        public void Reset(float newSecondsToFinish)
        {
            SecondsToFinish = newSecondsToFinish;
            Reset();
        }

        /// <summary>
        /// Adds or subtracts time needed to finish. 
        /// Positive values push completion further away; negative values speed it up.
        /// </summary>
        public void AddTime(float secondsToAdd)
        {
            SecondsToFinish += secondsToAdd;
        }
    }
}