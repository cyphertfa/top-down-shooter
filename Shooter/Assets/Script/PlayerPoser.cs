using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoser : MonoBehaviour {
    public SkeletonAnimation SkeletonToPose;

    Aim aim;
    Weapon weapon;

    // Use this for initialization
    void Start () {
        aim = GetComponent<Aim>();
        weapon = GetComponent<Weapon>();
    }
	
	// Update is called once per frame
	void Update () {
        //Set aim bone to mouse angle.
        //skelAnimation.Skeleton.FindBone("aimBone").rotation = aim.AimAngle;
        
        SkeletonToPose.Skeleton.SetToSetupPose();
        //Spine.TrackEntry animation = SkeletonToPose.state.SetAnimation(0, "Aim360", true);
        float animTime = ((aim.AimDegrees + 180) / 360f) * 2;
        //animation.TrackTime = animTime;
        //animation.timeScale = 0;

        SkeletonToPose.Skeleton.Data.FindAnimation("Aim360").Apply(SkeletonToPose.Skeleton, animTime, animTime, false, new Spine.ExposedList<Spine.Event>(), 1, Spine.MixPose.Setup, Spine.MixDirection.In);

        SkeletonToPose.Skeleton.Update(Time.deltaTime);
        SkeletonToPose.Skeleton.UpdateWorldTransform();


        Debug.Log(animTime);

        Color aimDirColor;
        if(weapon.CanFire)
        {
            aimDirColor = new Color(1, 1, 1, 1);
        }
        else
        {
            aimDirColor = new Color(1, 0, 0, 1);
        }

        //Set the color of the direction indicator (the arrow)
        SkeletonToPose.Skeleton.FindSlot("aimDir").SetColor(aimDirColor);
    }
}
