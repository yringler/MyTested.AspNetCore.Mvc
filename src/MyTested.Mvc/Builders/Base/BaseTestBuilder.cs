﻿namespace MyTested.Mvc.Builders.Base
{
    using Contracts.Base;
    using Utilities.Validators;
    using Microsoft.AspNet.Mvc;
    using System.Collections.Generic;
    using Microsoft.AspNet.Http;

    public class BaseTestBuilder : IBaseTestBuilder
    {
        private Controller controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTestBuilder" /> class.
        /// </summary>
        /// <param name="controller">Controller on which will be tested.</param>
        /// <param name="controllerAttributes">Collected attributes from the tested controller.</param>
        protected BaseTestBuilder(
            Controller controller,
            IEnumerable<object> controllerAttributes = null)
        {
            this.Controller = controller;
            this.ControllerLevelAttributes = controllerAttributes;
        }

        /// <summary>
        /// Gets the controller on which the action will be tested.
        /// </summary>
        /// <value>Controller on which the action will be tested.</value>
        internal Controller Controller
        {
            get
            {
                return this.controller;
            }

            private set
            {
                CommonValidator.CheckForNullReference(value, errorMessageName: "Controller");
                this.controller = value;
            }
        }

        internal IEnumerable<object> ControllerLevelAttributes { get; private set; }

        /// <summary>
        /// Gets the controller on which the action is tested.
        /// </summary>
        /// <returns>ASP.NET MVC 6 controller on which the action is tested.</returns>
        public Controller AndProvideTheController()
        {
            return this.Controller;
        }

        /// <summary>
        /// Gets the HTTP request message with which the action will be tested.
        /// </summary>
        /// <returns>HttpRequest from the tested controller.</returns>
        public HttpRequest AndProvideTheHttpRequest()
        {
            return this.Controller.Request;
        }

        /// <summary>
        /// Gets the HTTP context with which the action will be tested.
        /// </summary>
        /// <returns>HttpContext from the tested controller.</returns>
        public HttpContext AndProvideTheHttpContext()
        {
            return this.Controller.HttpContext;
        }

        /// <summary>
        /// Gets the attributes on the tested controller.
        /// </summary>
        /// <returns>IEnumerable of object representing the attributes or null, if no attributes were collected on the controller.</returns>
        public IEnumerable<object> AndProvideTheControllerAttributes()
        {
            return this.ControllerLevelAttributes;
        }
    }
}