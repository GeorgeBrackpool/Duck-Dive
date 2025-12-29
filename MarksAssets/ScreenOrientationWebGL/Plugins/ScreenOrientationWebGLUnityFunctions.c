#include <stdint.h>
#include "emscripten.h"

void (*ScreenOrientationWebGL_onOrientationChange_ref)(int orientation);

void ScreenOrientationWebGL_setUnityFunctions(void (*_onOrient)(int orientation)) {
  ScreenOrientationWebGL_onOrientationChange_ref = _onOrient;
}

void EMSCRIPTEN_KEEPALIVE ScreenOrientationWebGL_onOrientationChange(int orientation) {
  ScreenOrientationWebGL_onOrientationChange_ref(orientation);
}