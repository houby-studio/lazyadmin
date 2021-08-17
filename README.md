# Lazy Admin

Welcome to the new Lazy Admin project. Here we will once again try to learn from our previous project to deliver better, cleaner, faster... product!
This time around we will try it in better suited and more promising technologies called .NET (Just like PowerShell, yay!) and potentially Edge WebView2!

## News

At first we have tried to write our awesome Lazy Admin with WinUI3, but due to lack of documentation, online help and visual UI designer in Visual Studio we have quickly decided to drop that idea and try it with WPF instead.

## Overview

TODO:

### .NET advantages

* Faster
* PowerShell is built on .NET

## Development

### Setting up

We will setup both VSCode and Visual Studio as our development tools. We want to use VSCode as much as possible, but unless we want to design GUI by writing code, we need to use Visual Studio as well.  

__Note: Installing Visual Studio will also install some dependencies for the project, which will be utilized by the VSCode as well.__

#### Visual Studio

* Install
  * .NET Desktop Development
* Enable NuGet Package source

#### Visual Studio Code

* Install following extensions (not all are required, but helpful):
  * C# - ms-dotnettools.csharp
  * Docker - ms-azuretools.vscode-docker
  * PowerShell - ms-vscode.powershell
  * JS-CSS-HTML Formatter - lonefy.vscode-js-css-html-formatter
  * Markdown ALl in One - yzhang.markdown-all-in-one
  * markdownlint - davidanson.vscode-markdownlint
* TODO: Project has to have [launch.json](launch.json)

#### Other tools

This is the list of other helpful software we have installed on our development machines.

* **.NET 5 SDK x64 (Required!)**
* **WebView2 Runtime (Required!)**
* Github Desktop - Recommended for version control
* Git - Recommended for version control
* Docker desktop

#### Create Visual Studio project

We are following this guide how to [setup new WPF project](https://docs.microsoft.com/en-us/microsoft-edge/webview2/get-started/wpf).

* [Start Visual Studio](https://docs.microsoft.com/en-us/windows/apps/windows-app-sdk/set-up-your-development-environment)
* Create new project
* WPF .NET Core App
* HoubyStudio.LazyAdmin.DesktopApp

#### Notes

* To release production-ready product, it is recommended to production release on **stable SDK** and **WebView2 Runtime**
* Regularly test against both WebView2 Runtime and Microsoft Edge preview channel (**Canary**) as new features are getting added constantly

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
