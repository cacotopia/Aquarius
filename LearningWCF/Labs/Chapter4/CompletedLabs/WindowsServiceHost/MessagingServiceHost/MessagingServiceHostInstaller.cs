// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration.Install;
using System.ComponentModel;
using System.ServiceProcess;

// To install or uninstall this Windows service:
//
//"C:\Program Files\Microsoft SDKs\Windows\v6.0\Bin\installutil.exe" /u WindowsServiceHost.exe
//"C:\Program Files\Microsoft SDKs\Windows\v6.0\Bin\installutil.exe" WindowsServiceHost.exe

namespace MessagingServiceHost
{
    [RunInstaller(true)]
    public class MessagingServiceHostInstaller : Installer
    {

        public MessagingServiceHostInstaller()
        {
            ServiceProcessInstaller processInstaller = new ServiceProcessInstaller();
            ServiceInstaller serviceInstaller = new ServiceInstaller();

            processInstaller.Account = ServiceAccount.NetworkService;

            serviceInstaller.DisplayName = "MessagingServiceHost";
            serviceInstaller.Description = "WCF service host for the Messaging.MessagingService.";
            serviceInstaller.ServiceName = "MessagingServiceHost";
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
