using Godot;
using System;

public partial class UpgradeRow : HBoxContainer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void Fill(string name, int level, double cost, bool isMaxed = false)
	{
		GetNode<Label>("Name").Text = name;
		GetNode<Label>("Level").Text = level.ToString();
		GetNode<Label>("Cost").Text = cost.ToString();
		if(cost > GetNode<Main>("/root/Main").totalPoints || isMaxed)
		{
			GetNode<Button>("Button").Disabled = true;
		}
		else
		{
			GetNode<Button>("Button").Disabled = false;
		}
	}
}
