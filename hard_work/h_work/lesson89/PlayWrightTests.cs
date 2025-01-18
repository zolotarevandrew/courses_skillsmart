using Microsoft.Playwright;

namespace h_work.lesson89;

public static class PlaywrightTests
{
    private const string Url = "https://hidden/signup";
    
    public static async Task Run()
    {
        using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        var page = await OpenPage(browser);
        await FirstLogin(page, "a1311131@mail.ru");

        await browser.CloseAsync();
    }

    private static async Task<IPage> OpenPage(IBrowser browser)
    {
        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();
        await page.GotoAsync(Url);
        return page;
    }

    private static async Task ThirdRegisterNotExistingCompany(IPage page, string name)
    {
        await SearchCompany(page, name);
        await page.ClickAsync("a[data-test='go_manual_more_result']");
        await page.ClickAsync("div[data-test='legal-form']");
        await page.ClickAsync("li[data-title='GmbH (Gesellschaft mit beschränkter Haftung)']");
        await page.ClickAsync("button[data-test='manual_submit']");
        await WaitHeader(page);
    }

    private static async Task SearchCompany(IPage page, string name)
    {
        await page.ClickAsync("div[data-test='country']");
        await page.ClickAsync("li[data-title='Germany']");
        await page.ClickAsync("div[data-test='select_company']");
        await page.ClickAsync("div[data-test='select_company_inside']");
        await page.FillAsync("input[data-test='search']", name);
    }

    private static async Task SecondRegisterExistingCompany(IPage page, string name)
    {
        await SearchCompany(page, name);
        
        var foundItem = page.Locator(".onboarding__list-item").First;
        await foundItem.ClickAsync();
        await WaitHeader(page);
    }

    private static async Task WaitHeader(IPage page)
    {
        await page.WaitForSelectorAsync("div[data-test='onboarding-title']", new PageWaitForSelectorOptions
        {
            Timeout = 5000 
        });
    }

    private static async Task FirstLogin(IPage page, string email)
    {
        await page.FillAsync("input[type='email']", email);
        await page.ClickAsync("button[id='signup_next']");
        
        await page.FillAsync("input[name='userName']", "Andrey Zolotarev");
        await page.FillAsync("input[name='password']", "12345678");
        await page.ClickAsync("button[data-test='enter_password_done']");
        
        await WaitHeader(page);
    }
    
}