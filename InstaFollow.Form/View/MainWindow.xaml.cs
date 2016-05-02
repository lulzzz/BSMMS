﻿using System.ComponentModel;
using InstaFollow.Core.Factory;
using InstaFollow.Core.UI;
using InstaFollow.Core.UI.View;
using InstaFollow.Core.UI.ViewModel;

namespace InstaFollow.Form.View
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : BaseWindow
	{
		public MainViewModel ViewModel { get; set; }

		public MainWindow()
		{
			this.InitializeComponent();
		}

		public override void AttachContext(IBaseViewModel viewModel)
		{
			this.ViewModel = viewModel as MainViewModel;
			this.ViewModel.Init();

			this.DataContext = this.ViewModel;
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			this.ViewModel.HandleCloseEvent();

			base.OnClosing(e);
		}
	}
}
