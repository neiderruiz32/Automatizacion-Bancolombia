using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutomatedProgram
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Establecer la ubicación del archivo ChromeDriver
            string chromeDriverPath = "C:\\WebDrivers\\chromedriver_win32\\chromedriver.exe";
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            // Crear una instancia del controlador de Chrome
            using (IWebDriver driver = new ChromeDriver(chromeDriverPath, options))
            {
                // Paso 1: Ingresar a la URL de Bancolombia
                driver.Navigate().GoToUrl("https://www.bancolombia.com/personas");
                IWebElement closeButton = driver.FindElement(By.CssSelector("#close-modal-btn"));
                closeButton.Click();

                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);

                // Paso 2: Hacer clic en el botón "Documentos"
                IWebElement documentosButton = driver.FindElement(By.CssSelector("#btn-documentos > span"));
                documentosButton.Click();

                Thread.Sleep(2000);

                // Paso 3: Hacer clic en el botón "Certificado Bancario"
                IWebElement solicitarButton = driver.FindElement(By.CssSelector(".text-button"));
                solicitarButton.Click();

                // Esperar a que aparezca la ventana emergente
                Thread.Sleep(2000); // Puedes ajustar el tiempo de espera según sea necesario

                // Cambiar el controlador a la ventana emergente
                string mainWindowHandle = driver.CurrentWindowHandle;
                foreach (string handle in driver.WindowHandles)
                {
                    if (handle != mainWindowHandle)
                    {
                        driver.SwitchTo().Window(handle);
                        break;
                    }
                }

                // Verificar que estás en la ventana emergente
                Console.WriteLine("Ventana emergente actual: " + driver.Title);

                // Esperar a que los elementos del formulario estén presentes
                Thread.Sleep(2000); // Puedes ajustar el tiempo de espera según sea necesario

                // Paso 4: Llenar el formulario con datos alternos

                // Obtener el número total de iframes en la página
                int totalFrames = driver.FindElements(By.TagName("iframe")).Count;

                bool elementoEncontrado = false;

                // Iterar a través de los iframes y cambiar al contexto adecuado
                for (int i = 0; i < totalFrames; i++)
                {
                    // Cambiar al iframe por su índice
                    driver.SwitchTo().Frame(i);

                    try
                    {
                        // Realizar la búsqueda del elemento dentro del iframe
                        IWebElement tipoIdentificacionDropdown = driver.FindElement(By.Id("Formulario_tipo_identificacion"));

                        // Seleccionar tipo de identificación: Cédula de ciudadanía
                        SelectElement selectTipoIdentificacion = new SelectElement(tipoIdentificacionDropdown);
                        selectTipoIdentificacion.SelectByText("Cédula de ciudadanía");

                        // Ingresar número de identificación "1234567"
                        IWebElement numeroIdentificacionInput = driver.FindElement(By.Id("Formulario_numero_identificacion"));
                        numeroIdentificacionInput.Click();
                        numeroIdentificacionInput.SendKeys("1234567");

                        // Seleccionar el medio de envío "Sucursal Virtual Personas"
                        IWebElement medioEnvioDropdown = driver.FindElement(By.Id("Formulario_medio_envio"));
                        medioEnvioDropdown.Click();

                        IWebElement sucursalVirtualOption = medioEnvioDropdown.FindElement(By.XPath("//option[contains(text(), 'Sucursal Virtual Personas')]"));
                        sucursalVirtualOption.Click();

                        // Ingresar correo "PruebaKonecta@gmail.com"
                        IWebElement CorreoInput = driver.FindElement(By.Id("Formulario_email"));
                        CorreoInput.Click();
                        CorreoInput.SendKeys("Actividad1@Prueba.com");

                        // Ingresar numero celular "3117800465"
                        IWebElement CelularInput = driver.FindElement(By.Id("Formulario_celular"));
                        CelularInput.Click();
                        CelularInput.SendKeys("3222222");

                        // Seleccionar a quien va dirigida "Señores"
                        IWebElement DirigidaDropdown = driver.FindElement(By.Id("Formulario_cortesia"));
                        DirigidaDropdown.Click();
                        
                        IWebElement DirigidolOption = DirigidaDropdown.FindElement(By.XPath("//option[contains(text(), 'Señores')]"));
                        DirigidolOption.Click();

                        Thread.Sleep(2000);

                        // Ingresar dirigente "A quien pueda interesar"
                        IWebElement InteresInput = driver.FindElement(By.Id("Formulario_nombre"));
                        InteresInput.Click();
                        InteresInput.SendKeys("A quien pueda interesar");

                        // Seleccionar el tipo de producto "Tipo de producto"
                        IWebElement TipoProductoDropdown = driver.FindElement(By.Id("Formulario_tipo_producto"));
                        TipoProductoDropdown.Click();

                        IWebElement productolOption = TipoProductoDropdown.FindElement(By.XPath("//option[contains(text(), 'Cuenta de ahorros/Bancolombia a la mano')]"));
                        productolOption.Click();

                        Thread.Sleep(2000);

                        // Ingresar 4 ultimos digitos de producto "0000"
                        IWebElement UltimosDigitosInput = driver.FindElement(By.Id("Formulario_ultimos_digitos"));
                        UltimosDigitosInput.Click();
                        UltimosDigitosInput.SendKeys("0000");

                        // Confirmar 4 ultimos digitos de producto "0000"
                        IWebElement ConfirmUltimosDigitosInput = driver.FindElement(By.Id("Formulario_confirm_ultimos_digitos"));
                        ConfirmUltimosDigitosInput.Click();
                        ConfirmUltimosDigitosInput.SendKeys("0000");

                        // Indicar que el elemento ha sido encontrado
                        elementoEncontrado = true;

                        // Salir del bucle si se encuentra el elemento y se han ingresado los datos
                        break;
                    }
                    catch (NoSuchElementException)
                    {
                        // Si no se encuentra el elemento, volver al contexto del iframe anterior
                        driver.SwitchTo().ParentFrame();
                    }
                }

                // Continuar con el código después del bucle si el elemento ha sido encontrado
                if (elementoEncontrado)
                {
                    // Continúa con el código después de llenar el formulario
                }
                // Iterar a través de los iframes y buscar el que contiene el reCAPTCHA
                for (int i = 0; i < totalFrames; i++)
                {
                    try
                    {
                        // Cambiar al iframe por su índice
                        driver.SwitchTo().Frame(i);

                        // Verificar si el reCAPTCHA está presente dentro del iframe
                        if (driver.FindElements(By.CssSelector(".recaptcha-checkbox-border")).Count > 0)
                        {
                            // Realizar la acción deseada en el reCAPTCHA
                            IWebElement recaptchaCheckbox = driver.FindElement(By.CssSelector(".recaptcha-checkbox-border"));
                            recaptchaCheckbox.Click();

                            // Salir del bucle ya que se encontró y se interactuó con el reCAPTCHA
                            break;
                        }
                    }
                    catch (NoSuchFrameException)
                    {
                        // Si no se encuentra el marco, volver al contexto del marco principal
                        driver.SwitchTo().DefaultContent();
                    }
                }

                // Mantener la ventana abierta hasta que se presione Enter
                Console.WriteLine("Presiona Enter para salir...");
                Console.ReadLine();
            }
        }
    }
}
