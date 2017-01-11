using System;
using UIKit;
using System.Net;
using System.IO;
using Foundation;
using CoreGraphics;
using System.Collections.Generic;

namespace FreshMakes
{
	public class TableSource : UITableViewSource{
		List<Tuple<string, string>> tableItems = new List<Tuple<string, string>>();
		NSString _cellID = new NSString("TableCell");
		public TableSource(List<Tuple<string, string>> items){
			tableItems = items;
		}

		private UIImage fromUrl(string uri) {
			Console.WriteLine("downloading: " + uri);
			NSUrl url = new NSUrl(uri);
			NSData data = NSData.FromUrl(url);
			if (data == null){
				return null;
			}
			return UIImage.LoadFromData(data);}

		public override nint RowsInSection(UITableView tableview, nint section) {
			return tableItems.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(_cellID) as TweetsTableViewCell;

			var tweets = tableItems[indexPath.Row];


			if (cell == null) { cell = new TweetsTableViewCell(_cellID); }
			//cell.TextLabel.Text = tableItems[indexPath.Row].Item1;
			string url = tableItems[indexPath.Row].Item2;

			//cell.UpdateCellControlsWithTweetData(item1, item2);
			//cell.MapButton.TouchUpInside += delegate (object sender, EventArgs e){
			//UIApplication.SharedApplication.OpenUrl(new NSUrl(mapUrl));
			//};
			//cell.CallButton.TouchUpInside += CallNumber;


			if (url != null)
			{
				System.Console.WriteLine("URL:::" + url);
				UIImage image = fromUrl(url);
				if (image != null)
				{
					System.Console.WriteLine("found image");
					UIImageView imageview = new UIImageView(new CGRect(20, 20, 45, 45));
					imageview.Image = image;
					//cell.AddSubview(imageview);
					//UILabel label = new UILabel(new CGRect(70 + imageview.Frame.Width, 25, 25, 25));
					//cell.AddSubview(label);
					//label.Text = tableItems[indexPath.Row].ToString();
					//label.AdjustsFontSizeToFitWidth = true;
					cell.TextLabel.Lines = 3;
				}
			}

			else {
				Console.WriteLine("NO Image");
				cell.TextLabel.Text = tableItems[indexPath.Row].Item1;
				cell.TextLabel.AdjustsFontSizeToFitWidth = true;
				cell.TextLabel.Lines = 2;
			}
			return cell;
		}
	}
}

//tableItems.Add (new TableItem("Vegetables") { SubHeading = "65 items", ImageName = "Vegetables.jpg"});
//			tableItems.Add (new TableItem("Fruits") { SubHeading = "17 items", ImageName = "Fruits.jpg"});
//			tableItems.Add (new TableItem("Flower Buds") { SubHeading = "5 items", ImageName = "Flower Buds.jpg"});
//			tableItems.Add (new TableItem("Legumes") { SubHeading = "33 items", ImageName = "Legumes.jpg"});
//			tableItems.Add (new TableItem("Bulbs") { SubHeading = "18 items", ImageName = "Bulbs.jpg"});
//			tableItems.Add (new TableItem("Tubers") { SubHeading = "43 items", ImageName = "Tubers.jpg"});
//			table.Source = new TableSource(tableItems, this);
//			Add(table);