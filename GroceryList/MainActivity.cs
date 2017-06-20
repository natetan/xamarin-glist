using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace GroceryList {
	[Activity(Label = "Grocery List", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity {
		public static List<Item> Items = new List<Item>();

		protected override void OnCreate(Bundle bundle) {
			Items.Add(new Item("Milk", 2));
			Items.Add(new Item("Crackers", 1));
			Items.Add(new Item("Apples", 5));

			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);

			FindViewById<Button>(Resource.Id.itemsButton).Click += OnItemsClick;
			FindViewById<Button>(Resource.Id.addItemButton).Click += OnAddItemClick;
			FindViewById<Button>(Resource.Id.aboutButton).Click += OnAboutClick;
		}

		void OnItemsClick(object sender, EventArgs e) {
            var intent = new Intent(this, typeof(ItemsActivity));
            StartActivity(intent);
		}

		void OnAddItemClick(object sender, EventArgs e) {
            var intent = new Intent(this, typeof(AddItemActivity));
            StartActivityForResult(intent, 100);
		}

		void OnAboutClick(object sender, EventArgs e) {
            StartActivity(typeof(AboutActivity));
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data) {
            if (requestCode == 100 && resultCode == Result.Ok) {

                // Grab the data from the intent extras
                string itemName = data.GetStringExtra("ItemName");
                int itemCount = data.GetIntExtra("ItemCount", -1);

                // Add the new item into the list
                Items.Add(new Item(itemName, itemCount));
            }
		}
	}
}