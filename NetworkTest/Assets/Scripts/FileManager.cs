using System.Collections;
using System.IO;
using System.Collections.Generic;

public class FileManager : EditorWindow {
	
	public static string Apply()
	{
		string path = EditorUtility.OpenFilePanel("Overwrite with png", "", "");
		return path;
	}
}
