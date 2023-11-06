using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEvents : MonoBehaviour
{
    private Animator anim;
    private float eventTime;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void OnHitEvent()
    {
        anim.SetTrigger("Event_Hit");
        StartCoroutine(EventTimer(eventTime));
    }

    void SpitEvent()
    {
        anim.SetBool("IsSpatAt", true);
        StartCoroutine(EventTimer(eventTime));

    }

    private IEnumerator EventTimer(float time)
    {
        yield return new WaitForSeconds(time);
        anim.SetTrigger("Reset");

    }

    private IEnumerator SpitTimer(float time)
    {
        yield return new WaitForSeconds(time);
        anim.SetBool("IsSpatAt", false);
    }
}
