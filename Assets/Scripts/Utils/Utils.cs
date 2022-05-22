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
        private float min;
        [SerializeField]
        private float max;
        public float current { get { return _current; } private set {} }
        
        [SerializeField]
        private float _current;

        public event Action MinReachedEvent;
        public event Action MaxReachedEvent;

        public RangedValue(float minVal, float maxVal, float currentVal)
        {
            min = minVal;
            max = maxVal;
            current = currentVal;
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

            current = newValue;
            _current = current;
        }

        public float IncrementValue(float incrementBy)
        {
            float newValue = current + incrementBy;
            SetValue(newValue);
            return current;
        }
    }
}
