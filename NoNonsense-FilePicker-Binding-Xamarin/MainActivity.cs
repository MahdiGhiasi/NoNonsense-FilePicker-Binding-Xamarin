using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Com.Nononsenseapps.Filepicker;
using Android.Runtime;
using System;
using System.Linq;

namespace NoNonsense_FilePicker_Binding_Xamarin
{
    [Activity(Label = "Main Page", MainLauncher = true )]
    public class MainActivity : Activity
    {
        readonly int filePickerId = 1001;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            FindViewById<Button>(Resource.Id.btnSingle).Click += SelectSingleFile_Click;
            FindViewById<Button>(Resource.Id.btnMultiple).Click += SelectMultipleFiles_Click;
            FindViewById<Button>(Resource.Id.btnFolder).Click += SelectSingleFolder_Click;
            FindViewById<Button>(Resource.Id.btnCombined).Click += SelectCombined_Click;
            FindViewById<Button>(Resource.Id.btnNewFile).Click += SelectNewFile_Click;
        }

        private void SelectNewFile_Click(object sender, EventArgs e)
        {
            // This always works
            Intent i = new Intent(this, typeof(FilePickerActivity));
            // This works if you defined the intent filter
            // Intent i = new Intent(Intent.ACTION_GET_CONTENT);

            // Set these depending on your use case. These are the defaults.
            i.PutExtra(FilePickerActivity.ExtraAllowMultiple, false);
            i.PutExtra(FilePickerActivity.ExtraAllowCreateDir, true);
            i.PutExtra(FilePickerActivity.ExtraMode, FilePickerActivity.ModeNewFile);

            // Configure initial directory by specifying a String.
            // You could specify a String like "/storage/emulated/0/", but that can
            // dangerous. Always use Android's API calls to get paths to the SD-card or
            // internal memory.
            i.PutExtra(FilePickerActivity.ExtraStartPath, Android.OS.Environment.ExternalStorageDirectory.Path);

            StartActivityForResult(i, filePickerId);
        }

        private void SelectCombined_Click(object sender, EventArgs e)
        {
            // This always works
            Intent i = new Intent(this, typeof(FilePickerActivity));
            // This works if you defined the intent filter
            // Intent i = new Intent(Intent.ACTION_GET_CONTENT);

            // Set these depending on your use case. These are the defaults.
            i.PutExtra(FilePickerActivity.ExtraAllowMultiple, true);
            i.PutExtra(FilePickerActivity.ExtraAllowCreateDir, false);
            i.PutExtra(FilePickerActivity.ExtraMode, FilePickerActivity.ModeFileAndDir);

            // Configure initial directory by specifying a String.
            // You could specify a String like "/storage/emulated/0/", but that can
            // dangerous. Always use Android's API calls to get paths to the SD-card or
            // internal memory.
            i.PutExtra(FilePickerActivity.ExtraStartPath, Android.OS.Environment.ExternalStorageDirectory.Path);

            StartActivityForResult(i, filePickerId);
        }

        private void SelectSingleFolder_Click(object sender, EventArgs e)
        {
            // This always works
            Intent i = new Intent(this, typeof(FilePickerActivity));
            // This works if you defined the intent filter
            // Intent i = new Intent(Intent.ACTION_GET_CONTENT);

            // Set these depending on your use case. These are the defaults.
            i.PutExtra(FilePickerActivity.ExtraAllowMultiple, false);
            i.PutExtra(FilePickerActivity.ExtraAllowCreateDir, true);
            i.PutExtra(FilePickerActivity.ExtraMode, FilePickerActivity.ModeDir);
            
            // Configure initial directory by specifying a String.
            // You could specify a String like "/storage/emulated/0/", but that can
            // dangerous. Always use Android's API calls to get paths to the SD-card or
            // internal memory.
            i.PutExtra(FilePickerActivity.ExtraStartPath, Android.OS.Environment.ExternalStorageDirectory.Path);

            StartActivityForResult(i, filePickerId);
        }

        private void SelectMultipleFiles_Click(object sender, EventArgs e)
        {
            // This always works
            Intent i = new Intent(this, typeof(FilePickerActivity));
            // This works if you defined the intent filter
            // Intent i = new Intent(Intent.ACTION_GET_CONTENT);

            // Set these depending on your use case. These are the defaults.
            i.PutExtra(FilePickerActivity.ExtraAllowMultiple, true);
            i.PutExtra(FilePickerActivity.ExtraAllowCreateDir, false);
            i.PutExtra(FilePickerActivity.ExtraMode, FilePickerActivity.ModeFile);

            // Configure initial directory by specifying a String.
            // You could specify a String like "/storage/emulated/0/", but that can
            // dangerous. Always use Android's API calls to get paths to the SD-card or
            // internal memory.
            i.PutExtra(FilePickerActivity.ExtraStartPath, Android.OS.Environment.ExternalStorageDirectory.Path);

            StartActivityForResult(i, filePickerId);
        }

        private void SelectSingleFile_Click(object sender, System.EventArgs e)
        {
            // This always works
            Intent i = new Intent(this, typeof(FilePickerActivity));
            // This works if you defined the intent filter
            // Intent i = new Intent(Intent.ACTION_GET_CONTENT);

            // Set these depending on your use case. These are the defaults.
            i.PutExtra(FilePickerActivity.ExtraAllowMultiple, false);
            i.PutExtra(FilePickerActivity.ExtraAllowCreateDir, false);
            i.PutExtra(FilePickerActivity.ExtraMode, FilePickerActivity.ModeFile);

            // Configure initial directory by specifying a String.
            // You could specify a String like "/storage/emulated/0/", but that can
            // dangerous. Always use Android's API calls to get paths to the SD-card or
            // internal memory.
            i.PutExtra(FilePickerActivity.ExtraStartPath, Android.OS.Environment.ExternalStorageDirectory.Path);

            StartActivityForResult(i, filePickerId);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == filePickerId)
            {
                if (resultCode == Result.Ok) {
                    var files = Utils.GetSelectedFilesFromResult(data).Select(x => x.Path);
                    var message = "Selected files: " + string.Join(", ", files);

                    var alert = new AlertDialog.Builder(this)
                        .SetTitle("Ok")
                        .SetMessage(message)
                        .SetPositiveButton("Finish", (s, e) => { });

                    RunOnUiThread(() =>
                    {
                        alert.Show();
                    });
                }
                else
                {
                    var alert = new AlertDialog.Builder(this)
                        .SetTitle(resultCode.ToString())
                        .SetMessage("")
                        .SetPositiveButton("Finish", (s, e) => { });

                    RunOnUiThread(() =>
                    {
                        alert.Show();
                    });
                }
            }
        }
    }
}

