# Forte.EpiStructuredData

#### 1. Create structured data generator
You need to create structure data genarator that will be mapping properties from your Entry to [Schema.NET](https://www.nuget.org/packages/Schema.NET/) classes.

Example generator:
```cs
public class ArticleStructuredDataGenerator : StructuredDataGenerator<ArticlePage, Schema.NET.Article>
{
    protected override Schema.NET.Article GetStructuredData(ArticlePage article)
    {
        return new Schema.NET.Article
        {
            Headline = article.Heading,
            AlternativeHeadline = article.AdditionalHeadingInfo,
            ArticleBody = article.Body.ToString()
        };
    }
}
```

#### 2. Add StructureData attribute to your Entry
Add `StructuredData` attribute that will point to generator that should be used to get structured data. If there is more than one generator, you can add multiple `StructuredData` attributes.

```cs
[StructuredData(typeof(ArticleStructuredDataGenerator))]
[ContentType(GUID = "47D7321A-3D9D-4E83-AB21-4F58059157D8", DisplayName = "Article Page")]
public class ArticlePage : BasePage
{
    public virtual string Heading { get; set; }
    public virtual string AdditionalHeadingInfo { get; set; }
    public virtual XhtmlString Body { get; set; }
}
```

#### 3. Call structured data generator in layout
In head section of your layout:

```cs
@Html.StructuredData(Request.RequestContext.GetContentLink())
```

#### 4. (Optional) Add option to include your custom structured data
You can also add possibility to include structured data in Episerver CMS. To do this your Entry that should have structured data have to inherit from `IStructuredDataSource` and have property `StructuredData`:

```cs
[StructuredData(typeof(ArticleStructuredDataGenerator))]
[ContentType(GUID = "47D7321A-3D9D-4E83-AB21-4F58059157D8", DisplayName = "Article Page")]
public class ArticlePage : BasePage, IStructuredDataSource
{
    public virtual string Heading { get; set; }
    public virtual string AdditionalHeadingInfo { get; set; }
    public virtual XhtmlString Body { get; set; }
    public virtual StructuredDataBlock StructuredData { get; set;  }
}
```

This will add list property to your Entry for custom structured data that will be added if included JSONs are valid.