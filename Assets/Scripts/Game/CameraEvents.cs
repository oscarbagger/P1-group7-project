using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEvents : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject spit;
    [SerializeField] private float eventTime;
    [SerializeField] AudioClip SpitSFX;
    AudioManager audiomanager; 

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        audiomanager = FindObjectOfType<AudioManager>();
    }
    // pick a random event to play
    public void PlayEvent()
    {
        int randomInt = Random.Range(0, 2);
        switch(randomInt)
        {
            case 0:
                {
                    OnHitEvent();
                    break;
                }
            case 1: {
                    SpitEvent();
                    break;
                }

        }
    }

    public void OnHitEvent()
    {
        anim.SetTrigger("Event_Hit"); // start animation for hit event
        StartCoroutine(EventTimer(eventTime)); // set a timer for how long the event lasts
    }

    public void SpitEvent()
    {
        audiomanager.PlaySFX(SpitSFX);
        /*if (audiomanager.GetComponent<AudioSource>().name == "SFXSource" && !audiomanager.GetComponent<AudioSource>().isPlaying)
        {

        }*/
        spit.GetComponent<Animator>().SetBool("IsSpatAt", true);
        StartCoroutine(SpitTimer(eventTime));

    }

    private IEnumerator EventTimer(float time) // wait x seconds before resetting the event animation, ending the event
    {
        yield return new WaitForSeconds(time);
        anim.SetTrigger("Reset");

    }

    private IEnumerator SpitTimer(float time)
    {
        yield return new WaitForSeconds(time);
        spit.GetComponent<Animator>().SetBool("IsSpatAt", false);
    }
}
