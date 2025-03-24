using UnityEngine;
using UnityEngine.Events;

public class LeverActives : MonoBehaviour
{
    private Animator anim;
    public bool active;
    public UnityEvent onLeverPulled;

    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("On") && !active) 
        {
            active = true;
            onLeverPulled?.Invoke();
        }
        else if (!anim.GetBool("On") && active)
        {
            active = false;
        }
    }

    private void PlayLeverSFX()
    {
        Debug.Log("Lever");
        AkSoundEngine.PostEvent("Play_Lever", gameObject);
    }
       
}

