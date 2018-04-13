using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace Com.Nononsenseapps.Filepicker
{
    public partial class FilePickerFragment : global::Com.Nononsenseapps.Filepicker.AbstractFilePickerFragment
    {
        public override string GetFullPath(Java.Lang.Object p0)
        {
            return GetFullPath(p0 as Java.IO.File);
        }

        public override string GetName(Java.Lang.Object p0)
        {
            return GetName(p0 as Java.IO.File);
        }

        public override Java.Lang.Object GetParent(Java.Lang.Object p0)
        {
            return GetParent(p0 as Java.IO.File);
        }

        public override bool IsDir(Java.Lang.Object p0)
        {
            return IsDir(p0 as Java.IO.File);
        }

        public override void OnLoadFinished(Android.Support.V4.Content.Loader loader, Java.Lang.Object data)
        {
            throw new NotImplementedException();
        }

        public override Android.Net.Uri ToUri(Java.Lang.Object p0)
        {
            return ToUri(p0 as Java.IO.File);
        }
    }

    internal partial class AbstractFilePickerFragmentInvoker : AbstractFilePickerFragment, global::Com.Nononsenseapps.Filepicker.ILogicHandler
    {

        public override string GetFullPath(Java.Lang.Object p0)
        {
            throw new NotImplementedException();
        }

        public override string GetName(Java.Lang.Object p0)
        {
            throw new NotImplementedException();
        }

        public override Java.Lang.Object GetParent(Java.Lang.Object p0)
        {
            throw new NotImplementedException();
        }

        public override bool IsDir(Java.Lang.Object p0)
        {
            throw new NotImplementedException();
        }

        public override Android.Net.Uri ToUri(Java.Lang.Object p0)
        {
            throw new NotImplementedException();
        }
    }
}