using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuNavigation : MonoBehaviour {

     

    public void PlayOnClick()
    {
        TrasitionController.instance.FadeOutToLevel();
    }

    public void LeaveOnClick()
    {
        Application.Quit();
    }

    
}
