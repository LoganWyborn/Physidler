using Godot;
using System;

public partial class ExitZone : Area2D
{
	[Signal]
	public delegate void OnBallExitingEventHandler(Ball ball);
	[Export]
	public float multiplier = 1f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnExitZoneBodyExited(Node2D body)
	{
		if(body is Ball ball && ball.Position.Y >= 720)
		{
			ball.totalValue *= multiplier;
			EmitSignal(SignalName.OnBallExiting, ball);
		}
	}
}
