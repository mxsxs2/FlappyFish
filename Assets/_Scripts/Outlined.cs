﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outlined : MonoBehaviour {

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 0.25f);
    }
}
