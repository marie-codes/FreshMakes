using System;
using UIKit;
using Tweetinvi;
using System.Collections.Generic;


namespace TwitterAPI
{
	public partial class FirstViewController : UIViewController
	{
		public void TwitterAPI(IntPtr handle) : base(handle) { }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			Auth.SetUserCredentials("mJTwVjbfg4GUs0S3j1RN7GUMa", "KcDFpnQ6JbYyayUxNX8RURr4gVW4OdGto5i9dw8Fje9frQDpzM", "364491875-zyI5q3bO8fcauBf7GwpdOvtCKtapzYHYCkFJPyRJ", "yKvUzVyGZgoxCfrgIwA4fjIrmrJ1EX5oCQR04VhUxRrxE");
			var tweets = Tweetinvi.Search.SearchTweets("from:FreshDirect");
			List<Tuple<string, string>> myCollection = new List<Tuple<string, string>>();

		foreach (var tweet in tweets)
			{
				if (tweet.Media.Count > 0)
				{
					Console.WriteLine(tweet.Media[0].MediaURL);
				}
				Console.WriteLine(tweet);
				myCollection.Add(tweet.Text);
				//var imageURL = tweet.Entities.Medias.First().MediaURL;
				//Console.WriteLine("Some tweet: " + tweet);
				//tweetList = tweetList.insert(tweet.Text);
			}
			Console.WriteLine(tweets);
		}
	}
}


