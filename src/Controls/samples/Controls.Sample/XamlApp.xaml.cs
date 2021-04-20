﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Maui.Controls.Sample.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample
{
	public partial class XamlApp : Application
	{
		public XamlApp(IServiceProvider services, ITextService textService, IList<IWindow> windows)
		{
			InitializeComponent();

			Services = services;

			Debug.WriteLine($"The .NET Purple color is {Resources["DotNetPurple"]}");
			Debug.WriteLine($"The injected text service had a message: '{textService.GetText()}'");
		}

		public IServiceProvider Services { get; }

		public override IWindow CreateWindow(IActivationState activationState)
		{
			Microsoft.Maui.Controls.Compatibility.Forms.Init(activationState);

			return Services.GetRequiredService<IWindow>();
		}
	}
}