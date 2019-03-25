using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candyController : MonoBehaviour {

    public candyData data;

    internal int value;

    private void Awake()
    {
        value = data.value;
    }

    private void Start()
    {
        Destroy(gameObject, 15f);
    }
}
