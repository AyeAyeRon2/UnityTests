using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    public PlayableDirector cutscene;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            cutscene.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        cutscene.Play();
    }
}
