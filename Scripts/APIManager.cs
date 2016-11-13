using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using myWWWHandler;

using MiniJSON;

public class APIManager : WWWHandler {

	public static APIManager instance = new APIManager();

	public string testNigga;

	void Awake()
	{
		if (instance != this)
			instance = this;
	
		DontDestroyOnLoad (this);
	}

	void Start()
	{
		//paymayaCheckOut (testNigga); 
	}

	string  messageID()
	{
		string glyphs = "abcdefghijklmnopqrstuvwxyz0123456789";
		string myString = "";
		int charAmount = 32;

		for (int i = 0; i < charAmount; i++) {
			myString += glyphs [Random.Range (0, glyphs.Length)];
		}

		return myString;
	}
	public string[] yeahson;

	public void paymayaCheckOut(string json)
	{
		/*
		Dictionary<string, object> DICT = new Dictionary<string,object> ();

		Dictionary<string,object> dict = new Dictionary<string, object>();
		dict = Json.Deserialize (json) as Dictionary<string,object>;

		Dictionary<string, object> dict2 = new Dictionary<string,object> ();
		foreach (object a in dict["totalAmount"]) {
			Debug.LogError (a.ToString ());
		}*/
		Debug.Log (json);
		List<RootObject> rootList = new List<RootObject> ();
		var objList = Json.Deserialize (json) as Dictionary<string,object>;

		/*
		List<string> strings = new List<string> ();
		List<string> strings2 = new List<string> ();

		Dictionary<string,object> empty = new Dictionary<string, object>();
		foreach (object b in objList.Values) {
			strings.Add (b.ToString ());
		}foreach (string a in objList.Keys) {
			strings2.Add (a);
		}

		for (int i = 0; i < strings.Count; i++) {
			empty.Add (strings2 [i], strings [i]);
		}
		/*
		foreach (object o in objList) {
			var dict = o as Dictionary<string,object>;
			rootList.Add (new RootObject (dict));
		}*/


		foreach (object a in objList.Values) {
			Debug.LogError (a.ToString ());

		}
		Dictionary<string,object> dict2 = new Dictionary<string,object> ();

		dict2.Add ("totalAmount", yeahson [0]);
		dict2.Add ("buyer", yeahson [1]);
		dict2.Add ("items", yeahson [2]);
		dict2.Add ("redirectUrl", yeahson [3]);
		dict2.Add ("requestReferenceNumber", "000141386713");
		dict2.Add ("metadata", "{}");

		postRequest ("https://pg-sandbox.paymaya.com/checkout/v1/checkouts", dict2 , null, null);
	}
	public void sendTextMessage(string message, string phoneNumber, System.Action<string, bool> successCallBack, System.Action<string, bool> failedCallBack)
	{
			Dictionary<string,object> dict = new Dictionary<string,object> ();

			dict.Add ("message_type", "SEND");
			dict.Add ("mobile_number", phoneNumber);
			dict.Add ("message", message);
			dict.Add ("message_id", messageID());
			dict.Add ("shortcode", "292902233");
			dict.Add ("client_id", "f5ba3c5e55dbfd30a8930aa7478425ded63e1ca7bf6f9353858c10b5b5ce31aa");
			dict.Add ("secret_key", "7ff1685249be0df6fa6c0f3d4acaa9a8ad3745f7d83810f05e14c29eec9ffb3b");

		postRequest ("https://post.chikka.com/smsapi/request" ,dict, successCallBack, failedCallBack);
	       
	}
}
