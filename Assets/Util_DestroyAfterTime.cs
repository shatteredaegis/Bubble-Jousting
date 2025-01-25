using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util_DestroyAfterTime : MonoBehaviour
{
    private void Start()
    {
        Destroy(this, 2);
    }
}
