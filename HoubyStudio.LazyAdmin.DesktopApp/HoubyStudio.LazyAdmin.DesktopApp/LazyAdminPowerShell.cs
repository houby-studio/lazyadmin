// <copyright file="LazyAdminPowerShell.cs" company="Houby Studio">
// Copyright (c) Houby Studio. All rights reserved.
// </copyright>

namespace HoubyStudio.LazyAdmin.DesktopApp
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Controls;
    using System.Windows.Threading;
    using Microsoft.Web.WebView2.Core;
    using Newtonsoft.Json;

    /// <summary>
    /// Handles postMessage events received from EdgeView2 control.
    /// </summary>
    public class LazyAdminPowerShell
    {
        public TextBox MockPowerShell;
        // private Dispatcher dispatcher = Dispatcher.CurrentDispatcher;

        public void ReceiveMessage(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            this.MockPowerShell.Text = "Execution started";
            LazyAdminWebView.ShowMessage("Execution started");
            ////try
            ////{
            //// Open new runspace
            // runspacePool.Open();

            //// Create PowerShell object
            // PowerShell powerShell = PowerShell.Create();

            //// Assign PowerShell object to runspace
            // powerShell.RunspacePool = runspacePool;

            //// Command received from WebView
            // string data = args.WebMessageAsJson;

            //// Debug
            // MockPowerShell.Text = data;

            //// Add command to PowerShell object
            // powerShell.AddCommand("Get-Command");

            //// Invoke the command asynchronously.
            // IAsyncResult gpcAsyncResult = powerShell.BeginInvoke();
            //// Get the results of running the command.
            // PSDataCollection<PSObject> gpcOutput = powerShell.EndInvoke(gpcAsyncResult);
            ////}
            ////catch
            ////{
            ////    MockPowerShell.Text = "";
            ////}
            // runspacePool.Close();

            // TODO: If running command within JEA session
            // string computerName = "SERVER01";
            // string configName = "JEAMaintenance";
            // See https://docs.microsoft.com/dotnet/api/system.management.automation.pscredential

            // If running on local machine
            // Needs to run elevated to be able to remote on localhost
            // WSManConnectionInfo connectionInfo = new WSManConnectionInfo();

            //// If loading alternate credentials from credential store
            // System.Security.SecureString password = new();
            // PSCredential creds = new("test", password);// create a PSCredential object here

            //// Run with alternate credentials on remote host
            // WSManConnectionInfo connectionInfoRemoteCred = new WSManConnectionInfo(
            //    false,                 // Use SSL
            //    computerName,          // Computer name
            //    5985,                  // WSMan Port
            //    "/wsman",              // WSMan Path
            //                           // Connection URI with config name
            //    string.Format(CultureInfo.InvariantCulture, "http://schemas.microsoft.com/powershell/{0}", configName),
            //    creds);                // Credentials

            //// Run with default credentials on remote host
            // WSManConnectionInfo connectionInfoRemoteDefaultCred = new WSManConnectionInfo(new Uri($"http://{computerName}:5985/WSMAN"));
            // connectionInfoRemoteDefaultCred.ShellUri = string.Format(CultureInfo.InvariantCulture, "http://schemas.microsoft.com/powershell/{0}", configName);

            // Now, use the connection info to create a runspace where you can run the commands
            using (Runspace runspace = RunspaceFactory.CreateRunspace(/*connectionInfo*/))
            {
                // Open the runspace
                runspace.Open();

                using (PowerShell ps = PowerShell.Create())
                {
                    var receivedJson = JsonConvert.DeserializeObject<ExecutePowerShellMessage>(args.WebMessageAsJson);
                    var uid = receivedJson.Uid;
                    var command = receivedJson.Command;
                    // Set the PowerShell object to use the JEA runspace
                    // TODO: On creation pass runspace id or instanceId to webview, so it knows what to kill
                    // OR LazyAdminPowerShell could hold reference to each runspace associated to uid from WebView and communicate with identified runspace that way
                    ps.Runspace = runspace;

                    // Now you can add and invoke commands
                    _ = ps.AddCommand(command);

                    // Simple handle PowerShell async
                    // IAsyncResult gpcAsyncResult = ps.BeginInvoke();
                    //// Get the results of running the command.
                    // PSDataCollection<PSObject> gpcOutput = ps.EndInvoke(gpcAsyncResult);

                    // Simple handle PowerShell sync
                    // foreach (var result in ps.Invoke())
                    // {
                    //    Console.WriteLine(result);
                    //    MockPowerShell.Text += result;
                    // }

                    // Handle properly asyncwith events and all

                    // Add the event handlers.  If we did not care about hooking the DataAdded
                    // event, we would let BeginInvoke create the output stream for us.
                    PSDataCollection<PSObject> output = new();
                    // TODO: Extend DataAddedEventArgs and PSInvocationStateChangedEventArgs to pass uid and command
                    output.DataAdded += new EventHandler<DataAddedEventArgs>(this.Output_DataAdded);
                    ps.InvocationStateChanged += new EventHandler<PSInvocationStateChangedEventArgs>(this.Powershell_InvocationStateChanged);

                    // Invoke the pipeline asynchronously.
                    IAsyncResult asyncResult = ps.BeginInvoke<PSObject, PSObject>(null, output);

                    try
                    {
                        PSDataCollection<PSObject> gpcOutput = ps.EndInvoke(asyncResult);
                    }
                    catch
                    {
                    }

                    // This is how different thread may access function from main thread
                    // _ = System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    //  {
                    //      MainWindow.ShowMessageFromThread(uid);
                    //  }));
                    // This throws error
                    // LazyAdminWebView.ShowMessage("Endded invoke");

                    // Wait for things to happen. If the user hits a key before the
                    // script has completed, then call the PowerShell Stop() method
                    // to halt processing.
                    // Console.ReadKey();
                    // if (ps.InvocationStateInfo.State != PSInvocationState.Completed)
                    // {
                    //    // Stop the invocation of the pipeline.
                    //    Console.WriteLine("\nStopping the pipeline!\n");
                    //    ps.Stop();

                    // // Wait for the Windows PowerShell state change messages to be displayed.
                    //    System.Threading.Thread.Sleep(500);
                    //    Console.WriteLine("\nPress a key to exit");
                    //    Console.ReadKey();
                    // }
                }

                // Close the runspace
                runspace.Close();
            }
        }

        /// <summary>
        /// The output data added event handler. This event is called when
        /// data is added to the output pipe. It reads the data that is
        /// available and displays it on the console.
        /// </summary>
        /// <param name="sender">The output pipe this event is associated with.</param>
        /// <param name="e">Parameter is not used.</param>
        private void Output_DataAdded(object sender, DataAddedEventArgs e)
        {
            PSDataCollection<PSObject> myp = (PSDataCollection<PSObject>)sender;

            Collection<PSObject> results = myp.ReadAll();
            foreach (PSObject result in results)
            {
                _ = System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    // LazyAdminWebView.ShowMessage("Results obtained");
                    MainWindow.ShowMessageFromThread(Guid.NewGuid(), "Running");
                }));
                // LazyAdminWebView.ShowMessage("Result mate");
                // dispatcher.Invoke((Action)(() => MockPowerShell.Text = result + "`r`n"));
            }
        }

        /// <summary>
        /// This event handler is called when the pipeline state is changed.
        /// If the state change is to Completed, the handler issues a message
        /// asking the user to exit the program.
        /// </summary>
        /// <param name="sender">This parameter is not used.</param>
        /// <param name="e">The PowerShell state information.</param>
        private void Powershell_InvocationStateChanged(object sender, PSInvocationStateChangedEventArgs e)
        {
            // dispatcher.Invoke((Action)(() => MockPowerShell.Text = ("PowerShell object state changed: state: {0}\n", e.InvocationStateInfo.State) + "`r`n"));
            if (e.InvocationStateInfo.State == PSInvocationState.Completed)
            {
                // dispatcher.Invoke((Action)(() => MockPowerShell.Text = "Processing completed, press a key to exit!"));
                // MockPowerShell.Text = "Processing completed, press a key to exit!";
                _ = System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    LazyAdminWebView.ShowMessage("Finished");
                    MainWindow.ShowMessageFromThread(Guid.NewGuid(), "Completed");
                }));
            }
        }
    }
}
