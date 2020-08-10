using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float delayLoadTime = 2f;

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
