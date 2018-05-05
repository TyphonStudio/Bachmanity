using UnityEngine;

public class Effect : MonoBehaviour {

    [SerializeField]
    SpriteRenderer sr;

    Animator myAnimator;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void PlayEffectAndDestroy()
    {
        if(sr)
            sr.enabled = false;
        myAnimator.SetTrigger("playEffect");
        //Destroy(gameObject, myAnimator.GetCurrentAnimatorStateInfo(0).length);
    }

    public void DestroyEffect()
    {
        Destroy(gameObject);
    }
}
