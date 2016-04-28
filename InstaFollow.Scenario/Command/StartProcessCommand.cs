﻿using System;
using System.Threading;
using InstaFollow.Core.Container;
using InstaFollow.Core.Context;
using InstaFollow.Core.Enum;
using InstaFollow.Core.Exceptions;
using InstaFollow.Scenario.Strategy;
using log4net;

namespace InstaFollow.Scenario.Command
{
	public class StartProcessCommand : BaseContextCommand<IExploreContext>
	{
		/// <summary>
		/// Prevents a default instance of the <see cref="StartProcessCommand"/> class from being created.
		/// </summary>
		private StartProcessCommand() { }

		/// <summary>
		/// Executes the command scenario.
		/// Called by UI.
		/// </summary>
		/// <param name="obj">An object. (currently not used, so it is null).</param>
		/// <exception cref="InstagramException">An error occured during login!</exception>
		public override void Execute(object obj)
		{
			var strategy = new ExploreStrategy(this.CurrentContext, InstagramHttpContainer.Instance);
			new Thread(() => strategy.Explore()).Start();
		}

		/// <summary>
		/// Evaluates if this command can be executed or not.
		/// </summary>
		/// <returns>True if execution is allowed, false otherwise.</returns>
		protected internal override bool EvaluateCanExecute()
		{
			return !string.IsNullOrEmpty(this.CurrentContext.UserName) &&
				 !string.IsNullOrEmpty(this.CurrentContext.Password) &&
					  !string.IsNullOrEmpty(this.CurrentContext.Keywords) &&
					  this.CurrentContext.ProcessState != ProcessState.Running &&
						(this.CurrentContext.Like || this.CurrentContext.Follow || this.CurrentContext.Comment);
		}
	}
}
