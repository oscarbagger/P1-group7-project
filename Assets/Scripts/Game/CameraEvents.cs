using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEvents : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject spit;
    [SerializeField] private float eventTime;
    [SerializeField] AudioClip SpitSFX;
    [SerializeField] private Animator portraitAnim;
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
        int randomInt = Random.Range(0, 3);
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
            case 2:
                {
                    BeatDownEvent();
                    break;
                }
        }
    }

    public void OnHitEvent()
    {
        anim.SetTrigger("Event_Hit"); // start animation for hit event
        StartCoroutine(EventTimer(eventTime)); // set a timer for how long the event lasts
    }

    public void SpitEvent() //Spit event begin and is set true
    {
        audiomanager.PlaySFX(SpitSFX);
        spit.GetComponent<Animator>().SetBool("IsSpatAt", true);
        StartCoroutine(SpitTimer(eventTime));
    }
    public void BeatDownEvent() //Beatdown event is set true
    {
        portraitAnim.SetTrigger("beatDown");
    }

    private IEnumerator EventTimer(float time) // wait x seconds before resetting the event animation, ending the event
    {
        yield return new WaitForSeconds(time);
        anim.SetTrigger("Reset");

    }

    private IEnumerator SpitTimer(float time) // spit event is set false, so it can be set true again
    {
        yield return new WaitForSeconds(time);
        spit.GetComponent<Animator>().SetBool("IsSpatAt", false);
    }
}
