using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : SingletonBehaviour<PlayerManager>
{
    public bool Hidden;
    public Animator PlayerAnimator;
    public Rigidbody2D RB;
    public AudioSource Source;

    public UnityEvent OnHide;
    public UnityEvent OnOut;
    public UnityEvent OnCaught;

    public void Hide()
    {
        if (!Hidden)
        {
            Hidden = true;
            PlayerAnimator.SetBool("Hidden", true);
            RB.velocity = Vector2.zero;
            PlayerAnimator.SetBool("Walking", false);
            PlayerAnimator.SetBool("Grounded", true);
            OnHide.Invoke();
        }
        else
            Out();
    }

    public void Out()
    {
        PlayerAnimator.SetBool("Hidden", false);
        Hidden = false;
        OnOut.Invoke();
    }

    public void Caught()
    {
        OnCaught.Invoke();
        Debug.Log("CAUGHT! - Game Over");
    }

    public void PlayStepSound(AudioClip clip)
    {
        Source.PlayOneShot(clip);
    }
}