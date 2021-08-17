# Lazy Admin

Welcome to the new Lazy Admin project. Here we will once again try to learn from our previous project to deliver better, cleaner, faster... product!
This time around we will try it in better suited and more promising technologies called .NET (Just like PowerShell, yay!) and Edge WebView2!

## Overview

TODO:

### .NET advantages

* Faster
* PowerShell is built on .NET

### Edge WebView2 advantages

* Does not eat all the available resources
* Web ecosystem & skillset
* Rapid innovation
* Windows 7, 8, and 10 support
* Native capabilities
* Code-sharing
* Microsoft support
* Evergreen distribution
* Fixed Version distribution
* Incremental adoption

## Development

### Setting up

We will setup both VSCode and Visual Studio as our development tools. We want to use VSCode as much as  possible, but unless we want to design GUI by writing code, we need to use Visual Studio as well.  

__Note: Installing Visual Studio will also install some dependencies for the project, which will be utilized by the VSCode as well.__

#### Visual Studio

* Install
  * Universal Windows Platform development
  * Desktop development with C++
  * .NET Desktop Development
  * Windows 10 SDK (10.0.19041.0)
  * C++ (v142) Universal Windows Platform tools
* Enable NuGet Package source
* Install the Windows App SDK extension for Visual Studio (Project Reunion)

#### Visual Studio Code

* Install following extensions (not all are required, but helpful):
  * C# - ms-dotnettools.csharp
  * Docker - ms-azuretools.vscode-docker
  * PowerShell - ms-vscode.powershell
  * JS-CSS-HTML Formatter - lonefy.vscode-js-css-html-formatter
  * Markdown ALl in One - yzhang.markdown-all-in-one
  * markdownlint - davidanson.vscode-markdownlint
* TODO: Project has to have [launch.json](launch.json), which is already present in this project.

#### Other tools

This is the list of other helpful software we have installed on our development machines.

* **.NET 5 SDK x64 (Required!)**
* **WebView2 Runtime (Required!)**
* Github Desktop - Recommended for version control
* Git - Recommended for version control
* Docker desktop

#### Create Visual Studio project

We are following this guide how to [setup new WinUI3 project][10].

* [Start Visual Studio][12]
* Create new project
* Blank App, Packaged (WinUI in Desktop)
* lazyadmin (Windows 10 2004)

*

#### Notes

* To test latest features, it is recommended to develop on **prerelease SDK** and **preview channel of Microsoft Edge**
* To release production-ready product, it is recommended to production release on **stable SDK** and **WebView2 Runtime**
* Regularly test against both WebView2 Runtime and Microsoft Edge preview channel (**Canary**) as new features are getting added constantly
* We can choose from both WPF and WinUI3 - we will try to use the latest option that is WinUI3. If it fails, we will fallback to UWP.

## License

MIT License

Copyright (c) 2021 Houby Studio

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

[1]: <https://docs.microsoft.com/en-us/microsoft-edge/webview2/#get-started> "Docs"
[2]: <https://github.com/MicrosoftEdge/WebView2Samples#net-wpf-and-windows-forms> "Github Examples"
[3]: <https://www.nuget.org/packages/Microsoft.Web.WebView2> "NuGet package"
[4]: <https://docs.microsoft.com/en-us/microsoft-edge/webview2/concepts/versioning> "Understand WebView2 SDK versions"
[5]: <https://docs.microsoft.com/en-us/microsoft-edge/webview2/how-to/set-preview-channel> "Switch to a preview channel to test upcoming APIs and features"
[6]: <https://docs.microsoft.com/en-us/microsoft-edge/webview2/concepts/distribution> "Distribute a WebView2 app and the WebView2 Runtime"
[7]: <https://docs.microsoft.com/en-us/microsoft-edge/webview2/concepts/security> "Best practices for developing secure WebView2 applications"
[8]: <https://docs.microsoft.com/en-us/microsoft-edge/webview2/concepts/user-data-folder> "Manage the user data folder"
[9]: <https://docs.microsoft.com/en-us/microsoft-edge/webview2/how-to/debug?tabs=visualstudiocode> "Get started debugging WebView2 apps"
[10]: <https://docs.microsoft.com/en-us/microsoft-edge/webview2/get-started/winui> "Get started with WebView2 in WinUI 3 (Windows App SDK)"
[11]: <https://docs.microsoft.com/en-us/windows/apps/winui/winui3/create-your-first-winui3-app?tabs=desktop-csharp> "Create your first WinUI 3 app"
[12]: <https://docs.microsoft.com/en-us/windows/apps/windows-app-sdk/set-up-your-development-environment> "Install tools for Windows app development"
[13]: <https://github.com/MicrosoftEdge/WebView2Samples/tree/master/SampleApps/WebView2WpfBrowser> "WebView2 WPF Browser"
