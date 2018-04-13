using Android.Net;
using Android.OS;
using Android.Support.V4.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Com.Nononsenseapps.Filepicker;
using Java.Lang;

namespace Com.Nononsenseapps.Filepicker
{
    public abstract partial class AbstractFilePickerFragment : global::Android.Support.V4.App.Fragment, global::Android.Support.V4.App.LoaderManager.ILoaderCallbacks, global::Com.Nononsenseapps.Filepicker.ILogicHandler, global::Com.Nononsenseapps.Filepicker.NewItemFragment.IOnNewFolderListener
    {
        public abstract string GetFullPath(global::Java.Lang.Object p0);
        public abstract string GetName(Object p0);
        public abstract Object GetParent(Object p0);
        public abstract bool IsDir(Object p0);
        public abstract Uri ToUri(Object p0);
    }
}