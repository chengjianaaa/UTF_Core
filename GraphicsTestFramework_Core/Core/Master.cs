﻿using System;
using UnityEngine;

namespace GraphicsTestFramework
{
    // ------------------------------------------------------------------------------------
    // Master
    // - System data structures and returns
    // - Maintains persistence of other logic objects

    public class Master : MonoBehaviour
    {
        // ------------------------------------------------------------------------------------
        // Variables

        // Singleton
        private static Master _Instance = null;
        public static Master Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = (Master)FindObjectOfType(typeof(Master));
                return _Instance;
            }
        }

        // ------------------------------------------------------------------------------------
        // Setup

        // On Awake
        private void Awake()
        {
            DontDestroyOnLoad(gameObject); // Set this object to DontDestroy
        }

        // ------------------------------------------------------------------------------------
        // Get System Data

        // Get SystemData to use for building ResultsCommon
        public SystemData GetSystemData()
		{
            Console.Instance.Write(DebugLevel.Full, MessageLevel.Log, "Getting system data"); // Write to console
            SystemData output = new SystemData(); // Create new class instance
            Settings settings = SuiteManager.GetSettings(); // Get settings
			output.UnityVersion = settings.unityVersion+"|"+settings.unityBranch; // Get Unity version
			output.AppVersion = Common.applicationVersion.ToString(); // Get application version
            output.OS = SystemInfo.operatingSystem; // Get OS
            output.Device = SystemInfo.deviceModel + "|" + SystemInfo.graphicsDeviceName + "|" + SystemInfo.processorType;
			output.Platform = Application.platform.ToString(); // Get platform
			output.API = SystemInfo.graphicsDeviceType.ToString(); // Get graphics device type
			return output; // Return
		}

        // Get the current system time
		public DateTime GetSystemTime()
        {
            Console.Instance.Write(DebugLevel.Full, MessageLevel.Log, "Getting system time"); // Write to console
            return DateTime.UtcNow; // Return current DateTime
		}

        // ------------------------------------------------------------------------------------
        // Application

        // Exit the application
        public void ExitApplication()
        {
            Application.Quit(); // Quit
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // If editor stop play mode
#endif
        }

    }

    // ------------------------------------------------------------------------------------
    // Global Data Structures

    // System data class
    [System.Serializable]
	public class SystemData
	{
		public string UnityVersion;
		public string AppVersion;
        public string OS;
        public string Device;
		public string Platform;
		public string API;
	}
}
