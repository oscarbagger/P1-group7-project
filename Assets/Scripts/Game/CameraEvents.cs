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
        anim.SetTrigger("Event_Hit");
        StartCoroutine(EventTimer(eventTime));
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

    private IEnumerator EventTimer(float time)
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
