#pragma strict

function Start () {

}

function Update () {

}



/*
	Draw rectangle
*/
//via BOUNDS
static function drawRect(bounds:Bounds, col:Color)
{
	drawRect(bounds.min.x, bounds.max.x, bounds.min.y, bounds.max.y, col);
}
static function drawRect(bounds:Bounds, col:Color, border:boolean)
{
	drawRect(bounds.min.x, bounds.max.x, bounds.min.y, bounds.max.y, col, border);
}

// via RECT
static function drawRect(rect:Rect, col:Color)
{
	drawRect(rect.xMin, rect.xMax, rect.yMin, rect.yMax, col);
}

//via coordinates (default)
static function drawRect(x1:float, x2:float, y1:float, y2:float, col:Color)
{
	drawRect(x1, x2, y1, y2, col, false);
}

static function drawRect(x1:float, x2:float, y1:float, y2:float, col:Color, border:boolean)
{

	if(border)
	{
		var offset:float = 0.2;
		//drawRect(x1-offset, x2+offset, y1-offset, y2+offset, col, true);
		//drawRect(x1+offset, x2-offset, y1+offset, y2-offset, col, true);
	}

	Debug.DrawLine (Vector3(x1,y1,0), Vector3 (x2, y1, 0), col);
	Debug.DrawLine (Vector3(x1,y2,0), Vector3 (x2, y2, 0), col);
	
	Debug.DrawLine (Vector3(x1,y1,0), Vector3 (x1, y2, 0), col);
	Debug.DrawLine (Vector3(x2,y1,0), Vector3 (x2, y2, 0), col);
}

