using System;
using UnityEngine;

namespace UtilityToolkit.Runtime
{
    public class CountdownTimer
    {

        public bool IsFinished => TimeOfCompletion < Time.time;
        public float FractionDone => SecondsPassed / _secondsToFinish;
        public float SecondsPassed => Time.time - _timeOfCreation;
        public float SecondsLeft => TimeOfCompletion - Time.time;
        public float TimeOfCompletion => _timeOfCreation + _secondsToFinish;

        private readonly float _secondsToFinish;
        private float _timeOfCreation = Time.time;

        public void Reset() => _timeOfCreation = Time.time;
        public void AddTime(float secondsToAdd) => _timeOfCreation += secondsToAdd;

        public CountdownTimer(float secondsToFinish)
        {
            _secondsToFinish = secondsToFinish;
        }
    }
}