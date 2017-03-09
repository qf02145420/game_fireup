using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Image_Untouch : Image {
    
    override public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        return false;
    }

}
