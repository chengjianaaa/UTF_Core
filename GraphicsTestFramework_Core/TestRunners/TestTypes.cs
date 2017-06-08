﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace GraphicsTestFramework
{
    // ------------------------------------------------------------------------------------
    // TestTypes
    // - Master dictionary of all test types
    // - Used to get a test type

    public static class TestTypes
    {
        static Dictionary< int, Type> m_TypeList = new Dictionary<int, Type>
        {
            //{#, typeof(ExampleModel) }, // We dont include ExampleModel here as it is only for reference
            {0, typeof(AverageFrameTimeModel) },
            {1, typeof(FrameComparisonModel) },
        };

        public static Dictionary<int, Type> typeList { get { return m_TypeList; } }

        // ------------------------------------------------------------------------------------
        // Get Data

        // Get a type from its index
        public static Type GetTypeFromIndex(int index)
        {
            return m_TypeList[index]; // Return requested type
        }

        // Get an array of test types names
        public static string[] GetTypeStringList()
        {
            string[] output = new string[m_TypeList.Count];
            for (int i = 0; i < m_TypeList.Count; i++)
                output[i] = m_TypeList[i].ToString().Replace("GraphicsTestFramework.", "").Replace("Model", "");
            return output; // Return
        }

        // Get a logic type from list index
        public static object GetModelInstance(int index)
        {
            var T = GetTypeFromIndex(index);
            return Activator.CreateInstance(T);
        }
    }

}
