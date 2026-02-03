# ISeeUglyCode.Razor.PrettyIf

Stop breaking your HTML indentation with messy @if blocks. This library provides clean, attribute-based conditional rendering for ASP.NET Core Razor Pages and MVC.

Especially useful when you have a wrapping tag which should be conditional (see Usage section below, point 2).

Targets .NET 8 and .NET 10

## Installation

Install the package via the .NET CLI:

```bash
dotnet add package ISeeUglyCode.Razor.PrettyIf
```

## Setup

To enable the Tag Helpers in your project, add the following line to your Views/_ViewImports.cshtml (or Pages/_ViewImports.cshtml):

```razor
@addTagHelper *, ISeeUglyCode.Razor.PrettyIf
```

## Usage

### 1. Basic Conditional Rendering
The `pretty-if` attribute determines if the element (and its children) should be rendered.

```html
<div class="alert alert-danger" pretty-if="@Model.HasErrors">
    <strong>Error!</strong> Please check your input.
</div>
```

### 2. Transparent Wrappers (The "Link" Pattern)
Use `pretty-children` to remove the outer tag but keep the content inside if the condition is false.

```html
<a href="@Model.Website" 
   pretty-if="@(!string.IsNullOrEmpty(Model.Website))" 
   pretty-children>
    @Model.AuthorName
</a>
```

### 3. Complex Logic
You can pass any C# boolean expression into the attribute.

```html
<section pretty-if="@(Model.Items.Any() && User.Identity.IsAuthenticated)">
    <ul>
        @foreach(var item in Model.Items) {
            <li>@item.Name</li>
        }
    </ul>
</section>
```

### 4. Conditional output of the child elements
The `pretty-children` attribute can be set to a boolean expression as well. It defaults to `false`, and is ignored if `pretty-if` is `true`.

## Features
* **Deterministic Builds:** The DLL is byte-for-byte reproducible.
* **Source Link:** Debug directly into the library source code from GitHub.

## License
MIT
