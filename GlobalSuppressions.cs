// This file is used by Code Analysis to maintain SuppressMessage attributes that are applied to
// this project. Project-level suppressions either have no target or are given a specific target and
// scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "It's a signal event handler, so they cannot be removed.", Scope = "member", Target = "~M:Godot.Bed.OnAreaInputEvent(Godot.Node,Godot.InputEvent,Godot.Vector3,Godot.Vector3,System.Int64)")]