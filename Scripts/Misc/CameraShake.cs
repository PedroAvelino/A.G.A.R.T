using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    #region Singleton
    public static CameraShake instance { get; private set; }
    #endregion


    public Camera mainCam;

    float shakeAmount = 0.1f;
    float lenght = 1.5f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }

        if (mainCam == null)
            mainCam = Camera.main;
        
    }

    public void Shake()
    {
        InvokeRepeating("BeginShake", 0f, 0.01f);
        Invoke("StopShake", lenght);
    }

    void BeginShake()
    {
        if (shakeAmount > 0)
        {
            Vector3 camPos = mainCam.transform.position;

            float offSetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offSetY = Random.value * shakeAmount * 2 - shakeAmount;
            camPos.x += offSetX;
            camPos.y += offSetY;


            mainCam.transform.position = camPos;
        }
    }

    
    void StopShake()
    {
        CancelInvoke("BeginShake");
        mainCam.transform.localPosition = Vector3.zero;
    }
}
