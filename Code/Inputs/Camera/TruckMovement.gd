extends Camera3D

@export var speed = 10.0

func _process(delta):
	var screen_size = get_viewport().size
	var mouse_pos = get_viewport().get_mouse_position()

	var movement = Vector3()

	if mouse_pos.x < 10:
		movement.x -= 1
	elif mouse_pos.x > screen_size.x - 10:
		movement.x += 1

	if mouse_pos.y < 10:
		movement.z -= 1
	elif mouse_pos.y > screen_size.y - 10:
		movement.z += 1

	# Normalize the movement vector and apply speed
	movement = movement.normalized() * speed

	global_transform.origin.x += movement.x * delta
	global_transform.origin.z += movement.z * delta
