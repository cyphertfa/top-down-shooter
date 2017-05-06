using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoser : MonoBehaviour {
    SkeletonAnimation skelAnimation;
    // Use this for initialization
    void Start () {
        skelAnimation = GetComponent<SkeletonAnimation>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePosition = Input.mousePosition;
        //make 0,0 screen center.
        mousePosition -= new Vector3(Screen.width / 2, Screen.height / 2, 0); 

        float rot = Mathf.Atan2(mousePosition.y, mousePosition.x) * 180f / Mathf.PI;
        
        //Set aim bone to mouse angle.
        skelAnimation.Skeleton.FindBone("aimBone").rotation = rot;
    }
}
