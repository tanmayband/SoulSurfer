using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Constants
{
    public enum LAYER
    {
        Ghost = 7,
        Character = 8
    }

    public class ConstantsUtils
    {
        public static bool CheckLayer(int checkLayer, LAYER targetLayer)
        {
            return checkLayer == (int)targetLayer;
        }
    }
}
