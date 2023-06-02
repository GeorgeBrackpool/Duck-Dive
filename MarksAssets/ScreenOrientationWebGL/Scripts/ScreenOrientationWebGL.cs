using AOT;
using System;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.Events;

namespace MarksAssets.ScreenOrientationWebGL {
	public class ScreenOrientationWebGL : MonoBehaviour {
		#if UNITY_WEBGL && !UNITY_EDITOR
		[DllImport("__Internal", EntryPoint="ScreenOrientationWebGL_Start")]
		
		public static extern void Play(ref ScreenOrientation orientation);
		#else
		public static void Play(ref ScreenOrientation orientation) {return;}
		#endif
		#if UNITY_WEBGL && !UNITY_EDITOR
		[DllImport("__Internal", EntryPoint="ScreenOrientationWebGL_Stop")]
		public static extern void Stop();
		#else
		public static void Stop() { return; }
		#endif
		#if UNITY_WEBGL && !UNITY_EDITOR
		[DllImport("__Internal", EntryPoint="ScreenOrientationWebGL_setUnityFunctions")]
		private static extern void setUnityFunctions(Action<int> _onOrientationChange);
		#else
		private static void setUnityFunctions(Action<int> _onOrientationChange) { return; }
		#endif
		[Serializable]
		public class UnityEventInt : UnityEvent<int> { }

		private static UnityEventInt onOrientationChangeCallbackStatic;
		
		public enum ScreenOrientation { Portrait, PortraitUpsideDown, LandscapeLeft, LandscapeRight };
		[Tooltip("If true it starts listening to orientation changes on game start. If false you will need to activate the plug-in manually.")]
		public bool autoStart = true;
		public static ScreenOrientation orientation;
		public UnityEventInt onOrientationChangeCallback;
		
		void Awake() {
			onOrientationChangeCallbackStatic = onOrientationChangeCallback;
			setUnityFunctions(_onOrientationChangeCallback);
		}
		
		void Start() {
			if (autoStart)
				Play(ref orientation);//don't call this on Awake, because the javascript buffer is resized between the Awake and Start, causing an unnecessary new assignment.
		}
		
		[MonoPInvokeCallback(typeof(Action<int>))]
		private static void _onOrientationChangeCallback(int orientation) {
			//invoke user's method, so the user doesn't need to touch this file.
			if (onOrientationChangeCallbackStatic != null) {
				onOrientationChangeCallbackStatic.Invoke(orientation);
			}
		}
	}
}