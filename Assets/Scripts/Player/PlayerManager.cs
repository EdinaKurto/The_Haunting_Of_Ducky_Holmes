using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : SingletonBehaviour<PlayerManager>
{
    public bool Hidden;
    public Animator PlayerAnimator;
    public Rigidbody2D RB;

    public UnityEvent OnHide;
    public UnityEvent OnOut;

    [HideInInspector] public bool wasHidden = false;

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
}