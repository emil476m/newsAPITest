using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    [Test]
    public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
    {
        await Page.GotoAsync("https://playwright.dev");

        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));

        // create a locator
        var getStarted = Page.GetByRole(AriaRole.Link, new() { Name = "Get started" });

        // Expect an attribute "to be strictly equal" to the value.
        await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");

        // Click the get started link.
        await getStarted.ClickAsync();

        // Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*intro"));
    }

    [Test]
    public async Task testCreateFunction()
    {
        
        await Page.GotoAsync("http://localhost:5000/home");

        await Page.GetByRole(AriaRole.Button, new() { Name = "Create Article" }).ClickAsync();
        

        await Page.GetByRole(AriaRole.Textbox).First.FillAsync("1984 hello world");
        

        await Page.GetByRole(AriaRole.Textbox).Nth(1).FillAsync("1984 test");
        

        await Page.GetByRole(AriaRole.Textbox).Nth(2).FillAsync("Bob");
        

        await Page.GetByRole(AriaRole.Textbox).Nth(3).FillAsync("1912131dsada");

        await Page.GetByRole(AriaRole.Button, new() { Name = "Create" }).ClickAsync();

        await Page.GetByText("1984 hello world").ClickAsync();
        
        //make expectations

        await Expect(Page.GetByText("1984 hello world")).ToBeVisibleAsync();

    }
}