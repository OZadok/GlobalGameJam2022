using System;
using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	[field: SerializeField] public PlayerInputBehaviour InputBehaviour { get; private set; }
	[field: SerializeField] public Camera PlayerCamera { get; private set; }
	[field: SerializeField] public Rigidbody Rigidbody { get; private set; }
	[field: SerializeField] public Animator Animator { get; private set; }

	internal StateMachine StateMachine;

	public MovementState MovementState;
	public PostState PostState;
	public SwapState SwapState;

	public FamilyType FamilyType = FamilyType.None;

	private void Awake()
	{
		if (InputBehaviour == null)
		{
			InputBehaviour = GetComponent<PlayerInputBehaviour>();
		}
		if (PlayerCamera == null)
		{
			PlayerCamera = Camera.current;
		}
		if (Rigidbody == null)
		{
			Rigidbody = GetComponent<Rigidbody>();
		}
		if (Animator == null)
		{
			Animator = GetComponent<Animator>();
		}

		MovementState = new MovementState(this);
		PostState = new PostState(this);
		SwapState = new SwapState(this);
	}

	private void Start()
	{
		StateMachine = ScriptableObject.CreateInstance <States.StateMachine>();
		StateMachine.ChangeState(MovementState);
	}

	private void Reset()
	{
		if (InputBehaviour == null)
		{
			InputBehaviour = GetComponent<PlayerInputBehaviour>();
		}
		if (PlayerCamera == null)
		{
			PlayerCamera = Camera.current;
		}
		if (Rigidbody == null)
		{
			Rigidbody = GetComponent<Rigidbody>();
		}
		if (Animator == null)
		{
			Animator = GetComponent<Animator>();
		}
	}

	private void Update()
	{
		StateMachine.Update();
	}

	private void FixedUpdate()
	{
		StateMachine.FixedUpdate();
	}
}
