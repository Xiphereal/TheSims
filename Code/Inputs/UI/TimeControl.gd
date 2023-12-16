extends Button

@export var timer : Timer
@export var wait_time : float

func _on_pressed():
	if wait_time == 0:
		timer.stop()
	else: 
		timer.start()
		timer.wait_time = wait_time
