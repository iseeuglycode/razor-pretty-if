using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ISeeUglyCode.Razor.PrettyIf;

/// <summary>
/// Provides conditional rendering for HTML tags. 
/// Use this to avoid wrapping blocks of HTML in messy @if statements.
/// 
/// <para>Examples:</para>
/// <code>
/// // 1. Full Suppression (Default behavior)
/// // If 'show' is false, the div and the h1 vanish entirely.
/// &lt;div pretty-if="@show"&gt;&lt;h1&gt;Hello&lt;/h1&gt;&lt;/div&gt;
/// 
/// // 2. Transparent Wrapper
/// // If 'Model.HRef' is null or empty, the &lt;a&gt; tag is removed but "Click Me" remains.
/// &lt;a href="@Model.HRef" pretty-if="@(!string.IsNullOrEmpty(Model.HRef))" pretty-children&gt;Click Me&lt;/a&gt;
/// 
/// // 3. Full Suppression or Transparent Wrapper
/// // If Model.Text is null, the div is suppressed. Then, if Model.HRef is not null, the child elements are printed.
/// // If Model.Text is NOT null, pretty-children is ignored, and the whole tag is rendered.
/// // Therefor, the a tag needs its own check!
/// &lt;div class="wrapper"
///      pretty-if="@(!string.IsNullOrEmpty(Model.Text))"
///      pretty-children="@(!string.IsNullOrEmpty(Model.HRef))"&gt;
///     &lt;a href="@Model.HRef"
///        pretty-if="@(!string.IsNullOrEmpty(Model.HRef))"
///        pretty-children&gt;@Model.Text&lt;/a&gt;
/// &lt;/div&gt;
/// </code>
/// </summary>
[HtmlTargetElement(Attributes = "pretty-if")]
public class PrettyIfTagHelper : TagHelper
{
    /// <summary>
    /// If true, the tag renders normally. If false, the tag is suppressed.
    /// </summary>
    [HtmlAttributeName("pretty-if")]
    public bool PrettyIf { get; set; } = true;

    /// <summary>
    /// If pretty-if is false AND this is true, only the tag is removed, but children are kept.
    /// If both are false, the entire element and its children are removed.
    /// </summary>
    [HtmlAttributeName("pretty-children")]
    public bool PrettyChildren { get; set; } = false;


    /// <inheritdoc/>
    public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        Process(context, output);

        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (PrettyIf)
        {
            //
            // EARLY OUT!
            //
            return;
            //
            // EARLY OUT!
            //
        }

        if (PrettyChildren)
        {
            output.TagName = null;
        }
        else
        {
            output.SuppressOutput();
        }
    }
}
