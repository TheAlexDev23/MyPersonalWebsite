﻿using System.Net.Mime;
using Microsoft.AspNetCore.Components;

namespace PersonalBlogPracticeWebsite.Data;

public class ArticleContent
{
    public int ArticleContentId { get; set; }
    public string? MarkDownUrl { get; set; }
    public string? HtmlContent { get; set; }
    public string? MarkDownContent { get; set; }
}
