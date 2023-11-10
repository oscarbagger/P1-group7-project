using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEvents : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float eventTime;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayEvent()
    {
        OnHitEvent();
    }

    public void OnHitEvent()
    {
        Debug.Log("Hit");
        anim.SetTrigger("Event_Hit");
        StartCoroutine(EventTimer(eventTime));
    }

    public void SpitEvent()
    {
        Debug.Log("Spit");
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
