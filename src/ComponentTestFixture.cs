﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Egil.RazorComponents.Testing.Extensions;
using Microsoft.AspNetCore.Components;
using EC = Microsoft.AspNetCore.Components.EventCallback;

namespace Egil.RazorComponents.Testing
{
    /// <summary>
    /// Base class for test classes that contains XUnit Razor component tests.
    /// </summary>
    public abstract class ComponentTestFixture : TestContext
    {
        /// <summary>
        /// Creates a <see cref="ComponentParameter"/> with an <see cref="Microsoft.AspNetCore.Components.EventCallback"/> as parameter value 
        /// for this <see cref="TestContext"/> and
        /// <paramref name="callback"/>.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="callback">The event callback.</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        protected ComponentParameter EventCallback(string name, Action callback)
        {
            return ComponentParameter.CreateParameter(name, EC.Factory.Create(this, callback));
        }

        /// <summary>
        /// Creates a <see cref="ComponentParameter"/> with an <see cref="Microsoft.AspNetCore.Components.EventCallback"/> as parameter value for this <see cref="TestContext"/> and
        /// <paramref name="callback"/>.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="callback">The event callback.</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        protected ComponentParameter EventCallback(string name, Action<object> callback)
        {
            return ComponentParameter.CreateParameter(name, EC.Factory.Create(this, callback));
        }

        /// <summary>
        /// Creates a <see cref="ComponentParameter"/> with an <see cref="Microsoft.AspNetCore.Components.EventCallback"/> as parameter value for this <see cref="TestContext"/> and
        /// <paramref name="callback"/>.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="callback">The event callback.</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        protected ComponentParameter EventCallback(string name, Func<Task> callback)
        {
            return ComponentParameter.CreateParameter(name, EC.Factory.Create(this, callback));
        }

        /// <summary>
        /// Creates a <see cref="ComponentParameter"/> with an <see cref="Microsoft.AspNetCore.Components.EventCallback"/> as parameter value for this <see cref="TestContext"/> and
        /// <paramref name="callback"/>.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="callback">The event callback.</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        protected ComponentParameter EventCallback(string name, Func<object, Task> callback)
        {
            return ComponentParameter.CreateParameter(name, EC.Factory.Create(this, callback));
        }

        /// <summary>
        /// Creates a <see cref="ComponentParameter"/> with an <see cref="Microsoft.AspNetCore.Components.EventCallback"/> as parameter value for this <see cref="TestContext"/> and
        /// <paramref name="callback"/>.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="callback">The event callback.</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        protected ComponentParameter EventCallback<TValue>(string name, Action callback)
        {
            return ComponentParameter.CreateParameter(name, EC.Factory.Create<TValue>(this, callback));
        }

        /// <summary>
        /// Creates a <see cref="ComponentParameter"/> with an <see cref="Microsoft.AspNetCore.Components.EventCallback"/> as parameter value for this <see cref="TestContext"/> and
        /// <paramref name="callback"/>.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="callback">The event callback.</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        protected ComponentParameter EventCallback<TValue>(string name, Action<TValue> callback)
        {
            return ComponentParameter.CreateParameter(name, EC.Factory.Create<TValue>(this, callback));
        }

        /// <summary>
        /// Creates a <see cref="ComponentParameter"/> with an <see cref="Microsoft.AspNetCore.Components.EventCallback"/> as parameter value for this <see cref="TestContext"/> and
        /// <paramref name="callback"/>.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="callback">The event callback.</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        protected ComponentParameter EventCallback<TValue>(string name, Func<Task> callback)
        {
            return ComponentParameter.CreateParameter(name, EC.Factory.Create<TValue>(this, callback));
        }

        /// <summary>
        /// Creates a <see cref="ComponentParameter"/> with an <see cref="Microsoft.AspNetCore.Components.EventCallback"/> as parameter value for this <see cref="TestContext"/> and
        /// <paramref name="callback"/>.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="callback">The event callback.</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        protected ComponentParameter EventCallback<TValue>(string name, Func<TValue, Task> callback)
        {
            return ComponentParameter.CreateParameter(name, EC.Factory.Create<TValue>(this, callback));
        }

        /// <summary>
        /// Creates a component parameter which can be passed to a test contexts render methods.
        /// </summary>
        /// <param name="name">Parameter name</param>
        /// <param name="value">Value or null of the parameter</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        protected static ComponentParameter Parameter(string name, object? value)
        {
            return ComponentParameter.CreateParameter(name, value);
        }

        /// <summary>
        /// Creates a cascading value which can be passed to a test contexts render methods.
        /// </summary>
        /// <param name="name">Parameter name</param>
        /// <param name="value">Value of the parameter</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        protected static ComponentParameter CascadingValue(string name, object value)
        {
            return ComponentParameter.CreateCascadingValue(name, value);
        }

        /// <summary>
        /// Creates a cascading value which can be passed to a test contexts render methods.
        /// </summary>
        /// <param name="value">Value of the parameter</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        protected static ComponentParameter CascadingValue(object value)
        {
            return ComponentParameter.CreateCascadingValue(null, value);
        }

        /// <summary>
        /// Creates a ChildContent <see cref="ComponentParameter"/> with the provided <paramref name="markup"/> as the <see cref="RenderFragment"/>.
        /// </summary>
        /// <param name="markup">Markup to pass to the child content parameter</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        protected static ComponentParameter ChildContent(string markup)
        {
            return ComponentParameter.CreateParameter(nameof(ChildContent), markup.ToMarkupRenderFragment());
        }

        /// <summary>
        /// Creates a ChildContent <see cref="RenderFragment"/> which will render a <typeparamref name="TComponent"/> component
        /// with the provided <paramref name="parameters"/> as input.
        /// </summary>
        /// <typeparam name="TComponent">The type of the component to render with the <see cref="RenderFragment"/></typeparam>
        /// <param name="parameters">Parameters to pass to the <typeparamref name="TComponent"/>.</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        protected static ComponentParameter ChildContent<TComponent>(params ComponentParameter[] parameters) where TComponent : class, IComponent
        {
            return ComponentParameter.CreateParameter(nameof(ChildContent), parameters.ToComponentRenderFragment<TComponent>());
        }
    }
}
