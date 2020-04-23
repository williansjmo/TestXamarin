using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestApp.Models;
using TestApp.Services;
using TestApp.Views;
using Xamarin.Forms;

namespace TestApp.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        Api api = new Api();

        public UserViewModel()
        {
            Task.Run(async ()=> await GetListUserAsync());
            if (ImageSource == null)
                ImageSource = "https://cdn.cwsplatform.com/assets/no-photo-available.png";

            instancia = this;
        }

        #region Command
        public ICommand AddUserCommand => new Command(async () => await AddUserAsync());
        public ICommand AddUserPageCommand => new Command(async () => await App.Navigator.PushAsync(new AddUserPage()));
        public ICommand AddImageCommand => new Command(async ()=> await AddImageAsync());
        #endregion

        #region Propiedades
        private MediaFile file;

        private static UserViewModel instancia;
        public static UserViewModel Instancia
        {
            get => instancia;
            set => instancia = value;
        }

        private string avatar;
        public string Avatar
        {
            get => avatar;
            set => SetValue(ref avatar, value);
        }

        private string nombre;
        public string Nombre
        {
            get => nombre;
            set => SetValue(ref nombre, value);
        }

        private string apellido;
        public string Apellido
        {
            get => apellido;
            set => SetValue(ref apellido, value);
        }

        private string telefono;
        public string Telefono
        {
            get => telefono;
            set => SetValue(ref telefono, value);
        }


        private ObservableCollection<Result> listUsers;
        public ObservableCollection<Result> ListUsers
        {
            get => listUsers;
            set => SetValue(ref listUsers, value);
        }

        ImageSource imageSource;
        public ImageSource ImageSource 
        { 
            get=> imageSource; 
            set=> SetValue(ref imageSource,value); 
        }
        #endregion

        #region Funciones
        async Task AddImageAsync()
        {
            try
            {
                await CrossMedia.Current.Initialize();

                var source = await Application.Current.MainPage.DisplayActionSheet(
                    "¿Donde tomas la foto?",
                    "Cancelar",
                    null,
                    "De la galería",
                    "Desde camara");

                if (source == "Cancelar")
                {
                    this.file = null;
                    return;
                }

                if (source == "Desde camara")
                {
                    this.file = await CrossMedia.Current.TakePhotoAsync(
                        new StoreCameraMediaOptions
                        {
                            Directory = "Sample",
                            Name = "photo.jpg",
                            PhotoSize = PhotoSize.Small,
                        }
                    );
                }
                else
                {
                    this.file = await CrossMedia.Current.PickPhotoAsync();
                }

                if (this.file != null)
                {
                    this.ImageSource = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        return stream;
                    });
                    Avatar = file.Path;
                    ImageSource = Avatar;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        async Task GetListUserAsync()
        {
            var result = await api.GetrespondeAsync<UsersModel>("users?_format=json&access-token=b8c_No_smaFpiwClC-Rsy5KUAOi3SjF_7uzr", new Token { access_token = "Bearer b8c_No_smaFpiwClC-Rsy5KUAOi3SjF_7uzr", type_token = "json" });
            if (!result.IsSuccess)
            {
                return;
            }

            var users = result.Result as UsersModel;
            ListUsers = new ObservableCollection<Result>(users.result.Select(s => new Result
            {
                address = s.address,
                dob = s.dob,
                email = s.email,
                first_name = s.first_name,
                gender = s.gender,
                id = s.id,
                last_name = s.last_name,
                phone = s.phone,
                status = s.status,
                website = s.website,
                _links = s._links
            }).OrderBy(o => o.first_name).ToList());
        }

        async Task AddUserAsync()
        {
            if (string.IsNullOrEmpty(Avatar))
            {
                await Application.Current.MainPage.DisplayAlert("Validaciôn", "Debe ingresar una Imagen.", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(Nombre))
            {
                await Application.Current.MainPage.DisplayAlert("Validaciôn", "Debe ingresar el Nombre.", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(Apellido))
            {
                await Application.Current.MainPage.DisplayAlert("Validaciôn", "Debe ingresar el Apellido.", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(Telefono))
            {
                await Application.Current.MainPage.DisplayAlert("Validaciôn", "Debe ingresar el Teléfono.", "Ok");
                return;
            }

            await App.Navigator.PushAsync(new ListaUsuariosPage());
            Instancia.ListUsers.Add(new Result { first_name = Nombre, last_name = Apellido, phone = Telefono });
        }
        #endregion
    }
}
