using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraManager
{
    static Camera myCamera = Camera.main;

    public static MyBounds GetCameraBounds()
    {
        float myCameraHeight = 2f * myCamera.orthographicSize;
        float myCameraWidth = myCameraHeight * myCamera.aspect;

        float minX = myCamera.transform.position.x - myCameraWidth / 2f;
        float maxX = myCamera.transform.position.x + myCameraWidth / 2f;
        float minY = myCamera.transform.position.y - myCameraHeight / 2f;
        float maxY = myCamera.transform.position.y + myCameraHeight / 2f;

        MyBounds cameraBounds = new MyBounds(minX, maxX, minY, maxY);
        return cameraBounds;
    }
}
