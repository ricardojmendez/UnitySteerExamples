var mouseOverColor = Color.blue;
private var originalColor : Color;
function Start () {
	originalColor = renderer.sharedMaterial.color;
}
function OnMouseEnter () {
	renderer.material.color = mouseOverColor;
}

function OnMouseExit () {
	renderer.material.color = originalColor;
}

function OnMouseDown () {
	var screenSpace = Camera.main.WorldToScreenPoint(transform.position);
	var offset = transform.position - Camera.main.ScreenToWorldPoint(Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
	while (Input.GetMouseButton(0))
	{
		var curScreenSpace = Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
		var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
		transform.position = curPosition;
		yield;
	}
}