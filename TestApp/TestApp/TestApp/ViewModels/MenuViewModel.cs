using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestApp.Models;
using Xamarin.Forms;

namespace TestApp.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {

        public MenuViewModel()
        {
            LoadMenus();
        }

        #region Propiedades
        ObservableCollection<MenuModel> listaMenu;
        public ObservableCollection<MenuModel> ListaMenu
        {
            get => listaMenu;
            set => SetValue(ref listaMenu, value);
        }

        #endregion

        #region Funciones
        void LoadMenus()
        {
            var menu = new List<MenuModel>
            {
                new MenuModel{ Title ="Lista de usuarios", Icon ="menuuser.png", PageName = "ListaUsuariosPage" },
                new MenuModel{ Title ="Salir", Icon ="menulogout.png", PageName = "", MenuDetail = "Cerrar Aplicación" },
            };

            listaMenu = new ObservableCollection<MenuModel>(menu.Select(m => new MenuItemViewModel { Icon = m.Icon, Title = m.Title, PageName = m.PageName }).OrderBy(o => o.Title).ToList());
        } 
        #endregion
    }
}
