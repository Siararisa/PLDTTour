using UnityEngine;
using UnityEditor;

public class MyTools {

	[MenuItem("MyTools/CreateGameChapter")]

	static void CreateChapterPrefab(){
		GameObject clone = PrefabUtility.InstantiatePrefab (Selection.activeObject as GameObject) as GameObject;
		clone.transform.parent = GameObject.Find ("Canvas").transform;
	}
}
