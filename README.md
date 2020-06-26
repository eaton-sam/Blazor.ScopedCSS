# Blazor.ScopedCSS
Blazor library for scoping CSS styles to a component.

**Note: this is purely experimental, I would not recommend using this in a production app. 
Changes to rendering in Blazor will probably break the style extraction at some point in the future.**

Usage:

Register services in Startup
```csharp
services.AddScopedCSS();
```

Add the namespace to your _Imports file
```csharp
@using ScopedCSS
```

Add ScopedRenderer component to your layout
```html
<ScopedRenderer />
```

Use ScopedComponent inside your blazor component:
```html
<ScopedComponent>
  <Style>
    h1 {
      color: red;
    }
    button {
      background: cyan;
    }
  </Style>
  <Content>
    <h1>H1's are red only here!</h1>
    <button>Click this blue button</button>
  </Content>
</ScopedComponent>
```
