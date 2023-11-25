using System.Numerics;
using GodotVector3 = Godot.Vector3;

namespace Inputs.Extensions
{
    public static class GodotExtensions
    {
        public static Vector3 ToNumericsVector(this GodotVector3 godot)
        {
            return new Vector3(godot.X, godot.Y, godot.Z);
        }
    }
}