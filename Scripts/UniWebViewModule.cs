using UnityEngine;
using System.Collections;

public class UniWebViewModule : MonoBehaviour
{
	[SerializeField] UniWebView uniwebview ;
	[SerializeField] protected string url = "" ;
	[SerializeField] bool isOpen = false ;
	[SerializeField] bool hasLoaded = false ;
	[SerializeField] bool hideBrowserBar = false ;
	[SerializeField] string displayHeader = "LOADING" ;
	[SerializeField] string displayMessage = "Please Wait" ;

	//protected override void TransitionInCallback ()
	//{
		//Menu.Instance.TransitionKeys( "LoadingAnim" , TransitionState.In ) ;
		//WwwEndpointHandler.CheckConnectivity( ConnectivityAnimCallback ) ;
	//}
	
	void ConnectivityAnimCallback( object obj , bool isError )
	{
		//if( isError ) Menu.Instance.TransitionKeys( "LoadingAnim" , TransitionState.Out , NoInternetCallback ) ;
		//else HasInternetCallback() ;
	}
	
	void NoInternetCallback()
	{
		//Menu.Instance.UpdateErrorMessage( "CONNECTION FAILED!" , "Failure to Connect to Gamer Green" ) ;
		//Menu.Instance.TransitionKeys( "ErrorMessage" , TransitionState.In , ()=>{Application.LoadLevel(0);} ) ;
	}
	
	public void HasInternetCallback()
	{
		isOpen = true ;
		//base.TransitionInCallback ();
		
		uniwebview = GetComponent<UniWebView>();
		if( uniwebview == null ) uniwebview = gameObject.AddComponent<UniWebView>() ;
		//uniwebview.backButtonEnable = false ;
		
		uniwebview.OnLoadComplete += OnLoadComplete;
		uniwebview.OnReceivedKeyCode += OnReceivedKeyCode;
		
		uniwebview.InsetsForScreenOreitation += InsetsForScreenOreitation;
		
		uniwebview.url = url ;
		
		uniwebview.Load() ;
		
		//Menu.Instance.TransitionKeys( "LoadingMessage" , TransitionState.In ) ;
		//Menu.Instance.UpdateLoadingMessage( displayHeader , displayMessage ) ;
		
		//uniwebview.ShowToolBar( true ) ;
	}

	/*
	protected override void TransitionOutCallback ()
	{
		isOpen = false ;
		hasLoaded = false ;

		//uniwebview.HideToolBar( true ) ;
		
		Destroy(uniwebview);
		
		uniwebview.OnLoadComplete -= OnLoadComplete;
		uniwebview.OnReceivedKeyCode -= OnReceivedKeyCode;

		uniwebview.InsetsForScreenOreitation -= InsetsForScreenOreitation;
		uniwebview = null;
		
		//base.TransitionOutCallback ();
	}*/

	UniWebViewEdgeInsets InsetsForScreenOreitation(UniWebView webView, UniWebViewOrientation orientation) 
	{
		int bottomInset = (int)(UniWebViewHelper.screenHeight * 0.1f);

		if( hideBrowserBar ) return new UniWebViewEdgeInsets(bottomInset,5,5,5);
		return new UniWebViewEdgeInsets(bottomInset,5,bottomInset,5);
	}
	
	void OnLoadComplete(UniWebView webView, bool success, string errorMessage) {
		if (!success) 
		{
			Debug.Log("Something wrong in webview loading: " + errorMessage);
		}
		//!!!!!!!!!!
		else {//Menu.Instance.TransitionKeys( "LoadingAnim" , TransitionState.Out , ()=>{
			hasLoaded = true ;
			if(transform.GetChild(0) != null)
				transform.GetChild (0).gameObject.SetActive (true);
			webView.Show(); } //) ;
			
	}

	void OnReceivedKeyCode (UniWebView webView, int keyCode)
	{
		//if( keyCode == 4 ) Menu.Instance.TriggerBackButton() ;
	}

	public void CloseWebView()
	{
		if(uniwebview == null) return ;
		
		uniwebview.Hide() ;
		uniwebview.CleanCache() ;
		uniwebview.CleanCookie() ;

		isOpen = false ;
		hasLoaded = false ;

		//uniwebview.HideToolBar( true ) ;

		Destroy(uniwebview);

		uniwebview.OnLoadComplete -= OnLoadComplete;
		uniwebview.OnReceivedKeyCode -= OnReceivedKeyCode;

		uniwebview.InsetsForScreenOreitation -= InsetsForScreenOreitation;
		uniwebview = null;
	}

	public void GoFwd()
	{
		uniwebview.GoForward() ;
	}

	public void GoBak()
	{
		uniwebview.GoBack() ;
	}

	[ContextMenu("Reload")]
	public void Reload()
	{
		uniwebview.Reload() ;
	}

	void OnApplicationPause( bool isPaused )
	{
		if( !hasLoaded ) return ;

		#if UNITY_ANDROID
		//pausing the app messes up the gameobjects in android since UniWebView is NOT THE MAIN ACTIVITY
		if( isPaused ) uniwebview.Hide() ;
		else uniwebview.Show() ;
		#endif
	}
}
