using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace myWWWHandler
{
	public class WWWHandler : MonoBehaviour
	{

		System.Action RequestCB;

		void Start()
		{
		}

		void getRequest()
		{
			
		}

		public void postRequest(string url,Dictionary<string,object> dict, System.Action<string, bool> sCB , System.Action<string, bool> fCB)
		{
			List<string> keyList = new List<string> ();
			List<string> valueList = new List<string> ();

			keyList.Clear ();
			valueList.Clear ();

			WWWForm form = new WWWForm ();
			foreach (object a in dict.Values) {
				valueList.Add (a.ToString ());
			}

			foreach (string b in dict.Keys) {
				keyList.Add (b);
			}

			for (int i = 0; i < valueList.Count; i++) {
				form.AddField (keyList [i], valueList [i]);
			}

			Dictionary<string,string> header = new Dictionary<string,string> ();
			header.Add ("Authorization", "Basic cGstTzB1VnhLVzdqc0hhcDlwcldvRmFXaWxIZW5DaXZqMTRLSFprQ0FDQ1h5Wjo=");
			//header.Add ("Content-Type", "application/json");
			//header ["Authorization"] = "Basic cGstTzB1VnhLVzdqc0hhcDlwcldvRmFXaWxIZW5DaXZqMTRLSFprQ0FDQ1h5Wjo=";
			//header ["Content-Type"] = "application/json";

			byte[] rawData = form.data;

			WWW www = new WWW (url, form.data, header);

			StartCoroutine(WaitForRequest(www, sCB, fCB));
		}

	
		IEnumerator WaitForRequest(WWW www, System.Action<string, bool> cb, System.Action<string, bool> fcb)
		{
			yield return www;

			if (www.error == null) {
				Debug.LogError (www.data);
				if(cb!=null)cb (www.data, true);
			} else {
				Debug.LogError (www.error + www.data);	
				if(fcb!=null)fcb (www.error, true);
			}
		}



	}
}