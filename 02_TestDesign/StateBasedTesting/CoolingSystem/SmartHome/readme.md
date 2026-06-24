

# Diagram stanu
```
[*] --> Off
stateDiagram-v2
	Off --> On : MotionDetected
	On --> Dimmed : Timeout
	Dimmed --> Off : Timeout
```