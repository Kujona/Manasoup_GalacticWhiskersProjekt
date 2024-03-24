using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneSetup : MonoBehaviour
{
    private GameObject StorySequenz;
    public int startsequenz;
    public int endsequenz;

    private void Awake()
    {
        StorySequenz = GameObject.FindWithTag("StorySequenz");
        StorySequenz.GetComponent<Animator>().SetInteger("cutscene", startsequenz);
    }

    public void EndLevelCutscene()
    {
        StorySequenz.GetComponent<Animator>().SetInteger("cutscene", endsequenz);
    }

}
