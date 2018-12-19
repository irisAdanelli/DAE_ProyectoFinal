using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppEvaMovil.Interfaces.SQLite;//ok
using AppEvaMovil.UWP.SQLite;
using System.IO; //ok
using Windows.Storage; //ok
using Xamarin.Forms; //ok


[assembly: Dependency(typeof(FicConfigSQLiteUWP))]
namespace AppEvaMovil.UWP.SQLite 
{
    class FicConfigSQLiteUWP : IFicConfigSQLiteNETStd
    {
        public string FicGetDatabasePath()
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, AppSettings.FicDataBaseName);
        }//TRAER LA RUTA FISICA DONDE SE GUARDA LA BASE DE DATOS EN UWP
    }
}
