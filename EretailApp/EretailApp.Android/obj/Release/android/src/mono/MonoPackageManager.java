package mono;

import java.io.*;
import java.lang.String;
import java.util.Locale;
import java.util.HashSet;
import java.util.zip.*;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ApplicationInfo;
import android.content.res.AssetManager;
import android.util.Log;
import mono.android.Runtime;

public class MonoPackageManager {

	static Object lock = new Object ();
	static boolean initialized;

	static android.content.Context Context;

	public static void LoadApplication (Context context, ApplicationInfo runtimePackage, String[] apks)
	{
		synchronized (lock) {
			if (context instanceof android.app.Application) {
				Context = context;
			}
			if (!initialized) {
				android.content.IntentFilter timezoneChangedFilter  = new android.content.IntentFilter (
						android.content.Intent.ACTION_TIMEZONE_CHANGED
				);
				context.registerReceiver (new mono.android.app.NotifyTimeZoneChanges (), timezoneChangedFilter);
				
				System.loadLibrary("monodroid");
				Locale locale       = Locale.getDefault ();
				String language     = locale.getLanguage () + "-" + locale.getCountry ();
				String filesDir     = context.getFilesDir ().getAbsolutePath ();
				String cacheDir     = context.getCacheDir ().getAbsolutePath ();
				String dataDir      = getNativeLibraryPath (context);
				ClassLoader loader  = context.getClassLoader ();

				Runtime.init (
						language,
						apks,
						getNativeLibraryPath (runtimePackage),
						new String[]{
							filesDir,
							cacheDir,
							dataDir,
						},
						loader,
						new java.io.File (
							android.os.Environment.getExternalStorageDirectory (),
							"Android/data/" + context.getPackageName () + "/files/.__override__").getAbsolutePath (),
						MonoPackageManager_Resources.Assemblies,
						context.getPackageName ());
				
				mono.android.app.ApplicationRegistration.registerApplications ();
				
				initialized = true;
			}
		}
	}

	public static void setContext (Context context)
	{
		// Ignore; vestigial
	}

	static String getNativeLibraryPath (Context context)
	{
	    return getNativeLibraryPath (context.getApplicationInfo ());
	}

	static String getNativeLibraryPath (ApplicationInfo ainfo)
	{
		if (android.os.Build.VERSION.SDK_INT >= 9)
			return ainfo.nativeLibraryDir;
		return ainfo.dataDir + "/lib";
	}

	public static String[] getAssemblies ()
	{
		return MonoPackageManager_Resources.Assemblies;
	}

	public static String[] getDependencies ()
	{
		return MonoPackageManager_Resources.Dependencies;
	}

	public static String getApiPackageName ()
	{
		return MonoPackageManager_Resources.ApiPackageName;
	}
}

class MonoPackageManager_Resources {
	public static final String[] Assemblies = new String[]{
		/* We need to ensure that "EretailApp.Android.dll" comes first in this list. */
		"EretailApp.Android.dll",
		"EretailApp.dll",
		"FormsViewGroup.dll",
		"Microsoft.Data.Edm.dll",
		"Microsoft.Data.OData.dll",
		"Microsoft.WindowsAzure.Mobile.dll",
		"Microsoft.WindowsAzure.Mobile.Ext.dll",
		"Microsoft.WindowsAzure.Mobile.SQLiteStore.dll",
		"Microsoft.WindowsAzure.Storage.dll",
		"MvvmHelpers.dll",
		"Newtonsoft.Json.dll",
		"PCLCrypto.dll",
		"PInvoke.BCrypt.dll",
		"PInvoke.Kernel32.dll",
		"PInvoke.NCrypt.dll",
		"PInvoke.Windows.Core.dll",
		"Plugin.Connectivity.Abstractions.dll",
		"Plugin.Connectivity.dll",
		"Plugin.CurrentActivity.dll",
		"Plugin.Media.Abstractions.dll",
		"Plugin.Media.dll",
		"Plugin.Permissions.Abstractions.dll",
		"Plugin.Permissions.dll",
		"Rg.Plugins.Popup.dll",
		"Rg.Plugins.Popup.Droid.dll",
		"Rg.Plugins.Popup.Platform.dll",
		"SQLite.Net.Async.dll",
		"SQLite.Net.Cipher.dll",
		"SQLite.Net.dll",
		"SQLite.Net.Platform.XamarinAndroid.dll",
		"SQLitePCLRaw.batteries_green.dll",
		"SQLitePCLRaw.core.dll",
		"SQLitePCLRaw.lib.e_sqlite3.dll",
		"SQLitePCLRaw.provider.e_sqlite3.dll",
		"System.Drawing.dll",
		"System.Net.Http.Extensions.dll",
		"System.Net.Http.Primitives.dll",
		"System.Spatial.dll",
		"Validation.dll",
		"Xamarin.Android.Support.Animated.Vector.Drawable.dll",
		"Xamarin.Android.Support.Design.dll",
		"Xamarin.Android.Support.v4.dll",
		"Xamarin.Android.Support.v7.AppCompat.dll",
		"Xamarin.Android.Support.v7.CardView.dll",
		"Xamarin.Android.Support.v7.MediaRouter.dll",
		"Xamarin.Android.Support.v7.RecyclerView.dll",
		"Xamarin.Android.Support.Vector.Drawable.dll",
		"Xamarin.Forms.Core.dll",
		"Xamarin.Forms.Platform.Android.dll",
		"Xamarin.Forms.Platform.dll",
		"Xamarin.Forms.Xaml.dll",
		"Xamarin.iOS.dll",
		"Xamarin.UITest.dll",
		"System.Configuration.dll",
		"System.Runtime.Remoting.dll",
		"System.Web.dll",
		"System.DirectoryServices.dll",
		"System.Web.RegularExpressions.dll",
		"System.Design.dll",
		"System.Windows.Forms.dll",
		"Accessibility.dll",
		"System.Deployment.dll",
		"System.Runtime.Serialization.Formatters.Soap.dll",
		"System.Data.OracleClient.dll",
		"System.Drawing.Design.dll",
		"System.Web.ApplicationServices.dll",
		"System.DirectoryServices.Protocols.dll",
		"System.Runtime.Caching.dll",
		"System.ServiceProcess.dll",
		"System.Configuration.Install.dll",
		"Microsoft.Build.Utilities.v4.0.dll",
		"Microsoft.Build.Framework.dll",
		"System.Xaml.dll",
		"Microsoft.Build.Tasks.v4.0.dll",
	};
	public static final String[] Dependencies = new String[]{
	};
	public static final String ApiPackageName = "Mono.Android.Platform.ApiLevel_23";
}