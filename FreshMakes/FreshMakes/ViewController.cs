using System;
using UIKit;
using Tweetinvi;
using System.Collections.Generic;

namespace FreshMakes
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			Auth.SetUserCredentials("mJTwVjbfg4GUs0S3j1RN7GUMa", "KcDFpnQ6JbYyayUxNX8RURr4gVW4OdGto5i9dw8Fje9frQDpzM", "364491875-zyI5q3bO8fcauBf7GwpdOvtCKtapzYHYCkFJPyRJ", "yKvUzVyGZgoxCfrgIwA4fjIrmrJ1EX5oCQR04VhUxRrxE");
			var tweets = Tweetinvi.Search.SearchTweets("from:FreshDirect");
			List<Tuple<string, string>> myCollection = new List<Tuple<string, string>>();

			foreach (var tweet in tweets)
			{
				var text = tweet.Text;
				string url = null;
				if (tweet.Media.Count > 0)
				{
					foreach (var media in tweet.Media)
					{
						url = media.MediaURLHttps;
						if (url != null)
						{
							break;
						}
					}
				}

				Tuple<string, string> item = new Tuple<string, string>(text, url);
				myCollection.Add(item);
			}

			UITableView _table;
			_table = new UITableView

			{
				Frame = new CoreGraphics.CGRect(0, 65, View.Bounds.Width, View.Bounds.Height - 65),
				Source = new TableSource(myCollection)
			};

			View.AddSubview(_table);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
