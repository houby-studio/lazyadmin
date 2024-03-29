﻿# Lazy Admin

Welcome to the new Lazy Admin project. We have decided to try to learn from our previous project and deliver better, cleaner, faster tool for administrators!
This time around we do it with better suited and more promising technologies. Application's main code is written in .NET (Just like **PowerShell**, yay!), UI is being rendered using Edge WebView2, which displays stylish UI built with Quasar, just like previous Lazy Admin.

## Changes

* At first we have tried to write our awesome Lazy Admin with WinUI3, but due to lack of documentation, online help and visual UI designer in Visual Studio we have quickly decided to drop that idea and try it with WPF instead.
* We can try to utilize former Lazy Admin's UI. Afterall it is the thing we have spent most time on. WebView2 should be able to easily serve those files. If this proves as best solution, we will probably keep C# and JS code in separate repositories (e.g. rename lazy-admin to lazyadmin-ui).
* Former Lazy Admin has many calls to electron and filesystem, registry etc. It will take some cleanup before we can import files as SPA to new Lazy Admin. But we will do it!
* Former Lazy Admin's UI was built using Quasar v1, which used Vue v2. We have to keep things up to date, so we will migrate whole UI to latest Quasar v2 using Vue v3, which brings many breaking changes. It will be way harder than first expected.

## Overview

TODO:

### .NET advantages

* Faster
* PowerShell is built on .NET
* We will utilize proper .NET library for PowerShell handling, which will be way more reliable than process stdin and stdout parsing with javascript.

## Development

### Setting up

We will setup both VSCode and Visual Studio as our development tools. We want to use VSCode as much as possible, but unless we want to design GUI by writing code, we need to use Visual Studio as well.  
For Lazy Admin's UI, visit it's [Lazy Admin UI repository](https://github.com/houby-studio/lazyadmin-ui).

__Note: Installing Visual Studio will also install some dependencies for the project, which will be utilized by the VSCode as well.__

#### Visual Studio

* Install
  * .NET Desktop Development
* Enable NuGet Package source
* Install NuGet package `Microsoft.Web.WebView2`

#### Visual Studio Code

Note: Visual Studio builds currently do not work.

* Install following extensions (not all are required, but helpful):
  * C# - ms-dotnettools.csharp
  * Docker - ms-azuretools.vscode-docker
  * PowerShell - ms-vscode.powershell
  * JS-CSS-HTML Formatter - lonefy.vscode-js-css-html-formatter
  * Markdown ALl in One - yzhang.markdown-all-in-one
  * markdownlint - davidanson.vscode-markdownlint
* TODO: Project has to have [launch.json](launch.json)

#### Quasar CLI

To be moved to lazyadmin-ui repository.

* [Install Node.js](https://nodejs.org/en/)
  * We have installed `14.17.5 LTS` for `Windows (x64)` and installed other `necessary tools` within setup (chocolatey, python3, etc.)
* [Install yarn](https://classic.yarnpkg.com/en/docs/install)
  * `npm install --global yarn`
* [Install Quasar CLI](https://quasar.dev/quasar-cli/installation)
  * `yarn global add @quasar/cli`
  * Add `%LOCALAPPDATA%\yarn\bin` to your user PATH

#### Other tools

This is the list of other helpful software we have installed on our development machines.

* **.NET 5 SDK x64 (Required!)**
* **WebView2 Runtime (Required!)**
* Github Desktop - Recommended for version control
* Git - Recommended for version control
* Docker desktop

#### Contributing

To be moved to CONTRIBUTING

This project strictly follows code rules from [StyleCopAnalyzers](https://github.com/DotNetAnalyzers/StyleCopAnalyzers). If you want to contribute, please resolve all rule violations, otherwise the automated build will fail.

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
