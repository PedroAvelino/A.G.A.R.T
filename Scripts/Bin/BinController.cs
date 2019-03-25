using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinController : MonoBehaviour {

    #region Singleton
    public static BinController instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }
    #endregion


    public void DeactivateColliders()
    {
        foreach (Collider2D c in GetComponents<Collider2D>())
        {
            c.enabled = false;
            Destroy(this, 7f);
     }
    }
}
