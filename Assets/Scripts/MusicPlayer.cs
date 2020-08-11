﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    private void Awake()
    {
        int numOfMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if(numOfMusicPlayers <= 1)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
