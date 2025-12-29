Module['ScreenOrientationWebGL'] = Module['ScreenOrientationWebGL'] || {};

Module['ScreenOrientationWebGL'].onOrientationChange = function(orientation) {
	this.onOrientationChangeInternal = this.onOrientationChangeInternal || Module.cwrap("ScreenOrientationWebGL_onOrientationChange", null, ["number"]);
	this.onOrientationChangeInternal(orientation);
};