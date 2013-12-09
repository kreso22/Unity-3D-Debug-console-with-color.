// ------------------------------------------------------------------------------
//  <Advanced console debugger for Unity 3D>
//      This is a proof of concept rather than a full scale solution
//		
//		Showing how to color text & how to wrap it so it jumps to line of code being debugged.
//
//
//		1. To color text wrap it in <color></color> tags
//		2. To enable double-click on console to jump ot proper line of code - code needs to be compiled 
//			into a DLL. Follow simple instructions from Unity's web site.
// 
//		To use (after you compile DLL and put it in your Plugins folder):
//
//		debug.log("Important message. Color it red and show in the console");
//
//		debug.log(debug.cat.YOURCATEGORY, "Debug message from a specific category. Custom color and important level (will always print)");
//
//		debug.log(debug.cat.YOURCATEGORY, "Debug message from a specific category, moderate importantce (marked as debug level 5)", 5);
//
//		debug.log(debug.cat.YOURCATEGORY, "Debug message, same as previous but will also print gameObject containing this call, it's name as well as highlight it from console+click)", 1, gameObject);
//
//  </Advanced console debugger for Unity 3D>
// ------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;

namespace WW
{

	
	public static class debug
	{
		
		//deactivate debugger to disable all log calls.
		public static bool debuggerActive = true;
		
		//debugger will print only important stuff (lower level = more important)
		public static int debugLevel = 0; // 0 - 9
		
		//available log categories
		public enum cat
		{
			IMPORTANT = 0, 
			TRIGGERS = 1, 
			INGAMEUI = 2,
			CAMERA = 3,
			SAVEDATA = 4,
			INPUT = 5,
			INVENTORY = 6,
			ANIMATION = 7,
			PLAYER = 8,
			EDITOR = 9,
			GAME = 10
		};
		
		//each category will have it's own color
		private static string[] colors = new string[] {
			"FF0000",//red(0)					-- IMPORTANT
			"FF9933",//orange (1)				-- TRIGGERS
			"669999",//dull green/blue  (2)		-- In game UI			
			"52CC29",//green (3)				-- CAMERA RELATED
			"99CCFF",//bright blue (4)			-- SAVE DATA
			"FFFF00",//yellow (5)				-- INPUT
			"CC6699",//dull red/purple (6)		-- INVENTORY
			"D96EBF",//purple (7)
			"66FFCC",//greenish (8)
			"FFFFFF",//white; (9)				-- EDITOR
			"666699"//dark purple; (10)
		};

		
		
		public static void log(string str)
		{
			log((int)cat.IMPORTANT, str, 0, null);
		}
		public static void log(int type, string str)
		{
			log(type, str, 0, null);
		}
		public static void log(int type, string str, float lvl)
		{
			log(type, str, lvl, null);
		}


		//format the string and print it out
		public static void log(int type, string str, float lvl, GameObject context)
		{
			if(!debuggerActive)
				return;
			
			if(lvl < debugLevel)
				return;
			
			//create indentation depending on the debugLevel
			string tabs = "";
			for(int t=1; t<=lvl; t++)
			{
				tabs += "\t- ";
			}
			
			tabs += "-{"+lvl+"} ";

			//get category name as string
			cat typeName = ((cat)type);
			string typeNameString = typeName.ToString();

			string objInfo = " ";
			if(context)
				objInfo += context.transform.root.gameObject.name;

			//format
			str = "<color=#" + colors[type] + ">" +
				"["+typeNameString+"] " +
					tabs +
					"<b>" + str + "</b>" +
					"<i>" + objInfo + "</i>" +
					"</color>";
			
			//print it out
			Debug.Log(str, context);
		}
		
		
		
		
		
		
		
		
		
	}
}

