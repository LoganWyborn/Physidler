using Godot;
using System;

public partial class ActionPeg : CollisionShape2D
{
	[Export]
	public float bouncePower = 0f;
	[Export]
	public float scoreAdder { get; set; } = 0f;
	[Export]
	public float scoreMulti { get; set; } = 1f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnBounceDetectorBodyExited(Node2D body)
	{
		if (body is Ball ball)
		{
			if(bouncePower != 0f)
			{
				ball.ApplyImpulse(ball.LinearVelocity * bouncePower, Position);
			}
			if(scoreAdder != 0f)
			{
				ball.totalValue += scoreAdder;
			}
			if(scoreMulti != 1f)
			{
				ball.totalValue *= scoreMulti;
			}
		}
	}
}
