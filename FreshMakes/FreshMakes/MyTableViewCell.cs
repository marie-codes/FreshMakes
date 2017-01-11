using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace FreshMakes {
	public partial class TweetsTableViewCell : UITableViewCell {
		public TweetsTableViewCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId) {
			SelectionStyle = UITableViewCellSelectionStyle.Gray;
			ContentView.BackgroundColor = UIColor.White;
		}
	}
}
//mapButton = new UIButton();
//mapButton.Font = newFont;
//mapButton.SetTitle("Map", UIControlState.Normal);

//callButton = new UIButton();
//callButton.Font = newFont;
//ContentView.AddSubviews(new UIView[] { nameLabel, mapButton, callButton });


//public void UpdateCellControlsWithTweetData(string item1, string item2)
//{

//	UILabel item1 = "";
//	//callButton.SetTitle(phone, UIControlState.Normal);


//}

//public override void LayoutSubviews() {
//	base.LayoutSubviews();
//	nameLabel.Frame = new CGRect(10, 0, 150, 33);
//	mapButton.Frame = new CGRect(170, 0, 30, 33);
//}
//}