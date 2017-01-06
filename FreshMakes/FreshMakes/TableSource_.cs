using System;
using UIKit;
using System.Net;
using System.IO;
using Foundation;
using CoreGraphics;
using System.Collections.Generic;

namespace FreshMakes
{
    public partial class TableSource : UITableViewCell
    {
        public TableSource (IntPtr handle) : base (handle)
        {
			List<Tuple<string, string>> items;
		{
			tableItems = items;

			//headingLabel = new UILabel() {
			//	Font = UIFont.FromName("Cochin-BoldItalic", 22f),
			//	TextColor = UIColor.FromRGB(127, 51, 0),
			//	BackgroundColor = UIColor.Clear
			//};

		}
			}

		//public override nint RowsInSection(UITableView tableview, nint section)
		//{
		//	return tableItems.Count;
		//}

		//public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
		//{
		//	//tableView.DeselectRow(indexPath, true);
		//}

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
			//cell.TextLabel.Text = tableItems[indexPath.Row].Item2;
			//cell.ImageView.Image = UIImage.FromFile()

			string url = tableItems[indexPath.Row].Item2;
			//string url = "http://pbs.twimg.com/media/C1civc6W8AA2gjq.jpg";
			if (url != null)
			{
				System.Console.WriteLine("URL:::" + url);
				UIImage image = fromUrl(url);
				if (image != null)
				{
					System.Console.WriteLine("found image");
					UIImageView imageview = new UIImageView(new CGRect(25, 25, 25, 25));
					imageview.Image = image;
					cell.AddSubview(imageview);
				}
				else {
					Console.WriteLine("NO Image");
				}

			}

			return cell;
		}
    }
}