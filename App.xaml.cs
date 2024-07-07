using System.Configuration;
using System.Data;
using System.Windows;

namespace DMApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjI0MTIyQDMyMzAyZTMxMmUzME0zdGJYSmZlVVBkOWgrYTBPUmtrOG95TTZrL3p5a1lVQ2dldktqTjV1OEU9");
    }
}

