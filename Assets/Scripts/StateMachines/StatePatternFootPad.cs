﻿using UnityEngine;
using System.Collections;

public class StatePatternFootPad : MonoBehaviour {

    public bool rightLegNext = true;
    public float stepRight = 0.2f;
    public float stepLeft = -0.2f;
    public float stepFront = 0.2f;
    public float stepBack = -0.2f;
    [HideInInspector] public IFootPadState currentState;
    [HideInInspector] public RightState rightState;
    [HideInInspector] public LeftState leftState;
    [HideInInspector] public FrontState frontState;
    [HideInInspector] public BackState backState;

    private void Awake ()
    {
        frontState = new FrontState(this);
        backState = new BackState(this);
        rightState = new RightState(this);
        leftState = new LeftState(this);
  
    }
	// Use this for initialization
	void Start () {
        currentState = leftState;
        rightLegNext = true;
    }
	
	// Update is called once per frame
	void Update () {
        currentState.UpdateState();
	}

    private void OnTriggerEnter (Collider other)
    {
        currentState.OnTriggerEnter(other);
    }

    public void toggleLeg()
    {
        rightLegNext = !rightLegNext;
    }
}
