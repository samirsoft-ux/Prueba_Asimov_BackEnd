using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Asimov.API.SystemTests.Steps;

[Binding]
public class US011
{
    
    private static WebDriver webDriver;
    public US011()
    {
        string workingDirectory = Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        webDriver = new ChromeDriver(Path.Combine(projectDirectory, "Drivers"));
    }
    
    [Given(@"el docente se encuentra en el menú de la aplicación")]
    public void GivenElDocenteSeEncuentraEnElMenuDeLaAplicacion()
    {
        webDriver.Navigate().GoToUrl("https://pry-asimov-cybersoft-21.web.app/sign-up");
        var btnGoToLogin = webDriver.FindElement(By.XPath("//*[@id='app']/div/main/div/div/div[1]/div/div/div[2]/div/a/span"));
        btnGoToLogin.Click();

        var tboxEmail = webDriver.FindElement(By.XPath("//*[@id='input-76']"));
        tboxEmail.SendKeys("omar@gmail.com");
            
        var tboxPassword = webDriver.FindElement(By.XPath("//*[@id='input-81']"));
        tboxPassword.SendKeys("alves");
            
        var radiusTeacher = webDriver.FindElement(By.XPath("//*[@id='app']/div/main/div/div/div[1]/div/div/div/div[2]/form/div[3]/div[1]/div[1]/div/div[2]/div/div"));
        radiusTeacher.Click();
            
        var btnSubmit = webDriver.FindElement(By.XPath("//*[@id='app']/div[1]/main/div/div/div[1]/div/div/div/div[3]/button[2]/span"));
        btnSubmit.Click();
            
        WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
        IWebElement btnProfile = wait.Until(e => e.FindElement(By.XPath("//*[@id='app']/div/header/div/a/span")));
        btnProfile.Click();
        webDriver.Navigate().GoToUrl("https://pry-asimov-cybersoft-21.web.app/dashboard");
    }

    [When(@"seleccione el diccionario de competencias")]
    public void WhenSeleccioneElDiccionarioDeCompetencias()
    {
        webDriver.Navigate().GoToUrl("https://pry-asimov-cybersoft-21.web.app/competences");
    }

    [Then(@"aparecerá una lista de las competencias con sus definiciones\.")]
    public void ThenApareceraUnaListaDeLasCompetenciasConSusDefiniciones()
    {
        if (webDriver.Url == "https://pry-asimov-cybersoft-21.web.app/competences")
        {
            Console.Write("Mirando Lista De Las Competencias");
        }
    }

    [Then(@"aparecerá el mensaje “Actualmente no existen competencias”\.")]
    public void ThenApareceraElMensajeActualmenteNoExistenCompetencias()
    {
        if (webDriver.Url == "https://pry-asimov-cybersoft-21.web.app/competences")
        {
            Console.Write("No existen competencias");
        }
    }

    [Then(@"aparecerá el mensaje “Error interno: no se ha podido acceder a la información”\.")]
    public void ThenApareceraElMensajeErrorInternoNoSeHaPodidoAccederALaInformacion()
    {
        if (webDriver.Url == "https://pry-asimov-cybersoft-21.web.app/competences")
        {
            Console.Write("Error");
        }
    }
}