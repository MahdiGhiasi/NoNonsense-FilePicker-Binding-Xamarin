using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Com.Nononsenseapps.Filepicker;
using Android.Runtime;

namespace NoNonsense_FilePicker_Binding_Xamarin
{
    [Activity(Label = "NoNonsense_FilePicker_Binding_Xamarin", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

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
            i.PutExtra(FilePickerActivity.ExtraStartPath, Environment.ExternalStorageDirectory.Path);

            StartActivityForResult(i, 1234);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
        }
    }
}

