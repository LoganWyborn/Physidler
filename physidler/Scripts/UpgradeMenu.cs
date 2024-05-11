using Godot;
using System;

public partial class UpgradeMenu : VBoxContainer
{
	[Export]
	private PackedScene UpgradeRowScene { get; set; }
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		IUpgradeable Parent = GetParentOrNull<IUpgradeable>();
		if (Parent is null)
		{
			GD.Print("Upgrade Menu can't find proper parent.");
			return;
		}

		foreach(Upgrade upgrade in Parent.Upgrades)
		{
			UpgradeRow row = UpgradeRowScene.Instantiate<UpgradeRow>();
			row.Fill(upgrade.Name, upgrade.currentLevel, upgrade.GetCurrentCost());
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
