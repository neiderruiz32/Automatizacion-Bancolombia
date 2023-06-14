# Automatización de Prueba - README

Este repositorio contiene un programa de automatización de prueba utilizando Selenium WebDriver en C# para interactuar con el sitio web de Bancolombia y llenar un formulario para certificación bancaria.

## Requisitos

- .NET Framework o .NET Core instalado en tu máquina.
- ChromeDriver instalado y configurado en la ubicación correcta.
- 
## Configuración

1. Clona o descarga este repositorio en tu máquina local.
2. Abre el proyecto en tu IDE o editor de código preferido.

## Instrucciones de Uso

1. Abre el archivo `Program.cs` en el proyecto.
2. Actualiza la variable `chromeDriverPath` con la ubicación del archivo ChromeDriver en tu máquina.
3. Personaliza el código dentro del método `Main` según tus necesidades de prueba.
4. Ejecuta la aplicación.

El programa automatizará los siguientes pasos:

1. Ingresar a la URL de Bancolombia y cerrar el anuncio de la pagina inicial.
2. Hacer clic en el botón "Documentos".
3. Hacer clic en el botón "Certificado Bancario".
4. Cambiar al controlador de la ventana emergente.
5. Llenar el formulario con datos asignados de manera predeterminada, incluyendo la selección de tipo de identificación, número de identificación, medio de envío, correo, número de celular, a quien va dirigida, tipo de producto, 4 últimos dígitos de producto y confirmación de 4 últimos dígitos de producto.
6. Interactuar con el reCAPTCHA seleccionando "No soy un robot".

## Notas

- Asegurarse de haber actualizado la ubicación correcta del archivo ChromeDriver en la variable `chromeDriverPath`.
- Puedes personalizar el código dentro del método `Main` para ajustarlo a tus necesidades específicas de prueba.
- Asegúrate de tener una conexión a Internet activa durante la ejecución de la prueba, ya que el programa interactúa con elementos en línea.
