using ABI.System;
using HtmlAgilityPack;
using Microsoft.Playwright;
using System.Net;

namespace CinemaBox.Utilities.Loader;

public static class HtmlLoader
{
    public static async Task<HtmlDocument?> LoadDocumentAsync(string url, int i = 0)
    {

        //HtmlWeb web = new();
        try
        {
            //web.PreRequest = request =>
            //{
            //    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36";
            //    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            //    request.Headers.Add("Accept-Language", "en-US,en;q=0.9");
            //    return true;
            //};
            //return await web.LoadFromWebAsync(url);
            var LoadDoc = await Load(url);



            var doc = new HtmlDocument();
            doc.LoadHtml(LoadDoc);
            return doc;
        }
        catch (System.Exception ex)
        {
            if (i >= 3)
                return null;
            return await LoadDocumentAsync(url, i++);


        }

    }
    public static async Task<string> Load(string url)
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            SlowMo = 50,
            Args =
            [
                "--start-maximized"
            ]
        });

        var context = await browser.NewContextAsync(new BrowserNewContextOptions
        {
            UserAgent =
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 " +
                "(KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36",
            ViewportSize = new ViewportSize
            {
                Width = 1280,
                Height = 800
            },            Locale = "en-US",

            ExtraHTTPHeaders = new Dictionary<string, string>
            {
                ["Accept-Language"] = "en-US,en;q=0.9"
            }
        });

        var page = await context.NewPageAsync();
        var response = await page.GotoAsync(url, new PageGotoOptions
        {
            WaitUntil = WaitUntilState.DOMContentLoaded,
            Timeout = 120000
        }) ?? throw new System.Exception("No response received.");
        // کمی صبر برای JSهای اولیه یا redirect احتمالی
        await page.WaitForTimeoutAsync(5000);
        // تلاش برای رسیدن به حالت لود کامل، بدون وابستگی شدید به NetworkIdle
        try
        {
            await page.WaitForLoadStateAsync(LoadState.Load, new PageWaitForLoadStateOptions
            {
                Timeout = 30000
            });
        }
        catch
        {
            // بعضی سایت‌ها کامل load نمی‌شوند؛ ادامه می‌دهیم
        }
        // تعامل ساده انسانی/اسکرول، برای lazy-load معمولی
        await page.Mouse.MoveAsync(200, 200);
        await page.Mouse.MoveAsync(400, 400);
        await page.EvaluateAsync("() => window.scrollTo(0, document.body.scrollHeight)");
        await page.WaitForTimeoutAsync(2000);
        await page.EvaluateAsync("() => window.scrollTo(0, 0)");
        // منتظر یکی از selectorهای محتوای اصلی بمان
        var selectors = new[]
        {
        "h1",
        "main",
        "article",
        "[role='main']",
        ".content",
        "#content"
    };
        var contentLoaded = false;
        foreach (var selector in selectors)        
            try
            {
                await page.WaitForSelectorAsync(selector, new PageWaitForSelectorOptions
                {
                    Timeout = 10000,
                    State = WaitForSelectorState.Visible
                });
                contentLoaded = true;
                break;
            }
            catch
            {
                // selector بعدی را امتحان می‌کنیم
            }
        
        if (!contentLoaded)        
            Console.WriteLine("Main content selector was not found. Returning current HTML anyway.");  
        var html = await page.ContentAsync();
        return html;
    }

}