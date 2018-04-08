﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : MonoBehaviour {

    [Tooltip("How much damage per shot.")]
    public int damage = 5;
    [Tooltip("How much basic damage multiplies per headshot.")]
    public float headshotMultiplier = 1.5f;
    public int currentClipAmmo;
	

    [Tooltip("How much water fits in a clip")]
    public int clipSize = 100;

    [Tooltip("How much one shot consumes water")]
    public int shotUsage = 1;

    [Tooltip("How long to wait until shoot input gets called again. E.g. 0.1f means shooting 10 rounds per second.")]
    public float fireRate = 0.25f;

    [Tooltip("This force-stops shooting after given time. Use isContinuous = true with this.")]
    public float maxShootTime = 0;

    public bool centerAim, lerpAim;


    [Tooltip("How quickly gun rotates towards worldpoint that is in the middle of the camera viewport.")]
    public float rotationSpeed = 1f;


    public int maxCollisionCountPerFrame = 1;


}
