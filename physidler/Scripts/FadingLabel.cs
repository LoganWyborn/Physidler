using Godot;
using System;

public partial class FadingLabel : Label
{
	public float lifetime = 1f;
	public Vector2 TravelPerSecond { get; set; }
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		LabelSettings.FontColor -= new Color(0f, 0f, 0f, (float)delta / lifetime);
		if(LabelSettings.FontColor.A <= 0)
			QueueFree();
		else
		{
			Position += (float)delta * TravelPerSecond;
		}
	}
}
