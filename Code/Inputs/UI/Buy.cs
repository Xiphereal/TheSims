using Godot;

public partial class Buy : Button
{
    private Node3D item;

    public void BuyItem()
    {
        item = ResourceLoader
            .Load<PackedScene>("res://Scenes/bed.tscn")
            .Instantiate<Node3D>();

        GetTree().Root.GetNode("Root").AddChild(item);
    }

    public override void _Process(double delta)
    {
        if (item is not null)
            MoveWithCursor(item);
    }

    private void MoveWithCursor(Node3D item)
    {
        Vector2 mousePosition = GetGlobalMousePosition();
        Vector3 targetPosition = Asdfljkadfhs(mousePosition);

        const float ArbitraryHeightThatMatchTheFloors = 0.5f;
        item.Position = new Vector3(
            targetPosition.X,
            ArbitraryHeightThatMatchTheFloors,
            -targetPosition.Y);
    }

    private Vector3 Asdfljkadfhs(Vector2 mousePosition)
    {
        const int ArbitraryZDepthToBestFitTheMouseMovement = 5;
        return GetViewport()
            .GetCamera3D()
            .ProjectPosition(mousePosition, ArbitraryZDepthToBestFitTheMouseMovement);
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseButton && mouseButton.Pressed)
            PlaceItem();

        if (@event is InputEventKey keyEvent
                && keyEvent.Pressed
                && keyEvent.Keycode == Key.Escape)
            CancelPurchase();
    }

    private void CancelPurchase()
    {
        item.QueueFree();

        item = null;
    }

    private void PlaceItem()
    {
        item = null;
    }
}