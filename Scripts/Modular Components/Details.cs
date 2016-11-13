using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

[System.Serializable]
public class Details {
	public string discount { get; set; }
	public string serviceCharge { get; set; }
	public string shippingFee { get; set; }
	public string tax { get; set; }
	public string subtotal { get; set; }

	public Details(Dictionary<string, object> dict){
		discount = dict ["discount"].ToString ();
		serviceCharge = dict ["serviceCharge"].ToString ();
		shippingFee = dict ["serviceFee"].ToString ();
		tax = dict ["tax"].ToString ();
		subtotal= dict ["subtotal"].ToString ();
	}
}

[System.Serializable]
public class TotalAmount{
	public string currency { get; set; }
	public string value { get; set; }
	public Details details { get; set; }

	public TotalAmount(Dictionary<string,object> dict){
		currency= dict ["currency"].ToString ();
		value = dict ["value"].ToString ();
		details = new Details(dict ["details"]as Dictionary<string,object>);
	}
}

[System.Serializable]
public class Contact{
	public string phone{get;set;}
	public string email{get;set;}
	public Contact(Dictionary<string,object> dict){
		phone = dict ["phone"].ToString ();
		email = dict ["email"].ToString ();
	}
}

[System.Serializable]
public class ShippingAddress
{
	public string line1 { get; set; }
	public string line2 { get; set; }
	public string city { get; set; }
	public string state { get; set; }
	public string zipCode { get; set; }
	public string countryCode { get; set; }

	public ShippingAddress(Dictionary<string,object> dict){
		line1 =dict["line1"].ToString();
		line2=dict["line2"].ToString();
		city=dict["city"].ToString();
		state=dict["state"].ToString();
		zipCode =dict["zipCode"].ToString();
		countryCode=dict["countryCode"].ToString();
	}
}

public class BillingAddress
{
	public string line1 { get; set; }
	public string line2 { get; set; }
	public string city { get; set; }
	public string state { get; set; }
	public string zipCode { get; set; }
	public string countryCode { get; set; }

	public BillingAddress(Dictionary<string,object> dict){
		line1 =dict["line1"].ToString();
		line2=dict["line2"].ToString();
		city=dict["city"].ToString();
		state=dict["state"].ToString();
		zipCode =dict["zipCode"].ToString();
		countryCode=dict["countryCode"].ToString();
	}
}

public class Buyer
{
	public string firstName { get; set; }
	public string middleName { get; set; }
	public string lastName { get; set; }
	public Contact contact { get; set; }
	public ShippingAddress shippingAddress { get; set; }
	public BillingAddress billingAddress { get; set; }
	public string ipAddress { get; set; }

	public Buyer(Dictionary<string,object> dict){
		firstName = dict ["firstName"].ToString ();
		middleName= dict ["middleName"].ToString ();
		lastName=dict ["lastName"].ToString ();
		contact = new Contact (dict ["contact"] as Dictionary<string,object>);
		shippingAddress = new ShippingAddress (dict ["shippingAddress"]as Dictionary<string,object>);
		billingAddress = new BillingAddress (dict ["billingAddress"]as Dictionary<string,object>);
		ipAddress = dict ["ipAddress"].ToString ();
	}
}

public class Details2
{
	public string discount { get; set; }
	public string subtotal { get; set; }

	public Details2(Dictionary<string,object> dict){
		discount = dict ["discount"].ToString ();
		subtotal = dict ["subtotal"].ToString ();
	}
}

public class Amount
{
	public string value { get; set; }
	public Details2 details { get; set; }
	public Amount(Dictionary<string,object> dict){
		value = dict ["value"].ToString ();
		details = new Details2 (dict ["details"]as Dictionary<string,object>);
	}
}

public class Details3
{
	public string discount { get; set; }
	public string subtotal { get; set; }
	public Details3 (Dictionary<string,object> dict){
		discount = dict ["discount"].ToString ();
		subtotal = dict ["subtotal"].ToString ();
	}
}

public class TotalAmount2
{
	public string value { get; set; }
	public Details3 details { get; set; }

	public TotalAmount2(Dictionary<string,object> dict){
		value = dict ["value"].ToString ();
		details = new Details3 (dict ["details"]as Dictionary<string,object>);
	}
}

public class Item
{
	public string name { get; set; }
	public string code { get; set; }
	public string description { get; set; }
	public string quantity { get; set; }
	public Amount amount { get; set; }
	public TotalAmount2 totalAmount { get; set; }
	public Item(Dictionary<string,object> dict){
		name = dict ["name"].ToString ();
		code= dict ["code"].ToString ();
		description = dict ["description"].ToString ();
		quantity =dict ["quantity"].ToString ();
		amount = new Amount (dict ["amount"]as Dictionary<string,object>);
		totalAmount = new TotalAmount2 (dict ["totalAmount"]as Dictionary<string,object>);
	}
}

public class RedirectUrl
{
	public string success { get; set; }
	public string failure { get; set; }
	public string cancel { get; set; }
	public RedirectUrl(Dictionary<string,object> dict){
		success = dict ["success"].ToString ();
		failure =dict ["failure"].ToString ();
		cancel =dict ["cancel"].ToString ();
	}
}

public class Metadata
{
	public Metadata(Dictionary<string,object> dict){

	}
}

public class RootObject
{
	public TotalAmount totalAmount { get; set; }
	public Buyer buyer { get; set; }
	public List<Item> items { get; set; }
	public RedirectUrl redirectUrl { get; set; }
	public string requestReferenceNumber { get; set; }
	public Metadata metadata { get; set; }

	public RootObject(Dictionary<string,object> dict)
	{
		totalAmount = new TotalAmount (dict ["totalAmount"] as Dictionary<string,object>);
		buyer = new Buyer (dict ["buyer"]as Dictionary<string,object>);
		items = new List<Item> ();
		foreach (object obj in items) {
			Dictionary<string,object> d = obj as Dictionary<string,object>;
			items.Add (new Item (d));
		}
		redirectUrl = new RedirectUrl (dict ["redirectUrl"] as Dictionary<string,object>);
		requestReferenceNumber = dict ["requestReferenceNumber"].ToString ();
		metadata = new Metadata (dict ["metadata"] as Dictionary<string,object>);
	}
}