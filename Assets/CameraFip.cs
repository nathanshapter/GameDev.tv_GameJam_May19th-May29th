using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFip : MonoBehaviour
{
  [SerializeField]  CinemachineVirtualCamera cam;
  public bool flipped180 = false;

    private void Start()
    {
        if (flipped180)
        {
            cam.transform.Rotate(0, 0, 180);
        }
    }
}
