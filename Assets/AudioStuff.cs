using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioStuff : MonoBehaviour {
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;
    public AudioClip clip5;
    public AudioClip clip6;
    int activeClip = 1;
    List<AudioClip> clips = new List<AudioClip>();
    AudioSource audio;

    // Use this for initialization
    void Start () {
        clips.Add(clip1);
        clips.Add(clip2);
        clips.Add(clip3);
        clips.Add(clip4);
        clips.Add(clip5);
        clips.Add(clip6);
        audio = GetComponent<AudioSource>();
        audio.clip = clip1;
        audio.Play();

    }

    // Update is called once per frame
    void Update () {
	    if(!audio.isPlaying)
        {
            audio.clip = clips[activeClip];
            audio.Play();

            activeClip++;
            if (activeClip >= clips.Count)
                activeClip = 1;
        }
    }
}
