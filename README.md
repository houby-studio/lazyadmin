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

### Links

* [Docs](https://docs.microsoft.com/en-us/microsoft-edge/webview2/#get-started)
* [Github Examples](https://github.com/MicrosoftEdge/WebView2Samples#net-wpf-and-windows-forms)
* [NuGet package](https://www.nuget.org/packages/Microsoft.Web.WebView2)
* [Understand WebView2 SDK versions](https://docs.microsoft.com/en-us/microsoft-edge/webview2/concepts/versioning)
* [Switch to a preview channel to test upcoming APIs and features](https://docs.microsoft.com/en-us/microsoft-edge/webview2/how-to/set-preview-channel)
* [Distribute a WebView2 app and the WebView2 Runtime](https://docs.microsoft.com/en-us/microsoft-edge/webview2/concepts/distribution)
* [Best practices for developing secure WebView2 applications](https://docs.microsoft.com/en-us/microsoft-edge/webview2/concepts/security)
* [Manage the user data folder](https://docs.microsoft.com/en-us/microsoft-edge/webview2/concepts/user-data-folder)
* [Get started debugging WebView2 apps](https://docs.microsoft.com/en-us/microsoft-edge/webview2/how-to/debug?tabs=visualstudiocode)
* [Get started with WebView2 in WinUI 3 (Windows App SDK)](https://docs.microsoft.com/en-us/microsoft-edge/webview2/get-started/winui)
* [Create your first WinUI 3 app](https://docs.microsoft.com/en-us/windows/apps/winui/winui3/create-your-first-winui3-app?tabs=desktop-csharp)

### Setting up

#### Visual Studio

* Install [Visual Studio](https://docs.microsoft.com/en-us/windows/apps/windows-app-sdk/set-up-your-development-environment)
  * Universal Windows Platform development
  * Desktop development with C++
  * .NET Desktop Development
  * Windows 10 SDK (10.0.19041.0)
  * C++ (v142) Universal Windows Platform tools
* Enable NuGet Package source
* Install the Windows App SDK extension for Visual Studio

#### Visual Studio Code

* Project has to have [launch.json](launch.json), which is already present in this project.

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
