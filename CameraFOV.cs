using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFOV : MonoBehaviour
{
   [RequireComponent(typeof(Camera))]
    public class CameraFovSwitcher : MonoBehaviour {
    Camera cam;
    Camera Cam { get { if (!cam) cam = GetComponent<Camera>(); return cam; } }
 
    [Range(0.1f, 2)]
    [Tooltip("Aspect treshold for switching to horizontal fov calculation")]
    public float HFovOnAspect = 1.777f;
   
    float vFov;
    float vFovNew;
 
    private void Awake() {
        vFov = Cam.fieldOfView;
    }
 
    void Update() {
        if (Cam.aspect < HFovOnAspect) {
            vFovNew = Camera.HorizontalToVerticalFieldOfView(Camera.VerticalToHorizontalFieldOfView(vFov, HFovOnAspect), Cam.aspect);
            if (Cam.fieldOfView != vFovNew) {
                Cam.fieldOfView = vFovNew;
            }
        } else if (Cam.fieldOfView != vFov) {
            Cam.fieldOfView = vFov;
        }
        }
    }
}
