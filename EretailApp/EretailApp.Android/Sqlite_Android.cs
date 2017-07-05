using System;
using Xamarin.Forms;
using Sqlloginbusinesslogic.Droid;
using System.IO;

[assembly: Dependency(typeof(Sqlite_Android))]
namespace Sqlloginbusinesslogic.Droid
{
  public class Sqlite_Android : ISQLite
    {
        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var filename = "masterdata.db";
            var documentspath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentspath, filename);

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);
            return connection;
        }
    }
}