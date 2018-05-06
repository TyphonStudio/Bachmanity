using UnityEngine;

public class Effect : MonoBehaviour {

    Animator myAnimator;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void PlayEffectAndDestroy()
    {
        myAnimator.SetTrigger("playEffect");
        // playEffect animation has an event that calls DestroyEffect when animation is over
    }

    public void DestroyEffect()
    {
        Destroy(gameObject);
    }
}
