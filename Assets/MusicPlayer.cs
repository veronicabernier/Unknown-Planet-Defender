using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] float delayLoadTime = 2f;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //wait and load next scene
        Invoke("loadGame", delayLoadTime);
    }

    private void loadGame()
    {
        SceneManager.LoadScene(1);
    }
}
