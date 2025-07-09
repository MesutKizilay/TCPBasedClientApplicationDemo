using LeibingerControlCenter.Business.Abstract;
using LeibingerControlCenter.Business.Concrete;
using LeibingerControlCenter.DataAccess.Abstract;
using LeibingerControlCenter.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Sockets;
using System.Text;

namespace LeibingerControlCenterUI
{
    internal static class Program
    {
        private static IServiceProvider ServiceProvider { get; set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            IHost _host = Host.CreateDefaultBuilder()
                              .ConfigureAppConfiguration(config =>
                              {
                                  config.SetBasePath(AppContext.BaseDirectory)
                                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                        .Build();
                              })
                              .ConfigureServices((context, services) =>
                              {
                                  services.AddTransient<IFileManager, FileManager>();
                                  services.AddTransient<IClientService, ClientManager>();
                                  services.AddTransient<IClientDal, ClientDal>();
                                  services.AddTransient<TcpClient>();

                                  var connectionString = context.Configuration.GetConnectionString("LeibingerConnection");

                                  // DbContext'i DI container'a ekle
                                  services.AddDbContext<LeibingerContext>(options =>
                                      options.UseSqlServer(connectionString));

                                  services.AddTransient<Form1>();
                              }).Build();

            var mainForm = _host.Services.GetRequiredService<Form1>();


            //var serviceCollection = new ServiceCollection();
            //ConfigureServices(serviceCollection);
            //ServiceProvider = serviceCollection.BuildServiceProvider();

            //var mainForm = ServiceProvider.GetRequiredService<Form1>();

            Application.Run(mainForm);
        }

        private static void ConfigureServices(ServiceCollection serviceCollection)
        {
            var config = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
                                                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                                   .Build();

            serviceCollection.AddTransient<Form1>();

            serviceCollection.AddTransient<IClientService, ClientManager>();
            serviceCollection.AddTransient<TcpClient>();
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {// All exceptions thrown by the main thread are handled over this method
            Exception ex = (Exception)e.Exception;
            ShowExceptionDetails(e.Exception.GetBaseException());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {// All exceptions thrown by additional threads are handled in this method

            ShowExceptionDetails(e.ExceptionObject as Exception);

            // Suspend the current thread for now to stop the exception from throwing.
            Thread.CurrentThread.Suspend();
        }

        static void ShowExceptionDetails(Exception exception)
        {
            //MessageBox.Show(exception.Message);
            MessageBox.Show(exception.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //LogHelper.LogError(exception);
        }
    }
}