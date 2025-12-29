using MarksAssets.ScreenOrientationWebGL;
using UnityEngine;
using UnityEngine.UI;
using ScreenOrientation = MarksAssets.ScreenOrientationWebGL.ScreenOrientationWebGL.ScreenOrientation;

public class example : MonoBehaviour {
    public Text text;

	public void setText(int orient) {
		ScreenOrientation orientation = (ScreenOrientation)orient;
		
		//the 'if' is obviously unnecessary. I'm just testing if the comparisons are working as expected. It's an example after all, might as well be thorough.
		if (orientation == ScreenOrientation.Portrait || orientation == ScreenOrientation.PortraitUpsideDown || orientation == ScreenOrientation.LandscapeLeft || orientation == ScreenOrientation.LandscapeRight)
			text.text = orientation.ToString();
	}
}
