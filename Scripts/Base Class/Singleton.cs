using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T: MonoBehaviour 
{
	private static T _instance;
	public static T Instance
	{
		get
		{
			// referencing blocker in the event where the instance is called while OnDestroy
			if( applicationIsQuitting )
			{
				return null ;
			}
				
			if(!_instance)
			{
				_instance = (T)FindObjectOfType(typeof(T));
			}

			if(!_instance)
			{
				Debug.Log((typeof(T)).Name) ;
				T instance = Resources.Load<T>("System/"+(typeof(T)).Name);
				T go = (T)Instantiate(instance);
				_instance = go;
			}

			return _instance;
		}
	}

	private static bool _isInitialized;
	private static bool applicationIsQuitting = false ;

	[SerializeField] protected bool isDestroyable = false ;



	protected virtual void Awake()
	{
		if(_instance == null) _instance = this as T;

		if( !isDestroyable ) DontDestroyOnLoad(this.gameObject);

		_isInitialized = true;
	}

	protected virtual void OnDestroy()
	{
		applicationIsQuitting = true ;
	}
}
