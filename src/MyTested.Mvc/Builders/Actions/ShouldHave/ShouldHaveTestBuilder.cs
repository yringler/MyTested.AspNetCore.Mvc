﻿namespace MyTested.Mvc.Builders.Actions.ShouldHave
{
    using Base;
    using Contracts.Actions;
    using Contracts.Http;
    using Http;
    using Utilities.Validators;
    using Internal.TestContexts;
    using Contracts.And;
    using System;

    /// <summary>
    /// Used for testing action attributes and controller properties.
    /// </summary>
    /// <typeparam name="TActionResult">Result from invoked action in ASP.NET MVC controller.</typeparam>
    public partial class ShouldHaveTestBuilder<TActionResult>
        : BaseTestBuilderWithActionResult<TActionResult>, IShouldHaveTestBuilder<TActionResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShouldHaveTestBuilder{TActionResult}" /> class.
        /// </summary>
        /// <param name="controller">Controller on which the action will be tested.</param>
        /// <param name="actionName">Name of the tested action.</param>
        /// <param name="caughtException">Caught exception during the action execution.</param>
        /// <param name="actionResult">Result from the tested action.</param>
        /// <param name="actionAttributes">Collected action attributes from the method call.</param>
        public ShouldHaveTestBuilder(ControllerTestContext testContext)
            : base(testContext)
        {
        }

        /// <summary>
        /// Checks whether the tested action applies additional features to the HTTP response.
        /// </summary>
        /// <returns>Test builder with AndAlso method.</returns>
        public IAndTestBuilder<TActionResult> HttpResponse(Action<IHttpResponseTestBuilder> httpResponseTestBuilder)
        {
            CommonValidator.CheckForException(this.CaughtException);
            
            httpResponseTestBuilder(new HttpResponseTestBuilder(this.TestContext));

            return this.NewAndTestBuilder();
        }
    }
}
