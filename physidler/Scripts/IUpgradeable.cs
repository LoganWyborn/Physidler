using Godot;
using System;
using System.Collections.Generic;

public interface IUpgradeable
{
    [Export]
    UpgradeMenu UpgradeUI { get; set; }
    [Export]
    Vector2 UIOffset { get; set; }
    public List<Upgrade> Upgrades { get; set; }
}

public class Upgrade
{
    public string Name { get; set; }
    public int currentLevel { get; set; } = 0;

    public double GetCurrentCost()
    {

        return 0;
    }
}