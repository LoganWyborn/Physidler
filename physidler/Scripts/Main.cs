using Godot;
using System;

public partial class Main : Node
{
	[Export]
	public PackedScene BallScene { get; set; }
	[Export]
	public PackedScene FadingLabelScene { get; set; }
	public bool onClickCooldown = false;
	public double totalPoints = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public override void _Input(InputEvent ev)
    {
        base._Input(ev);
		if(!onClickCooldown && ev is InputEventMouseButton evClick && evClick.IsPressed() && evClick.Position.Y <= 128)
		{
			Ball ball = BallScene.Instantiate<Ball>();
			ball.Position = evClick.Position;
			GetNode<Timer>("ClickCooldown").Start();
			onClickCooldown = true;
			AddChild(ball);
			CreateFadingLabel("Wow!!", evClick.Position, new Vector2(GD.RandRange(-30, 30), -100), new Color("WHITE"));
		}
    }

	public void OnClickCooldownTimeout()
	{
		onClickCooldown = false;
	}

	public void CreateFadingLabel(string textToFloat, Vector2 pos, Vector2 travelPerSecond, Color color, float lifetime = 1f)
	{
		FadingLabel label = FadingLabelScene.Instantiate<FadingLabel>();
		label.Text = textToFloat;
		label.Position = pos;
		label.TravelPerSecond = travelPerSecond;
		label.LabelSettings = new LabelSettings();
		label.LabelSettings.FontColor = color;
		label.lifetime = lifetime;
		AddChild(label);
	}

	public async void OnBallExiting(Ball ball)
	{
		totalPoints += ball.totalValue;
		GetNode<Label>("ScoreLabel").Text = $"{totalPoints}";
		CreateFadingLabel("+" + ball.totalValue, new Vector2(ball.Position.X, ball.Position.Y - 20), new Vector2(GD.RandRange(-30, 30), -100), new Color("GOLD"), 2f);
		await ToSignal(GetTree().CreateTimer(0.2f), Timer.SignalName.Timeout);
		ball.QueueFree();
	}
}
