using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Spine.Unity;

public class RicktusAnimations : MonoBehaviour
{
    [SerializeField]
    public SkeletonAnimation ricktusSkeleton;
    public AnimationReferenceAsset idle;
    public AnimationReferenceAsset running;
    public AnimationReferenceAsset attacking;
    public AnimationReferenceAsset BackWalking;

    public string currentState;
    public string currentAnimation;

    void Start()
    {
        currentState = "Idle";
        SetCharacterState(currentState);
    }
    private void Update()
    {
        
    }


    public void SetAnimations (AnimationReferenceAsset animation, bool loop, float timeScale)
    {
        if(animation.name.Equals(currentAnimation))
        {
            return;
        }
        ricktusSkeleton.state.SetAnimation(0,animation,loop).TimeScale = timeScale;
        currentAnimation = animation.name;
        currentState= animation.name;
    }

    public void SetCharacterState(string state)
    {
        if (state.Equals("Idle"))
        {
            SetAnimations(idle, true, 1f);

        }
        else if(state.Equals("Runing"))
        {
            SetAnimations(running, true, 1f);
        }
        else if (state.Equals("Attacking"))
        {
            SetAnimations(attacking, true, 1f);
        }
    }
}
