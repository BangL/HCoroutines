namespace HCoroutines.Samples.IconDemo;

using Godot;

public partial class IconSpawner : Node2D {
    [Export] private PackedScene _icon;

    public override void _Input(InputEvent e) {
        if (e is InputEventMouseButton mouseEvent) {
            if (mouseEvent.ButtonIndex == MouseButton.Left && mouseEvent.Pressed) {
                Node2D node = _icon.Instantiate<Node2D>();
                node.Position = GetLocalMousePosition();
                AddChild(node);
            }
        }
    }
}
