using Godot;
using System;

public partial class Ball : RigidBody2D
{
	[Export]
	public float baseValue { get; set; } = 1f;
	public float totalValue { get; set; }
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		totalValue = baseValue;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
