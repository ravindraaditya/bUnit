---
uid: passing-parameters-to-components
title: Passing Parameters to a Component Under Test
---

# Passing Parameters to a Component Under Test

bUnit comes with a bunch of ways to pass parameters to a component under test. 

In Razor-based tests, those written in `.razor` files, passing parameters is exactly the same as in your normal Blazor pages and components, i.e. through the normal Razor syntax, so this parameter passing style will not be covered here. Instead, this page will cover passing parameters in C# code.

For C#-based test code, you can:

- use loosely typed factory methods
- use a simple tuple-based syntax, i.e. `(name, value)`
- use a strongly typed builder (still experimental)

There are two methods in bUnit that allows passing parameters:

- `RenderComponent` on the test context
- `SetParametersAndRender` on a rendered component

In the following sub sections we will show each style, just click between them using the tabs.

> [!TIP]
> In all examples below, the <xref:Bunit.ComponentParameterFactory> is imported into the test class using `using static Bunit.ComponentParameterFactory;`. This results in a lot less boilerplate code, which improves test readability.

> [!NOTE]
> The examples below are written using xUnit, but the code is the same with NUnit and MSTest.

## Regular Parameters

A regular parameters is one that is declared using the `[Parameter]` attribute. 

First, let's look at an example of passing parameter that takes types which or _not_ special to Blazor, i.e.:

[!code-csharp[AllKindsOfParams.razor](../../samples/components/AllKindsOfParams.razor#L3-L7)]

Using either C# tuples, a factory method or the parameter builder, this can be done like this:

[!code-csharp[AllKindsOfParamsTest.cs](../../samples/tests/xunit/AllKindsOfParamsTest.cs#L17-L39)]

All of these examples does the same thing, here is what is going on:

1. The first example, passes parameters using C# tuples, `(string name, object? value)`.
2. The second example also uses C# tuples to pass the parameters, but the name is retrieved in a refactor safe manner using the `nameof` keyword in C#.
3. The third example uses the <xref:Bunit.ComponentParameterFactory.Parameter(System.String,System.Object)> factory method.
4. The last example uses the <xref:Bunit.ComponentParameterBuilder`1>'s `Add` method, which takes a parameter selector expression that selects the parameter using a lambda, and forces you to provide the correct type for the value. This makes the builders methods strongly typed and refactor safe.

### EventCallback

### ChildContent

### RenderFragment

### Templates

### Unmatched Parameters

## Cascading Value Parameters

## Render Component Test inside other Components

## Further Reading

- <xref:inject-services-into-components>