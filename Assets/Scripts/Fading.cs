using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fading : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Fade(1);
        }
    }

    public void Fade(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadingShader");
    }

    public void FadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
