using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace WPFClient.ViewModel
{

    public class ViewModelLocator
    {

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);


            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<EditSongViewModel>();
            SimpleIoc.Default.Register<EditAlbumViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public EditAlbumViewModel Album
        {
            get
            {
                //return new EditAlbumViewModel();
                return ServiceLocator.Current.GetInstance<EditAlbumViewModel>();
            }
        }

        public EditSongViewModel Song
        {
            get
            {
                //return new EditAlbumViewModel();
                return ServiceLocator.Current.GetInstance<EditSongViewModel>();
            }
        }

        public static void Cleanup()
        {

        }
    }
}