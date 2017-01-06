using System;
using UIKit;
using System.Net;
using System.IO;
using Foundation;
using CoreGraphics;
using System.Collections.Generic;

namespace FreshMakes
{
	public class TableSource : UITableViewSource
	{
		List<Tuple<string, string>> tableItems = new List<Tuple<string, string>>();

		string cellIdentifier = "TableCell";

		public UILabel headingLabel { get; private set; }
		public UILabel subheadingLabel { get; private set; }
		public TableSource(List<Tuple<string, string>> items)
		{
			tableItems = items;

			headingLabel = new UILabel() 
			{
				Font = UIFont.FromName("Cochin-BoldItalic", 22f),
				TextColor = UIColor.FromRGB(127, 51, 0),
				BackgroundColor = UIColor.Clear
			};

			subheadingLabel = new UILabel()
			{
				Font = UIFont.FromName("AmericanTypewriter", 12f),
				TextColor = UIColor.FromRGB(38, 127, 0),
				TextAlignment = UITextAlignment.Center,
				BackgroundColor = UIColor.Clear
			};
		}

		public void UpdateCell(string caption, string subtitle, UIImage image)
		{
			//imageView.Image = image;
			headingLabel.Text = caption;
			subheadingLabel.Text = subtitle;
		}


		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return tableItems.Count;
		}

		public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			//tableView.DeselectRow(indexPath, true);
		}

		private UIImage fromUrl(string uri)
		{

			Console.WriteLine("downloading: " + uri);
			NSUrl url = new NSUrl(uri);
			NSData data = NSData.FromUrl(url);
			if (data == null)
			{
				return null;
			}
			return UIImage.LoadFromData(data);
		}

		public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);

			if (cell == null)
				cell = new UITableViewCell(UITableViewCellStyle.Subtitle, cellIdentifier);

			cell.TextLabel.Text = tableItems[indexPath.Row].Item1;
			cell.TextLabel.Add(headingLabel);
			cell.DetailTextLabel.Add(subheadingLabel);

			//load images in tableView
			//if (url != null)
			//{
			//	System.Console.WriteLine("URL:::" + url);
			//	UIImage image = fromUrl(url);
			//	if (image != null)
			//	{
			//		System.Console.WriteLine("found image");
			//		UIImageView imageview = new UIImageView(new CGRect(40, 40, 40, 40)),

					//imageview.Image = image;
					//cell.AddSubview(imageview);
				//}
			//	else {
			//		Console.WriteLine("NO Image");
			//	}
			//}
			return cell;
		}
	}
}
