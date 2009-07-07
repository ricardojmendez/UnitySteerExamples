

private var buttonRect = Rect (10, 10, 75, 25);

function OnGUI()
{
	var reset = GUI.Button(buttonRect, "Reset");
	if (reset)
	    Application.LoadLevel(Application.loadedLevel);
}