using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BossDeathSound : MonoBehaviour
{

    private AudioSource source;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = this.clip;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
