using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace GroceryList {
	[Activity(Label = "Add Item")]
	public class AddItemActivity : Activity {
		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.AddItem);

			FindViewById<Button>(Resource.Id.saveButton).Click += OnSaveClick;
			FindViewById<Button>(Resource.Id.cancelButton).Click += OnCancelClick;
		}

		void OnSaveClick(object sender, EventArgs e) {
			string name = FindViewById<EditText>(Resource.Id.nameInput).Text;
			int count = int.Parse(FindViewById<EditText>(Resource.Id.countInput).Text);

            // Setting up the intent
            var intent = new Intent();
            intent.PutExtra("ItemName", name);
            intent.PutExtra("ItemCount", count);

            // Load the data we want to return and go back to MainActivity
            SetResult(Result.Ok, intent);
            Finish();
		}

		void OnCancelClick(object sender, EventArgs e) {
            // Completes the activity
            Finish();
		}
	}
}