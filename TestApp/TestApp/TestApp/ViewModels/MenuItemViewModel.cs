using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestApp.Models;
using TestApp.Views;
using Xamarin.Forms;

namespace TestApp.ViewModels
{
    public class MenuItemViewModel : MenuModel
    {
        #region Command
        public ICommand SelectMenuCommand => new Command(async () => await SelectMenu()); 
        #endregion

        #region Funciones
        async Task SelectMenu()
        {
            App.Master.IsPresented = false;

            switch (PageName)
            {
                case "ListaUsuariosPage":
                    await App.Navigator.PushAsync(new ListaUsuariosPage());
                    break;
                case "PerfilPage":
                    break;
                default:
                    break;
            }
        } 
        #endregion
    }
}
