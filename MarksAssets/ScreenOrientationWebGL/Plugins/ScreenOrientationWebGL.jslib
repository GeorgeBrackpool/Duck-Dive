mergeInto(LibraryManager.library, {
	ScreenOrientationWebGL_Start: function(orient) {		
		if (Module['ScreenOrientationWebGL'].updateOrient)
			return;
			
		Module['ScreenOrientationWebGL'].orient = orient;
		Module['ScreenOrientationWebGL'].orientBuf = Module['ScreenOrientationWebGL'].orientBuf || new Int32Array(HEAP8.buffer, orient, 1);
		Module['ScreenOrientationWebGL'].updateOrient = Module['ScreenOrientationWebGL'].updateOrient || function () {
			if (Module['ScreenOrientationWebGL'].orientBuf.byteLength === 0)//buffer changed size, need to get new reference
				Module['ScreenOrientationWebGL'].orientBuf = new Int32Array(HEAP8.buffer, Module['ScreenOrientationWebGL'].orient, 1);
			//var ori = (screen.orientation || {}).type || screen.mozOrientation || screen.msOrientation;
			//if (!ori)//safari. Commented this out because since iOS 16.4, screen.orientation is supported but works differently than other browsers. window.orientation works universally.
				var ori = window.orientation === 0 ? "portrait-primary" : window.orientation === 180 ? "portrait-secondary" : window.orientation === 90 ? "landscape-primary" : "landscape-secondary";
			Module['ScreenOrientationWebGL'].orientBuf[0] = ori === "portrait-primary" ? 0 : ori === "portrait-secondary" ? 1 : ori === "landscape-primary" ? 2 : 3;
			Module['ScreenOrientationWebGL'].onOrientationChange(Module['ScreenOrientationWebGL'].orientBuf[0]);
		}
		Module['ScreenOrientationWebGL'].updateOrient();
		window.addEventListener("orientationchange", Module['ScreenOrientationWebGL'].updateOrient);
	},
	ScreenOrientationWebGL_Stop: function() {
		if (Module['ScreenOrientationWebGL'].updateOrient) {
			window.removeEventListener("orientationchange", Module['ScreenOrientationWebGL'].updateOrient);
			Module['ScreenOrientationWebGL'].updateOrient = undefined;
		}
	}
});