using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilsClasses
{
    public interface IClassWithEvents
    {
        void ClearEventHandlers();
    }

    [Serializable]
    public class RangedValue : IClassWithEvents
    {
        [SerializeField]
        public float min { get; private set; }
        [SerializeField]
        private float max;
        public float current { get { return _current; } private set {} }
        
        [SerializeField]
        private float _current; // so that the current value can be set from inspector, but not from any other script.

        public event Action MinReachedEvent;
        public event Action MaxReachedEvent;

        public RangedValue(float minVal, float maxVal, float currentVal)
        {
            min = minVal;
            max = maxVal;
            _current = currentVal;
        }

        public void ClearEventHandlers()
        {
            MinReachedEvent = null;
            MaxReachedEvent = null;
        }
        
        public void SetValue(float newValue)
        {
            if(newValue <= min)
            {
                newValue = min;
                MinReachedEvent?.Invoke();
            }
            else if(newValue >= max)
            {
                newValue = max;
                MaxReachedEvent?.Invoke();
            }

            _current = newValue;
        }

        public float IncrementValue(float incrementBy)
        {
            float newValue = current + incrementBy;
            SetValue(newValue);
            return current;
        }
    }

    [Serializable]
    public class SteppedRange
    {
        [SerializeField]
        public List<float> stepRangeValues { get; private set; }

        public SteppedRange(List<float> values)
        {
            stepRangeValues = values;
        }

        public bool WithinRange(float checkValue)
        {
            return (checkValue >= stepRangeValues[0]) && (checkValue <= stepRangeValues[stepRangeValues.Count - 1]);
        }

        public bool WithinRange(double checkValue)
        {
            return WithinRange((float)checkValue);
        }

        public float GetSteppedValue(float convertValue)
        {
            float steppedValue;
            int stepIndex = 0;
            while(
                stepRangeValues[stepIndex] < convertValue && 
                stepIndex < stepRangeValues.Count
            )
            {
                stepIndex++;
            }

            stepIndex = Mathf.Clamp(stepIndex - 1, 0, stepRangeValues.Count - 1);
            steppedValue = stepRangeValues[stepIndex];

            return steppedValue;
        }

        public float GetSteppedValue(double convertValue)
        {
            return GetSteppedValue((float)convertValue);
        }
    }
}
