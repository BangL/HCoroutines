namespace HCoroutines.Samples.IconDemo;

using Godot;

public partial class IconSpawner : Node2D {
    [Export] private PackedScene _icon;

    public override void _Input(InputEvent @event) {
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.ButtonIndex == MouseButton.Left && mouseEvent.Pressed) {
            Node2D node = _icon.Instantiate<Node2D>();
            node.Position = GetLocalMousePosition();
            AddChild(node);
        }
    }
}
