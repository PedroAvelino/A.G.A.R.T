using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuNavigation : MonoBehaviour {

    public Button btn_1;
    public Button btn_2;
    

	void Start () {

        btn_1 = GetComponent<Button>();
        btn_2 = GetComponent<Button>();

        btn_1.onClick.AddListener(PlayOnClick);
        btn_2.onClick.AddListener(LeaveOnClick);

	}
	
    public void PlayOnClick()
    {
        SceneManager.LoadScene(1);
    }

    public void LeaveOnClick()
    {
        Application.Quit();
    }
}
