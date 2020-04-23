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
                new MenuModel{ Title ="Lista de usuarios", Icon ="https://images.vexels.com/media/users/3/151870/isolated/preview/8b1a89d3f271913146d4cd63f3920464-icono-de-trazo-de-lista-de-comprobaci--n-m--dica-by-vexels.png", PageName = "ListaUsuariosPage" },
                new MenuModel{ Title ="Salir", Icon ="https://toppng.com/uploads/preview/logout-11551049168o9cg0mxxib.png", PageName = "Salir", MenuDetail = "Cerrar Aplicación" },
            };

            listaMenu = new ObservableCollection<MenuModel>(menu.Select(m => new MenuItemViewModel { Icon = m.Icon, Title = m.Title, PageName = m.PageName }).OrderBy(o => o.Title).ToList());
        } 
        #endregion
    }
}
