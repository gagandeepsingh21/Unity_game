using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
     public Light mylight;
    //start is called before the first frame update;
    public float duration = 1.0F;
    // Start is called before the first frame update
    //Create an audio source object
    public AudioSource alarm;
    //create an audio source object for the soft music
    public AudioSource softmusic;
    //create an audio source object for the loud music
    public AudioSource loudmusic;
    //We define the fade time
    public float FadeTime = 5.0F;
    //Create a particle emission object
    public ParticleSystem ps;
    void Start()
    {
        //We declare an emission variable: used for playing or stoping the
        //particle emission effect
        var em = ps.emission;
        em.enabled = false;

        loudmusic.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered the Danger Zone!");
        //we play the alarm
        alarm.Play();
        //stop soft music
        softmusic.volume = Mathf.Lerp(0, softmusic.volume, FadeTime);
        softmusic.volume -= softmusic.volume;
        //play the loud music
        loudmusic.Play();
        //emit the particles
        var em = ps.emission;
        em.enabled = true;


    }
    void OnTriggerStay(Collider other)
    {
        Debug.Log("Within the Danger Zone!");
        //dimming the light when within the danger zone
        mylight.intensity = Mathf.PingPong(Time.time, 1);
        //defining the time during which the color will change
        float t = Mathf.PingPong(Time.time, duration) / duration;
        //color change
        mylight.color = Color.Lerp(Color.blue,Color.gray, t);
        //emit the particles
        var em = ps.emission;
        em.enabled = true;

    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited the Danger zone");
        mylight.intensity = 1;
        mylight.color = Color.white;
        //loudmusic.volume = Mathf.Lerp(0, loudmusic.volume, FadeTime);

        //We stop the alarm
        alarm.Stop();
        //we stop the smoke
        var em = ps.emission;
        em.enabled = false;
    }
}
