﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReLoad : MonoBehaviour {
    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha0))
        {
            SceneManager.LoadScene(1);
        }
    }
}
