using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;


public async void GetDataAsync() {

	Dictionary<string, string> trail = new Dictionary<string, string>();

	trail.Add("postKey", "postvalue");
	trail.Add("password", "secretpassword");

	var stuff = await REST.GetSimpleData("https://www.titsrp.com/boombox/fetch.php?");
	Console.WriteLine(stuff);

	var post = await REST.PostSimpleData("http://httpbin.org/post", trail);
	Console.WriteLine(post);

}

