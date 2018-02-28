using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    private void OnEnable()
    {
        Destroy(gameObject, 16f);
    }
}
