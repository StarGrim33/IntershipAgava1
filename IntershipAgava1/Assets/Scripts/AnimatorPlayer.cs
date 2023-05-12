using UnityEngine;
using UnityEngine.Events;

public class AnimatorPlayer : MonoBehaviour
{
    public event UnityAction OnKickedAnimationFinished;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _animator.SetBool(Params.IsAiming, true);
            _animator.Play("DropKick", 0, 0f);

        }
        else if (Input.GetMouseButtonUp(0))
        {
            _animator.SetBool(Params.IsAiming, false);
        }
    }

    public void AnimationEvent()
    {
        OnKickedAnimationFinished.Invoke();
    }

    public static class Params
    {
        public const string IsAiming = ("isAiming");
    }

    public static class States
    {
        public const string Idle = nameof(Idle);
        public const string DropKick = nameof(DropKick);
    }
}
