using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreTable : MonoBehaviour
{
    // This is just a script that calls a high score table game object when H is pressed.
    public GameObject highscoretable;
    private bool reverse = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            reverse = !reverse;
            highscoretable.SetActive(reverse);
        }

    }
}