﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualDesktopManager.Managers;

namespace VirtualDesktopManager.Controllers
{
    /// <summary>
    /// The main controller for the app - handles navigation between app-level processes.
    /// </summary>
    internal class AppController : SingletonController<AppController>
    {
        #region Properties
        /// <summary>
        /// The root page for app navigation.
        /// </summary>
        public MainWindow RootPage { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// Intended to be called upon app launch. Initializes app navigation.
        /// </summary>
        /// <param name="rootPage">The root page for this initialization of the app.</param>
        public void StartApp(MainWindow rootPage)
        {
            // Subscribe to the root page's events.

            // Set the given page as the root page.
            this.RootPage = rootPage;

            // Initialize the home page.
            this.InitializeHomePageAsync(rootPage);
        }

        /// <summary>
        /// Initializes the Home Page view.
        /// </summary>
        /// <returns></returns>
        public async Task InitializeHomePageAsync(MainWindow homePage)
        {
            // Get a list of the workspace names.
            List<string> workspaceNames = await WorkspaceDataManager.GetWorkspaces();

            // Set the view to display the workspaecs.
            homePage.DisplayWorkspaces(workspaceNames);
        }
        #endregion
    }
}