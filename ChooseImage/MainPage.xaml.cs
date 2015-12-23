using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ChooseImage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void btnChoose_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // representa un elemento GUI para poder seleccionar archivos
            FileOpenPicker opener = new FileOpenPicker();

            // indicamos una ruta para empezar a buscar en ella
            opener.SuggestedStartLocation = PickerLocationId.PicturesLibrary;

            // se establecen las extensiones de los archivos que deseamos buscar
            opener.FileTypeFilter.Add(".jpg");
            opener.FileTypeFilter.Add(".jpeg");
            opener.FileTypeFilter.Add(".png");

            // representa un archivo , brinda información del archivo y su contenido además de que permite manipularlo
            StorageFile storageFile = await opener.PickSingleFileAsync();

            // se verifica si se ha seleccionado un archivo
            if (storageFile != null)
            {
                // abrimos el archivo en modo lectura
                var stream = await storageFile.OpenAsync(Windows.Storage.FileAccessMode.Read);

                
                BitmapImage bitmapImage = new BitmapImage();

                // se establece el recurso como imagen
                await bitmapImage.SetSourceAsync(stream);

                // establecemos la imagen seleccionada en el preview
                imgPreview.Source = bitmapImage;


            }

        }
    }
}
