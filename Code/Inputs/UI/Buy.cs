using Godot;

public partial class Buy : Button
{
    public void BuyItem()
    {
        PackedScene item = ResourceLoader.Load<PackedScene>("res://Scenes/bed.tscn");

        AddChild(item.Instantiate());
    }
}