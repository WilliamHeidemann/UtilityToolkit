using System;
using UnityEngine;

namespace UtilityToolkit.Runtime
{
    public class CountdownTimer
    {
        public event Action OnTimerEnded;
        private float CurrentTime => IsPaused ? _timeAtPause : Time.time;
        public bool IsFinished => TimeOfCompletion < CurrentTime;
        public float FractionDone => SecondsPassed / _secondsToFinish;
        public float SecondsPassed => CurrentTime - _timeOfCreation;
        public float SecondsLeft => Mathf.Max(0, TimeOfCompletion - CurrentTime);
        public float TimeOfCompletion => _timeOfCreation + _secondsToFinish;
        public bool IsPaused { get; private set; }

        private float _secondsToFinish;
        private float _timeOfCreation = Time.time;
        private float _timeAtPause;
        private bool _hasEnded;

        public void Reset()
        {
            _timeOfCreation = Time.time;
            _hasEnded = false;
            IsPaused = false;
        }

        public void AddTime(float secondsToAdd) => _timeOfCreation += secondsToAdd;

        public void Pause()
        {
            if (IsPaused) return;
            _timeAtPause = Time.time;
            IsPaused = true;
        }
        
        public void Resume()
        {
            if (!IsPaused) return;
            _secondsToFinish += Time.time - _timeAtPause;
            IsPaused = false;
        }

        public void Tick()
        {
            if (!_hasEnded && IsFinished)
            {
                _hasEnded = true;
                OnTimerEnded?.Invoke();
            }
        }

        public CountdownTimer(float secondsToFinish)
        {
            _secondsToFinish = secondsToFinish;
        }
    }
}